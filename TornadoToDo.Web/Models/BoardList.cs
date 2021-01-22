using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TornadoToDo.Web.Models
{
    public class BoardList
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Başlık alanı geçerlidir.")]
        [MaxLength(50, ErrorMessage = "Başlık maksimum 50 karakter olabilir.")]
        public string Title { get; set; }
    }
}
