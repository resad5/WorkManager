using System;
using System.Collections.Generic;
using System.Text;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.DTO.DTOs.IsDTOs
{
  public  class IsListDTO
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Aciklama { get; set; }
        public bool Durum { get; set; }
        public DateTime OlusturulmaTarih { get; set; }
        public int VaciblikId { get; set; }

        public Vaciblik Vaciblik { get; set; }
    }
}
