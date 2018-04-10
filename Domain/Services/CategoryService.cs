namespace Yvadev.Domain.Services
{
    using System;
    using System.Collections.Generic;
    using Yvadev.Domain.Contracts;
    using Yvadev.Domain.Entities;

    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> repository;
        private readonly IAsyncRepository<Category> asyncRepository;

        public CategoryService(IRepository<Category> repository, IAsyncRepository<Category> asyncRepository)
        {
            this.repository = repository;
            this.asyncRepository = asyncRepository;
        }
        public void CreateCategory(Category category)
        {
            category.CreationDate = DateTime.UtcNow;
            repository.Add(category);
        }

        public void DeleteCategory(long id)
        {
            var category = repository.Get(id);
            repository.Delete(category);
        }

        public List<Category> GetCategories()
        {
            return repository.GetAll();
        }

        public Category GetCategory(long id)
        {
            return repository.Get(id);
        }

        public void UpdateCategory(Category category)
        {
            repository.Update(category);
        }
    }
}
