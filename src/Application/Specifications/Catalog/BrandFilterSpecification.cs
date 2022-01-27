using TestApi2.Application.Specifications.Base;
using TestApi2.Domain.Entities.Catalog;

namespace TestApi2.Application.Specifications.Catalog
{
    public class BrandFilterSpecification : HeroSpecification<Brand>
    {
        public BrandFilterSpecification(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                Criteria = p => p.Name.Contains(searchString) || p.Description.Contains(searchString);
            }
            else
            {
                Criteria = p => true;
            }
        }
    }
}
