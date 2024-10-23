using SnapnetGT.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SnapnetGT.Infrastructure.Utilities.Enum;

namespace SnapnetGT.Infrastructure.Interface.Repo
{
    public interface IOrderRepository
    {
        Task<Orders> PlaceOrder(int productId, string shippingAddress);
        Task<List<Orders>> GetOrderHistory(int userId);
        Task<bool> UpdateOrderStatus(string trackingReference, Status status);
    }
}
