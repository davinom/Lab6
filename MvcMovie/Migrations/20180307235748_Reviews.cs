using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MvcMovie.Migrations
{
    public partial class Reviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
               name: "Title",
               table: "Movie",
               type: "nvarchar(60)",
               maxLength: 60,
               nullable: false,
               oldClrType: typeof(string),
               oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Rating",
                table: "Movie",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Genre",
                table: "Movie",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MovieReview = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.ID);
                });
            /*
            migrationBuilder.CreateTable(
               name: "Reviews",
               columns: table => new
               {
                   ID = table.Column<int>(nullable: false)
                       .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                   ReviewId = table.Column<int>(nullable: true),
                   Author = table.Column<string>(nullable: true),
                   //ReleaseDate = table.Column<DateTime>(nullable: false),
                   Review = table.Column<string>(nullable: true)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Review", x => x.ID);
               });*/
            /*
            migrationBuilder.AddColumn<string>(
                name: "ReviewId",
                table: "Reviews",
                nullable: true);
        }
        
        migrationBuilder.AlterColumn<string>(
            name: "Title",
            table: "Movie",
            maxLength: 60,
            nullable: false,
            oldClrType: typeof(string),
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "Rating",
            table: "Movie",
            maxLength: 5,
            nullable: false,
            oldClrType: typeof(string),
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "Genre",
            table: "Movie",
            maxLength: 30,
            nullable: false,
            oldClrType: typeof(string),
            oldNullable: true);

        migrationBuilder.CreateTable(
            name: "Reviews",
            columns: table => new
            {
                ID = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                Author = table.Column<string>(nullable: true),
                Movie = table.Column<string>(nullable: true),
                Review = table.Column<string>(nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Reviews", x => x.ID);
            });
            */
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");
            migrationBuilder.AlterColumn<string>(
               name: "Title",
               table: "Movie",
               nullable: true,
               oldClrType: typeof(string),
               oldType: "nvarchar(60)",
               oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "Rating",
                table: "Movie",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<string>(
                name: "Genre",
                table: "Movie",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);
            /*
                migrationBuilder.AlterColumn<string>(
                    name: "Title",
                    table: "Movie",
                    nullable: true,
                    oldClrType: typeof(string),
                    oldMaxLength: 60);

                migrationBuilder.AlterColumn<string>(
                    name: "Rating",
                    table: "Movie",
                    nullable: true,
                    oldClrType: typeof(string),
                    oldMaxLength: 5);

                migrationBuilder.AlterColumn<string>(
                    name: "Genre",
                    table: "Movie",
                    nullable: true,
                    oldClrType: typeof(string),
                    oldMaxLength: 30);

        }
        */
        }
    }
}