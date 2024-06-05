using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class fixerrors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "College",
                table: "Departments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "College",
                table: "Departments");
        }
    }
}
