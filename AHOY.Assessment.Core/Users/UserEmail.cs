using AHOY.Assessment.Core.Common;
using Ardalis.GuardClauses;

namespace AHOY.Assessment.Core.Users
{
    public class UserEmail : ValueObject
    {
        public string Email { get; private set; }

        public UserEmail(string email)
        {
            Email = Guard.Against.NullOrEmpty(email); // More Validation should be here 

        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Email;
        }
    }
}
