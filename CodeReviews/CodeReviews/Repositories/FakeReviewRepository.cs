

using CodeReviews.Data;
using CodeReviews.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeReviews.Repositories
{
    public class FakeReviewRepository : IReviewRepository
    {
        public List<Review> Reviews = new List<Review>();

   
        public List<Review> GetAllReviews() { 
            return Reviews;
        }
        public Review GetReviewById(int id) {
            return Reviews
                .Where(review => review.ReviewId == id)
                .SingleOrDefault();
        }

        public int AddReview(Review review) {
            review.ReviewDate = DateTime.Now;

            review.ReviewId = Reviews.Count + 1;

            Reviews.Add(review);

            return 1;

        }

    }
}
