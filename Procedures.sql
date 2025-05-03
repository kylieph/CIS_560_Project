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

-- This procedure enables a customer to create a user profile
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
    

-- This procedure extracts metal types to be displayed in the application
CREATE PROCEDURE Store.GetAllMetalTypes
AS
BEGIN
    SELECT MetalName
    FROM Store.[MetalTypes];
END;
GO

-- This procedure extracts category types to be displayed in the application
CREATE PROCEDURE Store.GetAllCategoryTypes
AS
BEGIN
    SELECT CategoryName
    FROM Store.[Categories];
END;
GO

-- This procedure extracts all products to be displayed in the application

CREATE PROCEDURE Store.GetAllProducts
AS
BEGIN
    SELECT ItemName, ItemPrice, [Description], CategoryID
    FROM Store.[Items];
END;
GO

--This procedure filters by a selected metal type
CREATE PROCEDURE Store.GetAllProductsMetal
    @MetalID INT
AS
BEGIN
    SELECT ItemName, ItemPrice, [Description], CategoryID
    FROM Store.[Items]
    WHERE MetalID = @MetalID;
END;
GO

--This procedure filters by a selected category
CREATE PROCEDURE Store.GetAllProductsCategory
    @CategoryID INT
AS
BEGIN
    SELECT ItemName, ItemPrice, [Description], CategoryID
    FROM Store.[Items]
    WHERE CategoryID = @CategoryID;
END;
GO

--This procedure filters for the items that have been released in the last 3 months
CREATE PROCEDURE Store.GetNewestReleases
AS
BEGIN
    SELECT ItemName, ItemPrice, [Description]
    FROM Store.Items
    WHERE ItemReleaseDate >= DATEADD(MONTH, -3, SYSDATETIME());
END;
GO

--This procedure adds the selected items to the cart
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

-- This procedure gets items from the cart to calculate the receipt displayed
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

--This procedure allows the user to delete the items in their cart
CREATE PROCEDURE Store.DeleteCartItems
    @UserID INT
AS 
BEGIN
    DELETE FROM Store.Cart
    WHERE UserID = @UserID
END;
GO

-- This procedure allows the user to increase the quantity of the items in the cart
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

-- This procedure allows the user to decrease the quantity of the items in the cart

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

-- This procedure gets the highest priced items by arranging the items by price and shows the total quantity of each in the inventory
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

-- This procedure shows the 10 most Popular Items arranging them by the ones with the most purchases
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
 
--This procedure shows the most Popular Goldsmith and organizes them according to highest sales made
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
 
--This procedure shows the highest spending Customers and their ranking according to their total amount spent
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

--This procedure enables the admin to add an item to the store

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

--This procedure allows the admin to delete an item from the store
CREATE PROCEDURE Store.DeleteItem
    @StockItemID INT
AS
BEGIN
    DELETE FROM Store.Items
    WHERE StockItemID = @StockItemID
END;
GO

--This procedure adds the items that have been checked out to the orderlines.

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