using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampusMediaBack.Migrations
{
    /// <inheritdoc />
    public partial class AddComments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserSurname = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CommentText = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$vQlg/02MlsPZvpghnUHIiufRwRrUndr7XL/eqIRmXx9FZ9aDYc5We");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$CMjt6FId5/FC2k9AHiF2g.M2Dx5rtr1pv62f/gfwUhghQLrFzBjB.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$J7ln0lfmPDntUa3iGjCEAe/IZRp7s0JaZPIuUGvFP5dP2YhR1QLpi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "$2a$11$zOHI3A346p/xjxIdUn0.jesJybiLolcMMmpz0i8.tO16KfhPFeW8S");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "PasswordHash",
                value: "$2a$11$wfQ6WY0C14BD2XaznXpMlen8NoQWCgXlQVb1.kizdcN7d4nJzNfei");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "PasswordHash",
                value: "$2a$11$QNOqNpaQItPwtRDUfS.5FeCveT8REwGipLoPa4718LizY6bZshS4m");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "PasswordHash",
                value: "$2a$11$w2Yt8Xu/ySpLOkI3Jcg1oOmAPBuZ45vAp5cObzOyVG1Q7tNQH2Nzy");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "PasswordHash",
                value: "$2a$11$s2mQxgciCnTc0DBGYpFTbePKUWKQ2gONCqN8V/E/tYbhNPcf.Q3rq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "PasswordHash",
                value: "$2a$11$guwvgJoL3RaVkTyBunCsLuGBHy8jSqmsbBndhPkJkz.3rYt0VsdFi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "PasswordHash",
                value: "$2a$11$JgBRutY.I20tKsblUWUNou5R2ShAiLSOlERZMD.NhdLuMUpEBN5hK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$REobDnaAumg5PU94le7rxugv.i2XBjhe3iNv5yB08duy.RYUGhAmK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$louIYr.5CQr/j5cFOuUrWeKS0eI3VRD0ZmVrNPsa2RP9z.5FrE/1i");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$F3EV0OxyhEhuMN7gNLaiduRo5ICfkBWKTAWG3If4cSDD1hQlz55tG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "$2a$11$In7FWJPA/okdmwzGrcL0xOkUmP/J7H1HDoSuuSndGxGtU8YagkKhW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "PasswordHash",
                value: "$2a$11$.pUabNlaapFSzF3N1JkkXesEdIdOJtQ91nbQsXLMS04Ak3ElilmmC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "PasswordHash",
                value: "$2a$11$/wooHoILc/BFifCPfL5N5.rqBoR465tBu5zF9vMLFRfANQtUEwl5G");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "PasswordHash",
                value: "$2a$11$vq0jOy.X.uLGNdiLby.vL.YhT0.9i0ecSxbkGH3dtMA6zkWkoL9uK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "PasswordHash",
                value: "$2a$11$qUY8Ws7CBiAcDgqIy17ZQOPQ4a7MvOfkcyZTOM7yNSkKoMHnzQz8C");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "PasswordHash",
                value: "$2a$11$U.CIpJ.DWswJ8OY/F7Xs5uAU.wJmOUYOVjibm.VFurhzJ0rA.PGyO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "PasswordHash",
                value: "$2a$11$PXw36rt7TxhXDoOzZPt6je0U8KksqnjiAVThyLD.qwrGWTWpRiZny");
        }
    }
}
