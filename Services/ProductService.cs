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
            
            bool IfCategoryExists = await _categoryRepository.IfExistsById(requestDto.CategoryId);
            
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
            productDto.CategoryName = savedProduct.Category!.Name;
            return productDto;
        }


        public async Task<List<ProductDto>> GetAllProductsAsync()
        {
            var products = await _repository.GetAllAsync();

            return _mapper.Map<List<ProductDto>>(products);
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            if(product == null)
            {
                throw new NotFoundException($"Product with id:{id} not found");
            }

            return _mapper.Map<ProductDto>(product);
        }

        public async Task DeleteProductByIdAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null)
            {
                throw new NotFoundException($"Product with id:{id} not found");
            }

            await _repository.DeleteProductAsync(product);
        }

        public async Task UpdateProductAsync(int id, UpdateProductRequestDto requestDto)
        {
            var product = await _repository.GetByIdTractingAsync(id);
            if (product == null)
            {
                throw new NotFoundException($"Product with id:{id} not found");
            }

            if(requestDto.CategoryId.HasValue) 
            {
                bool IfCategoryExists = await _categoryRepository.IfExistsById(requestDto.CategoryId.Value);

                if (!IfCategoryExists)
                {
                    throw new NotFoundException($"Category With Id:{requestDto.CategoryId.Value} not exists");
                }

                product.CategoryId = requestDto.CategoryId.Value;
            }


            if(!String.IsNullOrWhiteSpace(requestDto.Name))
            {
                product.Name = requestDto.Name;
            }

            if(!String.IsNullOrWhiteSpace(requestDto.Description))
            {
                product.Description = requestDto.Description;
            }

            if(requestDto.Stock.HasValue)
            {
                product.Stock = requestDto.Stock.Value;
            }

            if(requestDto.Price.HasValue)
            {
                product.Price = requestDto.Price.Value;
            }

            await _repository.SaveChangesAsync();
        }

        public async Task<List<ProductDto>> GetProductByCategoryAsync(int categoryId)
        {
            bool IfCategoryExists = await _categoryRepository.IfExistsById(categoryId);

            if (!IfCategoryExists)
            {
                throw new NotFoundException($"Category With Id:{categoryId} not exists");
            }

            var category = await _categoryRepository.FindCategoryWithProductAsync(categoryId);

            var products = category!.Products;

            return _mapper.Map<List<ProductDto>>(products);

        }


        public async Task<List<ProductDto>> GetProductByPriceRangeAsync(decimal minValue, decimal maxValue)
        {
            var products = await _repository.GetProductByPriceRangeAsync(minValue, maxValue);
            return _mapper.Map<List<ProductDto>>(products);
        }
    }
}
