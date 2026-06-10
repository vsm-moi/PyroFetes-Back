using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PyroFetes.Migrations
{
    /// <inheritdoc />
    public partial class AddedInvoiceInDatabaseBis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Quotations_QuotationId",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceProduct_Invoice_InvoiceId",
                table: "InvoiceProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceProduct_Products_ProductId",
                table: "InvoiceProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InvoiceProduct",
                table: "InvoiceProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invoice",
                table: "Invoice");

            migrationBuilder.RenameTable(
                name: "InvoiceProduct",
                newName: "InvoiceProducts");

            migrationBuilder.RenameTable(
                name: "Invoice",
                newName: "Invoices");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceProduct_InvoiceId",
                table: "InvoiceProducts",
                newName: "IX_InvoiceProducts_InvoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoice_QuotationId",
                table: "Invoices",
                newName: "IX_Invoices_QuotationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvoiceProducts",
                table: "InvoiceProducts",
                columns: new[] { "ProductId", "InvoiceId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invoices",
                table: "Invoices",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceProducts_Invoices_InvoiceId",
                table: "InvoiceProducts",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceProducts_Products_ProductId",
                table: "InvoiceProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Quotations_QuotationId",
                table: "Invoices",
                column: "QuotationId",
                principalTable: "Quotations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceProducts_Invoices_InvoiceId",
                table: "InvoiceProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceProducts_Products_ProductId",
                table: "InvoiceProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Quotations_QuotationId",
                table: "Invoices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invoices",
                table: "Invoices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InvoiceProducts",
                table: "InvoiceProducts");

            migrationBuilder.RenameTable(
                name: "Invoices",
                newName: "Invoice");

            migrationBuilder.RenameTable(
                name: "InvoiceProducts",
                newName: "InvoiceProduct");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_QuotationId",
                table: "Invoice",
                newName: "IX_Invoice_QuotationId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceProducts_InvoiceId",
                table: "InvoiceProduct",
                newName: "IX_InvoiceProduct_InvoiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invoice",
                table: "Invoice",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvoiceProduct",
                table: "InvoiceProduct",
                columns: new[] { "ProductId", "InvoiceId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Quotations_QuotationId",
                table: "Invoice",
                column: "QuotationId",
                principalTable: "Quotations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceProduct_Invoice_InvoiceId",
                table: "InvoiceProduct",
                column: "InvoiceId",
                principalTable: "Invoice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceProduct_Products_ProductId",
                table: "InvoiceProduct",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
