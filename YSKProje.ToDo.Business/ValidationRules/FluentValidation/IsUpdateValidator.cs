using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using YSKProje.ToDo.DTO.DTOs.IsDTOs;

namespace YSKProje.ToDo.Business.ValidationRules.FluentValidation
{
    public class IsUpdateValidator:AbstractValidator<IsUpdateDTO>
    {
        public IsUpdateValidator()
        {
            RuleFor(i => i.Ad).NotNull().WithMessage("Ad hissesi bos kecile bilinmez!!!");
            RuleFor(i => i.VaciblikId).ExclusiveBetween(0, int.MaxValue).WithMessage("Zehmet olmasa bir vaciblik veziyeti secin!!!");
        }
    }
}
