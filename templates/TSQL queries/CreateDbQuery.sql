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
phone CHAR(10) NOT NULL CHECK(ISNUMERIC(phone)=1),
);

/*Store Inventory Table*/
Create Table Inventories(
storeId integer FOREIGN KEY REFERENCES Stores(storeId),
productId integer FOREIGN KEY REFERENCES Products(sku),
storeQuantity integer,
);

/*Customer Table*/
CREATE Table Accounts(
accountId int PRIMARY KEY IDENTITY (0,1),
fname NVARCHAR(50) NOT NULL ,
lname NVARCHAR(50) NOT NULL,
usrname NVARCHAR(50) UNIQUE,
pwd NVARCHAR(100),
email NVARCHAR(255) UNIQUE,
membership VARCHAR CHECK (membership = 'false' OR membership = 'true'),
balance int CHECK(balance >0)
);

/*Order Table*/
CREATE Table Orders(
orderId integer PRIMARY KEY IDENTITY(1,1),
storeId integer FOREIGN KEY REFERENCES Stores(storeId),
productId integer FOREIGN KEY REFERENCES Products(sku),
accountId integer FOREIGN KEY REFERENCES Accounts(accountId),
quanity integer,
total float,
createdAtTime DATETIMEOFFSET NOT NULL,
);

/*Favorite Store Table*/
CREATE TABLE FavoriteStore(
favorited VARCHAR CHECK (favorited = 'false' OR favorited = 'true'),
storeId integer FOREIGN KEY REFERENCES Stores(storeId),
accountId integer FOREIGN KEY REFERENCES Accounts(accountId),
);

/*Discount Table*/
CREATE Table Discounts(
discountId int PRIMARY KEY IDENTITY (100,1),
description NVARCHAR (100),
discountName NVARCHAR(50) NOT NULL UNIQUE,
priceModifier float NOT NULL
);

/*Cart Tables*/
Create Table Carts(
cartId int PRIMARY KEY Identity(1,1) ,
accountId int FOREIGN KEY REFERENCES Accounts(accountId),
productId int FOREIGN KEY REFERENCES Products(sku),
quantity int NOT NULL CHECK(quantity >0),
storeId int FOREIGN KEY REFERENCES Stores(storeId),
)

/*Session Table*/
Create Table Sessions(
sessionId int PRIMARY KEY,
accountId int FOREIGN KEY REFERENCES Accounts(accountId),
cartId int FOREIGN KEY REFERENCES Carts(cartId),
)