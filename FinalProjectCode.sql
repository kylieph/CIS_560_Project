USE master; -- insert databse

/*Creating Schema*/

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






-- 100 ORDERS AND OVER 2 DOZEN PRODUCTS


INSERT INTO Store.[User] (Email, Username, NormPassword, HashPassword, CustomerName, PhoneNumber, IsAdmin, AccountOpenedDate) VALUES
('tsmith@yahoo.com', 'tim', 'fw8j22s', '$2a$11$O2ZqOQMWJakzskV6kikTuuOuO0YpSPCauuj.xSRgszUhOjk2AJ/5i', 'Tara Smith', '+1-063-591-160', 0, '2024-05-30'),
('maryfuen@yahoo.com', 'tom', 'eruw3fwm', '$2a$11$w8Vg0B.DlukEMSTp5O9/beleBB0WVWOwod3Kv8iCn/.dlKyrhdbAG', 'Mary Fuentes', '+1-368-588-997', 1, '2025-02-24'),
('vpeters@yahoo.com', 'vipeters', 'da7c89d5', '$2a$11$4JtmEcykbySNJirk5OHy0OPGobrX2/TKauCVTwWAIoPFvBR7PijAm', 'Virginia Peters', '+1-415-565-499', 1, '2025-04-10'),
('katielynn@yahoo.com', 'katiely', 'bn4v45dj', '$2a$11$swSubVnHAZQlKXkQfHQ0aeL35Ul7sgwGLKusjw1gQ66qV3VXx0ur6', 'Katie Lynn', '+1-578-456-321', 0, '2025-03-11' ),
('johnkeller@ksu.edu', 'john_keller', '5dcb2a37', '$2a$11$slDmv0yCg1WOX2pC.FoR/OY2abLsOKmLfQh76/6hUNrHGtP0YwAem', 'John Keller', '+1-234-567-890', 0, '2025-01-15'),
('emily.jones@hotmail.com', 'emilyjones', '2b98dfd9', '$2a$11$IJxEIO2EuZVI1zQBmBE6YuhMbmQwKSaMHcqEb1ixS73822VS.Z/X.', 'Emily Jones', '+1-345-678-901', 1, '2025-03-22'),
('michaelsmith@aol.com', 'michael_s', '7c3bb0ed', '$2a$11$S.qAwPjnFE6ehCIRufBIZ.aKmvsAbrBByOFmCqp5mSZg5buahdV8a', 'Michael Smith', '+1-456-789-012', 0, '2024-12-05'),
('lauracarter@gmail.com', 'laura_carter', '8f78e9b4', '$2a$11$euIDlHjmYFgyHYM6GRNBWevYBmutF9gGHCoB13syC6qt9I8YMUtlS', 'Laura Carter', '+1-567-890-123', 1, '2025-02-12'),
('danielkim@yahoo.com', 'dankim92', 'f04e2b73', '$2a$11$Ruw/vGPBIjZ.zbDsglvSKO2sh9sjI7Fj8x.Ft1zvUPnvsnYq.3dX.', 'Daniel Kim', '+1-678-901-234', 0, '2025-04-03'),
('susanlee@hotmail.com', 'suslee', '9acdd1fa', '$2a$11$R35Dj1g/jeJlwMeQ08bD4eLx9ur4smwRQlAFs0K6aQtLp24AsJ/Sy', 'Susan Lee', '+1-789-012-345', 1, '2024-11-18');

INSERT INTO Store.Goldsmith (GoldsmithName, Quantity) VALUES
('Rita Jarvis', 5),
('Steven Brewer', 11),
('Pamela Foster', 18),
('Jazmine Greene', 4);

INSERT INTO Store.Categories (CategoryName) VALUES
('Rings'),
('Earrings'),
('Bracelets'),
('Necklaces'),
('Anklets');

INSERT INTO Store.MetalTypes (MetalName) VALUES
('Gold'),
('Silver'),
('Bronze'),
('Rose Gold');

