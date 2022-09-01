using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services.Database
{
    public class Favoriti
    {
        public int FavoritiId { get; set; }
        public Proizvodi Proizvod { get; set; }
        public int ProizvodId { get; set; }
        public Korisnici Korisnici { get; set; }
        public int KorisniciId { get; set; }
        public DateTime datumFavorita { get; set; }
    }
}
