using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MusicWebApp.Entities
{
    public class Song
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Title { get; set; }

        [Required]
        [MaxLength(150)]
        public string Genre { get; set;}

        [MaxLength(2500)]
        public string SongDesciption { get; set; }

        [Required]
        public Guid ArtistId { get; set; }

        [ForeignKey("ArtistId")]
        public virtual Artist Artist { get; set; }


        public bool? Deleted { get; set; }

    }
}
