--Populating Products table
INSERT INTO Products (make, text, price)
VALUES ('Jammers','The Ipsum Solid Compression Swim Jammer lets you swim with the confidence of unrivaled value.', 19.99);
INSERT INTO Products (make, text, price)
VALUES ('Briefs','The Ipsum Solid Swim Brief offers the same sleek brief style with a higher leg cut for even greater freedom of movement.', 19.99);
INSERT INTO Products (make, text, price)
VALUES ('One Piece','Swim comfortably in the Ipsum Solid Racerback One Piece Swimsuit. The narrow straps allows for better range of motion and flat seams reduce chafing.', 19.99);
INSERT INTO Products (make, text, price)
VALUES ('Goggles','The Ipsum Antifog S2 Mirrored Goggles offer high-quality anti-fog lenses; sleek, competitive styling; and an amazing streamline fit.', 9.99);
INSERT INTO Products (make, text, price)
VALUES ('Silicone cap','Reduce drag and protect your hair with the New Ipsum Latex Swim Caps.', 5.99);
INSERT INTO Products (make, text, price)
VALUES ('Kickboard','The Ipsum Kickboard is made of EVA foam for a stiffer board and features a channel on the bottom of the board that can be used as a hand grip.', 5.99);
INSERT INTO Products (make, text, price)
VALUES ('Pull buoy','The Ipsum Pull Buoy is essential for every swimmer. Perfect for practice, this pull buoy helps to elevate your lower body for a streamlined, correct body position in the water that enhances your technique and speed.', 8.99);
INSERT INTO Products (make, text, price)
VALUES ('Paddles','Focus on your swim and train with the Ipsum Nemesis Contour Paddles. The perfect fitness paddle for all swimming abilities, these swim paddles help you improve your swimming abilities for enhanced performance.', 8.99);
INSERT INTO Products (make, text, price)
VALUES ('Weighted fins','Go beyond your limits with the Ipsum Pro Weighted fins - with a patented compartment to fit various Ipsum weights to bring the power of your kick to another level.', 99.99);
INSERT INTO Products (make, text, price)
VALUES ('Training fins','Train hard and improve your speed and technique with the Ipsum Pro Swim Fins.', 19.99);
INSERT INTO Products (make, text, price)
VALUES ('Fins','Swim freely with underwater creatures, with the new Ispsum Flex Swim Fins 2.0.', 10.99);
INSERT INTO Products (make, text, price)
VALUES ('Snorkels','Explore what the sea with the Ipsum Pro III Swim Snorkel.', 109.99);
INSERT INTO Products (make, text, price)
VALUES ('Towels','Stay snug and warm at the beach this summer in the ultra-soft Ipsum Comfort Beach Towel. The durable terry cloth construction provides excellent softness and absorbency.', 19.99);
INSERT INTO Products (make, text, price)
VALUES ('Speedo Bag','Travel to your next meet with the Ipsum Team Allover Backpack. This backpack features multiple compartments for all of your training gear.', 39.99);
INSERT INTO Products (make, text, price)
VALUES ('Mesh bag','The Ipsum Mesh Bag is a great solution for storing your wet pool training gear after a long swim practice or training session.', 19.99);

--Populating Stores table
INSERT INTO Stores (city, state, address, phone)
VALUES ('Tampa', 'FL', '123 Tampa Rd', 7271234567);
INSERT INTO Stores (city, state, address, phone)
VALUES ('New York City', 'NY', '222 Main St',2124567890);
INSERT INTO Stores (city, state, address, phone)
VALUES ('Los Angeles', 'CA', '777 Hollywood Blvd',2135559900);
INSERT INTO Stores (city, state, address, phone)
VALUES ('Portland', 'Oregon', '420 Main St',5031237788);
INSERT INTO Stores (city, state, address, phone)
VALUES ('DC', 'DC', '456 Washington St',2022804364);
INSERT INTO Stores (city, state, address, phone)
VALUES ('Atlanta', 'GA', '404 Emory Rd',7701237890);

