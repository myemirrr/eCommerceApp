using eCommerce.Library.Models;

namespace eCommerce.Api.Services
{
    public interface ICategoryService
    {
        Task<List<Category>> GetCategoriesAsync();
    }
}
