IF DB_ID('Cheaper') IS NULL BEGIN CREATE DATABASE Cheaper; END
GO

USE Cheaper;
GO
BEGIN TRANSACTION;
CREATE TABLE Users (
	UserName NVARCHAR(24) PRIMARY KEY,
	Passwd VARCHAR(32) NOT NULL CHECK (DATALENGTH(Passwd) = 32),
	Email NVARCHAR(40) NOT NULL,
	BirthDate DATETIME NOT NULL,
	RegisterDate DATETIME NOT NULL DEFAULT GETDATE(),
	VerifCode NVARCHAR(16) NULL,
	CONSTRAINT MinPasswdLength CHECK (DATALENGTH(Passwd) = 32));
GO

CREATE TABLE AdditionalUserInfo (
	UserID NVARCHAR(24) PRIMARY KEY,
	ShowEmail BIT NOT NULL DEFAULT 0,
	ShowPhone BIT NOT NULL DEFAULT 0,
	ShowBirthDate BIT NOT NULL DEFAULT 1,
	StatsEnabled BIT NOT NULL DEFAULT 0,
	DisplayPic BINARY NULL,
	GaduGadu NVARCHAR(9) NULL,
	Phone NVARCHAR(12) NULL,
	FOREIGN KEY (UserID) REFERENCES Users(UserName) ON UPDATE CASCADE ON DELETE NO ACTION );
GO

CREATE TABLE Contacts (
	UserID NVARCHAR(24) NOT NULL,
	ContactID NVARCHAR(24) NOT NULL,
	CreationDate DATETIME NOT NULL DEFAULT GETDATE(),
	PRIMARY KEY (UserID, ContactID),
	FOREIGN KEY (UserID) REFERENCES Users(UserName) ON UPDATE CASCADE ON DELETE NO ACTION );
GO

CREATE TABLE Budgets (
	BudgetID INT IDENTITY(1,1) PRIMARY KEY,
	UserID NVARCHAR(24) NOT NULL,
	BudgetName NVARCHAR(50),
	CreationDate DATETIME NOT NULL DEFAULT GETDATE(),
	FOREIGN KEY (UserID) REFERENCES Users(UserName) ON UPDATE CASCADE ON DELETE NO ACTION);
GO

CREATE TABLE Categories (
	Id SMALLINT IDENTITY(1,1) PRIMARY KEY,
	Name NVARCHAR(30) NOT NULL);
GO

CREATE TABLE Products (
	ProductID INT IDENTITY(1,1) PRIMARY KEY,
	Name NVARCHAR(40) NOT NULL,
	CategoryID SMALLINT NOT NULL,
	UserID NVARCHAR(24) NOT NULL,
	FOREIGN KEY (CategoryID) REFERENCES Categories(Id) ON UPDATE CASCADE ON DELETE NO ACTION,
	FOREIGN KEY (UserID) REFERENCES Users(UserName) ON UPDATE NO ACTION ON DELETE NO ACTION);
GO

CREATE TABLE ExpenseCategories (
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Name NVARCHAR(50) NOT NULL,
	Amount DECIMAL(9,2) NOT NULL DEFAULT 0,
	UserID NVARCHAR(24) NOT NULL
	FOREIGN KEY (UserID) REFERENCES Users(UserName) ON UPDATE NO ACTION ON DELETE NO ACTION);
GO

CREATE TABLE Conversations (
	Id INT IDENTITY(1,1) PRIMARY KEY,
	CreationUserID NVARCHAR(24) NOT NULL,
	Name NVARCHAR(50) NULL,
	CreationDate DATETIME NOT NULL DEFAULT GETDATE(),
	FOREIGN KEY (CreationUserID) REFERENCES Users(UserName) ON UPDATE CASCADE ON DELETE NO ACTION);
GO

CREATE TABLE ConversationParticipants (
	ConversationID INT NOT NULL,
	UserID NVARCHAR(24) NOT NULL,
	PRIMARY KEY (ConversationID, UserID),
	FOREIGN KEY (ConversationID) REFERENCES Conversations(Id) ON UPDATE CASCADE ON DELETE NO ACTION,
	FOREIGN KEY (UserID) REFERENCES Users(UserName) ON UPDATE NO ACTION ON DELETE NO ACTION);
GO

CREATE TABLE Messages (
	MessageID INT,
	ConversationID INT NOT NULL,
	SenderID NVARCHAR(24) NOT NULL,
	Content NVARCHAR(3000) NOT NULL,
	SendDate DATETIME NOT NULL DEFAULT GETDATE(),
	PRIMARY KEY (MessageID, ConversationID),
	FOREIGN KEY (ConversationID) REFERENCES Conversations(Id) ON UPDATE CASCADE ON DELETE NO ACTION,
	FOREIGN KEY (SenderID) REFERENCES Users(UserName) ON UPDATE NO ACTION ON DELETE NO ACTION);
GO

CREATE TABLE Events (
	EventID INT IDENTITY(1,1) PRIMARY KEY,
	MethodName NVARCHAR(128) NOT NULL,
	ExMessage NVARCHAR(2048) NOT NULL,
	InnerExMessage NVARCHAR(2048) NULL,
	OccurenceDate DATETIME NOT NULL DEFAULT GETDATE(),
	UserName NVARCHAR(24) NOT NULL DEFAULT 'X',
	FOREIGN KEY (UserName) REFERENCES Users(UserName) ON UPDATE CASCADE ON DELETE NO ACTION);
GO

