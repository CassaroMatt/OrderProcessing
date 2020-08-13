using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderProcessing.Migrations
{
    public partial class order_employee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeID",
                table: "Order",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Order_EmployeeID",
                table: "Order",
                column: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Employee_EmployeeID",
                table: "Order",
                column: "EmployeeID",
                principalTable: "Employee",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Employee_EmployeeID",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_EmployeeID",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "EmployeeID",
                table: "Order");
        }
    }
}