INSERT INTO Store.Items (GoldsmithID, CategoryID, MetalID, ItemName, ItemPrice, StockQuantity, ItemUpdatedDate, ItemReleaseDate, [Description]) VALUES
(1, 1, 1, 'Sunshine Gold Ring', 119.97, 98, '2024-11-01', '2025-03-01', 'Handcrafted gold ring with flower design'),
(2, 2, 2, 'Moonlight Silver Earrings', 211.54, 45, '2024-06-17', '2024-12-08', 'Elegant silver earrings with moonstone'),
(3, 3, 3, 'Starlight Bronze Bracelet', 291.30, 49, '2025-03-13', '2024-07-14', 'Chic bronze bracelet with gems'),
(1, 4, 1, 'Golden Dawn Necklace', 159.99, 25, '2025-02-15', '2024-03-01', 'A radiant necklace with golden rays design'),
(2, 1, 2, 'Silver Petal Ring', 99.95, 60, '2024-11-22', '2024-12-15', 'A floral-inspired silver ring'),
(3, 5, 4, 'Rose Gold Harmony Anklet', 84.50, 40, '2024-10-05', '2024-11-10', 'Simple and elegant bronze anklet'),
(4, 5, 1, 'Twilight Gold Anklet', 178.25, 20, '2024-09-01', '2024-09-10', 'Gold cuff bracelet with twilight theme'),
(1, 2, 2, 'Silver Blossom Studs', 73.00, 50, '2025-01-10', '2025-01-25', 'Stud earrings with flower engraving'),
(2, 4, 3, 'Earthbound Bronze Chain', 124.75, 30, '2025-03-05', '2025-03-20', 'Rustic bronze chain for casual wear'),
(3, 4, 2, 'Elegant Curve Necklace', 199.99, 18, '2024-12-15', '2025-01-01', 'Curved silver necklace for formal occasions'),
(4, 2, 1, 'Classic Gold Studs', 89.90, 70, '2024-11-01', '2024-11-20', 'Minimalist gold stud earrings'),
(1, 4, 2, 'Silver Dream Pendant', 134.50, 33, '2024-10-10', '2024-10-25', 'Delicate silver pendant with gemstone'),
(2, 2, 4, 'Rose Gold Loop Earrings', 79.20, 55, '2025-02-08', '2024-12-22', 'Loop earrings with rustic bronze finish'),
(3, 3, 1, 'Golden Leaf Bangle', 150.60, 44, '2024-09-05', '2024-09-19', 'Gold bangle shaped like leaves'),
(4, 5, 2, 'Silver Twist Anklet', 92.10, 28, '2025-01-25', '2025-04-12', 'Twisting silver design anklet'),
(1, 3, 3, 'Bronze Pathway Bracelet', 120.00, 36, '2024-12-03', '2024-12-18', 'Geometric pathway design in bronze'),
(2, 4, 1, 'Sunburst Gold Necklace', 210.49, 19, '2024-08-20', '2024-09-10', 'Gold necklace inspired by sunrise'),
(3, 2, 2, 'Oceanic Silver Drop Earrings', 140.75, 42, '2024-07-22', '2024-08-15', 'Drop earrings with ocean blue stones'),
(4, 2, 3, 'Rustic Bronze Hoops', 98.30, 31, '2024-06-30', '2024-07-14', 'Hoop earrings in rugged bronze style'),
(1, 4, 4, 'Royal Rose Gold Pendant', 189.99, 22, '2025-03-15', '2024-03-29', 'Regal pendant with detailed goldwork'),
(2, 4, 2, 'Lunar Silver Chain', 112.60, 39, '2025-01-05', '2025-01-18', 'Simple chain with lunar charm'),
(3, 1, 3, 'Bold Bronze Ring', 105.45, 58, '2024-10-01', '2024-10-20', 'Statement ring in bronze'),
(4, 3, 4, 'Delicate Rose Gold Charm Bracelet', 175.00, 26, '2025-02-01', '2025-02-15', 'Gold bracelet with multiple charms');

