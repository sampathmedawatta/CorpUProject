using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CorpU.Data.Migrations
{
    /// <inheritdoc />
    public partial class Migratin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassType",
                columns: table => new
                {
                    class_type_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    class_description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassType", x => x.class_type_id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeRole",
                columns: table => new
                {
                    emp_role_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role_name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeRole", x => x.emp_role_id);
                });

            migrationBuilder.CreateTable(
                name: "Faculty",
                columns: table => new
                {
                    faculty_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    faculty_name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculty", x => x.faculty_id);
                });

            migrationBuilder.CreateTable(
                name: "QualificationType",
                columns: table => new
                {
                    qualification_type_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualificationType", x => x.qualification_type_id);
                });

            migrationBuilder.CreateTable(
                name: "Unit",
                columns: table => new
                {
                    unit_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    unit_name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    unit_code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit", x => x.unit_id);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    user_role_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role_name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.user_role_id);
                });

            migrationBuilder.CreateTable(
                name: "VacancyType",
                columns: table => new
                {
                    vacancy_type_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vacancy_name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacancyType", x => x.vacancy_type_id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    password = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    salt = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    user_role_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.user_id);
                    table.ForeignKey(
                        name: "FK_User_UserRole_user_role_id",
                        column: x => x.user_role_id,
                        principalTable: "UserRole",
                        principalColumn: "user_role_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Aplicants",
                columns: table => new
                {
                    applicant_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    resume_url = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aplicants", x => x.applicant_id);
                    table.ForeignKey(
                        name: "FK_Aplicants_User_user_id",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    emp_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    emp_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    emp_role_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    faculty_id = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.emp_id);
                    table.ForeignKey(
                        name: "FK_Employee_EmployeeRole_emp_role_id",
                        column: x => x.emp_role_id,
                        principalTable: "EmployeeRole",
                        principalColumn: "emp_role_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_Faculty_faculty_id",
                        column: x => x.faculty_id,
                        principalTable: "Faculty",
                        principalColumn: "faculty_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_User_user_id",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicantAvailability",
                columns: table => new
                {
                    app_availability_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    applicant_id = table.Column<int>(type: "int", nullable: false),
                    start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    end_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantAvailability", x => x.app_availability_id);
                    table.ForeignKey(
                        name: "FK_ApplicantAvailability_Aplicants_applicant_id",
                        column: x => x.applicant_id,
                        principalTable: "Aplicants",
                        principalColumn: "applicant_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicantClassPreferance",
                columns: table => new
                {
                    class_preferance_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    applicant_id = table.Column<int>(type: "int", nullable: false),
                    class_type_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantClassPreferance", x => x.class_preferance_id);
                    table.ForeignKey(
                        name: "FK_ApplicantClassPreferance_Aplicants_applicant_id",
                        column: x => x.applicant_id,
                        principalTable: "Aplicants",
                        principalColumn: "applicant_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicantClassPreferance_ClassType_class_type_id",
                        column: x => x.class_type_id,
                        principalTable: "ClassType",
                        principalColumn: "class_type_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicantContactDetail",
                columns: table => new
                {
                    app_contact_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    applicant_id = table.Column<int>(type: "int", nullable: false),
                    phone = table.Column<int>(type: "int", nullable: false),
                    address_line1 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    address_line2 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    state = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    postcode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantContactDetail", x => x.app_contact_id);
                    table.ForeignKey(
                        name: "FK_ApplicantContactDetail_Aplicants_applicant_id",
                        column: x => x.applicant_id,
                        principalTable: "Aplicants",
                        principalColumn: "applicant_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicantQualification",
                columns: table => new
                {
                    app_qualification_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    applicant_id = table.Column<int>(type: "int", nullable: false),
                    qualification_type_id = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    awarded_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    institute = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantQualification", x => x.app_qualification_id);
                    table.ForeignKey(
                        name: "FK_ApplicantQualification_Aplicants_applicant_id",
                        column: x => x.applicant_id,
                        principalTable: "Aplicants",
                        principalColumn: "applicant_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicantQualification_QualificationType_qualification_type_id",
                        column: x => x.qualification_type_id,
                        principalTable: "QualificationType",
                        principalColumn: "qualification_type_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Application",
                columns: table => new
                {
                    Application_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    applicant_id = table.Column<int>(type: "int", nullable: false),
                    resume_url = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    status = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application", x => x.Application_id);
                    table.ForeignKey(
                        name: "FK_Application_Aplicants_applicant_id",
                        column: x => x.applicant_id,
                        principalTable: "Aplicants",
                        principalColumn: "applicant_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vacancy",
                columns: table => new
                {
                    vacancy_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vacancy_type_id = table.Column<int>(type: "int", nullable: false),
                    class_type_id = table.Column<int>(type: "int", nullable: false),
                    emp_id = table.Column<int>(type: "int", nullable: false),
                    unit_id = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    publish_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    closing_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacancy", x => x.vacancy_id);
                    table.ForeignKey(
                        name: "FK_Vacancy_ClassType_class_type_id",
                        column: x => x.class_type_id,
                        principalTable: "ClassType",
                        principalColumn: "class_type_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vacancy_Employee_emp_id",
                        column: x => x.emp_id,
                        principalTable: "Employee",
                        principalColumn: "emp_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vacancy_Unit_unit_id",
                        column: x => x.unit_id,
                        principalTable: "Unit",
                        principalColumn: "unit_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vacancy_VacancyType_vacancy_type_id",
                        column: x => x.vacancy_type_id,
                        principalTable: "VacancyType",
                        principalColumn: "vacancy_type_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ClassType",
                columns: new[] { "class_type_id", "class_description", "status" },
                values: new object[,]
                {
                    { 1, "Online", true },
                    { 2, "Lab", true },
                    { 3, "Theory", true },
                    { 4, "Workshop", true },
                    { 5, "Tute", true }
                });

            migrationBuilder.InsertData(
                table: "EmployeeRole",
                columns: new[] { "emp_role_id", "role_name", "status" },
                values: new object[,]
                {
                    { 1, "Admin", true },
                    { 2, "Manager", true },
                    { 3, "Staff", true }
                });

            migrationBuilder.InsertData(
                table: "Faculty",
                columns: new[] { "faculty_id", "faculty_name", "status" },
                values: new object[,]
                {
                    { 1, "Human Resource", true },
                    { 2, "Information Technology", true },
                    { 3, "Civil Engineering", true }
                });

            migrationBuilder.InsertData(
                table: "QualificationType",
                columns: new[] { "qualification_type_id", "description", "status" },
                values: new object[,]
                {
                    { 1, "BSc", true },
                    { 2, "MSc", true },
                    { 3, "Phd", true }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "user_role_id", "role_name", "status" },
                values: new object[,]
                {
                    { 1, "Applicant", true },
                    { 2, "Employee", true }
                });

            migrationBuilder.InsertData(
                table: "VacancyType",
                columns: new[] { "vacancy_type_id", "status", "vacancy_name" },
                values: new object[,]
                {
                    { 1, true, "Fultime" },
                    { 2, true, "Parttime" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aplicants_user_id",
                table: "Aplicants",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantAvailability_applicant_id",
                table: "ApplicantAvailability",
                column: "applicant_id");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantClassPreferance_applicant_id",
                table: "ApplicantClassPreferance",
                column: "applicant_id");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantClassPreferance_class_type_id",
                table: "ApplicantClassPreferance",
                column: "class_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantContactDetail_applicant_id",
                table: "ApplicantContactDetail",
                column: "applicant_id");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantQualification_applicant_id",
                table: "ApplicantQualification",
                column: "applicant_id");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantQualification_qualification_type_id",
                table: "ApplicantQualification",
                column: "qualification_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_Application_applicant_id",
                table: "Application",
                column: "applicant_id");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_emp_role_id",
                table: "Employee",
                column: "emp_role_id");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_faculty_id",
                table: "Employee",
                column: "faculty_id");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_user_id",
                table: "Employee",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_User_user_role_id",
                table: "User",
                column: "user_role_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vacancy_class_type_id",
                table: "Vacancy",
                column: "class_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_Vacancy_emp_id",
                table: "Vacancy",
                column: "emp_id");

            migrationBuilder.CreateIndex(
                name: "IX_Vacancy_unit_id",
                table: "Vacancy",
                column: "unit_id");

            migrationBuilder.CreateIndex(
                name: "IX_Vacancy_vacancy_type_id",
                table: "Vacancy",
                column: "vacancy_type_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicantAvailability");

            migrationBuilder.DropTable(
                name: "ApplicantClassPreferance");

            migrationBuilder.DropTable(
                name: "ApplicantContactDetail");

            migrationBuilder.DropTable(
                name: "ApplicantQualification");

            migrationBuilder.DropTable(
                name: "Application");

            migrationBuilder.DropTable(
                name: "Vacancy");

            migrationBuilder.DropTable(
                name: "QualificationType");

            migrationBuilder.DropTable(
                name: "Aplicants");

            migrationBuilder.DropTable(
                name: "ClassType");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Unit");

            migrationBuilder.DropTable(
                name: "VacancyType");

            migrationBuilder.DropTable(
                name: "EmployeeRole");

            migrationBuilder.DropTable(
                name: "Faculty");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "UserRole");
        }
    }
}
