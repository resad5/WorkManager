using System;
using System.Collections.Generic;
using System.Text;

namespace YSKProje.ToDo.DTO.DTOs.AppUserDTOs
{
   public  class AppUserListDTO
    {
        public int Id { get; set; }

        //[Display(Name = "Ad"), Required(ErrorMessage = "Ad hissesi bs kecile bilinmez")]
        public string Name { get; set; }

        //[Display(Name = "Soyad"), Required(ErrorMessage = "Soyad hissesi bs kecile bilinmez")]
        public string Surname { get; set; }

        //[Display(Name = "Email"), Required(ErrorMessage = "Email hissesi bs kecile bilinmez")]
        public string Email { get; set; }

        //[Display(Name = "Sekil")]
        public string Picture { get; set; }
    }
}
