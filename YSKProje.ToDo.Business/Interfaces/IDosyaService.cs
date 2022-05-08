using System;
using System.Collections.Generic;
using System.Text;

namespace YSKProje.ToDo.Business.Interfaces
{
    public interface IDosyaService
    {
        string AktPdf<T>(List<T>list) where T:class,new();
        byte[] AKtExcel<T>(List<T> list) where T : class, new();
    }
}
