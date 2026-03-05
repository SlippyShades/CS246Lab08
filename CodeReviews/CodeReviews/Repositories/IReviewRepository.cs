

using CodeReviews.Models;

namespace CodeReviews.Repositories
{
    public interface IReviewRepository
    {
        public List<Review> GetAllReviews();
        public Review GetReviewById(int id);

        public int AddReview(Review review);

    }
}
