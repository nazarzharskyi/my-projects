using FluentMigrator;

namespace OnlineShop.Data.Migrations
{
    [Migration(202409020002)]
    public class InitialTables_202409020002 : Migration
    {
        public override void Up()
        {
            Execute.Sql(@"
                CREATE PROCEDURE MakeOrderOfSupply
                    @SupplierID int,
                    @ProductID int,
                    @ProductAmount int,
                    @OrderTime datetime
                AS
                BEGIN
                    DECLARE @InsertedOrder TABLE(
                    SupplierID int,
                    ProductId int,
                    ProductAmount int,
                    OrderTime datetime
                    )
                    INSERT INTO OrderSupply (SupplierID, ProductId, ProductAmount, OrderTime)
                    OUTPUT INSERTED.SupplierID, INSERTED.ProductId, INSERTED.ProductAmount, INSERTED.OrderTime
                    INTO @InsertedOrder
                    VALUES(@SupplierID, @ProductID, @ProductAmount, @OrderTime)
                    SELECT * FROM @InsertedOrder
                END
                GO

                CREATE PROCEDURE GetSupplyOrderByID
                    @SupplyID int
                AS
                BEGIN
                    SELECT * FROM OrderSupply WHERE SupplyOrderId = @SupplyID
                END
                GO
            ");
        }

        public override void Down()
        {
            Execute.Sql("DROP PROCEDURE IF EXISTS MakeOrderOfSupply");
            Execute.Sql("DROP PROCEDURE IF EXISTS GetSupplyOrderByID");
        }
    }
}