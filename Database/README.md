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
	CustID			INT		NOT NULL IDENTITY,
	CustomerName		NVARCHAR(50)	NOT NULL,
	PhoneNumber		NVARCHAR(24)	NOT NULL,
	BirthDate		DATE		NULL, 
	StreetAddress		NVARCHAR(50)	NOT NULL,
	City			NVARCHAR(50)	NOT NULL,
	Region			NVARCHAR(50)	NULL,
	ZipCode			INT		NOT NULL,
	Country			NVARCHAR(50)	NOT NULL,
	Email			NVARCHAR(50)	NOT NULL,
	Password		NVARCHAR(50)	NOT NULL,

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
	PayID				INT		NOT NULL IDENTITY,
	CustID				INT		NOT NULL,
	CardType			NVARCHAR(50)	NULL,
	FinancalInstitusion 		NVARCHAR(50)	NOT NULL,
	AccountNumber			INT		NOT NULL,
	BillingAddress			NVARCHAR(50)	NOT NULL,
	City				NVARCHAR(50)	NOT NULL,
	Region				NVARCHAR(50)	NULL,
	ZipCode				INT		NOT NULL,
	Country				NVARCHAR(50)	NOT NULL,

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
