using Philcosa.Application.Interfaces.Repositories;
using Philcosa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Philcosa.Infrastructure.Repositories
{
    public class CoverRepository : ICoverRepository
    {
        private readonly IRepositoryAsync<Cover, int> _repository;

        public CoverRepository(IRepositoryAsync<Cover, int> repository)
        {
            _repository = repository;
        }

        public IQueryable<Cover> IncludeLinkedEntities(string[] includes)
        {
            var query = this._repository.Entities;
            foreach(var i in includes)
            {
                query = query.Include(i);
            }
            return query;
        }
        //public async Task<bool> IsBrandUsed(int brandId)
        //{
        //    return await _repository.Entities.AnyAsync(b => b.BrandId == brandId);
        //}
    }
}