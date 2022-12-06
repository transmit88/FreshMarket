using FreshMarket.Core.Contracts;
using FreshMarket.Core.Models.Product;
using FreshMarket.Infrastructure.Data;
using FreshMarket.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreshMarket.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository repo;

        public ProductService(IRepository _repo)
        {
            this.repo = _repo;   
        }

        public async Task<ProductQueryModel> All(string? category = null, string? searchTern = null, ProductSorting sorting = ProductSorting.Newest, int currentPage = 1, int productPetPage = 1)
        {
            var result = new ProductQueryModel();
            var product = repo.AllReadonly<Product>()
                .Where(p => p.IsActive);

            if (string.IsNullOrEmpty(category) == false)
            {
                product = product
                    .Where(h => h.Category.Name == category);
            }

            if (string.IsNullOrEmpty(searchTern) == false)
            {
                searchTern = $"%searchTern.ToLower()%";
                product = product
                    .Where(p => EF.Functions.Like(p.Title, searchTern) ||
                        EF.Functions.Like(p.Address, searchTern) ||
                        EF.Functions.Like(p.Description, searchTern));
            }

            product = sorting switch
            {
                ProductSorting.Price => product
                    .OrderBy(p => p.Price),
                ProductSorting.NotRentedFirst => product
                    .OrderBy(p => p.BuyerId),
                _ => product.OrderByDescending(p => p.Id)
            };

            result.Products = await product
                .Skip((currentPage - 1) * productPetPage)
                .Take(productPetPage)
                .Select(p => new ProductServiceModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Address = p.Address,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl,
                    IsBuyer = p.BuyerId != null,
                })
                .ToListAsync();

            result.TotalProductCount = await product.CountAsync();

            return result;
        }

        public async Task<IEnumerable<ProductCategoriesModel>> AllCategories()
        {
            return await repo.AllReadonly<Category>()
                .OrderBy(c => c.Name)
                .Select(c => new ProductCategoriesModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> AllCategoriesNames()
        {
            return await repo.AllReadonly<Category>()
                .Select(c => c.Name)
                .Distinct()
                .ToListAsync();
        }

        public async Task<bool> CategoryExist(int categoryId)
        {
            return await repo.AllReadonly<Category>()
                .AnyAsync(c => c.Id == categoryId);
        }

        public async Task<int> Create(ProductModel model, int creatorId)
        {
            var product = new Product()
            {
                Title = model.Title,
                Price = model.Price,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                CreatorId = creatorId,
                CategoryId = model.CategoryId,
                Address = model.Address,
            };

            await repo.AddAsync(product);
            await repo.SaveChangesAsync();

            return product.Id;
        }

        public async Task Delete(int productId)
        {
            var product = await repo.GetByIdAsync<Product>(productId);
            product.IsActive = false;

            await repo.SaveChangesAsync();
        }

        public async Task Edit(int productId, ProductModel model)
        {
            var product = await repo.GetByIdAsync<Product>(productId);

            product.Title = model.Title;
            product.Price = model.Price;
            product.Description = model.Description;
            product.ImageUrl = model.ImageUrl;
            product.Address = model.Address;
            product.CategoryId= model.CategoryId;

            await repo.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            return await repo.AllReadonly<Product>()
                .AnyAsync(p => p.Id == id && p.IsActive);
        }

        public async Task<int> GetProductCategoryId(int productId)
        {
            return (await repo.GetByIdAsync<Product>(productId)).CategoryId;
        }

        public async Task<bool> HasCreatorWithId(int productId, string currentUserId)
        {
            bool result = false;

            var product = await repo.AllReadonly<Product>()
                .Where(p => p.IsActive)
                .Where(p => p.Id == productId)
                .Include(p => p.Creator)
                .FirstOrDefaultAsync();

            if (product?.Creator != null && product.Creator.UserId == currentUserId)
            {
                result = true;
            }

            return result;
        }

        public async Task<IEnumerable<ProductHomeModel>> LastTheeProduct()
        {
            return await repo.AllReadonly<Product>() // Take all
                .OrderByDescending(p => p.Id) // Sorted 
                .Select(p => new ProductHomeModel() // Select model
                {
                    Id = p.Id,
                    Title = p.Title,
                    ImageUrl = p.ImageUrl,
                })
                .Take(3) // Take first 3
                .ToListAsync();
        }

        public async Task<ProductDetailsModel> ProductDetailsById(int id)
        {
            return await repo.AllReadonly<Product>()
                .Where(p => p.IsActive)
                .Where(p => p.Id == id)
                .Select(p => new ProductDetailsModel()
                {
                    Title = p.Title,
                    Price = p.Price,
                    Address = p.Address,
                    Description = p.Description,
                    Category = p.Category.Name,
                    Id = id,
                    ImageUrl = p.ImageUrl,
                    IsBuyer = p.BuyerId != null,
                    Creator = new Models.Creator.CreatorServiceModel()
                    {
                        Email = p.Creator.User.Email,
                        PhoneNumber = p.Creator.PhoneNumber,
                    }
                })
                .FirstAsync();
        }
    }
}
