using Philcosa.Application.Specifications.Base;
using Philcosa.Infrastructure.Models.Identity;

namespace Philcosa.Infrastructure.Specifications
{
    public class UserFilterSpecification : HeroSpecification<BlazorHeroUser>
    {
        public UserFilterSpecification(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                Criteria = p => p.FirstName.Contains(searchString) || p.LastName.Contains(searchString) || p.Email.Contains(searchString) || p.PhoneNumber.Contains(searchString) || p.UserName.Contains(searchString);
            }
            else
            {
                Criteria = p => true;
            }
        }
    }
}