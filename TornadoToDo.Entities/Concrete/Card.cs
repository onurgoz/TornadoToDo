using System;
using System.Collections.Generic;
using System.Text;

namespace TornadoToDo.Entities.Concrete
{
    public class Card
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public DateTime TaskDate { get; set; } = DateTime.Now;
        public int ColumnId { get; set; }
        public Column Column { get; set; }
    }
}
