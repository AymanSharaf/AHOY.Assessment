using AHOY.Assessment.Core.Hotels;
using AHOY.Assessment.Core.Users;

namespace AHOY.Assessment.Core.Reviews
{
    public class HotelReview
    {
        public HotelId HotelId { get; private set; }

        private List<Review> _reviews;
        public IReadOnlyList<Review> Reviews => _reviews;

        public StarRatingValue TotalRating { get; private set; }

        private HotelReview()
        {

        }

        public static HotelReview CreateNew(HotelId hotelId)
        {
            return new HotelReview
            {
                HotelId = hotelId,
                _reviews = new List<Review>()
            };
        }

        public void AddReview(UserEmail email, string reviewTitle, string reviewDetails, short rating)
        {
            if (_reviews.Any(r => r.Email.Equals(email)))
            {
                throw new InvalidOperationException("this user has already voted");
            }
            _reviews.Add(Review.CreateNew(reviewTitle, reviewDetails, rating, email));

            var hotelTotalRating = _reviews.Sum(r => r.StarRating.Value.Value) / _reviews.Count();

            this.TotalRating = new StarRatingValue((short)hotelTotalRating); // Possible Issue in shortning 
        }

    }
}
