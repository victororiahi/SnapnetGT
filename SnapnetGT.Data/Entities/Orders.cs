using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnapnetGT.Data.Entities
{
    public class Orders
    {
        public int Id { get; set; }
        public DateTime DateAdded { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
         public string ShippingAddress { get; set; }
        public string Status { get; set; }
        public string TrackingReference { get; set; }
    }
}
