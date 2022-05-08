using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using YSKProje.ToDo.DTO.DTOs.AppUserDTOs;

namespace YSKProje.ToDo.Business.ValidationRules.FluentValidation
{
   public  class AppUserSignInValidator:AbstractValidator<AppUserSignInDTO>
    {

        public AppUserSignInValidator()
        {
            RuleFor(u => u.UserName).NotNull().WithMessage("Istifadeci adi hissesi bos kecile bilinmez");
            RuleFor(u => u.Password).NotNull().WithMessage("Sifre hissesi bos kecile bilinmez");

        }
       
      


    }
}