INSERT INTO Store.MailingAddress (City, Zipcode, [State], AddressLine) VALUES
('West Cassietown', '40496', 'HI', '4125 Gibbs Wells'),
('Davidtown', '56012', 'RI', '351 Emma Motorway Suite 489'),
('Adamsville', '55540', 'CA', '8771 Hardin Parkways Suite 142');

INSERT INTO Store.Orders (UserID, OrderDate) VALUES
(1, '2024-07-03'),
(2, '2025-02-10'),
(3, '2024-10-16'),
(4, '2024-12-24'),
(5, '2024-09-15'),
(6, '2024-05-02'),
(7, '2024-12-28'),
(8, '2025-04-01'),
(9, '2025-04-07'),
(10, '2024-09-13'),
(1, '2024-09-19'),
(2, '2024-11-11'),
(3, '2024-11-16'),
(4, '2024-09-12'),
(5, '2024-08-16'),
(6, '2025-03-25'),
(7, '2024-05-09'),
(8, '2024-05-05'),
(9, '2024-05-14'),
(10, '2025-04-02'),
(1, '2024-09-05'),
(2, '2024-07-25'),
(3, '2024-07-25'),
(4, '2024-08-09'),
(5, '2024-10-02'),
(6, '2025-04-05'),
(7, '2024-07-17'),
(8, '2024-05-29'),
(9, '2024-06-03'),
(10, '2025-02-16'),
(1, '2024-04-29'),
(2, '2024-10-09'),
(3, '2024-12-06'),
(4, '2024-09-23'),
(5, '2025-01-07'),
(6, '2024-09-23'),
(7, '2024-10-28'),
(8, '2025-03-27'),
(9, '2024-11-28'),
(10, '2024-12-06'),
(1, '2024-11-09'),
(2, '2025-03-05'),
(3, '2024-07-09'),
(4, '2024-12-11'),
(5, '2025-04-10'),
(6, '2025-04-18'),
(7, '2025-03-29'),
(8, '2024-09-19'),
(9, '2024-06-12'),
(10, '2024-05-07'),
(1, '2025-01-27'),
(2, '2024-05-13'),
(3, '2025-04-21'),
(4, '2025-03-25'),
(5, '2025-02-23'),
(6, '2024-11-05'),
(7, '2024-12-17'),
(8, '2024-07-24'),
(9, '2024-07-14'),
(10, '2024-11-06'),
(1, '2024-07-21'),
(2, '2024-12-03'),
(3, '2025-03-18'),
(4, '2024-05-18'),
(5, '2024-11-13'),
(6, '2025-01-05'),
(7, '2024-11-17'),
(8, '2024-09-14'),
(9, '2024-06-05'),
(10, '2025-01-16'),
(1, '2025-03-08'),
(2, '2024-07-28'),
(3, '2025-02-20'),
(4, '2024-05-17'),
(5, '2024-08-14'),
(6, '2024-09-02'),
(7, '2024-10-24'),
(8, '2025-02-24'),
(9, '2025-02-26'),
(10, '2024-11-26'),
(1, '2024-05-28'),
(2, '2024-05-27'),
(3, '2024-08-09'),
(4, '2024-10-22'),
(5, '2024-05-09'),
(6, '2024-04-28'),
(7, '2024-10-13'),
(8, '2024-07-28'),
(9, '2025-01-28'),
(10, '2024-11-04'),
(1, '2024-07-08'),
(2, '2024-05-12'),
(3, '2025-02-18'),
(4, '2024-08-29'),
(5, '2025-04-09'),
(6, '2024-05-31'),
(7, '2025-02-14'),
(8, '2024-08-20'),
(9, '2024-10-30'),
(10, '2024-06-14');
-- adding a product name

