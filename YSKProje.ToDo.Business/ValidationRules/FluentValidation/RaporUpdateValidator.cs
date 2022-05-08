using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using YSKProje.ToDo.DTO.DTOs.RaporDTOs;

namespace YSKProje.ToDo.Business.ValidationRules.FluentValidation
{
    public class RaporUpdateValidator :  AbstractValidator<RaporUpdateDTO>
    {
        public RaporUpdateValidator()
        {
            RuleFor(i => i.Tanim).NotNull().WithMessage("Tanim hissesi bos kecile bilinmez!!!");

            RuleFor(i => i.Detay).NotNull().WithMessage("Detay hissesi bos kecile bilinmez!!!");
        }
    }
}
