namespace Yvadev.Domain.Contracts
{
    using System.Collections.Generic;
    using Yvadev.Domain.Entities;

    public interface ICategoryService
    {
        List<Category> GetCategories();

        Category GetCategory(long id);

        void CreateCategory(Category category);

        void UpdateCategory(Category category);

        void DeleteCategory(long id);
    }
}
