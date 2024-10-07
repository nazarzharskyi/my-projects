-- Make sure the database is not in use
USE master;
GO

-- Close all active connections to the OnlineShop database
IF EXISTS (SELECT name FROM sys.databases WHERE name = 'OnlineShop')
BEGIN
    ALTER DATABASE OnlineShop SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
END
GO


-- Delete the database
DROP DATABASE IF EXISTS OnlineShop;
GO

CREATE DATABASE OnlineShop
GO

USE OnlineShop;
GO

