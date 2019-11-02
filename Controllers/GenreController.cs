using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicStoreSample.Data;
using MusicStoreSample.Models;
using MusicStoreSample.Services;

namespace MusicStoreSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        GenreService _srv;

        public GenreController(MusicStoreContext context)
        {
            _srv = new GenreService(context);
        }

        [HttpGet]
        public ActionResult Get()
        {

            return Ok(_srv.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(_srv.GetGenre(id));
        }

        [HttpPost]
        public ActionResult Post([FromBody] Genre Genre)
        {
            return Ok(_srv.SaveUpdate(Genre));
        }
    }
}