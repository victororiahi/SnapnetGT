using SnapnetGT.Data.Entities;
using SnapnetGT.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SnapnetGT.Infrastructure.Utilities.Enum;

namespace SnapnetGT.Infrastructure.Interface.Repo
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAll(Filter filter, string query);

        Task<Product> AddProduct(ProductDTO product);
        Task<Product> UpdateProduct(int id, ProductDTO product);
        Task<bool> DeleteProduct(int id);
        Task<Product> GetProduct(int id);

    }
}
