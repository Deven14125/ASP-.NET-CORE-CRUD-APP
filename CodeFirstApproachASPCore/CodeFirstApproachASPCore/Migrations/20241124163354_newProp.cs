using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFirstApproachASPCore.Migrations
{
    /// <inheritdoc />
    public partial class newProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Age",
                table: "Students",
                newName: "RollNo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RollNo",
                table: "Students",
                newName: "Age");
        }
    }
}
