using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCollectionSite.Migrations
{
    public partial class Seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CollectionItems",
                columns: new[] { "Id", "Acquired", "Description", "ImageURL", "Name" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2006), "Black hat with the classic atari logo", "https://hatcollection.blob.core.windows.net/hat-images/atari.jpg", "Atari" });

            migrationBuilder.InsertData(
                table: "CollectionItems",
                columns: new[] { "Id", "Acquired", "Description", "ImageURL", "Name" },
                values: new object[] { 2, new DateTime(2019, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "A white hat with blazor logo", "https://hatcollection.blob.core.windows.net/hat-images/blazor.jpg", "MyBlazorHat" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CollectionItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CollectionItems",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
