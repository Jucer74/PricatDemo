-- Clean Users
DELETE FROM Users WHERE Id >= 0;
DELETE FROM sqlite_sequence WHERE name='Users';

-- Clean Products
DELETE FROM Products WHERE Id >= 0;
DELETE FROM sqlite_sequence WHERE name='Products';

-- Clean Categories
DELETE FROM Categories WHERE Id >= 0;
DELETE FROM sqlite_sequence WHERE name='Categories';

-- Insert Users
INSERT INTO Users(UserEmail, FirstName, LastName, Password) VALUES ('Admin@email.com', 'Admin', 'User', 'P4ssw0rd*01');

-- Insert Categories
INSERT INTO Categories(`Description`) VALUES('Alimentos');
INSERT INTO Categories(`Description`) VALUES('Bebidas');
INSERT INTO Categories(`Description`) VALUES('Productos de Aseo');
INSERT INTO Categories(`Description`) VALUES('Ropa');
INSERT INTO Categories(`Description`) VALUES('Medicamentos');

-- Insert Products
INSERT INTO Products (`CategoryId`, `EanCode`, `Description`, `Unit`, `Price`) VALUES ( 1, '7707548516286', 'Arroz', 'Lb', 500.00);
INSERT INTO Products (`CategoryId`, `EanCode`, `Description`, `Unit`, `Price`) VALUES ( 1, '7707548941507', 'Papa', 'Lb', 1500.00);
INSERT INTO Products (`CategoryId`, `EanCode`, `Description`, `Unit`, `Price`) VALUES ( 2, '7707548160274', 'Cocacola', 'Lb', 2500.00);
INSERT INTO Products (`CategoryId`, `EanCode`, `Description`, `Unit`, `Price`) VALUES ( 2, '7707548110958', 'Pepsi', 'Und', 2500.00);
INSERT INTO Products (`CategoryId`, `EanCode`, `Description`, `Unit`, `Price`) VALUES ( 3, '7707548758303', 'Detergente', 'Kg', 12500.00);
INSERT INTO Products (`CategoryId`, `EanCode`, `Description`, `Unit`, `Price`) VALUES ( 3, '7707548210801', 'Cloro', 'CC', 21500.00);
INSERT INTO Products (`CategoryId`, `EanCode`, `Description`, `Unit`, `Price`) VALUES ( 4, '7707548472247', 'Camisa', 'Und', 1500.00);
INSERT INTO Products (`CategoryId`, `EanCode`, `Description`, `Unit`, `Price`) VALUES ( 4, '7707548427902', 'Pantalon', 'Und', 1500.00);
INSERT INTO Products (`CategoryId`, `EanCode`, `Description`, `Unit`, `Price`) VALUES ( 5, '7707548799412', 'Jarabe para la Tos', 'Und', 32500.00);
INSERT INTO Products (`CategoryId`, `EanCode`, `Description`, `Unit`, `Price`) VALUES ( 5, '7707548861546', 'Aspirina 500 mg x 20 Unidades', 'Caja', 42500.00);
