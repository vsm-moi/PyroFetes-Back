using System.ComponentModel.DataAnnotations;

namespace PyroFetes.Models;

public class Invoice
{
    [Key] public int Id { get; set; }

    [Required] public int QuotationId { get; set; }
    public Quotation? Quotation { get; set; }

    public List<InvoiceProduct>? InvoicesProducts { get; set; }
}