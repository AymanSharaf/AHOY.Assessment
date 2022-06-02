using AHOY.Assessment.Core.Users;

namespace AHOY.Assessment.Core.Reviews
{
    public class Review
    {
        public ReviewId Id { get; private set; }
        public ReviewTitle Title { get; private set; }
        public ReviewDetails Details { get; private set; }
        public StarRating StarRating { get; private set; }
        public UserEmail Email { get; set; }

        private Review()
        {

        }

        internal static Review CreateNew(string title, string details, short rating, UserEmail email)
        {
            return new Review
            {
                Id = ReviewId.GenerateNew(),
                Title = new ReviewTitle(title),
                Details = new ReviewDetails(details),
                StarRating = StarRating.Create(rating),
                Email = email
            };
        }
    }
}
