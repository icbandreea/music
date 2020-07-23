
using AutoMapper;
using MusicWebApp.Entities;
using MusicWebApp.ExternalModels;
using MusicWebApp.Services.UnitsOfWork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


namespace MusicWebApp.Controllers
{
    [Route("song")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly ISongUnitOfWork _songUnit;
        private readonly IMapper _mapper;

        public SongController(ISongUnitOfWork songUnit,
            IMapper mapper)
        {
            _songUnit = songUnit ?? throw new ArgumentNullException(nameof(songUnit));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        #region Song
        [HttpGet]
        [Route("{id}", Name = "GetSong")]
        public IActionResult GetSong(Guid id)
        {
            var songEntity = _songUnit.Song.Get(id);
            if (songEntity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<SongDTO>(songEntity));
        }

        [HttpGet]
        [Route("", Name = "GetAllSongs")]
        public IActionResult GetAllSongs()
        {
            var songEntities = _songUnit.Song.Find(a => a.Deleted == false || a.Deleted == null);
            if (songEntities == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<List<SongDTO>>(songEntities));
        }

        [HttpGet]
        [Route("details/{id}", Name = "GetSongDetails")]
        public IActionResult GetSongDetails(Guid id)
        {
            var songEntity = _songUnit.Song.GetSongDetails(id);
            if (songEntity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<SongDTO>(songEntity));
        }

        [Route("add", Name = "Add a new song")]
        [HttpPost]
        public IActionResult AddSong([FromBody] SongDTO song)
        {
            var songEntity = _mapper.Map<Song>(song);
            _songUnit.Song.Add(songEntity);

            _songUnit.Complete();

            _songUnit.Song.Get(songEntity.Id);

            return CreatedAtRoute("GetSong",
                new { id = songEntity.Id },
                _mapper.Map<SongDTO>(songEntity));
        }
        #endregion Song

        #region Artist
        [HttpGet]
        [Route("artist/{artistId}", Name = "GetArtist")]
        public IActionResult GetArtist(Guid artistId)
        {
            var artistEntity = _songUnit.Artist.Get(artistId);
            if (artistEntity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ArtistDTO>(artistEntity));
        }

        [HttpGet]
        [Route("artist", Name = "GetAllArtists")]
        public IActionResult GetAllArtists()
        {
            var artistEntities = _songUnit.Artist.Find(a => a.Deleted == false || a.Deleted == null);
            if (artistEntities == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<List<ArtistDTO>>(artistEntities));
        }

        [Route("artist/add", Name = "Add a new artist")]
        [HttpPost]
        public IActionResult AddArtist([FromBody] ArtistDTO artist)
        {
            var artistEntity = _mapper.Map<Artist>(artist);
            _songUnit.Artist.Add(artistEntity);

            _songUnit.Complete();

            _songUnit.Artist.Get(artistEntity.Id);

            return CreatedAtRoute("GetArtist",
                new { artistId = artistEntity.Id },
                _mapper.Map<ArtistDTO>(artistEntity));
        }

        [Route("artist/{artistId}", Name = "Mark artist as deleted")]
        [HttpPut]
        public IActionResult MarkArtistAsDeleted(Guid artistId)
        {
            var artist = _songUnit.Artist.FindDefault(a => a.Id.Equals(artistId) && (a.Deleted == false || a.Deleted == null));
            if (artist != null)
            {
                artist.Deleted = true;
                if (_songUnit.Complete() > 0)
                {
                    return Ok("Artist " + artistId + " was deleted.");
                }
            }
            return NotFound();
        }
        #endregion Artist
    }
}
