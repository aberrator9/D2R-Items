using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace D2RItems.Migrations
{
    /// <inheritdoc />
    public partial class ArmorsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Weapon",
                table: "Weapon");

            migrationBuilder.RenameTable(
                name: "Weapon",
                newName: "Armor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Armor",
                table: "Armor",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Armors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slot = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sockets = table.Column<int>(type: "int", nullable: false),
                    Class = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    ReqStr = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armors", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Armors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Armor",
                table: "Armor");

            migrationBuilder.RenameTable(
                name: "Armor",
                newName: "Weapon");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Weapon",
                table: "Weapon",
                column: "Id");
        }
    }
}
