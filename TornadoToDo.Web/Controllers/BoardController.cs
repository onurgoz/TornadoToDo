using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TornadoToDo.Business.Interfaces;
using TornadoToDo.Entities.Concrete;

using TornadoToDo.Web.Models;

namespace TornadoToDo.Web.Controllers
{
   
    public class BoardController : Controller
    {
        private readonly IBoardService _boardService;
        private readonly IHttpContextAccessor _accessor;
        public BoardController(IHttpContextAccessor accessor, IBoardService boardService)
        {
            _boardService = boardService;
            _accessor = accessor;
        }

        public async Task<IActionResult> Index()
        {
            string id = _accessor.HttpContext.Session.GetString("id");

            var model = await _boardService.GetBoardsByAppUserId(Convert.ToInt32(id));
            List<BoardList> boardList = new List<BoardList>();
            foreach (var item in model)
            {
                BoardList board = new BoardList { 
                    Id=item.Id,
                    Title=item.Title
                };
                boardList.Add(board);
            }
            return View(boardList);
        }

        public IActionResult AddCard(int id)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCard(AddCard viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);
            Card card = new Card
            {
                Title = viewModel.Title,
                Description=viewModel.Description,
                Note=viewModel.Note,
            };

            await _boardService.AddCard(card, viewModel.Id);

            return RedirectToAction(nameof(Detail), new { id = viewModel.Id });
        }

        public async Task<IActionResult> Detail(int id)
        {
            var board = await _boardService.GetBoardInfo(id);
            var model = new BoardView();
            model.Id = board.Id;
            model.Title = board.Title;

            foreach (var column in board.Columns)
            {
                var modelColumn = new BoardView.Column
                {
                    Title = column.Title,
                    Id = column.Id
                };

                foreach (var card in column.Cards)
                {
                    var modelCard = new BoardView.Card
                    {
                        Id = card.Id,
                        Title = card.Title
                    };

                    modelColumn.Cards.Add(modelCard);
                }

                model.Columns.Add(modelColumn);
            }

            return View(model);
        }

        public IActionResult AddBoard()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> AddBoard(AddBoardModel model)
        {
            string id = _accessor.HttpContext.Session.GetString("id");
            await _boardService.AddAsync(new Board
            {
                Title = model.Title,
                AppUserId = Convert.ToInt32(id)
            });

            return RedirectToAction("Index", "Board");
        }


        public async Task<IActionResult> Delete(int id)
        {
            var board = await _boardService.FindByIdAsync(id);

            if (board != null)
            {
                await _boardService.RemoveAsync(board);
            }

            return RedirectToAction("Index", "Board");
        }
    }
}
