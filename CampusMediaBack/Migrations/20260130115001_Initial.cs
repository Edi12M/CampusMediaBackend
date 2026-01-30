using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CampusMediaBack.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TargetType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TargetId = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReviewerId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Universities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Aliases = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Rating = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universities", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    University = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Department = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProfileImage = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Role = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Friends = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Suggestions = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UniversityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_Universities_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "Universities",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Caption = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Likes = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Stories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Username = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ViewedBy = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stories_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pedagogues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Surname = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    University = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Department = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Courses = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ResearchAreas = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Rating = table.Column<double>(type: "double", nullable: false),
                    YearsOfExperience = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedagogues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedagogues_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Programs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Department = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Rating = table.Column<double>(type: "double", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Programs_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "UniversityId" },
                values: new object[,]
                {
                    { 1, "Department 1", null },
                    { 2, "Department 2", null },
                    { 3, "Department 3", null },
                    { 4, "Department 4", null },
                    { 5, "Department 5", null },
                    { 6, "Department 6", null },
                    { 7, "Department 7", null },
                    { 8, "Department 8", null },
                    { 9, "Department 9", null },
                    { 10, "Department 10", null }
                });

            migrationBuilder.InsertData(
                table: "Pedagogues",
                columns: new[] { "Id", "Courses", "Department", "DepartmentId", "Name", "Rating", "ResearchAreas", "Surname", "University", "YearsOfExperience" },
                values: new object[,]
                {
                    { 1, "[]", "Department 2", null, "PedagogueName1", 4.0999999999999996, "[]", "PedagogueSurname1", "University 2", 6 },
                    { 2, "[]", "Department 3", null, "PedagogueName2", 4.2000000000000002, "[]", "PedagogueSurname2", "University 3", 7 },
                    { 3, "[]", "Department 4", null, "PedagogueName3", 4.2999999999999998, "[]", "PedagogueSurname3", "University 4", 8 },
                    { 4, "[]", "Department 5", null, "PedagogueName4", 4.4000000000000004, "[]", "PedagogueSurname4", "University 5", 9 },
                    { 5, "[]", "Department 6", null, "PedagogueName5", 4.5, "[]", "PedagogueSurname5", "University 6", 10 },
                    { 6, "[]", "Department 7", null, "PedagogueName6", 4.5999999999999996, "[]", "PedagogueSurname6", "University 7", 11 },
                    { 7, "[]", "Department 8", null, "PedagogueName7", 4.7000000000000002, "[]", "PedagogueSurname7", "University 8", 12 },
                    { 8, "[]", "Department 9", null, "PedagogueName8", 4.7999999999999998, "[]", "PedagogueSurname8", "University 9", 13 },
                    { 9, "[]", "Department 10", null, "PedagogueName9", 4.9000000000000004, "[]", "PedagogueSurname9", "University 10", 14 },
                    { 10, "[]", "Department 1", null, "PedagogueName10", 5.0, "[]", "PedagogueSurname10", "University 1", 15 }
                });

            migrationBuilder.InsertData(
                table: "Programs",
                columns: new[] { "Id", "Department", "DepartmentId", "Name", "Rating", "Type" },
                values: new object[,]
                {
                    { 1, "Department 2", null, "Program 1", 4.0999999999999996, "Bachelor" },
                    { 2, "Department 3", null, "Program 2", 4.2000000000000002, "Master" },
                    { 3, "Department 4", null, "Program 3", 4.2999999999999998, "PhD" },
                    { 4, "Department 5", null, "Program 4", 4.4000000000000004, "Master" },
                    { 5, "Department 6", null, "Program 5", 4.5, "Bachelor" },
                    { 6, "Department 7", null, "Program 6", 4.5999999999999996, "PhD" },
                    { 7, "Department 8", null, "Program 7", 4.7000000000000002, "Bachelor" },
                    { 8, "Department 9", null, "Program 8", 4.7999999999999998, "Master" },
                    { 9, "Department 10", null, "Program 9", 4.9000000000000004, "PhD" },
                    { 10, "Department 1", null, "Program 10", 5.0, "Master" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Comment", "Date", "ReviewerId", "Score", "TargetId", "TargetType" },
                values: new object[,]
                {
                    { "1", "Review Comment 1", "2026-01-29", "1", 4, 1, "prof" },
                    { "10", "Review Comment 10", "2026-01-20", "10", 4, 10, "uni" },
                    { "2", "Review Comment 2", "2026-01-28", "2", 5, 2, "uni" },
                    { "3", "Review Comment 3", "2026-01-27", "3", 3, 3, "prof" },
                    { "4", "Review Comment 4", "2026-01-26", "4", 4, 4, "uni" },
                    { "5", "Review Comment 5", "2026-01-25", "5", 5, 5, "prof" },
                    { "6", "Review Comment 6", "2026-01-24", "6", 3, 6, "uni" },
                    { "7", "Review Comment 7", "2026-01-23", "7", 4, 7, "prof" },
                    { "8", "Review Comment 8", "2026-01-22", "8", 5, 8, "uni" },
                    { "9", "Review Comment 9", "2026-01-21", "9", 3, 9, "prof" }
                });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Aliases", "Name", "Rating" },
                values: new object[,]
                {
                    { 1, "[]", "University 1", 4.0999999999999996 },
                    { 2, "[]", "University 2", 4.2000000000000002 },
                    { 3, "[]", "University 3", 4.2999999999999998 },
                    { 4, "[]", "University 4", 4.4000000000000004 },
                    { 5, "[]", "University 5", 4.5 },
                    { 6, "[]", "University 6", 4.5999999999999996 },
                    { 7, "[]", "University 7", 4.7000000000000002 },
                    { 8, "[]", "University 8", 4.7999999999999998 },
                    { 9, "[]", "University 9", 4.9000000000000004 },
                    { 10, "[]", "University 10", 5.0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Department", "Email", "Friends", "Name", "PasswordHash", "ProfileImage", "Role", "Suggestions", "University" },
                values: new object[,]
                {
                    { 1, "Department 2", "user1@example.com", "[]", "User 1", "$2a$11$Kzn31IcboE1zmS..8pvMmOCulCo27yQkyynGfZbLctkvjf/2vVlM.", "https://api.dicebear.com/7.x/avataaars/svg?seed=user1", "student", "[]", "University 2" },
                    { 2, "Department 3", "user2@example.com", "[]", "User 2", "$2a$11$Aixk/gNxGC12wYRDYpalzeub4VHMjX/.iuFmzOn8VcROWAfFkwtKa", "https://api.dicebear.com/7.x/avataaars/svg?seed=user2", "student", "[]", "University 3" },
                    { 3, "Department 4", "user3@example.com", "[]", "User 3", "$2a$11$srxOHoWWcc6hdNwE1AYgPeMsSZ2E88k8Csj8ZZhsgmId2gHWZF.LS", "https://api.dicebear.com/7.x/avataaars/svg?seed=user3", "student", "[]", "University 4" },
                    { 4, "Department 5", "user4@example.com", "[]", "User 4", "$2a$11$lksQWAKJyr.IwcPcExctGutQaGOO2uJlJvTlBxPe/GYjMtlYy5xPa", "https://api.dicebear.com/7.x/avataaars/svg?seed=user4", "student", "[]", "University 5" },
                    { 5, "Department 6", "user5@example.com", "[]", "User 5", "$2a$11$PgNHj.fCKmWhFrMqbaY4R.JY6RGc2CvPKfqvOTuN.eE/waZ6eGLum", "https://api.dicebear.com/7.x/avataaars/svg?seed=user5", "student", "[]", "University 6" },
                    { 6, "Department 7", "user6@example.com", "[]", "User 6", "$2a$11$GsQJUNW1AUlXzJ3vbxBmdunJQERhFgoZXBcauBsp1GpqtWo0lmAMe", "https://api.dicebear.com/7.x/avataaars/svg?seed=user6", "student", "[]", "University 7" },
                    { 7, "Department 8", "user7@example.com", "[]", "User 7", "$2a$11$wOctn8dFj3SKmexbszvCQOZgXARXuoSzQxzoP43TlHKi8ozoQRgve", "https://api.dicebear.com/7.x/avataaars/svg?seed=user7", "student", "[]", "University 8" },
                    { 8, "Department 9", "user8@example.com", "[]", "User 8", "$2a$11$F8OIElJwE5GkdmvX5ddjmOzpox03f5nGpA/UZKUd7FpnhkaxMCfv.", "https://api.dicebear.com/7.x/avataaars/svg?seed=user8", "student", "[]", "University 9" },
                    { 9, "Department 10", "user9@example.com", "[]", "User 9", "$2a$11$T65X4vG13WLlszhO0gX9F.UkjZcbxrxnISEWjrnlXZP3JNnh1C.Fe", "https://api.dicebear.com/7.x/avataaars/svg?seed=user9", "student", "[]", "University 10" },
                    { 10, "Department 1", "user10@example.com", "[]", "User 10", "$2a$11$OVayAJeFU2036ofiHOo.1uiKKnCQO/w.UwgofsH6Q0NNJN5B5fFi2", "https://api.dicebear.com/7.x/avataaars/svg?seed=user10", "student", "[]", "University 1" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Caption", "Date", "Image", "Likes", "UserId" },
                values: new object[,]
                {
                    { 1, "Post Caption 1", "2026-01-29", "https://picsum.photos/seed/post1/200/300", "[]", 1 },
                    { 2, "Post Caption 2", "2026-01-28", "https://picsum.photos/seed/post2/200/300", "[]", 2 },
                    { 3, "Post Caption 3", "2026-01-27", "https://picsum.photos/seed/post3/200/300", "[]", 3 },
                    { 4, "Post Caption 4", "2026-01-26", "https://picsum.photos/seed/post4/200/300", "[]", 4 },
                    { 5, "Post Caption 5", "2026-01-25", "https://picsum.photos/seed/post5/200/300", "[]", 5 },
                    { 6, "Post Caption 6", "2026-01-24", "https://picsum.photos/seed/post6/200/300", "[]", 6 },
                    { 7, "Post Caption 7", "2026-01-23", "https://picsum.photos/seed/post7/200/300", "[]", 7 },
                    { 8, "Post Caption 8", "2026-01-22", "https://picsum.photos/seed/post8/200/300", "[]", 8 },
                    { 9, "Post Caption 9", "2026-01-21", "https://picsum.photos/seed/post9/200/300", "[]", 9 },
                    { 10, "Post Caption 10", "2026-01-20", "https://picsum.photos/seed/post10/200/300", "[]", 10 }
                });

            migrationBuilder.InsertData(
                table: "Stories",
                columns: new[] { "Id", "Image", "UserId", "Username", "ViewedBy" },
                values: new object[,]
                {
                    { 1, "https://picsum.photos/seed/story1/200/300", 1, "User 1", "[]" },
                    { 2, "https://picsum.photos/seed/story2/200/300", 2, "User 2", "[]" },
                    { 3, "https://picsum.photos/seed/story3/200/300", 3, "User 3", "[]" },
                    { 4, "https://picsum.photos/seed/story4/200/300", 4, "User 4", "[]" },
                    { 5, "https://picsum.photos/seed/story5/200/300", 5, "User 5", "[]" },
                    { 6, "https://picsum.photos/seed/story6/200/300", 6, "User 6", "[]" },
                    { 7, "https://picsum.photos/seed/story7/200/300", 7, "User 7", "[]" },
                    { 8, "https://picsum.photos/seed/story8/200/300", 8, "User 8", "[]" },
                    { 9, "https://picsum.photos/seed/story9/200/300", 9, "User 9", "[]" },
                    { 10, "https://picsum.photos/seed/story10/200/300", 10, "User 10", "[]" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_UniversityId",
                table: "Departments",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedagogues_DepartmentId",
                table: "Pedagogues",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Programs_DepartmentId",
                table: "Programs",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Stories_UserId",
                table: "Stories",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pedagogues");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Programs");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Stories");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Universities");
        }
    }
}
