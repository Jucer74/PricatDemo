DELETE FROM Users WHERE Id >= 0;
DELETE FROM sqlite_sequence WHERE name='Users';

INSERT INTO Users(UserEmail, FirstName, LastName, Password) VALUES ('Admin@email.com', 'Admin', 'User', 'P4ssw0rd*01');
