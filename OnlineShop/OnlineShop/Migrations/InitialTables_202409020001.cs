using FluentMigrator;

namespace OnlineShop.Data.Migrations
{
    [Migration(202409020001)]
    public class InitialTables_202409020001 : Migration
    {
        public override void Up()
        {
            Execute.Sql(@"
                CREATE PROCEDURE CreateCard
                    @PercantageDiscount decimal(5, 1),
                    @BuyerID int
                AS
                BEGIN
                    DECLARE @InsertedCard TABLE(
                        PercantageDiscount decimal(5, 1),
                        BuyerID int
                    )

                    INSERT INTO DiscountCards (PercantageDiscount, BuyerID)
                    OUTPUT INSERTED.PercantageDiscount, INSERTED.BuyerID
                    INTO @InsertedCard
                    VALUES(@PercantageDiscount, @BuyerID)

                    SELECT * FROM @InsertedCard;
                END
                GO

                CREATE PROCEDURE UpdateCardPercantage
                    @CardID int,
                    @PercantageDiscount decimal(5, 1)
                AS
                BEGIN
                    UPDATE DiscountCards
                    SET
                        PercantageDiscount = @PercantageDiscount
                    WHERE
                        CardId = @CardID
                    SELECT CardID, PercantageDiscount
                    FROM DiscountCards
                    WHERE CardId = @CardID
                END
                GO

                CREATE PROCEDURE GetDiscountCardByID
                    @CardID int
                AS
                BEGIN
                    SELECT * FROM DiscountCards WHERE CardId = @CardID
                END
                GO
            ");
        }

        public override void Down()
        {
            Execute.Sql("DROP PROCEDURE IF EXISTS CreateCard");
            Execute.Sql("DROP PROCEDURE IF EXISTS UpdateCardPercantage");
            Execute.Sql("DROP PROCEDURE IF EXISTS GetDiscountCardByID");
        }
    }
}