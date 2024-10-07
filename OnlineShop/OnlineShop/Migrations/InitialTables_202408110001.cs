using FluentMigrator;

namespace OnlineShop.Data.Migrations
{
    [Migration(202408110001)]
    public class InitialTables_202408110001 : Migration
    {
        public override void Down()
        {
        }

        public override void Up()
        {
            Execute.Sql(@"
            CREATE PROCEDURE CreateManufacturer
              @ManufacturerName nvarchar(255),
              @ManufacturerEDRPOU nvarchar(10)
             AS
             BEGIN
              DECLARE @InsertedManufacturer TABLE (
               ManufacturerID int,
               ManufacturerName nvarchar(255),
               ManufacturerEDRPOU nvarchar(10)
              );

              INSERT INTO Manufacturer (ManufacturerName, ManufacturerEDRPOU)
              OUTPUT INSERTED.ManufacturerID, INSERTED.ManufacturerName, INSERTED.ManufacturerEDRPOU
              INTO @InsertedManufacturer
              VALUES (@ManufacturerName, @ManufacturerEDRPOU);

              SELECT * FROM @InsertedManufacturer;
            END;
            GO

            CREATE PROCEDURE GetManufacturerByID
              @ManufacturerID int
             AS
            BEGIN
              SELECT ManufacturerID, ManufacturerName, ManufacturerEDRPOU
              FROM Manufacturer
              WHERE ManufacturerID = @ManufacturerID;
            END;
            GO

            CREATE PROCEDURE GetManufacturerByName
              @ManufacturerName nvarchar(255)
             AS
            BEGIN
              SELECT ManufacturerID, ManufacturerName, ManufacturerEDRPOU
              FROM Manufacturer
              WHERE ManufacturerName LIKE '%' + @ManufacturerName + '%';
            END;
            GO

            CREATE PROCEDURE GetManufacturerByCode
              @ManufacturerEDRPOU nvarchar(10)
             AS
            BEGIN
              SELECT ManufacturerID, ManufacturerName, ManufacturerEDRPOU
              FROM Manufacturer
              WHERE ManufacturerEDRPOU LIKE '%' + @ManufacturerEDRPOU + '%';
            END;
            GO

            CREATE PROCEDURE UpdateManufacturerName
	          @ManufacturerID int,
	          @ManufacturerName nvarchar(255)
            AS
            BEGIN
		        UPDATE Manufacturer
		        SET 
			        ManufacturerName = @ManufacturerName
		        WHERE 
			        ManufacturerID = @ManufacturerID;

	           SELECT ManufacturerID, ManufacturerName, ManufacturerEDRPOU
	           FROM Manufacturer
	           WHERE ManufacturerID = @ManufacturerID;
            END;
            GO

            CREATE PROCEDURE UpdateManufacturerEDRPOU
	          @ManufacturerID int,
	          @ManufacturerEDRPOU nvarchar(10)
            AS
            BEGIN
		        UPDATE Manufacturer
		        SET 
			        ManufacturerEDRPOU = @ManufacturerEDRPOU
		        WHERE 
			        ManufacturerID = @ManufacturerID;

	           SELECT ManufacturerID, ManufacturerName, ManufacturerEDRPOU
	           FROM Manufacturer
	           WHERE ManufacturerID = @ManufacturerID;
            END;
            GO

            CREATE PROCEDURE DeleteManufacturerByID
              @ManufacturerID int
            AS
            BEGIN
              IF EXISTS (SELECT 1 FROM Manufacturer WHERE ManufacturerID = @ManufacturerID)
              DELETE FROM Manufacturer
              WHERE ManufacturerID = @ManufacturerID;
            END;
            GO

            CREATE PROCEDURE GetAllManufacturersWithProducts
            AS
            BEGIN
              SELECT m.*, p.* FROM Manufacturer m
              JOIN Product p ON p.ManufacturerID=m.ManufacturerID
            END
            GO
        ");
        }
    }
}