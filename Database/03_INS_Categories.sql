DELETE FROM Categories WHERE Id >= 0;
DELETE FROM sqlite_sequence WHERE name='Categories';
INSERT INTO Categories(`Description`) VALUES('Alimentos');
INSERT INTO Categories(`Description`) VALUES('Bebidas');
INSERT INTO Categories(`Description`) VALUES('Productos de Aseo');
INSERT INTO Categories(`Description`) VALUES('Ropa');
INSERT INTO Categories(`Description`) VALUES('Medicamentos');
