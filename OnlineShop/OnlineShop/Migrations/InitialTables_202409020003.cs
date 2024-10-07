using FluentMigrator;

namespace OnlineShop.Data.Migrations
{
    [Migration(202409020003)]
    public class InitialTables_202409020003 : Migration
    {
        public override void Down()
        {
            Execute.Sql("DROP PROCEDURE IF EXISTS CreateProductOnStock");
            Execute.Sql("DROP PROCEDURE IF EXISTS GetAmountByStockItemID");
            Execute.Sql("DROP PROCEDURE IF EXISTS UpdateOfAmount");
        }

        public override void Up()
        {
            Execute.Sql(@"
                CREATE PROCEDURE CreateProductOnStock
                    @ProductID int,
                    @ProductAmount int, 
                    @StockItemID int
                AS
                BEGIN
                    DECLARE @InsertedProduct TABLE(
                        ProductID int,
                        ProductAmount int,
                        StockItemID int
                    )
                    INSERT INTO Stocks(ProductID, ProductAmount, StockItemID)
                    OUTPUT INSERTED.ProductID, INSERTED.ProductAmount, INSERTED.StockItemID
                    INTO @InsertedProduct
                    VALUES(@ProductID, @ProductAmount, @StockItemID)
                    SELECT * FROM @InsertedProduct
                END
                GO

                CREATE PROCEDURE GetAmountByStockItemID
                    @StockItemID int
                AS
                BEGIN
                    SELECT * FROM Stocks WHERE StockItemId = @StockItemID
                END
                GO

                CREATE PROCEDURE UpdateOfAmount
                    @ProductID int,
                    @ProductAmount int,
                    @StockItemID int
                AS
                BEGIN
                    UPDATE Stocks
                    SET
                        ProductAmount = @ProductAmount
                    WHERE
                        StockItemId = @StockItemID
                    SELECT StockItemId, ProductAmount, ProductID 
                    FROM Stocks 
                    WHERE StockItemId = @StockItemID
                END
                GO
            ");
        }
    }
}