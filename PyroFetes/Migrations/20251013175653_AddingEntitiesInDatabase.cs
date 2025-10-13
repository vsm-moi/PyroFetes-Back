using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PyroFetes.Migrations
{
    /// <inheritdoc />
    public partial class AddingEntitiesInDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactServiceProvider_Contacts_ContactId",
                table: "ContactServiceProvider");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactServiceProvider_Providers_ServiceProviderId",
                table: "ContactServiceProvider");

            migrationBuilder.DropForeignKey(
                name: "FK_Contract_Providers_ServiceProviderId",
                table: "Contract");

            migrationBuilder.DropForeignKey(
                name: "FK_Contract_Shows_ShowId",
                table: "Contract");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialWarehouse_Materials_MaterialId",
                table: "MaterialWarehouse");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialWarehouse_Warehouses_WarehouseId",
                table: "MaterialWarehouse");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTimecode_Products_ProductId",
                table: "ProductTimecode");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTimecode_Shows_ShowId",
                table: "ProductTimecode");

            migrationBuilder.DropForeignKey(
                name: "FK_ProviderContacts_Providers_ProviderId",
                table: "ProviderContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Providers_ProviderTypes_ProviderTypeId",
                table: "Providers");

            migrationBuilder.DropForeignKey(
                name: "FK_ShowMaterial_Materials_MaterialId",
                table: "ShowMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_ShowMaterial_Shows_ShowId",
                table: "ShowMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_Shows_City_CityId",
                table: "Shows");

            migrationBuilder.DropForeignKey(
                name: "FK_ShowStaff_Shows_ShowId",
                table: "ShowStaff");

            migrationBuilder.DropForeignKey(
                name: "FK_ShowStaff_Staffs_StaffId",
                table: "ShowStaff");

            migrationBuilder.DropForeignKey(
                name: "FK_ShowTruck_Shows_ShowId",
                table: "ShowTruck");

            migrationBuilder.DropForeignKey(
                name: "FK_ShowTruck_Trucks_TruckId",
                table: "ShowTruck");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShowTruck",
                table: "ShowTruck");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShowStaff",
                table: "ShowStaff");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShowMaterial",
                table: "ShowMaterial");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Providers",
                table: "Providers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductTimecode",
                table: "ProductTimecode");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MaterialWarehouse",
                table: "MaterialWarehouse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contract",
                table: "Contract");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactServiceProvider",
                table: "ContactServiceProvider");

            migrationBuilder.DropPrimaryKey(
                name: "PK_City",
                table: "City");

            migrationBuilder.RenameTable(
                name: "ShowTruck",
                newName: "ShowTrucks");

            migrationBuilder.RenameTable(
                name: "ShowStaff",
                newName: "ShowStaffs");

            migrationBuilder.RenameTable(
                name: "ShowMaterial",
                newName: "ShowMaterials");

            migrationBuilder.RenameTable(
                name: "Providers",
                newName: "ServiceProviders");

            migrationBuilder.RenameTable(
                name: "ProductTimecode",
                newName: "ProductTimecodes");

            migrationBuilder.RenameTable(
                name: "MaterialWarehouse",
                newName: "MaterialWarehouses");

            migrationBuilder.RenameTable(
                name: "Contract",
                newName: "Contracts");

            migrationBuilder.RenameTable(
                name: "ContactServiceProvider",
                newName: "ContactServiceProviders");

            migrationBuilder.RenameTable(
                name: "City",
                newName: "Cities");

            migrationBuilder.RenameIndex(
                name: "IX_ShowTruck_TruckId",
                table: "ShowTrucks",
                newName: "IX_ShowTrucks_TruckId");

            migrationBuilder.RenameIndex(
                name: "IX_ShowStaff_ShowId",
                table: "ShowStaffs",
                newName: "IX_ShowStaffs_ShowId");

            migrationBuilder.RenameIndex(
                name: "IX_ShowMaterial_MaterialId",
                table: "ShowMaterials",
                newName: "IX_ShowMaterials_MaterialId");

            migrationBuilder.RenameIndex(
                name: "IX_Providers_ProviderTypeId",
                table: "ServiceProviders",
                newName: "IX_ServiceProviders_ProviderTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductTimecode_ShowId",
                table: "ProductTimecodes",
                newName: "IX_ProductTimecodes_ShowId");

            migrationBuilder.RenameIndex(
                name: "IX_MaterialWarehouse_WarehouseId",
                table: "MaterialWarehouses",
                newName: "IX_MaterialWarehouses_WarehouseId");

            migrationBuilder.RenameIndex(
                name: "IX_Contract_ServiceProviderId",
                table: "Contracts",
                newName: "IX_Contracts_ServiceProviderId");

            migrationBuilder.RenameIndex(
                name: "IX_ContactServiceProvider_ServiceProviderId",
                table: "ContactServiceProviders",
                newName: "IX_ContactServiceProviders_ServiceProviderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShowTrucks",
                table: "ShowTrucks",
                columns: new[] { "ShowId", "TruckId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShowStaffs",
                table: "ShowStaffs",
                columns: new[] { "StaffId", "ShowId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShowMaterials",
                table: "ShowMaterials",
                columns: new[] { "ShowId", "MaterialId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceProviders",
                table: "ServiceProviders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductTimecodes",
                table: "ProductTimecodes",
                columns: new[] { "ProductId", "ShowId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MaterialWarehouses",
                table: "MaterialWarehouses",
                columns: new[] { "MaterialId", "WarehouseId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contracts",
                table: "Contracts",
                columns: new[] { "ShowId", "ServiceProviderId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactServiceProviders",
                table: "ContactServiceProviders",
                columns: new[] { "ContactId", "ServiceProviderId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cities",
                table: "Cities",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ShowServiceProviders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowServiceProviders", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ContactServiceProviders_Contacts_ContactId",
                table: "ContactServiceProviders",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactServiceProviders_ServiceProviders_ServiceProviderId",
                table: "ContactServiceProviders",
                column: "ServiceProviderId",
                principalTable: "ServiceProviders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_ServiceProviders_ServiceProviderId",
                table: "Contracts",
                column: "ServiceProviderId",
                principalTable: "ServiceProviders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Shows_ShowId",
                table: "Contracts",
                column: "ShowId",
                principalTable: "Shows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialWarehouses_Materials_MaterialId",
                table: "MaterialWarehouses",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialWarehouses_Warehouses_WarehouseId",
                table: "MaterialWarehouses",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTimecodes_Products_ProductId",
                table: "ProductTimecodes",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTimecodes_Shows_ShowId",
                table: "ProductTimecodes",
                column: "ShowId",
                principalTable: "Shows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProviderContacts_ServiceProviders_ProviderId",
                table: "ProviderContacts",
                column: "ProviderId",
                principalTable: "ServiceProviders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceProviders_ProviderTypes_ProviderTypeId",
                table: "ServiceProviders",
                column: "ProviderTypeId",
                principalTable: "ProviderTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShowMaterials_Materials_MaterialId",
                table: "ShowMaterials",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShowMaterials_Shows_ShowId",
                table: "ShowMaterials",
                column: "ShowId",
                principalTable: "Shows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shows_Cities_CityId",
                table: "Shows",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShowStaffs_Shows_ShowId",
                table: "ShowStaffs",
                column: "ShowId",
                principalTable: "Shows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShowStaffs_Staffs_StaffId",
                table: "ShowStaffs",
                column: "StaffId",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShowTrucks_Shows_ShowId",
                table: "ShowTrucks",
                column: "ShowId",
                principalTable: "Shows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShowTrucks_Trucks_TruckId",
                table: "ShowTrucks",
                column: "TruckId",
                principalTable: "Trucks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactServiceProviders_Contacts_ContactId",
                table: "ContactServiceProviders");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactServiceProviders_ServiceProviders_ServiceProviderId",
                table: "ContactServiceProviders");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_ServiceProviders_ServiceProviderId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Shows_ShowId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialWarehouses_Materials_MaterialId",
                table: "MaterialWarehouses");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialWarehouses_Warehouses_WarehouseId",
                table: "MaterialWarehouses");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTimecodes_Products_ProductId",
                table: "ProductTimecodes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTimecodes_Shows_ShowId",
                table: "ProductTimecodes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProviderContacts_ServiceProviders_ProviderId",
                table: "ProviderContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceProviders_ProviderTypes_ProviderTypeId",
                table: "ServiceProviders");

            migrationBuilder.DropForeignKey(
                name: "FK_ShowMaterials_Materials_MaterialId",
                table: "ShowMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_ShowMaterials_Shows_ShowId",
                table: "ShowMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_Shows_Cities_CityId",
                table: "Shows");

            migrationBuilder.DropForeignKey(
                name: "FK_ShowStaffs_Shows_ShowId",
                table: "ShowStaffs");

            migrationBuilder.DropForeignKey(
                name: "FK_ShowStaffs_Staffs_StaffId",
                table: "ShowStaffs");

            migrationBuilder.DropForeignKey(
                name: "FK_ShowTrucks_Shows_ShowId",
                table: "ShowTrucks");

            migrationBuilder.DropForeignKey(
                name: "FK_ShowTrucks_Trucks_TruckId",
                table: "ShowTrucks");

            migrationBuilder.DropTable(
                name: "ShowServiceProviders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShowTrucks",
                table: "ShowTrucks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShowStaffs",
                table: "ShowStaffs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShowMaterials",
                table: "ShowMaterials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceProviders",
                table: "ServiceProviders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductTimecodes",
                table: "ProductTimecodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MaterialWarehouses",
                table: "MaterialWarehouses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contracts",
                table: "Contracts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactServiceProviders",
                table: "ContactServiceProviders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cities",
                table: "Cities");

            migrationBuilder.RenameTable(
                name: "ShowTrucks",
                newName: "ShowTruck");

            migrationBuilder.RenameTable(
                name: "ShowStaffs",
                newName: "ShowStaff");

            migrationBuilder.RenameTable(
                name: "ShowMaterials",
                newName: "ShowMaterial");

            migrationBuilder.RenameTable(
                name: "ServiceProviders",
                newName: "Providers");

            migrationBuilder.RenameTable(
                name: "ProductTimecodes",
                newName: "ProductTimecode");

            migrationBuilder.RenameTable(
                name: "MaterialWarehouses",
                newName: "MaterialWarehouse");

            migrationBuilder.RenameTable(
                name: "Contracts",
                newName: "Contract");

            migrationBuilder.RenameTable(
                name: "ContactServiceProviders",
                newName: "ContactServiceProvider");

            migrationBuilder.RenameTable(
                name: "Cities",
                newName: "City");

            migrationBuilder.RenameIndex(
                name: "IX_ShowTrucks_TruckId",
                table: "ShowTruck",
                newName: "IX_ShowTruck_TruckId");

            migrationBuilder.RenameIndex(
                name: "IX_ShowStaffs_ShowId",
                table: "ShowStaff",
                newName: "IX_ShowStaff_ShowId");

            migrationBuilder.RenameIndex(
                name: "IX_ShowMaterials_MaterialId",
                table: "ShowMaterial",
                newName: "IX_ShowMaterial_MaterialId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceProviders_ProviderTypeId",
                table: "Providers",
                newName: "IX_Providers_ProviderTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductTimecodes_ShowId",
                table: "ProductTimecode",
                newName: "IX_ProductTimecode_ShowId");

            migrationBuilder.RenameIndex(
                name: "IX_MaterialWarehouses_WarehouseId",
                table: "MaterialWarehouse",
                newName: "IX_MaterialWarehouse_WarehouseId");

            migrationBuilder.RenameIndex(
                name: "IX_Contracts_ServiceProviderId",
                table: "Contract",
                newName: "IX_Contract_ServiceProviderId");

            migrationBuilder.RenameIndex(
                name: "IX_ContactServiceProviders_ServiceProviderId",
                table: "ContactServiceProvider",
                newName: "IX_ContactServiceProvider_ServiceProviderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShowTruck",
                table: "ShowTruck",
                columns: new[] { "ShowId", "TruckId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShowStaff",
                table: "ShowStaff",
                columns: new[] { "StaffId", "ShowId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShowMaterial",
                table: "ShowMaterial",
                columns: new[] { "ShowId", "MaterialId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Providers",
                table: "Providers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductTimecode",
                table: "ProductTimecode",
                columns: new[] { "ProductId", "ShowId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MaterialWarehouse",
                table: "MaterialWarehouse",
                columns: new[] { "MaterialId", "WarehouseId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contract",
                table: "Contract",
                columns: new[] { "ShowId", "ServiceProviderId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactServiceProvider",
                table: "ContactServiceProvider",
                columns: new[] { "ContactId", "ServiceProviderId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_City",
                table: "City",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactServiceProvider_Contacts_ContactId",
                table: "ContactServiceProvider",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactServiceProvider_Providers_ServiceProviderId",
                table: "ContactServiceProvider",
                column: "ServiceProviderId",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_Providers_ServiceProviderId",
                table: "Contract",
                column: "ServiceProviderId",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_Shows_ShowId",
                table: "Contract",
                column: "ShowId",
                principalTable: "Shows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialWarehouse_Materials_MaterialId",
                table: "MaterialWarehouse",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialWarehouse_Warehouses_WarehouseId",
                table: "MaterialWarehouse",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTimecode_Products_ProductId",
                table: "ProductTimecode",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTimecode_Shows_ShowId",
                table: "ProductTimecode",
                column: "ShowId",
                principalTable: "Shows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProviderContacts_Providers_ProviderId",
                table: "ProviderContacts",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Providers_ProviderTypes_ProviderTypeId",
                table: "Providers",
                column: "ProviderTypeId",
                principalTable: "ProviderTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShowMaterial_Materials_MaterialId",
                table: "ShowMaterial",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShowMaterial_Shows_ShowId",
                table: "ShowMaterial",
                column: "ShowId",
                principalTable: "Shows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shows_City_CityId",
                table: "Shows",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShowStaff_Shows_ShowId",
                table: "ShowStaff",
                column: "ShowId",
                principalTable: "Shows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShowStaff_Staffs_StaffId",
                table: "ShowStaff",
                column: "StaffId",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShowTruck_Shows_ShowId",
                table: "ShowTruck",
                column: "ShowId",
                principalTable: "Shows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShowTruck_Trucks_TruckId",
                table: "ShowTruck",
                column: "TruckId",
                principalTable: "Trucks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
