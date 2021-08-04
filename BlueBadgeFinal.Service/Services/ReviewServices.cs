using BlueBadgeFinal.Data.Entities;
using BlueBadgeFinal.Models.ReviewModels;
using BlueBadgeFinalProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BlueBadgeFinal.Service
{
    public class ReviewServices
    {
        private readonly Guid _userId;
        public ReviewServices(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateReview(ReviewCreate model)
        {
            var entity =
            new Review()
            {
                UserId = _userId,
                TheatreReview = model.TheatreReview,
                MovieReview=model.MovieReview,
                TheatreID=model.TheatreID,
                ID=model.ID
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Reviews.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ReviewListItem> GetReviews()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                ctx
                .Reviews
                .Where(e => e.UserId == _userId)
                .Select(
                e =>
                new ReviewListItem
                {
                    UserId = e.UserId,
                    TheatreReview = e.TheatreReview,
                    MovieReview = e.MovieReview
                }
            );
                return query.ToArray();
            }
        }
        public IEnumerable<ReviewDetail> GetReviewById(Guid UserId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Reviews
                        .Where(e => e.UserId == _userId)
                        .Select(e => new ReviewDetail
                        {
                            UserId = e.UserId,
                            TheatreReview = e.TheatreReview,
                            MovieReview = e.MovieReview,
                        });
                return entity.ToArray();            
            }
        }
        public bool UpdateReview(ReviewEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Reviews
                        .First(e => e.UserId == model.UserId && e.UserId == _userId);
                entity.TheatreReview = model.TheatreReview;
                entity.MovieReview = model.MovieReview;
                return ctx.SaveChanges() >= 1;
            }
        }
        public bool DeleteReview(int reviewId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Reviews
                        .Single(e => e.ReviewId == reviewId && e.UserId == _userId);
                ctx.Reviews.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
