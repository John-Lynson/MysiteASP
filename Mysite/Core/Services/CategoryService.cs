using Mysite.Core.Interfaces;
using Mysite.Core.Models;
using Mysite.Core.Services;
using Mysite.DataAccess.Repositories;

namespace Mysite.Core.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<IEnumerable<Category>> GetCategoriesAsync()
    {
        return await _categoryRepository.GetCategoriesAsync();
    }

    public async Task<Category> GetCategoryByIdAsync(int id)
    {
        return await _categoryRepository.GetCategoryByIdAsync(id);
    }

    public async Task<bool> CreateCategoryAsync(Category category)
    {
        return await _categoryRepository.AddCategoryAsync(category);
    }

    public async Task<bool> UpdateCategoryAsync(Category category)
    {
        return await _categoryRepository.UpdateCategoryAsync(category);
    }

    public async Task<bool> DeleteCategoryAsync(int id)
    {
        return await _categoryRepository.DeleteCategoryAsync(id);
    }
}
