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
    public class ColumnController : Controller
    {
        private readonly IColumnService _columnService;
        private readonly IHttpContextAccessor _accessor;
        public ColumnController(IColumnService columnService, IHttpContextAccessor accessor)
        {
            _accessor = accessor;
            _columnService = columnService;
        }

        public IActionResult AddColumn()
        {
            return View();
        }

        public async Task<IActionResult> EditColumn(int id)
        {
            var column = await _columnService.FindByIdAsync(id);
            if (column!=null)
            {
                return View(new Column
                {
                    Id = column.Id,
                    Title=column.Title
                });
            }
            else
            {
                return RedirectToAction("Index", "Board");
            }
        }

        public async Task<IActionResult>  DeleteColumn(int id)
        {
            var column = await _columnService.FindByIdAsync(id);
            await _columnService.RemoveAsync(column);
            return RedirectToAction("Board","Index");
        }
    }
}
