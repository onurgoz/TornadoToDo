using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TornadoToDo.Web.Models
{
    public class AddCard
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Başlık alanı geçerlidir.")]
        [MaxLength(50,ErrorMessage ="Başlık maksimum 50 karakter olabilir")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Açıklama alanı geçerlidir.")]
        [MaxLength(500,ErrorMessage ="Açıklama maksimum 500 karakter olabilir.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Not alanı geçerlidir.")]
        [MaxLength(500, ErrorMessage = "Not maksimum 500 karakter olabilir.")]
        public string Note { get; set; }

    }
}
