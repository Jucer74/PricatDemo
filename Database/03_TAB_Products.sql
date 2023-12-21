CREATE TABLE Products (
    Id          INTEGER         PRIMARY KEY AUTOINCREMENT
                                NOT NULL,
    CategoryId  INTEGER         CONSTRAINT FK_Products_Categories REFERENCES Categories (Id) ON DELETE CASCADE
                                                                                             ON UPDATE CASCADE
                                NOT NULL,
    EanCode     STRING (13)     NOT NULL
                                CONSTRAINT UK_EanCode UNIQUE,
    Description STRING (50)     NOT NULL,
    Unit        STRING (20)     NOT NULL,
    Price       DECIMAL (13, 2) NOT NULL
);
