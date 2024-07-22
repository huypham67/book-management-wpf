using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObjects.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderDetailViewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW OrderDetailView AS
                                    SELECT 
                                        o.OrderId,
                                        o.OrderDate,
                                        u.FullName AS CustomerName,
                                        SUM(od.Quantity) AS Quantity,
                                        SUM(od.Quantity * od.UnitPrice) AS TotalPrice,
                                        o.OrderStatus
                                    FROM 
                                        Orders o
                                    INNER JOIN 
                                        OrderDetails od ON o.OrderId = od.OrderId
                                    INNER JOIN 
                                        Users u ON o.UserId = u.UserId
                                    GROUP BY
                                        o.OrderId,
                                        o.OrderDate,
                                        u.FullName,
                                        o.OrderStatus;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW [dbo].OrderDetailView");
        }
    }
}
