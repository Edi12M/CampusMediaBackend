using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampusMediaBack.Migrations
{
    /// <inheritdoc />
    public partial class AddAboutToUserProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "About",
                table: "UserProfiles",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$X1Ur7IaGIZS9tiOZX7g6G.FMX3qKZT.iJjKlfHaFBqxM3IkY9RQrm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$7TO9NWqkUhDKme6rTFZ4LOnm7ojWgtvg3EhvEVoCEENF.01PFo5G6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$bPmOs4NCueHPLNJ3B1QcaOQ0oZ67Mrx6ZvftEn4pgHY2gHrvylTsa");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "$2a$11$0b8JP2ghhzisp.QarPmfmeaiQkhCQEo6mvBY7B/OgnZTpZEks2xAW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "PasswordHash",
                value: "$2a$11$EwyScTXFkIJL7IW69L7FqOcTuI8OOFvl60Wv4TA1lGRlczQG4dTEe");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "PasswordHash",
                value: "$2a$11$qpX9iHuLxkIip1ymwgGnpeNOc5osr2UmQ9mamB8Re.Tm2LN2HaayK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "PasswordHash",
                value: "$2a$11$w3nN/AEUV327rNG1dWAs3OpfyVpPXSo8hZw0/yTUJjhk9SFn2loQO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "PasswordHash",
                value: "$2a$11$wVvttfrN9SKIBv64aXzaouAi6M3JkomvXdk8uPwD9LVrer83dtRsS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "PasswordHash",
                value: "$2a$11$tuu.sn6SOC9ouve7mv6chelbHzFK20WEQGdBAg/EW58nZuW8FBLza");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "PasswordHash",
                value: "$2a$11$3itFEgJvAy5BYcG8iqmh9e1z7QAt4bt4EXTyMYapO4iCoz85LFMeS");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "About",
                table: "UserProfiles");

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
    }
}
