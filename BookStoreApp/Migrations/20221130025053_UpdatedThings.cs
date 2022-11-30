using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedThings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_CustomerContactDetails_ContactID",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_ContactID",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "ContactID",
                table: "Customer");

            migrationBuilder.AlterColumn<int>(
                name: "ContactID",
                table: "CustomerContactDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Lname",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Fname",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerContactDetails_Customer_ContactID",
                table: "CustomerContactDetails",
                column: "ContactID",
                principalTable: "Customer",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerContactDetails_Customer_ContactID",
                table: "CustomerContactDetails");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Customer");

            migrationBuilder.AlterColumn<int>(
                name: "ContactID",
                table: "CustomerContactDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Lname",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Fname",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "ContactID",
                table: "Customer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_ContactID",
                table: "Customer",
                column: "ContactID");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_CustomerContactDetails_ContactID",
                table: "Customer",
                column: "ContactID",
                principalTable: "CustomerContactDetails",
                principalColumn: "ContactID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
