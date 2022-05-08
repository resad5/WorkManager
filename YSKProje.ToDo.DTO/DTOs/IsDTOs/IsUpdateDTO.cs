using System;
using System.Collections.Generic;
using System.Text;

namespace YSKProje.ToDo.DTO.DTOs.IsDTOs
{
   public  class IsUpdateDTO
    {
        //[Required(ErrorMessage = "Ad hissesi bos kecile bilinmez!!!")]


        public int Id { get; set; }
        public string Ad { get; set; }
        public string Aciklama { get; set; }



        //[Range(0, int.MaxValue, ErrorMessage = "Zehmet olmasa bir vaciblik derecesi secin!!!")]
        public int VaciblikId { get; set; }

    }
}
