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
    public class CardController : Controller
    {
        private readonly ICardService _cardService;
        private readonly IHttpContextAccessor _accessor;
        private readonly IColumnService _columnService;
        public CardController(IColumnService columnService,ICardService cardService, IHttpContextAccessor accessor)
        {
            _accessor = accessor;
            _cardService = cardService;
            _columnService = columnService;
        }

        public async Task<IActionResult> Details(int id)
        {
            var card = await _cardService.FindByIdAsync(id);
            CardViewModel model = new CardViewModel
            {
                Id = card.Id,
                Note = card.Note,
                Title = card.Title,
                Description=card.Description,
                TaskDate=card.TaskDate
            };

            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var card = await _cardService.FindByIdAsync(id);
            return View(new CardViewModel
            {
                Id=card.Id,
                Description=card.Description,
                Note=card.Note,
                Title=card.Title,
                TaskDate=card.TaskDate
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CardViewModel model)
        {
            var card = await _cardService.FindByIdAsync(model.Id);
            var column = await _columnService.FindByIdAsync(card.ColumnId);
            if (card!=null)
            {
                card.Note = model.Note;
                card.TaskDate = model.TaskDate;
                card.Title = model.Title;
                card.Description = model.Description;

                await _cardService.UpdateAsync(card);
                return RedirectToAction("Detail", "Board", new { id = column.BoardId });
            }
            return View(model);

        }

        public async Task<IActionResult> Delete(int id)
        {
            var card = await _cardService.FindByIdAsync(id);
            var column = await _columnService.FindByIdAsync(card.ColumnId);
            if (card!=null)
            {
                await _cardService.RemoveAsync(card);
            }

            return RedirectToAction("Detail", "Board",new{ id=column.BoardId});
        }
    }
}
