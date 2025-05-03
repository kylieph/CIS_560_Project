USE master;

IF SCHEMA_ID('Store') IS NULL
EXEC (N'CREATE SCHEMA [Store];');
GO
DROP TABLE IF EXISTS Store.Cart;
DROP TABLE IF EXISTS Store.OrderLines;
DROP TABLE IF EXISTS Store.Orders;
DROP TABLE IF EXISTS Store.UserMailingAddress;
DROP TABLE IF EXISTS Store.MailingAddress;
DROP TABLE IF EXISTS Store.Items;
DROP TABLE IF EXISTS Store.Goldsmith;
DROP TABLE IF EXISTS Store.Categories;
DROP TABLE IF EXISTS Store.MetalTypes;
DROP TABLE IF EXISTS Store.[User];

/*Create Tables*/
CREATE TABLE Store.[User]
(
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    Email NVARCHAR(225) NOT NULL UNIQUE,
    Username NVARCHAR(100) NOT NULL UNIQUE,
    NormPassword NVARCHAR(100) NOT NULL,
    HashPassword NVARCHAR(255) NOT NULL,
    CustomerName NVARCHAR(100) NOT NULL,
    PhoneNumber NVARCHAR(20),
    IsAdmin BIT NOT NULL DEFAULT 0,
    AccountOpenedDate DATETIME NOT NULL
); 

CREATE TABLE Store.Orders
(
    OrderID INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT NOT NULL FOREIGN KEY REFERENCES Store.[User](UserID),
    OrderDate DATETIME NOT NULL DEFAULT SYSDATETIME()
);

CREATE TABLE Store.OrderLines
(
    OrderLineID INT IDENTITY(1,1) PRIMARY KEY,
    OrderID INT NOT NULL FOREIGN KEY REFERENCES Store.Orders(OrderID),
    StockItemID INT NOT NULL,
    Quantity INT NOT NULL CHECK (Quantity > 0),
    UnitPrice DECIMAL(10,2) NOT NULL CHECK (UnitPrice >= 0)
);

CREATE TABLE Store.Goldsmith
(
    GoldsmithID INT IDENTITY(1,1) PRIMARY KEY,
    GoldsmithName NVARCHAR(100) NOT NULL UNIQUE,
    Quantity INT NOT NULL DEFAULT 0 CHECK (Quantity >= 0)

);

CREATE TABLE Store.Categories
(
    CategoryID INT IDENTITY(1,1) PRIMARY KEY,
    CategoryName NVARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE Store.MetalTypes
(
    MetalID INT IDENTITY(1,1) PRIMARY KEY,
    MetalName NVARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE Store.Items
(
    StockItemID INT IDENTITY(1,1) PRIMARY KEY,
    GoldsmithID INT NOT NULL FOREIGN KEY REFERENCES Store.Goldsmith(GoldsmithID),
    CategoryID INT NOT NULL FOREIGN KEY REFERENCES Store.Categories(CategoryID),
    MetalID INT NOT NULL FOREIGN KEY REFERENCES Store.MetalTypes(MetalID),
    ItemName NVARCHAR(100) NOT NULL,
    ItemPrice  DECIMAL(10,2) NOT NULL CHECK (ItemPrice >= 0),
    StockQuantity INT NOT NULL DEFAULT 0 CHECK (StockQuantity >= 0),
    ItemUpdatedDate DATETIME NOT NULL DEFAULT SYSDATETIME(),
    ItemReleaseDate DATETIME NOT NULL DEFAULT SYSDATETIME(),
    [Description] NVARCHAR(MAX)
);
CREATE TABLE Store.MailingAddress
(
    MailingAddressID INT IDENTITY(1,1) PRIMARY KEY,
    City NVARCHAR(100) NOT NULL,
    Zipcode NVARCHAR(10) NOT NULL,
    State NVARCHAR(50) NOT NULL,
    AddressLine NVARCHAR(255) NOT NULL
);

CREATE TABLE Store.UserMailingAddress
(
    MailingAddressID INT NOT NULL FOREIGN KEY REFERENCES Store.MailingAddress(MailingAddressID),
    UserID INT NOT NULL FOREIGN KEY REFERENCES Store.[User](UserID),
    PRIMARY KEY (MailingAddressID, UserID)
);

CREATE TABLE Store.Cart
(
    CartID INT IDENTITY(1, 1) PRIMARY KEY,
    UserID INT NOT NULL,
    StockItemID INT NOT NULL,
    Quantity INT NOT NULL DEFAULT 1
    CONSTRAINT FK_Cart_User FOREIGN KEY (UserID) REFERENCES Store.[User](UserID),
    CONSTRAINT FK_Cart_Item FOREIGN KEY (StockItemID) REFERENCES Store.Items(StockItemID),
    CONSTRAINT UQ_Cart_UserItem UNIQUE (UserID, StockItemID)
);