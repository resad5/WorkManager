using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using YSKProje.ToDo.DTO.DTOs.VaciblikDTOs;

namespace YSKProje.ToDo.Business.ValidationRules.FluentValidation
{
  public  class VaciblikUpdateValidation:AbstractValidator<VaciblikUpdateDTO>
    {
        public VaciblikUpdateValidation()
        {
            RuleFor(I => I.Ifade).NotNull().WithMessage("Ifade hissesi bos kecile bilinmez");
        }
    }
}