CREATE TABLE Shops (
	Id INT IDENTITY(1,1) PRIMARY KEY,
	FriendlyName NVARCHAR(50) NOT NULL,
	Street NVARCHAR(30) NULL,
	City NVARCHAR(30) NULL,
	PostCode NVARCHAR(6) NULL,
	UserID NVARCHAR(24) NOT NULL,
	CONSTRAINT PostCodeLength CHECK (LEN(PostCode) = 6 OR PostCode IS NULL));
GO

CREATE TABLE BudgetPositions (
	PositionID BIGINT IDENTITY(1,1) PRIMARY KEY,
	BudgetID INT NOT NULL,
	ExpenseCatID INT NOT NULL,
	ShopID INT NULL,
	UserID NVARCHAR(24) NOT NULL,
	ProdID INT NOT NULL,
	Price DECIMAL(9,2) NOT NULL DEFAULT 0,
	PurchaseDate DATETIME NULL,
	Quantity DECIMAL(9,2) NOT NULL,
	CreationDate DATETIME NOT NULL DEFAULT GETDATE(),
	AdditionalInfo NVARCHAR(300) NULL,
	FOREIGN KEY (BudgetID) REFERENCES Budgets(BudgetID) ON UPDATE CASCADE ON DELETE NO ACTION,
	FOREIGN KEY (ExpenseCatID) REFERENCES ExpenseCategories(Id) ON UPDATE CASCADE ON DELETE NO ACTION,
	FOREIGN KEY (ShopID) REFERENCES Shops(Id) ON UPDATE CASCADE ON DELETE NO ACTION,
	FOREIGN KEY (ProdID) REFERENCES Products(ProductID) ON UPDATE CASCADE ON DELETE NO ACTION,
	CONSTRAINT MinPrice CHECK (Price >= 0));
GO

CREATE VIEW ExpenseCatLastMthBalance AS
SELECT ec.Id, ec.UserID, ec.Name, ec.Amount,
	(ec.Amount - ISNULL((SELECT SUM(bp.Price * bp.Quantity)
	FROM BudgetPositions bp
	JOIN Budgets b ON bp.BudgetID = b.BudgetID
	WHERE bp.ExpenseCatID = ec.Id
		AND b.UserID = ec.UserID
		AND YEAR(bp.CreationDate) = YEAR(GETDATE())
		AND MONTH(bp.CreationDate) = MONTH(GETDATE())), 0)) AS Balance
FROM ExpenseCategories ec;
GO

CREATE VIEW BudgetsWithExpenses AS
SELECT b.BudgetID, b.UserID, b.BudgetName, b.CreationDate,
	ISNULL((SELECT SUM(bp.Price * bp.Quantity)
	FROM BudgetPositions bp
	WHERE bp.BudgetID = b.BudgetID
		AND YEAR(bp.PurchaseDate) = YEAR(GETDATE())
		AND MONTH(bp.PurchaseDate) = MONTH(GETDATE())), 0) AS ThisMonthExpenses,
	ISNULL((SELECT SUM(bp.Price * bp.Quantity)
	FROM BudgetPositions bp
	WHERE bp.BudgetID = b.BudgetID
		AND YEAR(bp.PurchaseDate) = YEAR(GETDATE())), 0) AS ThisYearExpenses
FROM Budgets b;
GO

commit;

-- POPULACJA STRUKTUR SŁOWNIKOWYCH DANYMI
begin transaction;

insert into Users values ('lubo', 'f6a3a3e101a484c1b0ff5facacf1be56', 'lubo@ue.katowice.pl', getdate(), getdate(), null);
INSERT INTO Users values ('dft', 'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx', 'x', getdate(), getdate(), null);

INSERT INTO Categories(Name)
	SELECT 'Elektronika'
	UNION SELECT 'AGD'
	UNION SELECT 'Żywność'
	UNION SELECT 'Motoryzacja'
	UNION SELECT 'Oprogramowanie'
	UNION SELECT 'Sport'
	UNION SELECT 'Rozrywka';
	
INSERT INTO Products(Name, CategoryID, UserID)
	VALUES ('Galaxy S3', 1, 'dft'),
		   ('Nexus 7 2', 1, 'dft'),
		   ('Monitor LG 23EA63', 1, 'dft'),
		   ('Lodówka Whirlpool WBC 3546 FCX', 2, 'dft'),
		   ('Pralka Whirlpool AWE6519/P', 2, 'dft'),
		   ('Zmywarka Candy CSF 4595 E', 2, 'dft'),
		   ('Arbuz', 3, 'dft'),
		   ('Papryka [szt]', 3, 'dft'),
		   ('Papryka [kg]', 3, 'dft'),
		   ('Pizza', 3, 'dft'),
		   ('Wymiana sprzęgła Focus MK II', 4, 'dft'),
		   ('Wymiana opon na zimowe', 4, 'dft'),
		   ('Olej napędowy [l]', 4, 'dft'),
		   ('Pakiet Office 2013', 5, 'dft'),
		   ('Runtastic PRO', 5, 'dft'),
		   ('GTA V', 5, 'dft'),
		   ('Nike DUAL FUSION RUN 2', 6, 'dft'),
		   ('Koszulka termoaktywna 4F', 6, 'dft'),
		   ('Pulsometr Sigma PC 10.11', 6, 'dft'),
		   ('Bilard 1h', 7, 'dft'),
		   ('Seans 3D', 7, 'dft'),
		   ('Wesołe miasteczko - karnet całodniowy', 7, 'dft');

commit;