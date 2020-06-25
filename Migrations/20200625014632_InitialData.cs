using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolMgmtAPI.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<Guid>(nullable: false),
                    CourseName = table.Column<string>(maxLength: 30, nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    OrganizationId = table.Column<Guid>(nullable: false),
                    OrgName = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.OrganizationId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 30, nullable: false),
                    OrganizationId = table.Column<Guid>(nullable: false),
                    CourseId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CourseName", "UserId" },
                values: new object[,]
                {
                    { new Guid("80abbca8-664d-4b20-b5de-024705497d4b"), "Acc101", new Guid("80abbca8-664d-4b20-b5de-024705497d4a") },
                    { new Guid("86dba8c0-d178-41e7-938c-ed49778fb52c"), "Math108", new Guid("80abbca8-664d-4b20-b5de-024705497d4a") },
                    { new Guid("021ca3c1-0deb-4afd-ae94-2159a8479822"), "IS690", new Guid("80abbca8-664d-4b20-b5de-024705497d4a") }
                });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "OrganizationId", "OrgName" },
                values: new object[,]
                {
                    { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "xyz org" },
                    { new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "lmnop org" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CourseId", "OrganizationId", "UserName" },
                values: new object[] { new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), null, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "fchoudhury" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CourseId", "OrganizationId", "UserName" },
                values: new object[] { new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), null, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "fac3" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CourseId", "OrganizationId", "UserName" },
                values: new object[] { new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), null, new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "fac33" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_CourseId",
                table: "Users",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_OrganizationId",
                table: "Users",
                column: "OrganizationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Organizations");
        }
    }
}
