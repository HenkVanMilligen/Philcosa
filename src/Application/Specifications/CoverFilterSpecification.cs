using Philcosa.Application.Specifications.Base;
using Philcosa.Domain.Entities;

namespace Philcosa.Application.Specifications
{
    public class CoverFilterSpecification : ApplicationSpecification<Cover>
    {
        public CoverFilterSpecification(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                Includes.Add(x => x.Country);
                Criteria = p => (
                    p.Description.Contains(searchString) ||
                    p.Country.Code.Contains(searchString) ||
                    p.CoverDate.Year.ToString() == searchString ||
                    p.CoverDate.Month.ToString() == searchString ||
                    p.CoverDate.Day.ToString() == searchString
                    //p.CoverThemes.Contains() || 
                    //p.Brand.Name.Contains(searchString)
                    );
            }
            else
            {
                Criteria = p => p.Description != null;
            }
            
        }
    }
}