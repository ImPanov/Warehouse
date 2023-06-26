using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Warehouse.Common.DataContext.Sqlite.Migrations
{
    /// <inheritdoc />
    public partial class reception : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Recipient",
                table: "ExpenceItem",
                newName: "Recepient");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Recepient",
                table: "ExpenceItem",
                newName: "Recipient");
        }
    }
}
