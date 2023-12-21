CREATE TABLE Users (
    Id        INTEGER      PRIMARY KEY AUTOINCREMENT
                           NOT NULL,
    UserEmail STRING (300) NOT NULL
                           CONSTRAINT UK_UserEmail UNIQUE,
    FirstName STRING (50)  NOT NULL,
    LastName  STRING (50)  NOT NULL,
    Password  STRING (20)  NOT NULL
);
