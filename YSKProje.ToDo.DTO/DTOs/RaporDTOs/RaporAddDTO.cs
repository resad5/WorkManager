using System;
using System.Collections.Generic;
using System.Text;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.DTO.DTOs.RaporDTOs
{
    public class RaporAddDTO
    {

        //[Display(Name = "Tanim:"), Required(ErrorMessage = "Tanim hissesi bos kecile  bilinmez!!!")]
        public string Tanim { get; set; }
        //[Display(Name = "Detay:"), Required(ErrorMessage = "Detay hissesi bos kecile  bilinmez!!!")]
        public string Detay { get; set; }

        public Is Is { get; set; }
        public int IsId { get; set; }
    }
}
