

using BlueBadgeFinal.Data.Entities;
using BlueBadgeFinalProject.Data;
using MovieRater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace MovieRater.Services
{
    public class RatingService
    {
        private readonly Guid _userId;
        public RatingService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateRating(RatingCreate model)
        {
            var entity =
                new Rating()
                {
                    MovieRating = model.MovieRating,
                    TheaterRating = model.TheaterRating,
                    CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Ratings.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<RatingListItem> GetRating()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                ctx
                .Ratings
                .Where(e => e.AuthorId == _userId)
                .Select(
                e =>
                new RatingListItem
                {
                    MovieRating = e.MovieRating,
                    TheaterRating = e.TheaterRating,
                    CreatedUtc = e.CreatedUtc
                }
            );
                return query.ToArray();
            }
        }
        public RatingDetail GetRatingById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Ratings
                        .Single(e => e.ID == id && e.AuthorId == _userId);
                return
                    new RatingDetail
                    {
                        ID = entity.ID,
                        MovieRating = entity.MovieRating,
                        TheaterRating = entity.TheaterRating,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }
        public RatingDetail GetRatingByAuthorId(Guid AuthorId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Ratings
                        .Single(e => e.AuthorId == _userId);
                return
                    new RatingDetail
                    {
                        ID = entity.ID,
                        AuthorId = entity.AuthorId,
                        MovieRating = entity.MovieRating,
                        TheaterRating = entity.TheaterRating,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }
        public bool UpdateRating(RatingEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Ratings
                        .Single(e => e.ID == model.ID && e.AuthorId == _userId);
                entity.MovieRating = model.MovieRating;
                entity.TheaterRating = model.TheaterRating;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteRating(int ID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Ratings
                        .Single(e => e.ID == ID && e.AuthorId == _userId);
                ctx.Ratings.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}