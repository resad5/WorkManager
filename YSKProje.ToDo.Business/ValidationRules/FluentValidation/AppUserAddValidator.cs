using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using YSKProje.ToDo.DTO.DTOs.AppUserDTOs;

namespace YSKProje.ToDo.Business.ValidationRules.FluentValidation
{
    public class AppUserAddValidator : AbstractValidator<AppUserAddDTO>
    {
        public AppUserAddValidator()
        {
            RuleFor(U => U.UserName).NotNull().WithMessage("Istifadeci Adi hissesi bos kecile bilinmez");
            RuleFor(U => U.Password).NotNull().WithMessage("Sifre hissesi bos kecile bilinmez");
            RuleFor(U => U.ConfirmPassword).NotNull().WithMessage("Sifre tekrari hissesi bos kecile bilinmez");

            RuleFor(U => U.ConfirmPassword).Equal(u => u.Password).WithMessage("Sifreler eyni deyil");


            RuleFor(U => U.Email).NotNull().WithMessage("Email  hissesi bos kecile bilinmez")
                .EmailAddress().WithMessage("Duzgun formatda email adresi daxil edin");

            RuleFor(U => U.Name).NotNull().WithMessage("Ad hissesi bos kecile bilinmez");
            RuleFor(U => U.Surname).NotNull().WithMessage("Soyad hissesi bos kecile bilinmez");
        }

    }
}
