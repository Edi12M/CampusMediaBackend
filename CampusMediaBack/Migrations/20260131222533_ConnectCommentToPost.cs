using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampusMediaBack.Migrations
{
    /// <inheritdoc />
    public partial class ConnectCommentToPost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$WfcCw.zHjegv2JX69mekeuW25PdJivFMvrv9D.hkOQm.VhZN9wWz2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$bMcdO1u/4rEqJPogRt9meeEr.zc94lajYpab2IScZECO2f1ly3oDq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$B0Z9PI26VTfa9WdllQEyRuhjOfetyPKLYny.0QuuJJI2jlmaOF4Oa");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "$2a$11$u1su6hjoYh4HYlzzxIdAgOf9w0f8c4FQ8ff4f5oGMhiHkGBuOE3Vu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "PasswordHash",
                value: "$2a$11$Xh6TQyzq35nN2w6I3n9GpOPgHWoeZBZJPsn5o.KUV6mARvaBtRy3S");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "PasswordHash",
                value: "$2a$11$LRv4Gu50uNJCG9EBzDHHTeFUpairZuQ2YGHRGMqX//2K.5h5sAtx2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "PasswordHash",
                value: "$2a$11$3LMODH4UZDPoWdf0xDGasOGHY51W/R/6zRnvDya4Zz47rc1GV6/YG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "PasswordHash",
                value: "$2a$11$/VvDfJDlAjdkPzLlNT7vAeDjDAnbCmNu.QC3BMEB5AA4wYt/VP0qS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "PasswordHash",
                value: "$2a$11$2D8.m89ErFZ7gvprEZA6L.dA3ogPp3U0zEHHWvGMrJP7bC.culATy");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "PasswordHash",
                value: "$2a$11$h6DuklFzdjC4IohAHIexnO.hsFw48N989KQfJkXK1y1DDZCWbvgYG");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_PostId",
                table: "Comments",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_PostId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_PostId",
                table: "Comments");

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
    }
}
