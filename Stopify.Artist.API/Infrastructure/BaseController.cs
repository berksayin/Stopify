using Microsoft.AspNetCore.Mvc;

namespace Stopify.Artist.API.Infrastructure
{
    public class BaseController : ControllerBase
    {
        public Model.Dtos.ArtistDto CurrentArtist{
            get{
                return new Model.Dtos.ArtistDto();
            }
        }
    }
}
