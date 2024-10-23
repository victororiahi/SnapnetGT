using Microsoft.EntityFrameworkCore;
using SnapnetGT.Data;
using SnapnetGT.Data.Entities;
using SnapnetGT.Infrastructure.DTOs;
using SnapnetGT.Infrastructure.Interface.Repo;
using SnapnetGT.Infrastructure.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SnapnetGT.Infrastructure.Utilities.Enum;

namespace SnapnetGT.Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _dbContext;
        public ProductRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product> AddProduct(ProductDTO product)
        {
            if (product.ImageUrl.IsValidUrl()) 
                throw new Exception("Invalid Image Url");

            var entity = await _dbContext.Set<Product>().FirstOrDefaultAsync(x => x.Name == product.Name);
            if (entity != null)
                throw new Exception($"Product: {product.Name} already exists!");
            var ent = new Product
            {
                DateAdded = DateTime.Now,
                Name = product.Name,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Price = product.Price,
                Quantity = product.Quantity
            };

            await _dbContext.AddAsync(ent);
            await _dbContext.SaveChangesAsync();
            return ent;
        
    }

        public async Task<bool> DeleteProduct(int id)
        {
            var entity = await _dbContext.Set<Product>().FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
                throw new Exception($"Product with Id: {id} not found!");

            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Product>> GetAll(Utilities.Enum.Filter filter, string query)
        {
            var records = _dbContext.Set<Product>().Where(x => x.Id > 0);
            switch (filter)
            {
                case Filter.Name:
                    records = records.Where(x => EF.Functions.Like(x.Name, $"%{query}%"));
                    break;

                case Filter.Description:
                    records = records.Where(x => EF.Functions.Like(x.Description, $"%{query}%"));

                    break;
                default:
                    break;
            }

            var results = await records.OrderByDescending(x => x.DateAdded).ToListAsync();
            return results;
        }

        public async Task<Product> GetProduct(int id)
        {
            var product = await _dbContext.Set<Product>().FirstOrDefaultAsync(x => x.Id == id);
            if (product == null) throw new Exception("Product not found");
            return product;
        }

        public async Task<Product> UpdateProduct(int id, ProductDTO product)
        {
            var entity = await _dbContext.Set<Product>().FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null) throw new Exception("Product not found");

            entity.Name = product.Name ?? entity.Name;
            entity.Description = product.Description ?? entity.Description;
            entity.Price = product.Price > 0 ? product.Price:entity.Price;
            entity.Quantity = product.Quantity > 0 ? product.Quantity : entity.Quantity;


            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }

}
