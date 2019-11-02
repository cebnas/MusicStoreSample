using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicStoreSample.Data;
using MusicStoreSample.Models;
using MusicStoreSample.Repository;
using Microsoft.AspNetCore.Authorization;

namespace MusicStoreSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class ArtistController : ControllerBase
    {
        ArtistService _srv;

        public ArtistController(MusicStoreContext context)
        {
            _srv = new ArtistService(context);
        }

        [HttpGet]
        public ActionResult Get()
        {

            return Ok(_srv.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(_srv.GetArtist(id));
        }

        [HttpPost]
        public ActionResult Post([FromBody] Artist artist)
        {
            return Ok(_srv.SaveUpdate(artist));
        }
    }
}