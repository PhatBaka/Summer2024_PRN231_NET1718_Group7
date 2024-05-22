-- Drop the database if it exists
IF DB_ID('JewelryShop') IS NOT NULL
BEGIN
	USE master;;
    DROP DATABASE JewelryShop;
END
GO

-- Create the JewelryShop database
CREATE DATABASE JewelryShop;
GO

-- Use the JewelryShop database
USE JewelryShop;
GO

-- Create tables based on the provIDed ERD

CREATE TABLE Role (
    RoleID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Role NVARCHAR(255)
);

CREATE TABLE Account (
    AccountID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Email NVARCHAR(255),
    Password NVARCHAR(255),
    PhoneNumber NVARCHAR(50),
    Status NVARCHAR(50),
    RoleID UNIQUEIDENTIFIER,
    FOREIGN KEY (RoleID) REFERENCES Role(RoleID)
);

CREATE TABLE Customer (
    CustomerID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Name NVARCHAR(255),
    PhoneNumber NVARCHAR(50),
    Email NVARCHAR(255),
    AmountSpent DECIMAL(10, 2) NOT NULL
);

CREATE TABLE Material (
    MaterialID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Name NVARCHAR(255),
    Description NVARCHAR(MAX)
);

CREATE TABLE MaterialPrice (
    MaterialPriceID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    MaterialID UNIQUEIDENTIFIER,
    Date DATE,
    Price DECIMAL(18, 2),
    FOREIGN KEY (MaterialID) REFERENCES Material(MaterialID)
);

CREATE TABLE JewelryType (
    TypeID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    TypeName NVARCHAR(255)
);

CREATE TABLE Jewelry (
    JewelryID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    ManufacturingFees DECIMAL(18, 2),
    JewelryType UNIQUEIDENTIFIER,
    Status NVARCHAR(50),
    Barcode NVARCHAR(255),
    GuaranteeDuration INT,
    FOREIGN KEY (JewelryType) REFERENCES JewelryType(TypeID)
);

CREATE TABLE JewelryMaterial (
    JewelryID UNIQUEIDENTIFIER,
    MaterialID UNIQUEIDENTIFIER,
    Weight DECIMAL(18, 2),
    PRIMARY KEY (JewelryID, MaterialID),
    FOREIGN KEY (JewelryID) REFERENCES Jewelry(JewelryID),
    FOREIGN KEY (MaterialID) REFERENCES Material(MaterialID)
);

CREATE TABLE Tier (
    TierID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    TierName VARCHAR(50) NOT NULL,
    MinAmountSpent DECIMAL(10, 2) NOT NULL,
    DiscountPercentage DECIMAL(5, 2) NULL
);

CREATE TABLE StoreDiscount (
    StoreDiscountID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    DiscountCode NVARCHAR(255),
    DiscountAmount DECIMAL(18, 2),
    StartDate DATE,
    EndDate DATE,
    RemainingUsage INT
);

CREATE TABLE Offer (
    OfferID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    OfferPercent DECIMAL(5, 2),
    Constraints NVARCHAR(MAX),
    CreatedByID UNIQUEIDENTIFIER,
    ApprovedByID UNIQUEIDENTIFIER,
    FOREIGN KEY (CreatedByID) REFERENCES Account(AccountID),
    FOREIGN KEY (ApprovedByID) REFERENCES Account(AccountID)
);

CREATE TABLE OrderType (
    OrderTypeID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    TypeName NVARCHAR(255)
);

CREATE TABLE OrderDiscount (
    OrderDiscountID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Type NVARCHAR(50),
    Name NVARCHAR(255),
    TierID UNIQUEIDENTIFIER,
    StoreDiscountID UNIQUEIDENTIFIER,
    OfferID UNIQUEIDENTIFIER,
    FOREIGN KEY (TierID) REFERENCES Tier(TierID),
    FOREIGN KEY (StoreDiscountID) REFERENCES StoreDiscount(StoreDiscountID),
    FOREIGN KEY (OfferID) REFERENCES Offer(OfferID)
);

CREATE TABLE [Order] (
    OrderID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    OrderDate DATE,
    TotalPrice DECIMAL(18, 2),
    DiscountPrice DECIMAL(18, 2),
    FinalPrice DECIMAL(18, 2),
    Status NVARCHAR(50),
    OrderTypeID UNIQUEIDENTIFIER,
    OrderDiscountID UNIQUEIDENTIFIER,
    AccountID UNIQUEIDENTIFIER,
    CustomerID UNIQUEIDENTIFIER,
    FOREIGN KEY (OrderTypeID) REFERENCES OrderType(OrderTypeID),
    FOREIGN KEY (OrderDiscountID) REFERENCES OrderDiscount(OrderDiscountID),
    FOREIGN KEY (AccountID) REFERENCES Account(AccountID),
    FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID)
);

CREATE TABLE OrderDetail (
    OrderDetailID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    OrderID UNIQUEIDENTIFIER,
    JewelryID UNIQUEIDENTIFIER,
    SubTotalPrice DECIMAL(18, 2),
    FOREIGN KEY (OrderID) REFERENCES [Order](OrderID),
    FOREIGN KEY (JewelryID) REFERENCES Jewelry(JewelryID),
);


CREATE TABLE Guarantee (
    GuaranteeID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    AccountID UNIQUEIDENTIFIER,
	OrderDetailID UNIQUEIDENTIFIER,
    DateReceive DATE,
    DateComplete DATE,
    DateBack DATE,
    Confirm NVARCHAR(50),
    FOREIGN KEY (AccountID) REFERENCES Account(AccountID),
	FOREIGN KEY (OrderDetailID) REFERENCES OrderDetail(OrderDetailID),
);