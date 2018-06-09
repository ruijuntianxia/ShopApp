using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ShopApp.Data.Migrations.AddDataDb
{
    public partial class CreateAddData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddDataViewModel",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    brand = table.Column<string>(maxLength: 30, nullable: true),
                    classify = table.Column<string>(maxLength: 30, nullable: true),
                    createdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    createuser = table.Column<string>(maxLength: 50, nullable: true),
                    imageurl = table.Column<string>(maxLength: 255, nullable: true),
                    model = table.Column<string>(maxLength: 50, nullable: true),
                    modelmum = table.Column<string>(maxLength: 50, nullable: true),
                    remark = table.Column<string>(maxLength: 255, nullable: true),
                    updatedate = table.Column<DateTime>(type: "datetime", nullable: true),
                    updateuser = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddDataViewModel", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddDataViewModel");
        }
    }
}
