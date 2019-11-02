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
    public class AlbumController : ControllerBase
    {
        AlbumService _srv;

        public AlbumController(MusicStoreContext context)
        {
            _srv = new AlbumService(context);
        }

        [HttpGet]
        public ActionResult Get()
        {

            return Ok(_srv.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(_srv.GetAlbum(id));
        }

        [HttpPost]
        public ActionResult Post([FromBody] Album Album)
        {
            return Ok(_srv.SaveUpdate(Album));
        }
    }
}