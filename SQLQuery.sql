CREATE TABLE Users 
(
    UserId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    Username NVARCHAR(20) NOT NULL,
    [Password] NVARCHAR(64) NOT NULL,
    Email NVARCHAR(50) UNIQUE NOT NULL,
    IsActive BIT DEFAULT 1 NOT NULL
);

go

CREATE TABLE UserProfiles
(
    UserProfileId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    FirstName VARCHAR(20) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    PersonalNumber VARCHAR(11) UNIQUE NOT NULL,
    UserId INT UNIQUE,
    FOREIGN KEY (userId) REFERENCES Users(userId)
);