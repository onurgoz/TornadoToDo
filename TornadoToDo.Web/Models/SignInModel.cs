using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TornadoToDo.Web.Models
{
    public class SignInModel
    {
        [Required(ErrorMessage = "Email alanı geçerlidir.")]
        [MaxLength(50, ErrorMessage = "Not maksimum 50 karakter olabilir.")]
        [EmailAddress(ErrorMessage ="Email adresi düzgün değil")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre alanı geçerlidir.")]
        [MaxLength(50, ErrorMessage = "Şifre maksimum 500 karakter olabilir.")]
        public string Password { get; set; }
    }
}
