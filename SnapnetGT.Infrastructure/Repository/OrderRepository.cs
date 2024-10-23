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
        public Task<List<Orders>> GetOrderHistory(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<Orders> PlaceOrder(int productId, string shippingAddress)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateOrderStatus(string trackingReference, Utilities.Enum.Status status)
        {
            throw new NotImplementedException();
        }
    }
}
