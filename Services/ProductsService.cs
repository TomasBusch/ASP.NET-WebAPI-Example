using AutoMapper;
using WebAPI.Data_Access;
using WebAPI.Models;
using WebAPI.DTO.Product;

namespace WebAPI.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IUnitOfWork _unitOfWork;

        public ProductsService(ILogger<ProductsService> logger, IUnitOfWork unitOfWork, IMapper mapper) 
        {
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<GetProductDTO>> getActiveProducts(int offset, int count)
        {
            var products = await _unitOfWork.ProductRepository.Get(offset: offset, count: count, filter: s => s.Discontinued == false);

            return _mapper.Map<List<GetProductDTO>>(products);
        }

        public async Task<IEnumerable<GetProductDTO>> getAllProducts(int offset, int count)
        {
            var products = await _unitOfWork.ProductRepository.Get(offset: offset, count: count);

            return _mapper.Map<List<GetProductDTO>>(products);
        }

        public async Task<IEnumerable<GetProductDTO>> getInactiveProducts(int offset, int count)
        {
            var products = await _unitOfWork.ProductRepository.Get(offset: offset, count: count, filter: s => s.Discontinued == true);

            return _mapper.Map<List<GetProductDTO>>(products);
        }

        public async Task<GetProductDTO> getProductById(int id)
        {
            return _mapper.Map<GetProductDTO>(await _unitOfWork.ProductRepository.GetById(id));
        }

        public async Task<bool> createProduct(SetProductDTO product)
        {
            await _unitOfWork.ProductRepository.Insert(_mapper.Map<Product>(product));
            await _unitOfWork.Save();

            return true;
        }

        public async Task<bool> deleteProduct(int id)
        {
            await _unitOfWork.ProductRepository.Delete(id);

            return true;
        }

        public async Task<bool> updateProduct(SetProductDTO product, Object id)
        {
            var DbProduct = await _unitOfWork.ProductRepository.GetById((int)id);

            if (DbProduct != null)
            {
                _mapper.Map(product, DbProduct);
                await _unitOfWork.ProductRepository.Update(DbProduct);
                await _unitOfWork.Save();

                return true;
            }

            return false;
        }
    }
}
