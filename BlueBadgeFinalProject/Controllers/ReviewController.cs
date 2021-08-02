using BlueBadgeFinal.Models.ReviewModels;
using BlueBadgeFinal.Service;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net.Http;
using System.Net;
using BlueBadgeFinal.Data;



namespace BlueBadgeFinalProject.Controllers
{
    public class ReviewController : ApiController
    {
        private ReviewServices CreateReviewService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var reviewService = new ReviewServices(userId);
            return reviewService;
        }
        public IHttpActionResult Get()
        {
            ReviewServices reviewService = CreateReviewService();
            var reviews = reviewService.GetReviews();
            return Ok(reviews);
        }
        public IHttpActionResult Post(ReviewCreate review)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateReviewService();
            if (!service.CreateReview(review))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Get(Guid UserId)
        {
            ReviewServices reviewService = CreateReviewService();
            var comment = reviewService.GetReviewById(UserId);
            return Ok(comment);
        }
        public IHttpActionResult Put(ReviewEdit review)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateReviewService();
            if (!service.UpdateReview(review))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Delete(int ReviewId)
        {
            var service = CreateReviewService();
            if (!service.DeleteReview(ReviewId))
                return InternalServerError();
            return Ok();
        }
    }
}
