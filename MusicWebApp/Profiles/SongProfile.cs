using AutoMapper;

namespace MusicWebApp.Profiles
{
    public class SongProfile : Profile
    {
        public SongProfile()
        {
            CreateMap<Entities.Artist, ExternalModels.ArtistDTO>();
            CreateMap<ExternalModels.ArtistDTO, Entities.Artist>();

            CreateMap<Entities.Song, ExternalModels.SongDTO>();
            CreateMap<ExternalModels.SongDTO, Entities.Song>();
        }
    }
}
