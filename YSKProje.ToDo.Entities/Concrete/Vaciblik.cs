using System;
using System.Collections.Generic;
using System.Text;
using YSKProje.ToDo.Entities.Interfaces;

namespace YSKProje.ToDo.Entities.Concrete
{
  public  class Vaciblik:ITablo
    {
       

      public int Id { get; set; }

        public string Ifade { get; set; }

        public List<Is> Isler { get; set; }

    }
}
