using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Dern_Support.Migrations
{
    /// <inheritdoc />
    public partial class seedKBA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "9ab7490a-43f6-43f4-8e03-7c2f3b60e781");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "4238bb97-16bc-4f3c-b01b-14713c98bdf0");

            migrationBuilder.InsertData(
                table: "KnowledgeBaseArticles",
                columns: new[] { "Id", "Content", "PublishedDate", "Title" },
                values: new object[,]
                {
                    { 1, "If your printer is not working properly, follow these steps: 1. Check the printer's connection to your computer. 2. Ensure that the printer has enough paper and ink. 3. Restart both your computer and printer. If these steps do not resolve the issue, consult the printer's manual or contact support.", new DateTime(2024, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "How to Fix Common Printer Issues" },
                    { 2, "To troubleshoot internet connectivity issues: 1. Verify that your modem and router are properly connected. 2. Check if other devices are able to connect to the internet. 3. Restart your modem and router. If the problem persists, contact your internet service provider.", new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Troubleshooting Internet Connectivity Problems" },
                    { 3, "If your computer is overheating, try the following steps: 1. Ensure that the computer's cooling vents are not blocked. 2. Clean the internal components to remove dust buildup. 3. Check that the cooling fans are working properly. If the issue continues, consider seeking professional assistance.", new DateTime(2024, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Steps to Resolve Computer Overheating" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "KnowledgeBaseArticles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "KnowledgeBaseArticles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "KnowledgeBaseArticles",
                keyColumn: "Id",
                keyValue: 3);

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
    }
}
