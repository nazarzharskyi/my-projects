using FluentMigrator;

namespace OnlineShop.Data.Migrations
{
    [Migration(202407020001)]
    public class InitialTables_202407020001 : Migration
    {
        public override void Down()
        {
            Delete.Table("Buyer");
            Delete.Table("DiscountCards");
            Delete.Table("Manufacturer");
            Delete.Table("Supplier");
            Delete.Table("Product");
            Delete.Table("Stocks");
            Delete.Table("OrderSupply");
        }
        public override void Up()
        {
            Execute.Sql(@"USE OnlineShop;");
            Create.Table("Buyer")
                .WithColumn("BuyerID").AsInt64().Identity().NotNullable().PrimaryKey()
                .WithColumn("BuyerEmail").AsString(75);

            Create.Table("DiscountCards")
                .WithColumn("CardId").AsInt64().Identity().NotNullable().PrimaryKey()
                .WithColumn("PercantageDiscount").AsFloat()
                .WithColumn("BuyerID").AsInt64().ForeignKey("FK_Product_Buyer", "Buyer", "BuyerID");

            Create.Table("Manufacturer")
                .WithColumn("ManufacturerID").AsInt64().Identity().NotNullable().PrimaryKey()
                .WithColumn("ManufacturerName").AsString(255)
                .WithColumn("ManufacturerEDRPOU").AsString(10);

            Create.Table("Supplier")
                .WithColumn("SupplierID").AsInt64().Identity().NotNullable().PrimaryKey()
                .WithColumn("SupplierName").AsString(255)
                .WithColumn("SupplierEDRPOU").AsString(10);

            Create.Table("Product")
                .WithColumn("ProductID").AsInt64().Identity().NotNullable().PrimaryKey()
                .WithColumn("ProductName").AsString(255)
                .WithColumn("ProductCategoryID").AsInt64()
                .WithColumn("ManufacturerID").AsInt64().ForeignKey("FK_Product_Manufacturer", "Manufacturer", "ManufacturerID")
                .WithColumn("SupplierID").AsInt64().ForeignKey("FK_Product_Supplier", "Supplier", "SupplierID")
                .WithColumn("ProductPrice").AsDecimal(10, 2);

            Create.Table("Stocks")
                .WithColumn("StockItemId").AsInt64().Identity().NotNullable().PrimaryKey()
                .WithColumn("ProductAmount").AsInt64()
                .WithColumn("ProductID").AsInt64().ForeignKey("FK_Stocks_Product", "Product", "ProductID");

            Create.Table("OrderSupply")
                .WithColumn("SupplyOrderId").AsInt64().Identity().NotNullable().PrimaryKey()
                .WithColumn("SupplierID").AsInt64().ForeignKey("FK_OrderSupply_Supplier", "Supplier", "SupplierID")
                .WithColumn("ProductId").AsInt64().ForeignKey("FK_OrderSupply_Product", "Product", "ProductID")
                .WithColumn("ProductAmount").AsInt64()
                .WithColumn("OrderTime").AsDateTime();
                //.WithColumn("EmployeeId").AsInt64().ForeignKey("FK_OrderSupply_Employee", "Employee", "EmployeeID");
        }
    }
}
