namespace AHOY.Assessment.Core.Countries
{
    public class City
    {
        public CityId Id { get; private set; }
        public Name Name { get; private set; }

        private City()
        {

        }

        internal static City CreateNew(string name)
        {
            return new City
            {
                Id = CityId.GenerateNew(),
                Name = new Name(name)
            };
        }
    }
}
