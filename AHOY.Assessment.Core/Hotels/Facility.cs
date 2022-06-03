namespace AHOY.Assessment.Core.Hotels
{
    public class Facility
    {
        public FacilityId Id { get; private set; }
        public FacilityName Name { get; private set; }
        private IList<Hotel> _hotels; // As a shortcut to make the fluent api work but should be removed

        private Facility()
        {

        }

        internal static Facility CreateNew(string name)
        {
            return new Facility
            {
                Id = FacilityId.GenerateFacilityId(),
                Name = new FacilityName(name)
            };
        }
    }
}
