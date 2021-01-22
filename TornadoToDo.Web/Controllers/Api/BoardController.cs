using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TornadoToDo.Business.Interfaces;
using TornadoToDo.Web.Models;

namespace TornadoToDo.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardController : ControllerBase
    {
        private readonly IBoardService _boardService;
        public BoardController(IBoardService boardService)
        {
            _boardService = boardService;
        }

        [HttpPost("movecard")]
        public async Task<IActionResult> MoveCard([FromBody]MoveCardModel command)
        {
            await _boardService.MoveAsync(command.CardId, command.ColumnId);
            return Ok(new
            {
                Moved = true
            });
        }
    }
}
