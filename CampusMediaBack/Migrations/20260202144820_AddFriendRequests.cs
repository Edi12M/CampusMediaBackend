using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampusMediaBack.Migrations
{
    /// <inheritdoc />
    public partial class AddFriendRequests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FriendRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    ReceiverId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FriendRequests_Users_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FriendRequests_Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$c4LzAlozRi4crZgR0K6lUe5iS.GULEq0S0peau3Bh3f3OYXyK33vW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$4uE.4u2GFTCHxICUvz2VXue43AgNygmidSg3WNkCI9H2CCV1tR2Wm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$iFEkXDZ4C80VhMipeu9MPuUvVkBekAfitXmTcnl1VvwPnEBULIVD6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "$2a$11$lnwtYvB8TrIFd8kn/hG.9.m16c4VBj1goIMoGr75MeLWdo8eKyExy");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "PasswordHash",
                value: "$2a$11$4sORazmhR.uWRMkkbFS4iu5gttxyr1R/AJ9sqCSH7ZY/rLvrlqca.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "PasswordHash",
                value: "$2a$11$qUX2Pun2mt4zDPgR/UQcRuWRssiBuLbXaEnrYh.MOuTF2Guvz0b6O");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "PasswordHash",
                value: "$2a$11$BPR7jN6SPXnxque7503Mj.OabiY9pVxv9e1kbN1wvUbM88UG6dce2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "PasswordHash",
                value: "$2a$11$rX6SDCaoolYCCTOIniXcsuYCAYLznm1qwTBf587klRLwFsjOLd7ma");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "PasswordHash",
                value: "$2a$11$05m9FKRSwd8tTmzbKCs05Oc7CQDFFk16vZUFAeRvqdK8ruVQDx3f2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "PasswordHash",
                value: "$2a$11$TwRbwqCFa1.oA/276cGJFOGYhmcSY.xM1OSCJIUgE.QkmSheRO9dS");

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequests_ReceiverId_Status",
                table: "FriendRequests",
                columns: new[] { "ReceiverId", "Status" });

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequests_SenderId_ReceiverId",
                table: "FriendRequests",
                columns: new[] { "SenderId", "ReceiverId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FriendRequests");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$kGEbSeLJdPMDl6sRceZ2lupjpsfyM8TFXOCY3ry3TuDNwu.ekwkF.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$9RI0mZhN3hR1FIrp4CMZY.kOtEaL0gR1hdjHVJMtfouVqYfRFpTEO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$Nw/VShvWhKF3bBJuC3OzKeBvuPmbESihpNI1N7.3JppwV3zLxNqnW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "$2a$11$CUicVMYN2UPN3bh66SDDt.KSa3mFogyH8Fyt9XlqK.dfXAx7vhpUy");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "PasswordHash",
                value: "$2a$11$NN6Ore3xPVs1opr7RyULeulTkKnklDvLNx1dIlX9LKzqQT9k1pdIS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "PasswordHash",
                value: "$2a$11$giXzLuZjhJiWUGwZTnqLGus.KzABPZ.6wU8/Hwv3uWtfDAvDBz4Nu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "PasswordHash",
                value: "$2a$11$qCMKmZZI53ytEbwXuwerTuCfWcN09dykP3Ee0Jnf2OXKtRT9AiSXu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "PasswordHash",
                value: "$2a$11$s.o9MxfGHrfw0mRpTEYJbeTHz2QI9WAEUAn4DCaOql6XpLla74Y8O");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "PasswordHash",
                value: "$2a$11$KOpEgH9uJ4VUc6qpavKZyu2ScnNGK9aKQAsZzLrbyhKPXSbnPxAE6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "PasswordHash",
                value: "$2a$11$j4VkWrLW/UJzTlN6HBfFYuKWXi4b9tmCdaB2CvIZpvctkxmuqa0pS");
        }
    }
}
