CREATE TABLE Coupon (
    ID SERIAL PRIMARY KEY  NOT NULL,
    ProductName  VARCHAR(24)  NOT NULL,
    Description  TEXT,
    Amount  INT
);