--Populating Customers table
INSERT INTO Customers (fname, lname, usrname, pwd, email)
VALUES ('Mark','Moore', 'MMore','uniquepassword','MarkMoore@revature.net','true');
INSERT INTO Customers (fname, lname, usrname, pwd, email)
VALUES ('Christian','Romero', 'CodeRomero','NoSimpingBelind@007!','christian.romero@revature.net','false');
INSERT INTO Customers (fname, lname, usrname, pwd, email)
VALUES ('Kyle','Romero', 'PricklyApple','mr.pinapple123','yumyumfruit@pinapple.net', 'false');
INSERT INTO Customers (fname, lname, usrname, pwd, email)
VALUES ('Vrinda','Madan', 'veryuneventful','password','vmadan@emory.edu','false');


--Populating Discounts Table
INSERT INTO Discounts (discountName, description, priceModifier)
VALUES ('firstPurchase', 'When customer makes their first purchase', .70);
INSERT INTO Discounts (discountName, description, priceModifier)
VALUES ('Christmas', 'When customer makes a purchase during Christmas time', .80);
INSERT INTO Discounts (discountName, description, priceModifier)
VALUES ('loyaltyProgram', 'When customer is a member', .90);

--Populating Orders Table

--Inventory: product approach w/ Stored Procedures - do later

--store 1

WHILE @count<=15
	BEGIN
		INSERT INTO Inventories (storeId, productId, storeQuantity) VALUES (1, (1000+@count), (8*(@count*1)+20+(@count*.3)))
		SET @count = @count +1;
	END;

--store 2

WHILE @count<=15
BEGIN
	INSERT INTO Inventories (storeId, productId, storeQuantity) VALUES (2, (1000+@count), (100*(@count*.03)+(@count+5)))
		SET @count = @count +1;
END;

--store 3

WHILE @count<=15
BEGIN
	INSERT INTO Inventories (storeId, productId, storeQuantity) VALUES (3, (1000+@count), ROUND(1000*RAND(),3)	)
		SET @count = @count +1;
END;

--store 4

WHILE @count<=15
BEGIN
	INSERT INTO Inventories (storeId, productId, storeQuantity) VALUES (4, (1000+@count), (ROUND(1000*RAND(9),3) ))
		SET @count = @count +1;
END;

--store 5


WHILE @count<=15
BEGIN
	INSERT INTO Inventories (storeId, productId, storeQuantity) VALUES (5, (1000+@count),  ROUND(100*(RAND()*9+1),2) )
		SET @count = @count +1;
END;

--store 6
DECLARE @count INT;
SET @count = 0;

WHILE @count<=15
BEGIN
	INSERT INTO Inventories (storeId, productId, storeQuantity) VALUES (6, (1000+@count), ROUND(10*(RAND()*100+30),2) )
	SET @count = @count +1;
END;

/*Populate ORDERS*/
INSERT INTO Orders (storeId, productId, customerId, quantity, orderTime, total, ordertime)
VALUES (1,1000, 0, 2, );
INSERT INTO Orders (storeId, productId, customerId, quantity, orderTime)
VALUES ('Vrinda','Madan', 'veryuneventful','password','vmadan@emory.edu');
INSERT INTO Orders (storeId, productId, customerId, quantity, orderTime)
VALUES ('Vrinda','Madan', 'veryuneventful','password','vmadan@emory.edu');
INSERT INTO Orders (storeId, productId, customerId, quantity, orderTime)
VALUES ('Vrinda','Madan', 'veryuneventful','password','vmadan@emory.edu');
INSERT INTO Orders (storeId, productId, customerId, quantity, orderTime)
VALUES ('Vrinda','Madan', 'veryuneventful','password','vmadan@emory.edu');
INSERT INTO Orders (storeId, productId, customerId, quantity, orderTime)
VALUES ('Vrinda','Madan', 'veryuneventful','password','vmadan@emory.edu');