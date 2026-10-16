using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Scope_India.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddTestimonialDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Company",
                table: "Testimonials",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "Testimonials",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Testimonials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Testimonials",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Company",
                table: "Testimonials");

            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "Testimonials");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Testimonials");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Testimonials");
        }
    }
}
