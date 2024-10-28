using Product.Core.Application.Interfaces.Repositories;
using Product.Core.Domain.Entities;
using Product.Infrastructure.Persistence.Context;


namespace Product.Infrastructure.Persistence.Repositories
{
    public class ProductoRepository : GenericRepository<Producto>, IProductoRepository
    {
        public ApplicationContext _context;
        public ProductoRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }
    }
}
