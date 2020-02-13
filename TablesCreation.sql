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

IF(EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Category'))
BEGIN
	DROP TABLE [Category]
END


CREATE TABLE Category (
id INT PRIMARY KEY IDENTITY(1,1),
"name" VARCHAR(50) NOT NULL,
"description" VARCHAR(255)
);

CREATE TABLE Product (
id INT PRIMARY KEY IDENTITY(1,1),
price DECIMAL,
"name" VARCHAR(50) NOT NULL,
"description" VARCHAR(255),
category_id INT NOT NULL,
FOREIGN KEY (category_id) REFERENCES Category(id)
);

INSERT INTO Category ([name], [description]) VALUES ('Peluche tigre', 'des peluches tigres trop cool');
INSERT INTO Category ([name], [description]) VALUES ('Peluche chien', 'des peluches chien trop cool');
INSERT INTO Category ([name], [description]) VALUES ('Peluche dragon', 'des peluches dragon trop cool');
INSERT INTO Category ([name], [description]) VALUES ('Peluche bébé', 'des peluches bébé trop cool');

INSERT INTO Product ([price], [name], [description], [category_id]) VALUES (23, 'peluche 1', '100% fibres pas naturelles', 1);
INSERT INTO Product ([price], [name], [description], [category_id]) VALUES (23, 'peluche 2', '100% fibres pas naturelles', 2);
INSERT INTO Product ([price], [name], [description], [category_id]) VALUES (23, 'peluche 2', '100% fibres pas naturelles', 3);
INSERT INTO Product ([price], [name], [description], [category_id]) VALUES (23, 'peluche 3', '100% fibres pas naturelles', 4);
INSERT INTO Product ([price], [name], [description], [category_id]) VALUES (23, 'peluche 4', '100% fibres pas naturelles', 1);
INSERT INTO Product ([price], [name], [description], [category_id]) VALUES (23, 'peluche 5', '100% fibres pas naturelles', 2);
INSERT INTO Product ([price], [name], [description], [category_id]) VALUES (23, 'peluche 6', '100% fibres pas naturelles', 3);
INSERT INTO Product ([price], [name], [description], [category_id]) VALUES (23, 'peluche 7', '100% fibres pas naturelles', 4);
INSERT INTO Product ([price], [name], [description], [category_id]) VALUES (23, 'peluche 8', '100% fibres pas naturelles', 1);
INSERT INTO Product ([price], [name], [description], [category_id]) VALUES (23, 'peluche 9', '100% fibres pas naturelles', 2);
INSERT INTO Product ([price], [name], [description], [category_id]) VALUES (23, 'peluche 10', '100% fibres pas naturelles', 3);
INSERT INTO Product ([price], [name], [description], [category_id]) VALUES (23, 'peluche 11', '100% fibres pas naturelles', 3);
INSERT INTO Product ([price], [name], [description], [category_id]) VALUES (23, 'peluche 12', '100% fibres pas naturelles', 4);

