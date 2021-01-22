using System;
using System.Collections.Generic;
using System.Text;

namespace TornadoToDo.Entities.Concrete
{
    public class AppUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public List<Board> Boards { get; set; }
    }
}
