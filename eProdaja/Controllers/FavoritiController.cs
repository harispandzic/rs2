using eProdaja.Services;
using Microsoft.AspNetCore.Mvc;

namespace eProdaja.Controllers
{
    public class FavoritiController : BaseCRUDController<Model.Favoriti, Model.SearchObjects.FavoritiSearchObject , Model.Requests.FavoritiInsertRequest, object>
    {
        public IFavoritiService FavoritiService { get; set; }
        public FavoritiController(IFavoritiService favoritiService)
            : base(favoritiService)
        {
            FavoritiService = favoritiService;
        }

    }
}
