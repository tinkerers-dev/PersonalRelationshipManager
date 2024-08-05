CREATE TABLE Relationships
(
    Id             UUID PRIMARY KEY,
    Type           VARCHAR(100)   NOT NULL,
    ContactMethods VARCHAR(100)[] NOT NULL,
    Email          VARCHAR(255)   NOT NULL,
    Name           VARCHAR(255)   NOT NULL,
    Phone          VARCHAR(50)    NOT NULL,
    Nickname       VARCHAR(255)   NOT NULL,
    CreatedAt      TIMESTAMP,
    UpdatedAt      TIMESTAMP
);