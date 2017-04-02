using System.Collections.Generic;

namespace RetroMarket.Models {

    public interface IOrderRepository {

        IEnumerable<Order> Orders { get; }
        void SaveOrder(Order order);
    }
}
