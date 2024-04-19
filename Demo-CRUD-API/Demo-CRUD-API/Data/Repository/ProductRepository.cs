using Demo_CRUD_API.Data.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Demo_CRUD_API.Data.Repository
{
    public class ProductRepository
    {
        private readonly AppDbContext _appDbContext;
        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddProductAsync(Product product)
        {
            await _appDbContext.Set<Product>().AddAsync(product);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllProductAsync()
        {
            return await _appDbContext.Products.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
           return await _appDbContext.Products.FindAsync(id);
        }

        public async Task UpdateProductAsync(int id, Product model)
        {
            var product = await _appDbContext.Products.FindAsync(id);
            if(product == null)
            {
                throw new Exception("Product not found");
            }
            product.Name = model.Name;
            product.Description = model.Description;
            product.Price = model.Price;
            product.Quantity = model.Quantity;
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _appDbContext.Products.FindAsync(id);
            if (product == null)
            {
                throw new Exception("Product not found");
            }
            _appDbContext.Products.Remove(product);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
