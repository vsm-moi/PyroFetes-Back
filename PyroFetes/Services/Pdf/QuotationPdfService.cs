using PyroFetes.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace PyroFetes.Services.Pdf;

public interface IQuotationPdfService
{
    byte[] Generate(Quotation quotation, List<QuotationProduct> lignes, Setting setting);
}

public class QuotationPdfService : IQuotationPdfService
{
    public byte[] Generate(Quotation quotation, List<QuotationProduct> lignes, Setting setting)
    {
        byte[] logo = Convert.FromBase64String(setting.Logo!);
        byte[] signature = Convert.FromBase64String(setting.ElectronicSignature!);
        decimal total = 0;
        Document document = Document.Create(container =>
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
                        col.Item().Text("Client").SemiBold().FontSize(12);
                        col.Item().Text($"{quotation.Customer?.Note}");
                        col.Item().Text($"{quotation.Customer?.CustomerType?.Label}");
                    });

                    // Logo + société à droite
                    row.ConstantItem(200).Column(col =>
                    {
                        col.Item().AlignRight().Height(70).Image(logo, ImageScaling.FitArea);
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
                        row.RelativeItem().Text($"Devis n° {quotation.Id}")
                            .FontSize(16).SemiBold();

                        row.ConstantItem(200).AlignRight().Text(
                            $"Le {DateTime.Now:dd/MM/yyyy}");
                    });
                    col.Item().Height(20);

                    col.Item().LineHorizontal(1);

                    // Tableau des lignes
                    col.Item().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn(10); // Produit
                            columns.RelativeColumn(2); // Qté
                            columns.RelativeColumn(3); // PU
                            columns.RelativeColumn(3); // Total
                        });

                        // En-têtes
                        table.Header(header =>
                        {
                            header.Cell().Element(CellHeader).Text("Produit");
                            header.Cell().Element(CellHeader).AlignRight().Text("Qté");
                            header.Cell().Element(CellHeader).AlignRight().Text("PU");
                            header.Cell().Element(CellHeader).AlignRight().Text("Total");
                        });

                        foreach (QuotationProduct l in lignes)
                        {
                            decimal price = l.Product!.Prices!
                                .FirstOrDefault(x => x.SupplierId == l.Quotation!.SupplierId && x.ProductId == l.ProductId)
                                ?.SellingPrice ?? 0;

                            table.Cell().Element(CellBody).Text(l.Product?.Name);
                            table.Cell().Element(CellBody).AlignRight().Text(l.Quantity.ToString());
                            table.Cell().Element(CellBody).AlignRight().Text($"{price:n2} €");
                            table.Cell().Element(CellBody).AlignRight().Text($"{price * l.Quantity:n2} €");

                            total += l.Quantity * price;
                        }

                        IContainer CellHeader(IContainer c) => c.BorderBottom(1).PaddingVertical(5).DefaultTextStyle(x => x.SemiBold());

                        IContainer CellBody(IContainer c) => c.PaddingVertical(2);
                    });

                    col.Item().LineHorizontal(1);
                    col.Item().Height(30);

                    col.Item().Row(row =>
                    {
                        // Colonne gauche : conditions de vente
                        row.RelativeItem().Column(left =>
                        {
                            left.Item().Text("Conditions de vente")
                                .SemiBold().FontSize(12);
                            left.Item().Text(quotation.ConditionsSale)
                                .FontSize(9);
                        });

                        // Colonne droite : totaux
                        row.ConstantItem(180).Column(right =>
                        {
                            right.Item().AlignRight().Text($"Total HT : {total:n2} €");
                            right.Item().AlignRight().Text("Taxe : 20 %");
                            right.Item().AlignRight().Text($"Total TTC : {total * (decimal)1.2:n2} €");
                        });
                    });
                });

                // Signature en bas à droite
                page.Footer().AlignRight().Column(col => { col.Item().AlignRight().Height(100).Image(signature, ImageScaling.FitArea); });
            });
        });

        // Pour avoir la vue du PDF en temps réel
        // document.ShowInCompanion();

        return document.GeneratePdf();
    }
}