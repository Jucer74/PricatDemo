DELETE FROM Categories WHERE Id >= 0;
DELETE FROM sqlite_sequence WHERE name='Categories';
INSERT INTO Categories(Description) VALUES('Food');
INSERT INTO Categories(Description) VALUES('Drinks');
INSERT INTO Categories(Description) VALUES('Grooming Products');
INSERT INTO Categories(Description) VALUES('Clothes');
INSERT INTO Categories(Description) VALUES('Medicines');
INSERT INTO Categories(Description) VALUES('Tools');
INSERT INTO Categories(Description) VALUES('Fruit');
INSERT INTO Categories(Description) VALUES('Jewelery');
INSERT INTO Categories(Description) VALUES('Technology');
INSERT INTO Categories(Description) VALUES('Toy store');
INSERT INTO Categories(Description) VALUES('Pets');
INSERT INTO Categories(Description) VALUES('Shoes');

