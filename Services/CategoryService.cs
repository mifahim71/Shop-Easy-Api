using AutoMapper;
using ShopEasyApi.Dtos.CategoryDtos;
using ShopEasyApi.Entities;
using ShopEasyApi.Exceptions;
using ShopEasyApi.Repositories;

namespace ShopEasyApi.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _repository;

        public CategoryService(IMapper mapper, ICategoryRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<CategoryDto> CreateCategoryAsync(CategoryCreateRequestDto requestDto)
        {
            var category = _mapper.Map<Category>(requestDto);

            var savedCategory = await _repository.CreateCategoryAsync(category);

            return _mapper.Map<CategoryDto>(savedCategory);
        }


        public async Task<CategoryDto> UpdateCategoryAsync(int id, CategoryUpdateRequestDto requestDto)
        {
            var category = await _repository.FindCategoryByIdAsync(id);
            if (category == null)
            {
                throw new NotFoundException($"Category with id:{id} not found");
            }

            if (!string.IsNullOrWhiteSpace(requestDto.Name))
                category.Name = requestDto.Name;

            if (!string.IsNullOrWhiteSpace(requestDto.Description))
                category.Description = requestDto.Description;

            await _repository.SaveChangesAsync();

            return _mapper.Map<CategoryDto>(category);
        }



        public async Task DeleteCategoryAsync(int categoryId)
        {
            var category = await _repository.FindCategoryByIdAsync(categoryId);
            if (category == null)
            {
                throw new NotFoundException($"Category with id:{categoryId} not found");
            }

            await _repository.DeleteCategoryAsync(category);
        }

        public async Task<List<CategoryDto>> GetAllCategoriesAsync()
        {
            var categories = await _repository.GetAllCategoriesAsync();

            return _mapper.Map<List<CategoryDto>>(categories);
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(int categoryId)
        {
            var category = await _repository.FindCategoryByIdAsync(categoryId);
            if (category == null)
            {
                throw new NotFoundException($"Category with id:{categoryId} not found");
            }

            return _mapper.Map<CategoryDto>(category);
        }
    }
}
