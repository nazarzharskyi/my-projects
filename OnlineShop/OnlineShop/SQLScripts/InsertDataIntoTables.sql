-- N is used before string values ​​to indicate that it is a Unicode string
USE OnlineShop;
INSERT INTO Manufacturer (ManufacturerName, ManufacturerEDRPOU) VALUES
(N'Norven', '1234567890'),
(N'Хладик', '2345678901'),
(N'Hankey Bannister', '3456789012'),
(N'Ariel', '4567890123'),
(N'Philadelphia', '5678901234'),
(N'Крафт', '5678901235'),
(N'Bells', '3456789012');

GO

INSERT INTO Supplier (SupplierName, SupplierEDRPOU) VALUES
(N'Supplier A', '1234509876'),
(N'Supplier B', '2345609871'),
(N'Supplier C', '3456709812'),
(N'Supplier D', '4567809123'),
(N'Supplier E', '5678901230'),
(N'Supplier F', '5678901231');
GO

INSERT INTO Product (ProductName, ProductCategoryID, ManufacturerID, SupplierID, ProductPrice) VALUES
(N'Сьомга філе слабосолена', 1, 1, 1, 10.50),
(N'Морозиво шоколадне', 2, 2, 2, 15.99),
(N'Морозиво пломбір', 2, 2, 2, 15.99),
(N'Віреники з картоплею', 3, 2, 2, 85.00),
(N'Віскі Original', 1, 3, 3, 299.00),
(N'Віскі Original', 1, 7, 3, 59.00),
(N'Гель для прання Color', 2, 4, 4, 289.00),
(N'Гель для прання White', 2, 4, 4, 289.00),
(N'Сир Philadelphia оригінальний', 1, 5, 5, 99.00);
GO

INSERT INTO Buyer (BuyerEmail) VALUES
('abc@gmail.com'),
('nick@gmail.com'),
('admins@gmail.com'),
('nicky@gmail.com'),
('ans@gmail.com');
GO

INSERT INTO DiscountCards (PercantageDiscount, BuyerID) VALUES
(8.5, 1),
(5.5, 2),
(15.5, 3),
(50, 4),
(3.5, 5);
GO

INSERT INTO Stocks(ProductAmount, ProductId) VALUES
(15, 1),
(10, 3),
(31, 5),
(2, 2),
(12, 4);
GO

INSERT INTO OrderSupply(SupplierID, ProductId, ProductAmount, OrderTime) VALUES
(1, 2, 15, '2024-06-26 18:05:23'),
(1, 3, 10, '2024-06-29 19:07:23'),
(3, 1, 12, '2024-06-30 12:07:35'),
(2, 2, 95, '2024-07-4 13:09:32'),
(2, 5, 45, '2024-06-9 21:10:39');
GO