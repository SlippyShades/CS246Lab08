using Xunit;
using Microsoft.AspNetCore.Mvc;
using CodeReviews.Repositories;
using CodeReviews.Models;
using CodeReviews.Controllers;
using System;
namespace ReviewTests
{
    public class ReviewTests
    {
        [Fact]
        public void TestAdd() {
            var fakeRepo = new FakeReviewRepository();
            var controller = new ReviewController(fakeRepo);

            var review = new Review {
                ReviewId = 1,
                Comments = "This is a test review"
            };

            var result = controller.Review(review);

            var reviews = fakeRepo.GetAllReviews();
            Assert.Single(reviews);

            var savedReview = reviews[0];

            Assert.Equal("This is a test review", savedReview.Comments);


        }
    }
}
