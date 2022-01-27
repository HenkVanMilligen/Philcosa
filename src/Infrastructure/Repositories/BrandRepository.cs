using TestApi2.Application.Interfaces.Repositories;
using TestApi2.Domain.Entities.Catalog;

namespace TestApi2.Infrastructure.Repositories
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