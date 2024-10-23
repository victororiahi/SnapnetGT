using SnapnetGT.Data;
using SnapnetGT.Data.Entities;
using SnapnetGT.Infrastructure.Interface.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnapnetGT.Infrastructure.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _dbContext;
        public OrderRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Orders>> GetOrderHistory(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<Orders> PlaceOrder(int productId, string shippingAddress)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateOrderStatus(string trackingReference, Utilities.Enum.Status status)
        {
            throw new NotImplementedException();
        }
    }
}
