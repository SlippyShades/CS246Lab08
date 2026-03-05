

using CodeReviews.Data;
using CodeReviews.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeReviews.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private AppDbContext context;

        public ReviewRepository(AppDbContext AppDbContext)
        {
           context = AppDbContext;
        }
        public List<Review> GetAllReviews() { 
         var reviews = context.Reviews
                .Include(review => review.Reviewer)
                .Include(review => review.Comments)
                .ToList<Review>();
            return reviews;
        }
        public Review GetReviewById(int id) {
            var review = context.Reviews
              .Include(review => review.Reviewer)
              .Include(review => review.Comments)
              .Where(review => review.ReviewId == id)
              .SingleOrDefault();

            return review;

        }

        public int AddReview(Review review) {
            review.ReviewDate = DateTime.Now;

            context.Reviews.Add(review);

            return context.SaveChanges();

        }

    }
}
