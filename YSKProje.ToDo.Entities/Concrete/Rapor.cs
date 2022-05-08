using System;
using System.Collections.Generic;
using System.Text;
using YSKProje.ToDo.Entities.Interfaces;

namespace YSKProje.ToDo.Entities.Concrete
{
   public class Rapor:ITablo
    {
        public int Id { get; set; }

        public string Tanim { get; set; }

        public string Detay { get; set; }

        public int IsId { get; set; }

        public Is Is { get; set; }
    }
}
