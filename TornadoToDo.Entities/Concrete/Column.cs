using System;
using System.Collections.Generic;
using System.Text;

namespace TornadoToDo.Entities.Concrete
{
    public class Column
    {
        public int Id { get; set; }
        public string Title  { get; set; }

        public int BoardId { get; set; }
        public Board Board { get; set; }

        public List<Card> Cards { get; set; }
    }

}
