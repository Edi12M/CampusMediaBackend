using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampusMediaBack.Migrations
{
    /// <inheritdoc />
    public partial class AddUserProfileTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Bio = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UserProfiles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$tRDE1aHMiWcylZDXFGxmpeNTuZlcOMc.Lp9wGZhlvth76NzJIoycy");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$biF6k9Zwh/oMji74ox/nfeUTfbkWGESTAlGTGPpTmza89e/UOCDKa");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$UelBhJeGkTjFfXcqx5Mn7eiKBPvyjGGKQPBiz6pRZLSIXMovuw6XS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "$2a$11$0XGejjEN1ZRYKYvRKVWAdecYpDZgW8g7tzZLAaehPds1zKeC81FdC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "PasswordHash",
                value: "$2a$11$ViUNHCtor6zU5WzFsPHoWe9.6LM7QEe9fJtUxvYk5d/Hpc9tL5asK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "PasswordHash",
                value: "$2a$11$VuOeKP4geOYeCdk4fA0CCeidmIZo24tn7OJ4lvT.fTvLxJ8rhX2MK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "PasswordHash",
                value: "$2a$11$BnZQOSX3saqguj1sR5P1.ePAkyiKcYtGQp9Q2D1vjd1JTZUxiwVj.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "PasswordHash",
                value: "$2a$11$N0JNH8CaubH0JRYoT7bkQeITh0TlD3FDOG002UAFAdqTmAKl2WEMO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "PasswordHash",
                value: "$2a$11$nE7uD37ycat.aEewlDcls.5/UwluElB4OZZ1Zicd1jp39Cl9LmSyK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "PasswordHash",
                value: "$2a$11$ht1rfMwmhxYZzwUAMIt2p.UFyLHg82Ub0V0ic2QJNinBzosCCgwiC");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$Rdsq66xQ78u7ghccZNsKYupZ08HB9APKqlEg64bnAl3xmJ0OfRY5C");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$mG1DHa2ck5p4tZOHy59Kiu1QGBik5jUc.FQd7JfHLw28cZIUO4xgm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$gmNN49rI.FT8ahgM0WhovOxcoy7riJp5Ay3HaN72JdeFKSk6GBWeW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "$2a$11$vWf31jtT8bvKzF4FTkto1.kqpGfPrpdwEoOLlKUJjehRVqgFcnRaq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "PasswordHash",
                value: "$2a$11$YFSTvpwC5kNhOWQ7vrMnMepLqrurTi1hRYQEFvjT493ywZksd7leK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "PasswordHash",
                value: "$2a$11$Uc9m7H0Tq2.0rgcROwl3HuA56tUkqWrodya6VxZ6sExFdVYBhuV0C");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "PasswordHash",
                value: "$2a$11$F.uQJFIM3i9xGFe753eNvuVI85jiSRtgAmJVK2nCDproS8DhAbxxC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "PasswordHash",
                value: "$2a$11$DxLFRFWTGVC2n2WrZLRMmu4B394PimJzsnp5YDzMLAbOBvd/aXr0C");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "PasswordHash",
                value: "$2a$11$mJsqI9.dVYKhbrsMmMmb6.8VYUmse.Us2bQUFra6P2i5iLmMKC9EK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "PasswordHash",
                value: "$2a$11$uPA4jF6mDPqhpKlrcMpjcebQNCOBAs24a3NlJji99TpYdMTUqHbM6");
        }
    }
}
