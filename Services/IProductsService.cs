using WebAPI.Models;
using WebAPI.DTO.Product;

namespace WebAPI.Services
{
    public interface IProductsService
    {
        public Task<IEnumerable<GetProductDTO>> getActiveProducts(int offset, int count);

        public Task<IEnumerable<GetProductDTO>> getInactiveProducts(int offset, int count);

        public Task<IEnumerable<GetProductDTO>> getAllProducts(int offset, int count);

        public Task<GetProductDTO> getProductById(int id);

        public Task<bool> createProduct(SetProductDTO product);

        public Task<bool> updateProduct(SetProductDTO product, Object id);

        public Task<bool> deleteProduct(int id);
    }
}
