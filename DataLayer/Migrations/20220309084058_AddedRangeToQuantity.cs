using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class AddedRangeToQuantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProductQuantity_Orders_OrderID",
                table: "OrderProductQuantity");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProductQuantity_Products_ProductBarcode",
                table: "OrderProductQuantity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderProductQuantity",
                table: "OrderProductQuantity");

            migrationBuilder.RenameTable(
                name: "OrderProductQuantity",
                newName: "OPQs");

            migrationBuilder.RenameIndex(
                name: "IX_OrderProductQuantity_ProductBarcode",
                table: "OPQs",
                newName: "IX_OPQs_ProductBarcode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OPQs",
                table: "OPQs",
                columns: new[] { "OrderID", "ProductBarcode" });

            migrationBuilder.AddForeignKey(
                name: "FK_OPQs_Orders_OrderID",
                table: "OPQs",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OPQs_Products_ProductBarcode",
                table: "OPQs",
                column: "ProductBarcode",
                principalTable: "Products",
                principalColumn: "Barcode",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OPQs_Orders_OrderID",
                table: "OPQs");

            migrationBuilder.DropForeignKey(
                name: "FK_OPQs_Products_ProductBarcode",
                table: "OPQs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OPQs",
                table: "OPQs");

            migrationBuilder.RenameTable(
                name: "OPQs",
                newName: "OrderProductQuantity");

            migrationBuilder.RenameIndex(
                name: "IX_OPQs_ProductBarcode",
                table: "OrderProductQuantity",
                newName: "IX_OrderProductQuantity_ProductBarcode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderProductQuantity",
                table: "OrderProductQuantity",
                columns: new[] { "OrderID", "ProductBarcode" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProductQuantity_Orders_OrderID",
                table: "OrderProductQuantity",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProductQuantity_Products_ProductBarcode",
                table: "OrderProductQuantity",
                column: "ProductBarcode",
                principalTable: "Products",
                principalColumn: "Barcode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
