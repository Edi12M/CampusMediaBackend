using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampusMediaBack.Migrations
{
    /// <inheritdoc />
    public partial class AddPostDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PostDetails",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false),
                    Feeling = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Location = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostDetails", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_PostDetails_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$AmLnptCxD5z17r5pC8faleSbmE.3PL/1vp1ltxUumwpSb8qEK2HGC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$G2IOhTejELjdbHLtTnu2ZuLytdFTVY4AncQffgHMkFEssxCKE4try");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$Dk.otePAIm1utLLlH9aXQurgJZ7vpL.iNSDqXXYjTTogFMeUHqaZu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "$2a$11$60Voo7Te2EwvDegEccZG.e6x4g5t44.qk9JsrZ0.wS6X82XSH2Sby");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "PasswordHash",
                value: "$2a$11$7lZGJphX55Cn/k1kn4lxNeNZ0owIYCwyQYtKOv7U1T0TiICnoao0m");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "PasswordHash",
                value: "$2a$11$0t774HEEUWIvatPbCMDZVO9K.ht.QU.eOyOJ1.cr7ResHIFhI3272");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "PasswordHash",
                value: "$2a$11$AXN/ApaPI6kZp8ldfKHUbezamhLDDzRDoWno/V9vDElgUfUWZPRBi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "PasswordHash",
                value: "$2a$11$yEujTUP3i3T8CVteZSvpnOyMEIzIokD8TL9wxsEkyKn6F496ulKO6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "PasswordHash",
                value: "$2a$11$vW5GjvuSi1/1D1ha7CagHujQbhygkeo.Dv6TO9kLFJAT3xPan3pEu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "PasswordHash",
                value: "$2a$11$pBtn82w17u/rx0iCn70iUudl2xUqXiLcOL.P2RVFgGtzqgKqRKQn.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostDetails");

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
    }
}
