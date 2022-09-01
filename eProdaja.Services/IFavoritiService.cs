using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public interface IFavoritiService : ICRUDService<Model.Favoriti, Model.SearchObjects.FavoritiSearchObject, Model.Requests.FavoritiInsertRequest, object>
    {
    }
}
