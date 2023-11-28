CREATE TABLE Users 
(
    userId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    username NVARCHAR(20) NOT NULL,
    [password] VARCHAR(64) NOT NULL,
    email NVARCHAR(50) UNIQUE NOT NULL,
    isActive BIT DEFAULT 1 NOT NULL
);

go

CREATE TABLE UserProfiles
(
    userProfilesId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    firstName VARCHAR(20) NOT NULL,
    lastName VARCHAR(50) NOT NULL,
    personalNumber VARCHAR(11) UNIQUE NOT NULL,
    userId INT UNIQUE,
    FOREIGN KEY (userId) REFERENCES Users(userId)
);