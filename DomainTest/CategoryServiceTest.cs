namespace DomainTest
{
    using Moq;
    using Xunit;
    using Yvadev.Domain.Contracts;
    using Yvadev.Domain.Entities;
    using Yvadev.Domain.Services;

    public class CategoryServiceTest
    {
        private Mock<IRepository<Category>> mockRepository;
        private Mock<IAsyncRepository<Category>> mockAsyncRepository;
        private ICategoryService categoryService;

        public CategoryServiceTest()
        {
            mockRepository = new Mock<IRepository<Category>>();
            mockAsyncRepository = new Mock<IAsyncRepository<Category>>();
            categoryService = new CategoryService(mockRepository.Object, mockAsyncRepository.Object);
        }

        [Fact]
        public void GetCategories_Return_Any()
        {

        }

        [Fact]
        public void GetCategory_ReturnOne()
        {

        }

        [Fact]
        public void UpadateCategory_Success()
        {

        }

        [Fact]
        public void CreateCategory_Success()
        {

        }

        [Fact]
        public void DeleteCategory_Success()
        {

        }
    }
}
