using System;
using System.Collections.Generic;
using System.Text;

namespace eProdaja.Model.SearchObjects
{
    public class ProizvodiSearchObject : BaseSearchObject
    {
        public string SearchKey { get; set; }
        public string Naziv { get; set; }
        public string Sifra { get; set; }
        public decimal Cijena { get; set; }
    }
}
