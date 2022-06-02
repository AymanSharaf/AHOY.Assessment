namespace AHOY.Assessment.Core.Countries
{
    public class Country
    {
        public CountryId Id { get; private set; }
        public Name Name { get; private set; }

        private List<City> _cities;
        public IReadOnlyList<City> Cities => _cities;

        private Country()
        {
        }

        public static Country CreateNew(string name)
        {
            return new Country
            {
                Id = CountryId.GenerateNew(),
                Name = new Name(name),
                _cities = new List<City>()
            };
        }

        public static Country CreateNewWithCities(string name, List<string> cities)
        {
            var country = new Country
            {
                Id = CountryId.GenerateNew(),
                Name = new Name(name),
                _cities = new List<City>()
            };

            cities.ForEach(city => country.AddCity(city));

            return country;
        }

        public void AddCity(string name)
        {
            if (_cities.Any(c => c.Name.Value.Equals(name)))
            {
                throw new ArgumentException($"This city \"{name}\" already exists in country ${Name.Value}"); // not optimal in performance
            }
            _cities.Add(City.CreateNew(name));
        }
    }
}
