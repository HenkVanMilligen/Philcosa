using TestApi2.Infrastructure.Models.Identity;
using TestApi2.Application.Specifications.Base;

namespace TestApi2.Infrastructure.Specifications
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