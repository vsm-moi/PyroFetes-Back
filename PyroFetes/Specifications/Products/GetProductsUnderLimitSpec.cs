using Ardalis.Specification;
using PyroFetes.Models;

namespace PyroFetes.Specifications.Products;

public sealed class GetProductsUnderLimitSpec : Specification<Product>
{
    public GetProductsUnderLimitSpec()
    {
        Query
            .Include(x => x.WarehouseProducts)
            .Where(x => x.WarehouseProducts != null && x.WarehouseProducts.Sum(p => p.Quantity) < x.MinimalQuantity
                                                    && !x.ProductDeliveries!.Any(d => d.DeliveryNote!.RealDeliveryDate == null));
    }
}