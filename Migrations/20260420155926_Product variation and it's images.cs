using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceApp.Migrations
{
    /// <inheritdoc />
    public partial class Productvariationanditsimages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Inv");

            migrationBuilder.CreateTable(
                name: "tblOpeningQuantity",
                schema: "Inv",
                columns: table => new
                {
                    OpeningQuantityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: true),
                    AccClassID = table.Column<int>(type: "int", nullable: true),
                    PurchaseQty = table.Column<double>(type: "float", nullable: true),
                    QuantityDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PurchaseRate = table.Column<decimal>(type: "money", nullable: true),
                    SalesRate = table.Column<decimal>(type: "money", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOpeningQuantity", x => x.OpeningQuantityID);
                    table.ForeignKey(
                        name: "FK_tblOpeningQuantity_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tblOpeningQtyProductVariation",
                schema: "Inv",
                columns: table => new
                {
                    OpeningQtyProductVariationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OpeningQtyID = table.Column<int>(type: "int", nullable: true),
                    ProductVariationDetailsID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOpeningQtyProductVariation", x => x.OpeningQtyProductVariationID);
                    table.ForeignKey(
                        name: "FK_tblOpeningQtyProductVariation_ProductVariationDetails_ProductVariationDetailsID",
                        column: x => x.ProductVariationDetailsID,
                        principalTable: "ProductVariationDetails",
                        principalColumn: "ProductVariationDetailsID");
                    table.ForeignKey(
                        name: "FK_tblOpeningQtyProductVariation_tblOpeningQuantity_OpeningQtyID",
                        column: x => x.OpeningQtyID,
                        principalSchema: "Inv",
                        principalTable: "tblOpeningQuantity",
                        principalColumn: "OpeningQuantityID");
                });

            migrationBuilder.CreateTable(
                name: "tblOpeningQuantityImage",
                schema: "Inv",
                columns: table => new
                {
                    ProductOpeningQuantityImageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OpeningQuantityID = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ImageType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOpeningQuantityImage", x => x.ProductOpeningQuantityImageID);
                    table.ForeignKey(
                        name: "FK_tblOpeningQuantityImage_tblOpeningQuantity_OpeningQuantityID",
                        column: x => x.OpeningQuantityID,
                        principalSchema: "Inv",
                        principalTable: "tblOpeningQuantity",
                        principalColumn: "OpeningQuantityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblOpeningQtyProductVariation_OpeningQtyID",
                schema: "Inv",
                table: "tblOpeningQtyProductVariation",
                column: "OpeningQtyID");

            migrationBuilder.CreateIndex(
                name: "IX_tblOpeningQtyProductVariation_ProductVariationDetailsID",
                schema: "Inv",
                table: "tblOpeningQtyProductVariation",
                column: "ProductVariationDetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_tblOpeningQuantity_ProductID",
                schema: "Inv",
                table: "tblOpeningQuantity",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_tblOpeningQuantityImage_FileName",
                schema: "Inv",
                table: "tblOpeningQuantityImage",
                column: "FileName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblOpeningQuantityImage_OpeningQuantityID",
                schema: "Inv",
                table: "tblOpeningQuantityImage",
                column: "OpeningQuantityID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblOpeningQtyProductVariation",
                schema: "Inv");

            migrationBuilder.DropTable(
                name: "tblOpeningQuantityImage",
                schema: "Inv");

            migrationBuilder.DropTable(
                name: "tblOpeningQuantity",
                schema: "Inv");
        }
    }
}
