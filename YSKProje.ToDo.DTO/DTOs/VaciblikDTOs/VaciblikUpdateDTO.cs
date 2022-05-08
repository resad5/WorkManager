using System;
using System.Collections.Generic;
using System.Text;

namespace YSKProje.ToDo.DTO.DTOs.VaciblikDTOs
{
    public class VaciblikUpdateDTO
    {
        public int Id { get; set; }

        //[Display(Name = "Ifadə:")]
        //[Required(ErrorMessage = "Ifade hissesi bos kecile bilinmez")]
        public string Ifade { get; set; }
    }
}
