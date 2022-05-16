/*This Query creates the Tables*/

/*ProductTable*/
CREATE Table Products(
sku integer PRIMARY KEY IDENTITY (1000,1),
make NVARCHAR(50) NOT NULL,
text NVARCHAR(400) NOT NULL Unique,
price decimal (5,2)
);

/*Retail Stores Table*/
CREATE Table Stores(
storeId integer PRIMARY KEY IDENTITY (1,1),
city NVARCHAR(50) NOT NULL,
state NVARCHAR(10) NOT NULL,
address NVARCHAR(200) UNIQUE,
phone CHAR(10) NOT NULL CHECK(ISNUMERIC(phone)='1'),
);

/*Customer Table*/
CREATE Table Customers(
customerId int PRIMARY KEY IDENTITY (0,1),
fname NVARCHAR(50) NOT NULL ,
lname NVARCHAR(50) NOT NULL,
usrname NVARCHAR(50) UNIQUE,
pwd NVARCHAR(100),
email NVARCHAR(255) UNIQUE,
membership VARCHAR CHECK (membership = 'false' OR membership = 'true')
);

/*Store Inventory Table*/
Create Table Inventories(
storeId integer FOREIGN KEY REFERENCES Stores(storeId),
productId integer FOREIGN KEY REFERENCES Products(sku),
storeQuantity integer,
);

/*Order Table*/
CREATE Table Orders(
orderId integer PRIMARY KEY IDENTITY(1,1),
storeId integer FOREIGN KEY REFERENCES Stores(storeId),
productId integer FOREIGN KEY REFERENCES Products(sku),
customerId integer FOREIGN KEY REFERENCES Customers(customerId),
quanity integer,
total float,
orderTime DATETIMEOFFSET NOT NULL,
);

/*Favorite Store Table*/
CREATE TABLE FavoriteStore(
favorited VARCHAR CHECK (favorited = 'false' OR favorited = 'true'),
storeId integer FOREIGN KEY REFERENCES Stores(storeId),
customerId integer FOREIGN KEY REFERENCES Customers(customerId),
);

/*Discount Table*/
CREATE Table Discounts(
discountId int PRIMARY KEY IDENTITY (100,1),
description NVARCHAR (100),
discountName NVARCHAR(50) NOT NULL UNIQUE,
priceModifier float NOT NULL
);


/*Session Table*/

/*Cart Table*/