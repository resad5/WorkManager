using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YSKProje.ToDo.Web.Models
{
    public class AppUserSignInModel
    {
        [Required(ErrorMessage = "Istifadeci Adi hissesi bos kecile bilinmez")]
        public string UserName { get; set; }
        [Display(Name = "Sifre:")]
        [Required(ErrorMessage = "Sifre hissesi bos kecile bilinmez")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Display(Name ="Meni xatirla")]
        public bool RememmberMe { get; set; }
    }
}
