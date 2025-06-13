using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FamilyTreeAPI.Migrations
{
    /// <inheritdoc />
    public partial class createmoretables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Creators",
                newName: "LastUpdatedAt");

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Creators",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Creators");

            migrationBuilder.RenameColumn(
                name: "LastUpdatedAt",
                table: "Creators",
                newName: "UpdatedAt");
        }
    }
}
