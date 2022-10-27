using Microsoft.EntityFrameworkCore.Migrations;

namespace SystemManagement.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Pallets",
                table: "Pallets");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Pallets");

            migrationBuilder.AddColumn<int>(
                name: "PalletId",
                table: "Pallets",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "LpnId",
                table: "Pallets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pallets",
                table: "Pallets",
                column: "PalletId");

            migrationBuilder.CreateTable(
                name: "Node",
                columns: table => new
                {
                    NodeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Node", x => x.NodeId);
                });

            migrationBuilder.CreateTable(
                name: "Lpn",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NodeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lpn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lpn_Node_NodeId",
                        column: x => x.NodeId,
                        principalTable: "Node",
                        principalColumn: "NodeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pallets_LpnId",
                table: "Pallets",
                column: "LpnId");

            migrationBuilder.CreateIndex(
                name: "IX_Lpn_NodeId",
                table: "Lpn",
                column: "NodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pallets_Lpn_LpnId",
                table: "Pallets",
                column: "LpnId",
                principalTable: "Lpn",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pallets_Lpn_LpnId",
                table: "Pallets");

            migrationBuilder.DropTable(
                name: "Lpn");

            migrationBuilder.DropTable(
                name: "Node");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pallets",
                table: "Pallets");

            migrationBuilder.DropIndex(
                name: "IX_Pallets_LpnId",
                table: "Pallets");

            migrationBuilder.DropColumn(
                name: "PalletId",
                table: "Pallets");

            migrationBuilder.DropColumn(
                name: "LpnId",
                table: "Pallets");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Pallets",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pallets",
                table: "Pallets",
                column: "Id");
        }
    }
}
