using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TornadoToDo.Web.Models
{
    public class AddBoardModel
    {
        [Required(ErrorMessage ="Başlık boş geçilemez")]
        [MaxLength(25,ErrorMessage ="Başlık 25 karakterden fazla olmamalı")]
        public string Title { get; set; }
        public int AppUserId { get; set; }
    }
}
