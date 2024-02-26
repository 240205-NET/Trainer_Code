CREATE SCHEMA [Garden];
GO

-- DROP TABLE [Garden].[Plants];
-- Go

CREATE TABLE [Garden].[Plants]
(
    PlantID INT PRIMARY KEY IDENTITY,
    SName NVARCHAR(255) NOT NULL,
    CName NVARCHAR(255) NOT NULL,
    Zone INT NOT NULL,
    Size INT NOT NULL,
    AdoptionDate DATETIME2 NOT NULL
)
GO

SELECT * FROM [Garden].[Plants];