using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PyroFetes.Models;

[PrimaryKey(nameof(ProductId), nameof(PurchaseOrderId))]
public class PurchaseProduct
{
    public Product? Product { get; set; }
    [Required] public int ProductId { get; set; }

    public PurchaseOrder? PurchaseOrder { get; set; }
    [Required] public int PurchaseOrderId { get; set; }

    [Required] public int Quantity { get; set; }
}