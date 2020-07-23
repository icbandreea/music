using System;

namespace MusicWebApp.ExternalModels
{

    public class SongDTO
    {
     
        public Guid Id { get; set; }

     
        public string Title { get; set; }

       
        public string Genre { get; set; }

     
        public string SongDesciption { get; set; }

  
        public Guid ArtistId { get; set; }

     
        public virtual ArtistDTO Artist { get; set; }

    }
}
