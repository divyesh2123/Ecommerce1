using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce.Migrations
{
    public partial class dataadd1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ADN",
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ade95b09-ca16-4369-91c3-2c1202265e71", "Admin", "ADMIN" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "CUS",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "35e1f309-b03a-43da-96cf-f7f1e5093295", "CUSTOMER" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "RET",
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1e488cc3-7e91-4ef8-9a8e-f41c68aa8a78", "Retailer", "RETAILER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ADN",
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d5597e53-d6ae-43de-83e4-2f205951cf59", "ADMIN", null });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "CUS",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "5c546244-a92a-401f-839b-d65ff3d3427d", null });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "RET",
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dafe626a-f7e2-4127-937f-49b1bb33e876", "RETAILER", null });
        }
    }
}
