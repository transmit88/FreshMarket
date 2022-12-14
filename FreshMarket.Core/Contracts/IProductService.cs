using FreshMarket.Core.Models.Product;

namespace FreshMarket.Core.Contracts
{
    public interface IProductService
    {

        Task<IEnumerable<ProductHomeModel>> LastTheeProduct();

        Task<IEnumerable<ProductCategoriesModel>> AllCategories();

        Task<bool> CategoryExist(int categoryId);

        Task<int> Create(ProductModel model, int agentId);

        Task<ProductQueryModel> All(
            string? category = null,
            string? searchTern = null,
            ProductSorting sorting = ProductSorting.Newest,
            int currentPage = 1,
            int productPetPage = 1);

        Task<IEnumerable<string>> AllCategoriesNames();

        Task<bool> Exists(int id);

        Task<ProductDetailsModel> ProductDetailsById(int id);

        Task<bool> HasCreatorWithId(int productId, string currentUserId);

        Task<int> GetProductCategoryId(int productId);

        Task Edit(int productId, ProductModel model);

        Task Delete(int productId);

        Task<IEnumerable<ProductServiceModel>> AllProductsByCreateId(int id);

        Task<IEnumerable<ProductServiceModel>> AllProductsByUserId(string userId);

    }
}
