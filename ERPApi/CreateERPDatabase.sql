CREATE DATABASE ERP;
GO

USE ERP;
GO

CREATE TABLE Client (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(50),
    Email NVARCHAR(100),
    Phone NVARCHAR(20)
);

INSERT INTO Client (Name, Email, Phone) VALUES
('User 1', 'user1@example.com', '123456789'),
('User 2', 'user2@example.com', '987654321'),
('User 3', 'user3@example.com', '555123456');
GO
