-- Create Database
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'LibraryDB')
BEGIN
    CREATE DATABASE LibraryDB;
END
GO

USE LibraryDB;
GO

-- Create Authors Table
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Authors')
BEGIN
    CREATE TABLE Authors
    (
        AuthorID INT PRIMARY KEY IDENTITY(1,1),
        AuthorName NVARCHAR(100) NOT NULL,
        Email NVARCHAR(100),
        Phone NVARCHAR(15)
    );
END
GO

-- Create Category Table
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Category')
BEGIN
    CREATE TABLE Category
    (
        CategoryID INT PRIMARY KEY IDENTITY(1,1),
        CategoryName NVARCHAR(100) NOT NULL
    );
END
GO

-- Create Books Table
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Books')
BEGIN
    CREATE TABLE Books
    (
        BookID INT PRIMARY KEY IDENTITY(1,1),
        BookName NVARCHAR(200) NOT NULL,
        AuthorID INT NOT NULL,
        CategoryID INT NOT NULL,
        ISBN NVARCHAR(20),
        PublishedYear INT,
        TotalCopies INT,
        AvailableCopies INT,
        FOREIGN KEY (AuthorID) REFERENCES Authors(AuthorID),
        FOREIGN KEY (CategoryID) REFERENCES Category(CategoryID)
    );
END
GO

-- Create Members Table
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Members')
BEGIN
    CREATE TABLE Members
    (
        MemberID INT PRIMARY KEY IDENTITY(1,1),
        MemberName NVARCHAR(100) NOT NULL,
        Email NVARCHAR(100),
        Phone NVARCHAR(15),
        MembershipDate DATETIME,
        Address NVARCHAR(255)
    );
END
GO

-- Create Transactions Table
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Transactions')
BEGIN
    CREATE TABLE Transactions
    (
        TransactionID INT PRIMARY KEY IDENTITY(1,1),
        BookID INT NOT NULL,
        MemberID INT NOT NULL,
        IssueDate DATETIME,
        ReturnDate DATETIME,
        DueDate DATETIME,
        Fine DECIMAL(10,2),
        FOREIGN KEY (BookID) REFERENCES Books(BookID),
        FOREIGN KEY (MemberID) REFERENCES Members(MemberID)
    );
END
GO

PRINT 'Database setup completed successfully!';
