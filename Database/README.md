# Salon Database

## Phsical Database Design
<hr>

[Physical Design](PhysicalDesign.md)

<hr>

### Drop and Create Database

```sql
USE master;
GO

DROP DATABASE IF EXISTS Salon;

CREATE DATABASE Salon;
GO

USE Salon;
GO

CREATE SCHEMA Products AUTHORIZATION dbo;
GO
CREATE SCHEMA Sales AUTHORIZATION dbo;
GO

```
### Customers Table
```sql
CREATE TABLE Sales.Customers
(
	CustID		INT		NOT NULL IDENTITY,
	CustomerName	NVARCHAR(50)	NOT NULL,
	PhoneNumber	NVARCHAR(24)	NOT NULL,
	BirthDate	DATE		NULL, 
	StreetAddress	NVARCHAR(50)	NOT NULL,
	City		NVARCHAR(50)	NOT NULL,
	Region		NVARCHAR(50)	NULL,
	ZipCode		INT		NOT NULL,
	Country		NVARCHAR(50)	NOT NULL,
	Email		NVARCHAR(50)	NOT NULL,
	Password	NVARCHAR(50)	NOT NULL,

 CONSTRAINT PK_Customers PRIMARY KEY (CustID), 
 CONSTRAINT UC_Email UNIQUE (Email),
 ) 
GO

CREATE NONCLUSTERED INDEX idx_nc_City     
	ON Sales.Customers(City);
CREATE NONCLUSTERED INDEX idx_nc_ZipCode  
	ON Sales.Customers(ZipCode);

INSERT INTO Sales.Customers(Email, Password, CustomerName, PhoneNumber, BirthDate, StreetAddress, City, Region, ZipCode, Country)
  VALUES(N'SaraDavis@hotmail.com', N'939685843', N'Davis, Sara', N'(206) 555-0101', '19681208', N'7890 - 20th Ave. E., Apt. 2A', N'Seattle', N'WA', 10003, N'USA');

```
### Customers Payment Table
```sql
CREATE TABLE Sales.CustomerPayment
(
	PayID			INT		NOT NULL IDENTITY,
	CustID			INT		NOT NULL,
	CardType		NVARCHAR(50)	NULL,
	FinancalInstitusion 	NVARCHAR(50)	NOT NULL,
	AccountNumber		INT		NOT NULL,
	BillingAddress		NVARCHAR(50)	NOT NULL,
	City			NVARCHAR(50)	NOT NULL,
	Region			NVARCHAR(50)	NULL,
	ZipCode			INT		NOT NULL,
	Country			NVARCHAR(50)	NOT NULL,

 CONSTRAINT PK_CustomerPayment PRIMARY KEY (PayID),
 CONSTRAINT FK_CustomerPayment_Customers FOREIGN KEY (CustID)
    REFERENCES Sales.Customers (CustID),
)
GO  

CREATE NONCLUSTERED INDEX idx_nc_ZipCode  
	ON Sales.CustomerPayment(ZipCode);
	
INSERT INTO Sales.CustomerPayment(CustID, CardType, FinancalInstitusion, AccountNumber, BillingAddress, City, Region, ZipCode, Country)
  VALUES(1, N'VISA', N'Wells Fargo', 63584219, N'7890 - 20th Ave. E., Apt. 2A', N'Seattle', N'WA', 10003, N'USA');

```
### Orders Table
```sql
CREATE TABLE Sales.Orders
(
	OrderID		INT	NOT NULL IDENTITY,
	CustID		INT	NOT NULL,
	PayID		INT	NOT NULL,
	OrderDate	DATE	NOT NULL,
	ShippedDate	DATE	NULL,
	Freight		MONEY	NOT NULL
		CONSTRAINT DFT_Orders_Freight DEFAULT(0),

 CONSTRAINT PK_Orders PRIMARY KEY (OrderID),
 CONSTRAINT FK_Orders_Customers FOREIGN KEY (CustID)
    REFERENCES Sales.Customers (CustID),
 CONSTRAINT FK_Orders_CustomerPayment FOREIGN KEY (PayID)
    REFERENCES Sales.CustomerPayment (PayID),
 CONSTRAINT CHK_OrderDate CHECK(OrderDate <= CAST(SYSDATETIME() AS DATE))
)
GO

CREATE NONCLUSTERED INDEX idx_nc_CustID         
	ON Sales.Orders(CustID);
CREATE NONCLUSTERED INDEX idx_nc_OrderDate      
	ON Sales.Orders(OrderDate);
CREATE NONCLUSTERED INDEX idx_nc_ShippedDate    
	ON Sales.Orders(ShippedDate);

INSERT INTO Sales.Orders(CustID, PayID, OrderDate, ShippedDate, Freight)
  VALUES(1, 1, '20190621', '20190705', 70.00);
  
```
### Product Categories Table
```sql
CREATE TABLE Products.Categories
(
	CtgyID		INT		NOT NULL IDENTITY,
	Category	NVARCHAR(50)	NOT NULL,
	Description	NVARCHAR(50)	NULL,

 CONSTRAINT PK_Categories PRIMARY KEY (CtgyID),
)
GO

INSERT INTO Products.Categories(Category, Description)
  VALUES(N'Hair Products', N'Products related to hair care.');
INSERT INTO Products.Categories(Category, Description)
  VALUES(N'Make-Up Products', N'Make-Up products for the face.');

```
### Product SubCategories Table
```sql
CREATE TABLE Products.SubCategories
(
	SubCtgyID	INT		NOT NULL IDENTITY,
	CtgyID		INT		NOT NULL,
	SubCategory	NVARCHAR(50)	NOT NULL,
	Description	NVARCHAR(50)	NOT NULL,

 CONSTRAINT PK_SubCategories PRIMARY KEY (SubCtgyID),
 CONSTRAINT FK_SubCategories_Categories FOREIGN KEY (CtgyID)
    REFERENCES Products.Categories (CtgyID),
)
GO

INSERT INTO Products.SubCategories(CtgyID, SubCategory, Description)
  VALUES(1, N'Shampoo', N'Shampoo from multipul brands');
INSERT INTO Products.SubCategories(CtgyID, SubCategory, Description)
  VALUES(1, N'Conditioner', N'Conditioner from multipul brands');
INSERT INTO Products.SubCategories(CtgyID, SubCategory, Description)
  VALUES(2, N'Eye Liner', N'Eye Liner from multipul brands');

```
### Products Table
```sql
CREATE TABLE Products.Product
(
	ProductID	INT		NOT NULL IDENTITY,
	SubCtgyID	INT		NOT NULL,
	CtgyID		INT		NOT NULL,
	ProductName     NVARCHAR(20)	NOT NULL,
	BrandName	NVARCHAR(50)	NOT NULL,
	Description	NVARCHAR(200)	NOT NULL,
	UnitPrice	MONEY		NOT NULL 
		CONSTRAINT DFT_Product_UnitPrice DEFAULT(0),
	Discount	NUMERIC(4, 3)	NOT NULL
		CONSTRAINT DFT_Product_Discount DEFAULT(0),

 CONSTRAINT PK_Product PRIMARY KEY (ProductID),
 CONSTRAINT FK_Product_SubCategories FOREIGN KEY (SubCtgyID)
    REFERENCES Products.SubCategories (SubCtgyID),
 CONSTRAINT FK_Product_Catagories FOREIGN KEY (CtgyID)
    REFERENCES Products.Categories (CtgyID),
)
GO

CREATE NONCLUSTERED INDEX idx_nc_CtgyID 
	ON Products.Product(CtgyID);
CREATE NONCLUSTERED INDEX idx_nc_ProductID	
	ON Products.Product(ProductID);

INSERT INTO Products.Product(SubCtgyID, CtgyID, ProductName, BrandName, unitprice, Description, Discount)
  VALUES(1, 1, N'LaShDy', N'LANZA', 30.00, N'Dry spray in Shampoo', 0);			    
INSERT INTO Products.Product(SubCtgyID, CtgyID, ProductName, BrandName, unitprice, Description, Discount)
  VALUES(2, 1, N'RCrES', N'REDKEN', 25.00, N'Extreme Strengthening Conditioner', 0);			    
INSERT INTO Products.Product(SubCtgyID, CtgyID, ProductName, BrandName, unitprice, Description, Discount)
  VALUES(4, 2, N'GrdeLMd', N'GRANDE COSMETICS', 65.00, N'Lash-MD Lash Enhancing', 0);	    

```
### Orders Details table
```sql
CREATE TABLE Sales.OrderDetails
(
	OrderID			INT		NOT NULL,
	ProductID		INT		NOT NULL,
	UnitPrice		MONEY		NOT NULL
		CONSTRAINT DFT_OrderDetails_UnitPrice DEFAULT(0),
	Qty			INT		NOT NULL
		CONSTRAINT DFT_OrderDetails_Quantity DEFAULT(1),
	Discount		NUMERIC(4, 3)	NULL
		CONSTRAINT DFT_OrderDetails_Discount DEFAULT(0),
	ShippingAddress		NVARCHAR(50)	NOT NULL,
	City			NVARCHAR(50)	NOT NULL,
	Region			NVARCHAR(50)	NULL,
	ZipCode			INT		NOT NULL,
	Country			NVARCHAR(50)	NOT NULL,

  CONSTRAINT PK_OrderDetails PRIMARY KEY(OrderID, ProductID),
  CONSTRAINT FK_OrderDetails_Orders FOREIGN KEY(OrderID)
    REFERENCES Sales.Orders(OrderID),
  CONSTRAINT FK_OrderDetails_Product FOREIGN KEY(ProductID)
    REFERENCES Products.Product(ProductID),
  CONSTRAINT CHK_Discount   CHECK (Discount BETWEEN 0 AND 1),
  CONSTRAINT CHK_Qty	    CHECK (Qty > 0),
  CONSTRAINT CHK_Unitprice  CHECK (Unitprice >= 0)
)
 GO
 
CREATE NONCLUSTERED INDEX idx_nc_OrderID	
	ON Sales.OrderDetails(OrderID);
CREATE NONCLUSTERED INDEX idx_nc_ProductID	
	ON Sales.OrderDetails(ProductID);
CREATE NONCLUSTERED INDEX idx_nc_ZipCode	
	ON Sales.OrderDetails(ZipCode);

INSERT INTO Sales.OrderDetails(OrderID, ProductID, UnitPrice, Qty, Discount, ShippingAddress, City, Region, ZipCode, Country)
  VALUES(1, 4, 35.00, 1, 0.00, N'7890 - 20th Ave. E., Apt. 2A', N'Seattle', N'WA', 10003, N'USA');
INSERT INTO Sales.OrderDetails(OrderID, ProductID, UnitPrice, Qty, Discount, ShippingAddress, City, Region, ZipCode, Country)
  VALUES(1, 9, 35.00, 1, 0.00, N'7890 - 20th Ave. E., Apt. 2A', N'Seattle', N'WA', 10003, N'USA');
INSERT INTO Sales.OrderDetails(OrderID, ProductID, UnitPrice, Qty, Discount, ShippingAddress, City, Region, ZipCode, Country)
  VALUES(4, 30, 22.00, 1, 0.00, N'7890 - 20th Ave. E., Apt. 2A', N'Seattle', N'WA', 10003, N'USA');
INSERT INTO Sales.OrderDetails(OrderID, ProductID, UnitPrice, Qty, Discount, ShippingAddress, City, Region, ZipCode, Country)
  VALUES(4, 31, 23.00, 1, 0.00, N'7890 - 20th Ave. E., Apt. 2A', N'Seattle', N'WA', 10003, N'USA');

```

Images
Format: ![Alt Text](url)

Headers
# This is an <h1> tag
## This is an <h2> tag
###### This is an <h6> tag
  
Emphasis
*This text will be italic*
_This will also be italic_
**This text will be bold**
__This will also be bold__
_You **can** combine them_

Lists
Unordered
* Item 1
* Item 2
  * Item 2a
  * Item 2b
Ordered
1. Item 1
1. Item 2
1. Item 3
   1. Item 3a
   1. Item 3b
