using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampusMediaBack.Migrations
{
    /// <inheritdoc />
    public partial class MakePostDetailFieldsNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "PostDetails",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Feeling",
                table: "PostDetails",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PostDetails",
                keyColumn: "Location",
                keyValue: null,
                column: "Location",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "PostDetails",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "PostDetails",
                keyColumn: "Feeling",
                keyValue: null,
                column: "Feeling",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Feeling",
                table: "PostDetails",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

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
    }
}