INSERT INTO Store.OrderLines (OrderID, StockItemID, Quantity, UnitPrice) VALUES
(1, 1, 3, 119.97),
(1, 2, 1, 200.63),
(2, 2, 1, 211.54),
(2, 1, 2, 787.30),
(3, 3, 2, 291.30),
(4, 4, 2, 159.99),
(4, 5, 1, 99.95),
(5, 6, 3, 84.50),
(5, 7, 2, 178.25),
(6, 8, 1, 73.00),
(6, 9, 2, 124.75),
(7, 10, 1, 199.99),
(7, 11, 4, 89.90),
(8, 12, 2, 134.50),
(8, 13, 1, 79.20),
(9, 14, 3, 150.60),
(9, 15, 2, 92.10),
(10, 16, 1, 120.00),
(10, 17, 2, 210.49),
(1, 18, 3, 140.75),
(2, 19, 1, 98.30),
(3, 20, 2, 189.99),
(4, 21, 2, 112.60),
(5, 22, 1, 105.45),
(6, 23, 3, 175.00),
(11, 1, 2, 119.97),
(11, 2, 3, 211.54),
(12, 3, 4, 291.30),
(12, 1, 1, 159.99),
(13, 2, 5, 99.95),
(13, 3, 2, 84.50),
(14, 1, 1, 178.25),
(14, 2, 3, 73.00),
(15, 3, 6, 124.75),
(15, 1, 2, 199.99),
(16, 2, 3, 89.90),
(16, 3, 4, 134.50),
(17, 1, 2, 79.20),
(17, 2, 1, 150.60),
(18, 3, 3, 92.10),
(18, 1, 4, 120.00),
(19, 2, 2, 210.49),
(19, 3, 5, 140.75),
(20, 1, 3, 98.30),
(20, 2, 6, 175.00),
(21, 1, 2, 119.97),
(21, 2, 1, 200.63),
(22, 3, 3, 291.30),
(22, 1, 2, 159.99),
(23, 2, 4, 99.95),
(23, 3, 2, 84.50),
(24, 1, 1, 178.25),
(24, 2, 5, 73.00),
(25, 3, 6, 124.75),
(25, 1, 3, 199.99),
(26, 2, 2, 89.90),
(26, 3, 4, 134.50),
(27, 1, 4, 79.20),
(27, 2, 1, 150.60),
(28, 3, 5, 92.10),
(28, 1, 2, 120.00),
(29, 2, 3, 210.49),
(29, 3, 2, 140.75),
(30, 1, 6, 98.30),
(30, 2, 4, 175.00);


DROP PROCEDURE IF EXISTS Store.CreateUserInfo;
DROP PROCEDURE IF EXISTS Store.GetAllMetalTypes;
DROP PROCEDURE IF EXISTS Store.GetAllCategoryTypes;
DROP PROCEDURE IF EXISTS Store.GetAllProducts;
DROP PROCEDURE IF EXISTS Store.GetAllProductsMetal;
DROP PROCEDURE IF EXISTS Store.GetAllProductsCategory;
DROP PROCEDURE IF EXISTS Store.GetNewestReleases;
DROP PROCEDURE IF EXISTS Store.AddToCart;
DROP PROCEDURE IF EXISTS Store.GetCartItems;
DROP PROCEDURE IF EXISTS Store.GetHighestPriceItems;
DROP PROCEDURE IF EXISTS Store.GetPopularItems;
DROP PROCEDURE IF EXISTS Store.GetPopularGoldsmith;
DROP PROCEDURE IF EXISTS Store.GetHighestSpendingCustomers;
DROP PROCEDURE IF EXISTS Store.AddNewItem;
DROP PROCEDURE IF EXISTS Store.DeleteItem;
DROP PROCEDURE IF EXISTS Store.DeleteCartItems;
DROP PROCEDURE IF EXISTS Store.IncreaseCartQuantity;
DROP PROCEDURE IF EXISTS Store.DecreaseCartQuantity;
DROP PROCEDURE IF EXISTS Store.InsertOrderLine;
GO

