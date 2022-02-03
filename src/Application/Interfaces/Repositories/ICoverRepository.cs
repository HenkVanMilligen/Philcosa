using Philcosa.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Philcosa.Application.Interfaces.Repositories
{
    public interface ICoverRepository
    {
        IQueryable<Cover> IncludeLinkedEntities(string[] includes);
        //Task<bool> IsBrandUsed(int brandId);
    }
}