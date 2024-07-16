using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814  

namespace Eftask2.Migrations
{
    /// <inheritdoc />
    public partial class mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "LastName", "Name" },
                values: new object[,]
                {
                    { 14, "Suleyman", "Ahmet Ümit" },
                    { 15, "Suleyman", "Elif Şafak" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 15);
        }
    }
}
