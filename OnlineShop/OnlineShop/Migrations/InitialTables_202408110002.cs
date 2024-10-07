using FluentMigrator;

namespace OnlineShop.Data.Migrations
{
    [Migration(202408110002)]
    public class InitialTables_202408110002 : Migration
    {
        public override void Down()
        {
        }

        public override void Up()
        {
            Execute.Sql(@"
            CREATE PROCEDURE CreateProduct
              @ProductName nvarchar(255),
              @ProductCategoryID int,
              @ManufacturerID int,
              @SupplierID int,
              @ProductPrice decimal(10, 2)

             AS
             BEGIN
              DECLARE @InsertedProduct TABLE (
              ProductName nvarchar(255),
              ProductCategoryID int,
              ManufacturerID int,
              SupplierID int,
              ProductPrice decimal(10, 2)
              );

              INSERT INTO Product (ProductName, ProductCategoryID, ManufacturerID, SupplierID, ProductPrice)
              OUTPUT INSERTED.ProductName, INSERTED.ProductCategoryID, INSERTED.ManufacturerID, INSERTED.SupplierID, INSERTED.ProductPrice
              INTO @InsertedProduct
              VALUES (@ProductName, @ProductCategoryID, @ManufacturerID, @SupplierID, @ProductPrice);

              SELECT * FROM @InsertedProduct;
            END;
            GO

            CREATE PROCEDURE GetProductByID
              @ProductID int
             AS
            BEGIN
              SELECT *
              FROM Product
              WHERE ProductID = @ProductID;
            END;
            GO

            CREATE PROCEDURE GetProductByName
              @ProductName nvarchar(255)
             AS
            BEGIN
              SELECT ProductID, ProductName, ProductPrice
              FROM Product
              WHERE ProductName LIKE '%' + @ProductName + '%';
            END;
            GO

            CREATE PROCEDURE UpdateProductName
	          @ProductID int,
	          @ProductName nvarchar(255)
            AS
            BEGIN
		        UPDATE Product
		        SET 
			        ProductName = @ProductName
		        WHERE 
			        ProductID = @ProductID;

	           SELECT ProductID, ProductName, ProductPrice
	           FROM Product
	           WHERE ProductID = @ProductID;
            END;
            GO

            CREATE PROCEDURE UpdateProductCategory
	          @ProductID int,
	          @ProductCategoryID int
            AS
            BEGIN
		        UPDATE Product
		        SET 
			        ProductCategoryID = @ProductCategoryID
		        WHERE 
			        ProductID = @ProductID;

	           SELECT ProductID, ProductName, ProductPrice
	           FROM Product
	           WHERE ProductID = @ProductID;
            END;
            GO

            CREATE PROCEDURE UpdateProductManufacturerID
	          @ProductID int,
	          @ManufacturerID int
            AS
            BEGIN
		        UPDATE Product
		        SET 
			        ManufacturerID = @ManufacturerID
		        WHERE 
			        ProductID = @ProductID;

	           SELECT ProductID, ProductName, ProductPrice, ManufacturerID
	           FROM Product
	           WHERE ProductID = @ProductID;
            END;
            GO

            CREATE PROCEDURE UpdateProductSupplierID
	          @ProductID int,
	          @SupplierID int

            AS
            BEGIN
		        UPDATE Product
		        SET 
			        SupplierID = @SupplierID
		        WHERE 
			        ProductID = @ProductID;

	           SELECT ProductID, ProductName, ProductPrice, ManufacturerID, SupplierID
	           FROM Product
	           WHERE ProductID = @ProductID;
            END;
            GO


            CREATE PROCEDURE UpdateProductProductPrice
	          @ProductID int,
	          @ProductPrice int
            AS
            BEGIN
		        UPDATE Product
		        SET 
			        ProductPrice = @ProductPrice
		        WHERE 
			        ProductID = @ProductID;

	           SELECT ProductID, ProductName, ProductPrice, ManufacturerID, SupplierID
	           FROM Product
	           WHERE ProductID = @ProductID;
            END;
            GO

            CREATE PROCEDURE DeleteProductByID
              @ProductID int
            AS
            BEGIN
              IF EXISTS (SELECT 1 FROM Product WHERE ProductID = @ProductID)
              DELETE FROM Product
              WHERE ProductID = @ProductID;
            END;
            GO
        ");
        }
    }
}