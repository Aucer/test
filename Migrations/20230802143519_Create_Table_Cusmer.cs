using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test.Migrations
{
    /// <inheritdoc />
    public partial class Create_Table_Cusmer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.AddColumn<string>(
                name: "CusmerID",
                table: "Person1",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CusmerName",
                table: "Person1",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Person1",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CusmerID",
                table: "Person1");

            migrationBuilder.DropColumn(
                name: "CusmerName",
                table: "Person1");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Person1");

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    PersonID = table.Column<string>(type: "TEXT", nullable: false),
                    StudentID = table.Column<string>(type: "TEXT", nullable: false),
                    StudentName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.PersonID);
                    table.ForeignKey(
                        name: "FK_Student_Person1_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Person1",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
