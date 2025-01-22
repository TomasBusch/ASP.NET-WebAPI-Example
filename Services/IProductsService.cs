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

        public void createProduct(SetProductDTO product);

        public void updateProduct(SetProductDTO product);

        public void deleteProduct(int id);
    }
}
