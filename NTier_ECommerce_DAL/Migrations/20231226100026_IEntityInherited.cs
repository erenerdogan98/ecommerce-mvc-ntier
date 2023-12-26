using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NTier_ECommerce_DAL.Migrations
{
    /// <inheritdoc />
    public partial class IEntityInherited : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MyProperty",
                table: "Producers",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "CategoryMovie",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryMovie",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Producers",
                newName: "MyProperty");
        }
    }
}
