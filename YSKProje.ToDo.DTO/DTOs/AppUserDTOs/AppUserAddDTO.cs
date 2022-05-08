using System;
using System.Collections.Generic;
using System.Text;

namespace YSKProje.ToDo.DTO.DTOs.AppUserDTOs
{
   public  class AppUserAddDTO
    {

        //[Required(ErrorMessage = "Istifadeci Adi hissesi bos kecile bilinmez")]
        public string UserName { get; set; }

        //[Display(Name = "Sifre:")]
        //[Required(ErrorMessage = "Sifre hissesi bos kecile bilinmez")]
        //[DataType(DataType.Password)]
        public string Password { get; set; }


        //[Display(Name = "Sifre tekrari:")]
        //[Compare("Password", ErrorMessage = "Sifreler eyni deyil")]
        //[DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }


        //[EmailAddress(ErrorMessage = "Duzgun formatda email adresi daxil edin")]
        //[Required(ErrorMessage = "Email hissesi bos kecile bilinmez")]
        public string Email { get; set; }

        //[Required(ErrorMessage = " Ad hissesi bos kecile bilinmez")]


        //[Display(Name = "Ad:")]
        public string Name { get; set; }


        //[Display(Name = "Soyad:")]

        //[Required(ErrorMessage = "Soyad hissesi bos kecile bilinmez")]
        public string Surname { get; set; }
    }
}
