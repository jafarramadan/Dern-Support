using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dern_Support.Migrations
{
    /// <inheritdoc />
    public partial class CustomerName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "status",
                table: "SupportRequests",
                newName: "Status");

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "SupportRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "245c50ea-c499-4201-af8c-b63a791c160d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "0111f3b5-3819-49f9-9d84-7d971454bb89");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "SupportRequests");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "SupportRequests",
                newName: "status");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "2d9261e5-af24-4379-9386-5b682f093daa");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "ca00758c-c705-40e1-92a8-e63316da02a9");
        }
    }
}
