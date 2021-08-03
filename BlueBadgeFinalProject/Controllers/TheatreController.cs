using BlueBadgeFinal.Models.TheatreModels;
using BlueBadgeFinal.Service;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlueBadgeFinalProject.Controllers
{
    [Authorize]
    public class TheatreController : ApiController
    {
       
        public IHttpActionResult Post(TheatreCreate theatre)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateTheatreService();

            if (!service.CreateTheatre(theatre))
                return InternalServerError();

            return Ok();
        }
        private TheatreService CreateTheatreService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var theatreService = new TheatreService(userId);
            return theatreService;
        }
        public IHttpActionResult Get(int id)
        {
            TheatreService theatreService = CreateTheatreService();
            var theatre = theatreService.GetTheatreById(id);
            return Ok(theatre);
        }
        public IHttpActionResult Put(TheatreEdit theatre)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateTheatreService();
            if (!service.UpdateTheatre(theatre))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateTheatreService();
            if (!service.DeleteTheatre(id))
                return InternalServerError();
            return Ok();
        }

    }
}