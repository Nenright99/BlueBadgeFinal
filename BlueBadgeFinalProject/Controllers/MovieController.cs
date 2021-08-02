using BlueBadgeFinal.Models;
using BlueBadgeFinal.Models.MovieModels;
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
    public class MovieController : ApiController
    {
        private MovieService CreateMovieService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var movieService = new MovieService(userId);
            return movieService;
        }
        public IHttpActionResult GetMovies(string title)
        {
            MovieService movieService = CreateMovieService();
            var movies = movieService.GetMovies(title);
            return Ok(movies);
        }
        public IHttpActionResult Post(MovieCreate movie)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateMovieService();
            if (!service.CreateMovie(movie))
                return InternalServerError();
            return Ok();
        }
        [ActionName("GetMovieById")]
        public IHttpActionResult GetMovieById(int id)
        {
            
            MovieService movieService = CreateMovieService();
            var movie = movieService.GetMovieById(id);
            return Ok(movie);
        }
        [ActionName("GetMovieByRelease")]
        public IHttpActionResult GetMovieByRelease(DateTime release)
        {
            MovieService movieService = CreateMovieService();
            var movie = movieService.GetMoviesByRelease(release);
            return Ok(movie);

        }
        [ActionName("GetMovieByRunTime")]
        public IHttpActionResult GetMovieByRunTime(int runtime)
        {
            MovieService movieService = CreateMovieService();
            var movie = movieService.GetMoviesByRunTime(runtime);
            return Ok(movie);

        }
        public IHttpActionResult Put(MovieEdit movie)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateMovieService();
            if (!service.UpdateMovie(movie))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateMovieService();
            if (!service.DeleteMovies(id))
                return InternalServerError();
            return Ok();
        }
    }
}

