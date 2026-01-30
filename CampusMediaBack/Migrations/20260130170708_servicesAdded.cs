using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampusMediaBack.Migrations
{
    /// <inheritdoc />
    public partial class servicesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$pipT1jjUDXBbYvIdK5zN2.eNUSlWMusDVqNh8WeuxP5JIdUmFO6dO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$k6sZ0Z9EJ4L/Pu0TvCyLcOxQom1JzRc7TujiisOWTdfqTvAlVDrjO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$plk0QtsV4CQc8q9ikNtyJ.UTVPzFkZlxpDnpXE4zwM/huGXeu5wSu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "$2a$11$Je54WUXKlMLabcToDNBfheU0SvXyBM6V2AAj7znI58mXem2kVIJ9y");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "PasswordHash",
                value: "$2a$11$H0pxHbpKB4TWsnH7RWo.Yen4AcppNA0hiKJskTZx8jXcbOmkOLeF2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "PasswordHash",
                value: "$2a$11$u7pVSOLy8x68od3YHyzJxOJ81g87AJ3TWmrrU984MvNMBF7AI70B.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "PasswordHash",
                value: "$2a$11$3u5i3ue/MFfRP7sBWW2VLuCBfFogWpvaxe23Kcq6tUVZqxMpEMDHO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "PasswordHash",
                value: "$2a$11$FZKvBmAmmFQ.UROSh4tn1uS10RKjfnXx5rMh5LbwbkDvWDJ7Lvxey");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "PasswordHash",
                value: "$2a$11$ZHm7VXisHL27CYGftSEMvuevap42SgINdkFIdENfPq5DlneM17xL.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "PasswordHash",
                value: "$2a$11$2j5DftVjeJa2M1T7EybUBuoIXl/EPRtgAEjBMvKk/xmBEsOM3VgcK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$Kzn31IcboE1zmS..8pvMmOCulCo27yQkyynGfZbLctkvjf/2vVlM.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$Aixk/gNxGC12wYRDYpalzeub4VHMjX/.iuFmzOn8VcROWAfFkwtKa");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$srxOHoWWcc6hdNwE1AYgPeMsSZ2E88k8Csj8ZZhsgmId2gHWZF.LS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "$2a$11$lksQWAKJyr.IwcPcExctGutQaGOO2uJlJvTlBxPe/GYjMtlYy5xPa");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "PasswordHash",
                value: "$2a$11$PgNHj.fCKmWhFrMqbaY4R.JY6RGc2CvPKfqvOTuN.eE/waZ6eGLum");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "PasswordHash",
                value: "$2a$11$GsQJUNW1AUlXzJ3vbxBmdunJQERhFgoZXBcauBsp1GpqtWo0lmAMe");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "PasswordHash",
                value: "$2a$11$wOctn8dFj3SKmexbszvCQOZgXARXuoSzQxzoP43TlHKi8ozoQRgve");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "PasswordHash",
                value: "$2a$11$F8OIElJwE5GkdmvX5ddjmOzpox03f5nGpA/UZKUd7FpnhkaxMCfv.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "PasswordHash",
                value: "$2a$11$T65X4vG13WLlszhO0gX9F.UkjZcbxrxnISEWjrnlXZP3JNnh1C.Fe");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "PasswordHash",
                value: "$2a$11$OVayAJeFU2036ofiHOo.1uiKKnCQO/w.UwgofsH6Q0NNJN5B5fFi2");
        }
    }
}