CREATE PROCEDURE Store.CreateUserInfo
    @Email NVARCHAR(225),
    @Username NVARCHAR(100),
    @NormPassword NVARCHAR(100),
    @HashPassword NVARCHAR(255),
    @Name NVARCHAR(100),
    @PhoneNumber NVARCHAR(20),
    @IsAdmin BIT,
    @AccountOpenedDate DATETIME,
    @City NVARCHAR(50),
    @Zipcode INT,
    @State NVARCHAR(2),
    @AddressLine NVARCHAR(225)
AS
BEGIN
    INSERT INTO Store.[User] (Email, Username, NormPassword, HashPassword, CustomerName, PhoneNumber, IsAdmin, AccountOpenedDate) VALUES
    (@Email, @Username, @NormPassword, @HashPassword, @Name, @PhoneNumber, @IsAdmin, @AccountOpenedDate)
    INSERT INTO Store.MailingAddress (City, Zipcode, [State], AddressLine) VALUES
    (@City, @Zipcode, @State, @AddressLine)
END;
GO
    

CREATE PROCEDURE Store.GetAllMetalTypes
AS
BEGIN
    SELECT MetalName
    FROM Store.[MetalTypes];
END;
GO

CREATE PROCEDURE Store.GetAllCategoryTypes
AS
BEGIN
    SELECT CategoryName
    FROM Store.[Categories];
END;
GO

CREATE PROCEDURE Store.GetAllProducts
AS
BEGIN
    SELECT ItemName, ItemPrice, [Description], CategoryID
    FROM Store.[Items];
END;
GO

CREATE PROCEDURE Store.GetAllProductsMetal
    @MetalID INT
AS
BEGIN
    SELECT ItemName, ItemPrice, [Description], CategoryID
    FROM Store.[Items]
    WHERE MetalID = @MetalID;
END;
GO

CREATE PROCEDURE Store.GetAllProductsCategory
    @CategoryID INT
AS
BEGIN
    SELECT ItemName, ItemPrice, [Description], CategoryID
    FROM Store.[Items]
    WHERE CategoryID = @CategoryID;
END;
GO

CREATE PROCEDURE Store.GetNewestReleases
AS
BEGIN
    SELECT ItemName, ItemPrice, [Description]
    FROM Store.Items
    WHERE ItemReleaseDate >= DATEADD(MONTH, -3, SYSDATETIME());
END;
GO

CREATE PROCEDURE Store.AddToCart
    @UserID INT,
    @StockItemID INT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Store.Cart WHERE UserID = @UserID and StockItemID = @StockItemID)
    BEGIN 
        UPDATE Store.Cart
        SET Quantity = Quantity + 1
        WHERE UserID = @UserID and StockItemID = @StockItemID;
    END;
    ELSE
    BEGIN
        INSERT INTO Store.Cart (UserID, StockItemID, Quantity) VALUES
        (@UserID, @StockItemID, 1)
    END;
END;
GO

CREATE PROCEDURE Store.GetCartItems
    @UserID INT
AS
BEGIN
    SELECT I.ItemName, I.ItemPrice, C.Quantity, 
        (I.ItemPrice * C.Quantity) AS TotalPrice
    FROM Store.Cart C
    INNER JOIN Store.Items I ON C.StockItemID = I.StockItemID
    WHERE C.UserID = @UserID
END;
GO

CREATE PROCEDURE Store.DeleteCartItems
    @UserID INT
AS 
BEGIN
    DELETE FROM Store.Cart
    WHERE UserID = @UserID
END;
GO

CREATE PROCEDURE Store.IncreaseCartQuantity
    @UserID INT,
    @StockItemID INT
AS
BEGIN
    UPDATE Store.Cart
    SET Quantity = Quantity + 1
    WHERE UserID = @UserID AND StockItemID = @StockItemID
END;
GO

CREATE PROCEDURE Store.DecreaseCartQuantity
    @UserID INT,
    @StockItemID INT
AS
BEGIN
    UPDATE Store.Cart
    SET Quantity = Quantity - 1
    WHERE UserID = @UserID AND StockItemID = @StockItemID
