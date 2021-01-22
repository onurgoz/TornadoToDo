using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TornadoToDo.Web.Models
{
    public class MoveCardModel
    {
        public int CardId { get; set; }
        public int ColumnId { get; set; }
    }
}
