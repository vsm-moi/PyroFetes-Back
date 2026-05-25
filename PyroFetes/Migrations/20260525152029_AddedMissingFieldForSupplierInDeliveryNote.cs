using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PyroFetes.Migrations
{
    /// <inheritdoc />
    public partial class AddedMissingFieldForSupplierInDeliveryNote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "DeliveryNotes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryNotes_SupplierId",
                table: "DeliveryNotes",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryNotes_Suppliers_SupplierId",
                table: "DeliveryNotes",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryNotes_Suppliers_SupplierId",
                table: "DeliveryNotes");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryNotes_SupplierId",
                table: "DeliveryNotes");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "DeliveryNotes");
        }
    }
}
