using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using YSKProje.ToDo.Entities.Interfaces;

namespace YSKProje.ToDo.Entities.Concrete
{
    public class Is : ITablo
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Aciklama { get; set; }
        public bool Durum { get; set; }
        public DateTime OlusturulmaTarih { get; set; } = DateTime.Now;
        public int VaciblikId { get; set; }

        public Vaciblik Vaciblik { get; set; }

        public int? AppUserId { get; set; }

        public AppUser AppUser { get; set; }

        

        public List<Rapor> Rapors { get; set; }


    }
}
