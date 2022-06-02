namespace AHOY.Assessment.Core.Reviews
{
    public class StarRating
    {
        public StarRatingId Id { get; private set; }
        public StarRatingValue Value { get; private set; }

        private StarRating()
        {

        }

        internal static StarRating Create(short value)
        {
            return new StarRating
            {
                Id = StarRatingId.GenerateNew(),
                Value = new StarRatingValue(value)
            };
        }
    }
}
