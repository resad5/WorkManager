using System;
using System.Collections.Generic;
using System.Text;
using YSKProje.ToDo.Entities.Interfaces;

namespace YSKProje.ToDo.Entities.Concrete
{
    public class Bildiris : ITablo
    {

        public int Id { get; set; }

        public string Aciklama { get; set; }

        public bool Drum { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
