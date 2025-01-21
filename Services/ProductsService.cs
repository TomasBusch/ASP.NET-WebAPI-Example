using AutoMapper;
using WebAPI.Data_Access;
using WebAPI.Models;
using WebAPI.Models.DTO.Product;

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

        public async void createProduct(SetProductDTO product)
        {
            _unitOfWork.ProductRepository.Insert(_mapper.Map<Product>(product));
            _unitOfWork.Save();
        }

        public void deleteProduct(int id)
        {
            _unitOfWork.ProductRepository.Delete(id);
        }

        public void updateProduct(SetProductDTO product)
        {
            throw new NotImplementedException();
        }
    }
}
