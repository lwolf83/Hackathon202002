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
Price DECIMAL(10,2),
"Name" VARCHAR(50) NOT NULL,
"Description" VARCHAR(255),
CategoryId INT NOT NULL,
FOREIGN KEY (CategoryId) REFERENCES Category(Id)
);
GO
INSERT INTO Category ([Name], [Description]) VALUES ('Stuffed toys', 'Gothic stuffed toys');
INSERT INTO Category ([Name], [Description]) VALUES ('Bags', 'Gothic bags super gothic');
INSERT INTO Category ([Name], [Description]) VALUES ('Jewelrey', 'Gothic jewelery');
INSERT INTO Category ([Name], [Description]) VALUES ('Figurine', 'Gothic figurine');

INSERT INTO Product ([Price], [Name], [Description], [CategoryId]) VALUES (50, 'Batbag', 'Basic little bag to show your support to batman.', 1);
INSERT INTO Product ([Price], [Name], [Description], [CategoryId]) VALUES (55, 'Catbag', 'Lets be honest : cat is the best animal on earth. Heres a little bag to remind you the beauty of this noble animal.', 1);
INSERT INTO Product ([Price], [Name], [Description], [CategoryId]) VALUES (45, 'Coffinbag ', 'This bag is perfect to transport your stuff like your voodoo dolls.', 1);
INSERT INTO Product ([Price], [Name], [Description], [CategoryId]) VALUES (70, 'Skullbag', 'This bag is perfect for witches. It can be filled with all the spell and herbs you need for your journey !', 1);
INSERT INTO Product ([Price], [Name], [Description], [CategoryId]) VALUES (30, 'Chimera ', 'This fantastic creature belong to the greek mythology, may this teddy bring you joy in your life !', 2);
INSERT INTO Product ([Price], [Name], [Description], [CategoryId]) VALUES (20, 'Hydra', 'Another teddy belonging to the greek mythology, protect it from the mean heros who desire to destroy it !', 2);
INSERT INTO Product ([Price], [Name], [Description], [CategoryId]) VALUES (20, 'Nounours', 'Lovely teddy bear which only wants to love and to be loved ! ', 2);
INSERT INTO Product ([Price], [Name], [Description], [CategoryId]) VALUES (666, 'Satan', 'With this beautiful teddy, the dark Lord will always be with you', 2);

INSERT INTO Product ([Price], [Name], [Description], [CategoryId]) VALUES (35, 'Necklace', 'A necklace to wear with anything', 3);
INSERT INTO Product ([Price], [Name], [Description], [CategoryId]) VALUES (20, 'Earings', 'Beautiful earings designed with two skulls', 3);

INSERT INTO Product ([Price], [Name], [Description], [CategoryId]) VALUES (60, 'Gothic fairy', 'A cut little fairy, perfect to decorate your room', 4);
INSERT INTO Product ([Price], [Name], [Description], [CategoryId]) VALUES (100, 'Gargoyle', 'A big Gargoyle to protect your house', 4);


GO

SELECT * FROM Category;
SELECT * FROM Product;