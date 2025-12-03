using PyroFetes.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace PyroFetes.Services.Pdf;

public interface IDeliveryNotePdfService
{
    byte[] Generate(DeliveryNote deliveryNote, List<ProductDelivery> lignes);
}

public class DeliveryNotePdfService : IDeliveryNotePdfService
{
    public byte[] Generate(DeliveryNote deliveryNote, List<ProductDelivery> lignes)
    {
        var logoPath = Path.Combine(AppContext.BaseDirectory, "wwwroot", "Images", "logo.jpg");
        var signaturePath = Path.Combine(AppContext.BaseDirectory, "wwwroot", "Images", "signature.png");
        int total = 0;
        int totalQuantity = 0;
        var document = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(30);
                page.DefaultTextStyle(x => x.FontSize(11));

                page.Header().Row(row =>
                {
                    // Client à gauche
                    row.RelativeItem().Column(col =>
                    {
                        col.Item().Text("");
                        col.Item().Text("");
                        col.Item().Text("");
                        col.Item().Text("");
                        col.Item().Text("Transporteur").SemiBold().FontSize(12);
                        col.Item().Text($"{deliveryNote.Deliverer?.Transporter}");
                        col.Item().Height(5);
                        col.Item().AlignLeft().Text($"Expédiée le {deliveryNote.ExpeditionDate}");
                        col.Item().Height(5);
                        col.Item().AlignLeft().Text($"Estimée au {deliveryNote.EstimateDeliveryDate}");
                        col.Item().Height(5);
                        col.Item().AlignLeft().Text($"Reçu le {deliveryNote.RealDeliveryDate}");
                    });

                    // Logo + société à droite
                    row.ConstantItem(200).Column(col =>
                    {
                        col.Item().AlignRight().Height(70).Image(logoPath, ImageScaling.FitArea);
                        col.Item().Height(20);
                        col.Item().AlignRight().Text("Pyro-Fêtes").SemiBold();
                        col.Item().Height(5);
                        col.Item().AlignRight().Text("24, rue La Fosse Mardeau\n41700 Le Controis-en-Sologne");
                        col.Item().Height(5);
                        col.Item().AlignRight().Text("Téléphone: 02 54 78 77 66");
                        col.Item().Height(5);
                        col.Item().AlignRight().Text("SIRET: 82031463100012");
                        col.Item().Height(40);
                    });
                });

                page.Content().Column(col =>
                {
                    // Titre + date
                    col.Item().Row(row =>
                    {
                        row.RelativeItem().Text($"Bon de livraison n° {deliveryNote.TrackingNumber}")
                            .FontSize(16).SemiBold();
                    });
                    col.Item().Height(20);

                    col.Item().LineHorizontal(1);

                    // Tableau des lignes
                    col.Item().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn(4);  // Produit
                            columns.RelativeColumn(2);  // Qté
                            columns.RelativeColumn(2);  // PU
                            columns.RelativeColumn(2);  // Total
                        });

                        // En-têtes
                        table.Header(header =>
                        {
                            header.Cell().Element(CellHeader).Text("Produit");
                            header.Cell().Element(CellHeader).AlignRight().Text("Qté");
                            header.Cell().Element(CellHeader).AlignRight().Text("PU");
                            header.Cell().Element(CellHeader).AlignRight().Text("Total");
                        });
                        
                        foreach (var l in lignes)
                        {
                            table.Cell().Element(CellBody).Text(l.Product?.Name);
                            table.Cell().Element(CellBody).AlignRight().Text(l.Quantity.ToString());
                            table.Cell().Element(CellBody).AlignRight().Text($"{l.Quantity:n2} €");
                            table.Cell().Element(CellBody).AlignRight().Text($"{l.Quantity * l.Quantity:n2} €");
                            
                            totalQuantity += l.Quantity;
                            total  += l.Quantity * l.Quantity;
                        }

                        IContainer CellHeader(IContainer c) =>
                            c.BorderBottom(1).PaddingVertical(5).DefaultTextStyle(x => x.SemiBold());

                        IContainer CellBody(IContainer c) =>
                            c.PaddingVertical(2);
                    });

                    col.Item().LineHorizontal(1);
                    col.Item().Height(30);

                    col.Item().AlignRight().Text($"Total: {totalQuantity:n2} produits");
                    col.Item().AlignRight().Text($"Total HT: {total:n2} €");
                    col.Item().AlignRight().Text("Taxe : 20 %");
                    col.Item().AlignRight().Text($"Total TTC: {(total * 1.2):n2} €");
                });

                // Signature en bas à droite
                page.Footer().AlignRight().Column(col =>
                {
                    col.Item().AlignRight().Height(100).Image(signaturePath, ImageScaling.FitArea);
                });
            });
        });

        return document.GeneratePdf();
    }
}
