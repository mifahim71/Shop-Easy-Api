using AutoMapper;
using ShopEasyApi.Dtos.ProductDtos;
using ShopEasyApi.Entities;
using ShopEasyApi.Repositories;
using ShopEasyApi.Exceptions;

namespace ShopEasyApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductService> _logger;

        public ProductService(IProductRepository repository, IMapper mapper, ICategoryRepository categoryRepository, ILogger<ProductService> logger) 
        {
            _repository = repository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ProductDto> CreateProductAsync(ProductCreateRequestDto requestDto)
        {
            _logger.LogWarning($"before checking if customer exists: {requestDto.CategoryId}");
            bool IfCategoryExists = await _categoryRepository.IfExistsById(requestDto.CategoryId);
            _logger.LogWarning($"after checking if customer exists: {IfCategoryExists}");
            if (!IfCategoryExists) 
            {
                throw new NotFoundException($"Category With Id:{requestDto.CategoryId} not exists");
            }

            
            var product = _mapper.Map<Product>(requestDto);
            
            var savedProduct = await _repository.CreateProductAsync(product);

            if (savedProduct == null) 
            {
                throw new OperationFailedException("Failed to save product");
            }

            var productDto = _mapper.Map<ProductDto>(savedProduct);
            productDto.CategoryName = savedProduct.Category.Name;
            return productDto;
        }

        public async Task<List<ProductDto>> GetAllProductsAsync()
        {
            var products = await _repository.GetAllAsync();

            return _mapper.Map<List<ProductDto>>(products);
        }
    }
}
