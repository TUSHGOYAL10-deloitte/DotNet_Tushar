using Microsoft.EntityFrameworkCore.Migrations;

namespace SystemManagement.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lpn_Node_NodeId",
                table: "Lpn");

            migrationBuilder.DropForeignKey(
                name: "FK_Pallets_Lpn_LpnId",
                table: "Pallets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Node",
                table: "Node");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lpn",
                table: "Lpn");

            migrationBuilder.RenameTable(
                name: "Node",
                newName: "Nodes");

            migrationBuilder.RenameTable(
                name: "Lpn",
                newName: "Lpns");

            migrationBuilder.RenameIndex(
                name: "IX_Lpn_NodeId",
                table: "Lpns",
                newName: "IX_Lpns_NodeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Nodes",
                table: "Nodes",
                column: "NodeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lpns",
                table: "Lpns",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "WareHouses",
                columns: table => new
                {
                    WareHouseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: false),
                    NodeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WareHouses", x => x.WareHouseId);
                    table.ForeignKey(
                        name: "FK_WareHouses_Nodes_NodeId",
                        column: x => x.NodeId,
                        principalTable: "Nodes",
                        principalColumn: "NodeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WareHouses_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WareHouses_NodeId",
                table: "WareHouses",
                column: "NodeId");

            migrationBuilder.CreateIndex(
                name: "IX_WareHouses_ProductId",
                table: "WareHouses",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lpns_Nodes_NodeId",
                table: "Lpns",
                column: "NodeId",
                principalTable: "Nodes",
                principalColumn: "NodeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pallets_Lpns_LpnId",
                table: "Pallets",
                column: "LpnId",
                principalTable: "Lpns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lpns_Nodes_NodeId",
                table: "Lpns");

            migrationBuilder.DropForeignKey(
                name: "FK_Pallets_Lpns_LpnId",
                table: "Pallets");

            migrationBuilder.DropTable(
                name: "WareHouses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Nodes",
                table: "Nodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lpns",
                table: "Lpns");

            migrationBuilder.RenameTable(
                name: "Nodes",
                newName: "Node");

            migrationBuilder.RenameTable(
                name: "Lpns",
                newName: "Lpn");

            migrationBuilder.RenameIndex(
                name: "IX_Lpns_NodeId",
                table: "Lpn",
                newName: "IX_Lpn_NodeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Node",
                table: "Node",
                column: "NodeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lpn",
                table: "Lpn",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lpn_Node_NodeId",
                table: "Lpn",
                column: "NodeId",
                principalTable: "Node",
                principalColumn: "NodeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pallets_Lpn_LpnId",
                table: "Pallets",
                column: "LpnId",
                principalTable: "Lpn",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
