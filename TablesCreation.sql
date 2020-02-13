IF  NOT EXISTS (SELECT * FROM sys.databases WHERE name = N'Hackathon202002')
    BEGIN
        CREATE DATABASE [Hackathon202002];
    END;
GO 

USE [Hackathon202002];
GO

IF(EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Product'))
BEGIN
	DROP TABLE [Product]
END
GO
IF(EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Category'))
BEGIN
	DROP TABLE [Category]
END
GO

CREATE TABLE Category (
Id INT PRIMARY KEY IDENTITY(1,1),
"Name" VARCHAR(50) NOT NULL,
"Description" VARCHAR(255)
);
GO
CREATE TABLE Product (
Id INT PRIMARY KEY IDENTITY(1,1),
Price MONEY,
"Name" VARCHAR(50) NOT NULL,
"Description" VARCHAR(255),
CategoryId INT NOT NULL,
FOREIGN KEY (CategoryId) REFERENCES Category(Id)
);
GO
INSERT INTO Category ([Name], [Description]) VALUES ('Peluche tigre', 'des peluches tigres trop cool');
INSERT INTO Category ([Name], [Description]) VALUES ('Peluche chien', 'des peluches chien trop cool');
INSERT INTO Category ([Name], [Description]) VALUES ('Peluche dragon', 'des peluches dragon trop cool');
INSERT INTO Category ([Name], [Description]) VALUES ('Peluche bébé', 'des peluches bébé trop cool');

INSERT INTO Product ([Price], [Name], [Description], [CategoryId]) VALUES (23, 'peluche 1', '100% fibres pas naturelles', 1);
INSERT INTO Product ([Price], [Name], [Description], [CategoryId]) VALUES (23, 'peluche 2', '100% fibres pas naturelles', 2);
INSERT INTO Product ([Price], [Name], [Description], [CategoryId]) VALUES (23, 'peluche 2', '100% fibres pas naturelles', 3);
INSERT INTO Product ([Price], [Name], [Description], [CategoryId]) VALUES (23, 'peluche 3', '100% fibres pas naturelles', 4);
INSERT INTO Product ([Price], [Name], [Description], [CategoryId]) VALUES (23, 'peluche 4', '100% fibres pas naturelles', 1);
INSERT INTO Product ([Price], [Name], [Description], [CategoryId]) VALUES (23, 'peluche 5', '100% fibres pas naturelles', 2);
INSERT INTO Product ([Price], [Name], [Description], [CategoryId]) VALUES (23, 'peluche 6', '100% fibres pas naturelles', 3);
INSERT INTO Product ([Price], [Name], [Description], [CategoryId]) VALUES (23, 'peluche 7', '100% fibres pas naturelles', 4);
INSERT INTO Product ([Price], [Name], [Description], [CategoryId]) VALUES (23, 'peluche 8', '100% fibres pas naturelles', 1);
INSERT INTO Product ([Price], [Name], [Description], [CategoryId]) VALUES (23, 'peluche 9', '100% fibres pas naturelles', 2);
INSERT INTO Product ([Price], [Name], [Description], [CategoryId]) VALUES (23, 'peluche 10', '100% fibres pas naturelles', 3);
INSERT INTO Product ([Price], [Name], [Description], [CategoryId]) VALUES (23, 'peluche 11', '100% fibres pas naturelles', 3);
INSERT INTO Product ([Price], [Name], [Description], [CategoryId]) VALUES (23, 'peluche 12', '100% fibres pas naturelles', 4);
GO

SELECT * FROM Category;
SELECT * FROM Product;