using Stopify.Model;

namespace Stopify.Service.Services.Interfaces
{
    public interface IArtistService
    {
        General<Model.Dtos.ArtistDto> Login(Stopify.Model.Dtos.LoginDto loginArtist);
        //General<Model.Dtos.ArtistDto> Insert(Stopify.Model.Dtos.ArtistDto newArtist);

    }
}
