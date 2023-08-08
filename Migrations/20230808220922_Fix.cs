using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace D2RItems.Migrations
{
    /// <inheritdoc />
    public partial class Fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Armors");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Armor",
                newName: "Slot");

            migrationBuilder.RenameColumn(
                name: "TwoHandDmg",
                table: "Armor",
                newName: "Weight");

            migrationBuilder.RenameColumn(
                name: "Speed",
                table: "Armor",
                newName: "ReqStr");

            migrationBuilder.RenameColumn(
                name: "OneHandDmg",
                table: "Armor",
                newName: "Class");

            migrationBuilder.CreateTable(
                name: "Weapon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sockets = table.Column<int>(type: "int", nullable: false),
                    OneHandDmg = table.Column<int>(type: "int", nullable: false),
                    TwoHandDmg = table.Column<int>(type: "int", nullable: false),
                    Speed = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapon", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Weapon");

            migrationBuilder.RenameColumn(
                name: "Weight",
                table: "Armor",
                newName: "TwoHandDmg");

            migrationBuilder.RenameColumn(
                name: "Slot",
                table: "Armor",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "ReqStr",
                table: "Armor",
                newName: "Speed");

            migrationBuilder.RenameColumn(
                name: "Class",
                table: "Armor",
                newName: "OneHandDmg");

            migrationBuilder.CreateTable(
                name: "Armors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Class = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReqStr = table.Column<int>(type: "int", nullable: false),
                    Slot = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sockets = table.Column<int>(type: "int", nullable: false),
                    Tier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armors", x => x.Id);
                });
        }
    }
}
