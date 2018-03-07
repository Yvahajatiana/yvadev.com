using System;
using System.Collections.Generic;
using System.Text;
using Yvadev.Domain.Contracts;
using Yvadev.Domain.Entities;

namespace Yvadev.Domain.Services
{
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
