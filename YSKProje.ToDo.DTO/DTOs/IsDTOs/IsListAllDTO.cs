using System;
using System.Collections.Generic;
using System.Text;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.DTO.DTOs.IsDTOs
{
  public  class IsListAllDTO
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Aciklama { get; set; }
        public DateTime OlusturulmaTarih { get; set; }


        public Vaciblik Vaciblik { get; set; }

        public AppUser AppUser { get; set; }

        public List<Rapor> Rapors { get; set; }
    }
}
