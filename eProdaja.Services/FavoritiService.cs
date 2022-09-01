using AutoMapper;
using eProdaja.Model.Requests;
using eProdaja.Model.SearchObjects;
using eProdaja.Services.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public class FavoritiService : BaseCRUDService<Model.Favoriti, Database.Favoriti, Model.SearchObjects.FavoritiSearchObject, Model.Requests.FavoritiInsertRequest, object>, IFavoritiService
    {
        public FavoritiService(eProdajaContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override IEnumerable<Model.Favoriti> Get(FavoritiSearchObject search = null)
        {
            var favoriti = Context.Favoriti
                .Include(s => s.Korisnici)
                .AsQueryable();

            if(search != null)
            {
                if(search.ProizvodId != 0)
                {
                    favoriti = favoriti.Where(s => s.ProizvodId == search.ProizvodId);
                }
            }

            var res = favoriti.ToList();

            List<Model.Favoriti> response = new List<Model.Favoriti>();

            foreach (var item in res)
            {
                response.Add(new Model.Favoriti
                {
                    FavoritiId = item.FavoritiId,
                    ImePrezimeKorisnika = item.Korisnici.Ime + " " + item.Korisnici.Prezime,
                    datumOznacavanja = item.datumFavorita.ToString("dd.MM.yyyy")
                }); 

            }

            return response;
        }

        public override Model.Favoriti Insert(FavoritiInsertRequest insert)
        {
            Database.Favoriti favorti = new Database.Favoriti
            {
                ProizvodId = insert.ProizvodId,
                KorisniciId = Context.Korisnicis.Where(s => s.KorisnickoIme == insert.Username).FirstOrDefault().KorisnikId,
                datumFavorita = DateTime.Now
            };

            Context.Favoriti.Add(favorti);
            Context.SaveChanges();

            Database.Favoriti addedFavorit = Context.Favoriti
                    .Where(s => s.FavoritiId == favorti.FavoritiId)
                    .Include(s => s.Korisnici)
                    .FirstOrDefault();

            Model.Favoriti response = new Model.Favoriti
            {
                FavoritiId = favorti.FavoritiId,
                ImePrezimeKorisnika = favorti.Korisnici.Ime + " " + favorti.Korisnici.Prezime,
                datumOznacavanja = favorti.datumFavorita.ToString("dd.MM.yyyy")
            };

            return response;
        }
    }
}
