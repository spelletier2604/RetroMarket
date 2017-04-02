using System.Collections.Generic;

namespace RetroMarket.Models {

    public interface IProductRepository {
        IEnumerable<Product> Products { get; }

        void SaveProduct(Product product);

        Product DeleteProduct(int productID);
    }
}