END;
GO
 
CREATE PROCEDURE Store.GetHighestPriceItems
AS
BEGIN
    SELECT I.ItemName, SUM(OL.Quantity) AS TotalQuantity, I.ItemPrice
    FROM Store.OrderLines OL
    INNER JOIN Store.Orders O ON O.OrderID = OL.OrderID
    INNER JOIN Store.Items I ON OL.StockItemID = I.StockItemID  
    WHERE O.OrderDate <= SYSDATETIME()
    GROUP BY I.ItemName, I.ItemPrice
    ORDER BY ItemPrice DESC;
END;
GO

-- Most Popular Items
CREATE PROCEDURE Store.GetPopularItems
AS
BEGIN
    SELECT TOP 10 I.ItemName, SUM(OL.Quantity) AS TotalQuantity, I.ItemPrice
    FROM Store.OrderLines OL
    INNER JOIN Store.Orders O ON O.OrderID = OL.OrderID
    INNER JOIN Store.Items I ON OL.StockItemID = I.StockItemID  
    WHERE O.OrderDate  >= DATEADD(MONTH, -3, SYSDATETIME())
    GROUP BY I.ItemName, I.ItemPrice
    ORDER BY TotalQuantity DESC;
END;
GO 
 
--Most Popular Goldsmith
CREATE PROCEDURE Store.GetPopularGoldsmith
AS
BEGIN
    SELECT TOP 3 G.GoldsmithName, SUM(OL.Quantity * OL.UnitPrice) AS TotalSales
    FROM Store.Goldsmith G
    INNER JOIN Store.Items I ON I.StockItemID = G.GoldsmithID
    INNER JOIN Store.OrderLines OL ON OL.StockItemID = I.StockItemID
    GROUP BY G.GoldsmithName
    ORDER BY TotalSales DESC;
END;
GO
 
--Highest spending Customers
CREATE PROCEDURE Store.GetHighestSpendingCustomers
AS
BEGIN
    WITH SpendersCTE (Username, TotalSpent)
    AS(
        SELECT TOP 5 U.Username, SUM(OL.Quantity * OL.UnitPrice) AS TotalSpent
        FROM Store.[User] U
        INNER JOIN Store.Orders O ON U.UserID = O.UserID
        INNER JOIN Store.OrderLines OL ON OL.OrderID = O.OrderID
        GROUP BY U.Username
    )
    SELECT SC.Username, SC.TotalSpent,
    RANK() OVER(ORDER BY SC.TotalSpent DESC) AS [Rank]
    FROM SpendersCTE SC
        ORDER BY TotalSpent DESC;
    END;
GO

CREATE PROCEDURE Store.AddNewItem
    @GoldsmithID INT,
    @CategoryID INT,
    @MetalID INT,
    @ItemName NVARCHAR(100),
    @ItemPrice DECIMAL(10,2),
    @StockQuantity INT,
    @Description NVARCHAR(MAX)
AS
BEGIN
    INSERT INTO Store.Items (GoldsmithID, CategoryID, MetalID, ItemName, ItemPrice, StockQuantity, [Description]) VALUES
    (@GoldsmithID, @CategoryID, @MetalID, @ItemName, @ItemPrice, @StockQuantity, @Description)
END;
GO

CREATE PROCEDURE Store.DeleteItem
    @StockItemID INT
AS
BEGIN
    DELETE FROM Store.Items
    WHERE StockItemID = @StockItemID
END;
GO

CREATE PROCEDURE Store.InsertOrderLine
    @UserID INT,
    @OrderID INT
AS
BEGIN
    INSERT INTO Store.OrderLines (OrderID, StockItemID, Quantity, UnitPrice)
    SELECT @OrderID, C.StockItemID, C.Quantity, I.ItemPrice
    FROM Store.Cart C
    INNER JOIN Store.Items I ON C.StockItemID = I.StockItemID
    WHERE UserID = @UserID
END;
GO