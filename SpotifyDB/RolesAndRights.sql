--1. Create AdminUser
USE master;
GO

CREATE LOGIN [AdminLogin] WITH PASSWORD = '12345';

--1.2 Add Admin to the SpotifyDatabase

USE SpotifyDatabase;
GO

CREATE USER [AdminUser] FOR LOGIN [AdminLogin];


--1.3. Add roles and grant permission
USE SpotifyDatabase;
GO

-- Add the user to the desired database roles
EXEC sp_addrolemember 'db_owner', 'AdminUser'; 

GRANT SELECT, INSERT, UPDATE, DELETE ON SCHEMA::dbo TO [AdminUser];

--2.Creating New Login for user( John Paul)

 USE master;
GO

CREATE LOGIN [John Paul] WITH PASSWORD = '12345';
GO

--2.1. Add the John paul User to the SpotifyDatabe

USE SpotifyDatabase;
GO

CREATE USER [John Paul] FOR LOGIN [John Paul];
GO

--2.2 Create Roles and Add permission

USE SpotifyDatabase;
GO

-- Create the custom role
CREATE ROLE Chief_Data_Analyst;
GO

-- Grant DML permissions to the Chief_Data_Analyst
GRANT SELECT, INSERT, UPDATE, DELETE ON SCHEMA::dbo TO Chief_Data_Analyst;
GO

--2.3. Add John paul to Chief_Data_Analyst role

USE SpotifyDatabase;
GO
-- Add the user to the database roles
EXEC sp_addrolemember 'Chief_Data_Analyst', 'John Paul';
GO

--3. Create New Login for James Brown

USE master;
GO

CREATE LOGIN [JamesBrown] WITH PASSWORD = '12345';
GO

--3.1 Add the James Brown User to the SpotifyDatabe

USE SpotifyDatabase;
GO

CREATE USER [James Brown] FOR LOGIN [JamesBrown];
GO

--3.2. Create Role and grant permission for Jonior_analyst
USE SpotifyDatabase;
GO

-- Create the role
CREATE ROLE Junior_Data_Analyst;
GO

-- Grant DML permission
GRANT SELECT, INSERT, UPDATE, DELETE ON SCHEMA::dbo TO Junior_Data_Analyst;

-- Deny SELECT permissions on specific tables
DENY SELECT, INSERT, UPDATE, DELETE ON dbo.Playlists TO Junior_Data_Analyst;
DENY SELECT, INSERT, UPDATE, DELETE ON dbo.UserLikes TO Junior_Data_Analyst;

--3.3. Add James Brown to Junior_Data_Analyst Role

USE SpotifyDatabase;
GO
-- Add the user to the database roles
EXEC sp_addrolemember 'Junior_Data_Analyst', 'James Brown';
GO
