using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Yvadev.Infrastructure.EF.Migrations
{
    public partial class RemoveSeoEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_SEO_SeoId",
                table: "Post");

            migrationBuilder.DropTable(
                name: "SEO");

            migrationBuilder.DropIndex(
                name: "IX_Post_SeoId",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "SeoId",
                table: "Post");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "SeoId",
                table: "Post",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SEO",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    MetaDescription = table.Column<string>(nullable: true),
                    MetaTitle = table.Column<string>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SEO", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Post_SeoId",
                table: "Post",
                column: "SeoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_SEO_SeoId",
                table: "Post",
                column: "SeoId",
                principalTable: "SEO",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
