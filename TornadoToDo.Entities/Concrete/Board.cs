using System;
using System.Collections.Generic;
using System.Text;

namespace TornadoToDo.Entities.Concrete
{
    public class Board
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public List<Column> Columns { get; set; }
    }
}
