using Philcosa.Domain.Entities.Catalog;
using Philcosa.Application.Interfaces.Repositories;

namespace Philcosa.Infrastructure.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly IRepositoryAsync<Brand, int> _repository;

        public BrandRepository(IRepositoryAsync<Brand, int> repository)
        {
            _repository = repository;
        }
    }
}