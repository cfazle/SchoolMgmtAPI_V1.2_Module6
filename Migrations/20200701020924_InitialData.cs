using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolMgmtAPI.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    AssignmentId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 30, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    SectionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.AssignmentId);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    EnrollmentId = table.Column<Guid>(nullable: false),
                    AttributeName = table.Column<string>(maxLength: 30, nullable: false),
                    StartDate = table.Column<DateTime>(type: "Date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "Date", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "Date", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "Date", nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    SectionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.EnrollmentId);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    OrganizationId = table.Column<Guid>(nullable: false),
                    OrgName = table.Column<string>(maxLength: 60, nullable: false),
                    Address = table.Column<string>(maxLength: 60, nullable: false),
                    Country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.OrganizationId);
                });

            migrationBuilder.CreateTable(
                name: "Submissions",
                columns: table => new
                {
                    SubmissionId = table.Column<Guid>(nullable: false),
                    SubmissionText = table.Column<string>(maxLength: 60, nullable: false),
                    Score = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "Date", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "Date", nullable: false),
                    AssignmentId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Submissions", x => x.SubmissionId);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    SectionId = table.Column<Guid>(nullable: false),
                    StartDate = table.Column<DateTime>(type: "Date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "Date", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "Date", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "Date", nullable: false),
                    CourseId = table.Column<Guid>(nullable: false),
                    AssignmentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.SectionId);
                    table.ForeignKey(
                        name: "FK_Sections_Assignments_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "Assignments",
                        principalColumn: "AssignmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<Guid>(nullable: false),
                    CourseName = table.Column<string>(maxLength: 30, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "Date", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "Date", nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    EnrollmentId = table.Column<Guid>(nullable: true),
                    SectionId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_Courses_Enrollments_EnrollmentId",
                        column: x => x.EnrollmentId,
                        principalTable: "Enrollments",
                        principalColumn: "EnrollmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Courses_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "SectionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 30, nullable: false),
                    Email = table.Column<string>(maxLength: 30, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "Date", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "Date", nullable: false),
                    OrganizationId = table.Column<Guid>(nullable: false),
                    CourseId = table.Column<Guid>(nullable: true),
                    SubmissionId = table.Column<Guid>(nullable: true)
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
                    table.ForeignKey(
                        name: "FK_Users_Submissions_SubmissionId",
                        column: x => x.SubmissionId,
                        principalTable: "Submissions",
                        principalColumn: "SubmissionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "AssignmentId", "Description", "SectionId", "Title" },
                values: new object[] { new Guid("80abbca8-664d-4b20-b5de-024705498a4b"), "Entity and databae connection", new Guid("80abbca8-664d-4b20-b5de-024705497d5a"), "Module 1" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CourseName", "CreatedDate", "EnrollmentId", "SectionId", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("80abbca8-664d-4b20-b5de-024705497d4b"), "Acc101", new DateTime(2019, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2019, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("80abbca8-664d-4b20-b5de-024705497d4a") },
                    { new Guid("86dba8c0-d178-41e7-938c-ed49778fb52c"), "Math108", new DateTime(2019, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2019, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("80abbca8-664d-4b20-b5de-024705497d4a") },
                    { new Guid("021ca3c1-0deb-4afd-ae94-2159a8479822"), "IS690", new DateTime(2019, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2019, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("80abbca8-664d-4b20-b5de-024705497d4a") }
                });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "EnrollmentId", "AttributeName", "CreatedDate", "EndDate", "SectionId", "StartDate", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("80abbca8-664d-4b20-b5de-024705497c5e"), "Fazle (Student)", new DateTime(2019, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("80abbca8-664d-4b20-b5de-024705497d5a"), new DateTime(2020, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("80abbca8-664d-4b20-b5de-024705497d4a") });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "OrganizationId", "Address", "Country", "OrgName" },
                values: new object[,]
                {
                    { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "583 Wall Dr. Gwynn Oak, MD 21207", "USA", "xyz org" },
                    { new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "3036 English Creek Ave, EHT, NJ 08234", "USA", "lmnop org" }
                });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "SectionId", "AssignmentId", "CourseId", "CreatedDate", "EndDate", "StartDate", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("80abbca8-664d-4b20-b5de-024705497d5a"), null, new Guid("80abbca8-664d-4b20-b5de-024705497d4b"), new DateTime(2019, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("80abbca8-664d-4b20-b5de-024705497d6a"), null, new Guid("86dba8c0-d178-41e7-938c-ed49778fb52c"), new DateTime(2019, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Submissions",
                columns: new[] { "SubmissionId", "AssignmentId", "CreatedDate", "Score", "SubmissionText", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("80abbca8-664d-4b20-b5de-024705493d5a"), new Guid("80abbca8-664d-4b20-b5de-024705498a4b"), new DateTime(2019, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, "Module 1 submission", new DateTime(2019, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("80abbca8-664d-4b20-b5de-024705497d4a") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CourseId", "CreatedDate", "Email", "OrganizationId", "SubmissionId", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), null, new DateTime(2018, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc@gmail.com", new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), null, new DateTime(2019, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "fchoudhury" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CourseId", "CreatedDate", "Email", "OrganizationId", "SubmissionId", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), null, new DateTime(2018, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "xyz@gmail.com", new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), null, new DateTime(2019, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "fac3" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CourseId", "CreatedDate", "Email", "OrganizationId", "SubmissionId", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), null, new DateTime(2019, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "efg@gmail.com", new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), null, new DateTime(2019, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "fac33" });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_EnrollmentId",
                table: "Courses",
                column: "EnrollmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_SectionId",
                table: "Courses",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_AssignmentId",
                table: "Sections",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CourseId",
                table: "Users",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_OrganizationId",
                table: "Users",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_SubmissionId",
                table: "Users",
                column: "SubmissionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "Submissions");

            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "Assignments");
        }
    }
}
