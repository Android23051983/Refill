Create DataBase RefillAndMiniCafe;
go
USE RefillAndMiniCafe;

CREATE TABLE Refill
(
	Id INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(10) NOT NULL,
	Price MONEY NOT NULL,
	ProductCount Float NOT NULL
);

CREATE TABLE HotDish
(
	Id INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(50) NOT NULL,
	Price MONEY NOT NULL,
	ProductCount Float NOT NULL
);

CREATE TABLE Garnish
(
	Id INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(50) NOT NULL,
	Price MONEY NOT NULL,
	ProductCount Float NOT NULL
);

CREATE TABLE BreadAndSouce
(
	Id INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(50) NOT NULL,
	Price MONEY NOT NULL,
	ProductCount Float NOT NULL
);

CREATE TABLE Deserts
(
	Id INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(50) NOT NULL,
	Price MONEY NOT NULL,
	ProductCount Float NOT NULL
);

CREATE TABLE Tea
(
	Id INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(50) NOT NULL,
	Price MONEY NOT NULL,
	ProductCount Float NOT NULL
);

CREATE TABLE Coffee
(
	Id INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(50) NOT NULL,
	Price MONEY NOT NULL,
	ProductCount Float NOT NULL
);

CREATE TABLE AdditionsToTeaCoffee
(
	Id INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(50) NOT NULL,
	Price MONEY NOT NULL,
	ProductCount Float NOT NULL
);

CREATE TABLE Users
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(50) NOT NULL,
	Passwd VARCHAR(25) UNIQUE,
	Status INT NOT NULL
);

CREATE TABLE Sales
(
	Id INT PRIMARY KEY IDENTITY,
	ProductName NVARCHAR(50) NOT NULL,
	Amount MONEY NOT NULL,
	Quantity Float NOT NULL,
	NameUsers NVARCHAR(50) NOT NULL,
	Date DATE NOT NULL,
	Time TIME NOT NULL 
);

INSERT INTO Refill VALUES
('АИ 95', 55.99, 1000),
('АИ 92', 51.29, 1000),
('ДТ', 59.99, 1000)

INSERT INTO HotDish VALUES
('Шашлык из варанины 175/50г', 350, 20),
('Шашлык из свинины 220/50г', 340, 35),
('Шашлык из курицы 150/50', 290, 20),
('Куриная колбаска гриль 180/50г', 275, 25),
('Свиная колбаска гриль 180/50г', 275, 20),
('Биф-стейк с имбирным соусом 210/30/10', 580, 15),
('Стейк из свинины с соусом терияки 190/50г', 390, 15),
('Стейк из сёмги 100г', 220, 10),
('Форель радужная 100г', 160, 10)

INSERT INTO Garnish VALUES
('Запечёный картофель 150/50г', 120, 10),
('Картофель фри 150г', 120, 10),
('Овощи гриль 150г', 150, 10)

INSERT INTO BreadAndSouce VALUES
('Пита/Лаваш', 50, 20),
('Кетчуп 50г', 40, 30),
('Острый соус 50г', 50, 20),
('Тар-тар 50г', 50, 20)

INSERT INTO Deserts VALUES
('Тирамису 175г', 210, 20),
('Медовик 150/30г', 160, 20),
('Фруктовый салат 250г', 220, 15),
('Мороженое 50/10г', 90, 20)

INSERT INTO Tea VALUES
('Чёрный чай 400мл', 200, 20),
('Зелёный чай 400мл', 200, 20),
('Фруктовый чай 400мл', 200, 20),
('Травяной чай 400мл', 200, 20),
('Фирменный чай 400мл', 200, 20)


INSERT INTO Coffee VALUES
('Экспрессо 50мл', 120, 20),
('Дабл экспрессо 100мл', 160, 20),
('Капучино 150мл', 170, 20),
('Американо 120мл', 150, 20),
('Латте 200мл', 200, 20),
('Гляссе 200мл', 230, 20)

INSERT INTO AdditionsToTeaCoffee VALUES
('Лимон 50г', 30, 20),
('Лайм 40г', 30, 20),
('Молоко 50мл', 30, 20),
('Сливки 50мл', 30, 20),
('Мята 5г', 30, 20)

INSERT INTO Users VALUES
('Кассир1', '123456', 0),
('Кассир2','654321', 0),
('Кассир','0987654321', 1),
('Администратор','1234567890', 2)