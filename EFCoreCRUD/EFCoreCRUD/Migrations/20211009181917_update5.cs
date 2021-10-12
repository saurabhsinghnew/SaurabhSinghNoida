using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreCRUD.Migrations
{
    public partial class update5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "varchar=50",
                schema: "dbo",
                table: "Employees",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                schema: "dbo",
                table: "Employees",
                type: "varchar(250)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "Employees",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                schema: "dbo",
                table: "Employees",
                type: "varchar(250)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                schema: "dbo",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "dbo",
                table: "Employees",
                newName: "varchar=50");

            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                schema: "dbo",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(250)");

            migrationBuilder.AlterColumn<string>(
                name: "varchar=50",
                schema: "dbo",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");
        }
    }
}
