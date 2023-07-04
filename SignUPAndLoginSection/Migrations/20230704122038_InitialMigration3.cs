using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignUPAndLoginSection.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "playerTable",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    first_name = table.Column<string>(type: "TEXT", nullable: false),
                    now_cost = table.Column<double>(type: "REAL", nullable: false),
                    second_name = table.Column<string>(type: "TEXT", nullable: false),
                    team = table.Column<int>(type: "INTEGER", nullable: false),
                    element_type = table.Column<int>(type: "INTEGER", nullable: false),
                    total_points = table.Column<double>(type: "REAL", nullable: false),
                    photo = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_playerTable", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "userTable",
                columns: table => new
                {
                    userId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    password = table.Column<string>(type: "TEXT", nullable: false),
                    fullName = table.Column<string>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: false),
                    mobilePhone = table.Column<string>(type: "TEXT", nullable: false),
                    userName = table.Column<string>(type: "TEXT", nullable: false),
                    OTPCode = table.Column<string>(type: "TEXT", nullable: false),
                    isvalid = table.Column<bool>(type: "INTEGER", nullable: false),
                    cash = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userTable", x => x.userId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "playerTable");

            migrationBuilder.DropTable(
                name: "userTable");
        }
    }
}
