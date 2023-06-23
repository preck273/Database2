
--A view in a database is a virtual table that is derived from one or more underlying tables

--1.Create a view for Top 5 most liked songs along with the number of likes each song has received.

CREATE VIEW PopularSongs AS
SELECT TOP 5 S.SongId, S.Title, COUNT(UserLikes.UserLikesId) AS LikeCount
FROM Songs AS S
LEFT JOIN UserLikes ON S.SongId = UserLikes.SongId
GROUP BY S.SongId, S.Title
ORDER BY LikeCount DESC;

--2.Create a view to lists the albums associated with each artist, along with the release date and the number of songs in each album.

CREATE VIEW ArtistAlbums AS
SELECT A.ArtistId, A.Name AS ArtistName, AB.AlbumId, AB.Title AS AlbumTitle, AB.ReleaseDate, COUNT(S.SongId) AS SongCount
FROM Artists AS A
INNER JOIN Albums AS AB ON A.ArtistId = AB.ArtistId
INNER JOIN Songs AS S ON AB.AlbumId = S.ArtistId
GROUP BY A.ArtistId, A.Name, AB.AlbumId, AB.Title, AB.ReleaseDate;

-- A stored procedure is a prepared SQL code that can be saved, so the code can be reused over and over again. 

--1. Create a stored procedure to inserts a new user into the Users table.

CREATE PROCEDURE CreateUser
    @Username NVARCHAR(50),
    @Email NVARCHAR(50),
    @Password NVARCHAR(255),
    @RegisteredDate DATETIME
AS
BEGIN
    INSERT INTO Users (Username, Email, Password, RegisteredDate)
    VALUES (@Username, @Email, @Password, @RegisteredDate)
END;
EXEC CreateUser

'Pepe', 'Pepe@email.com', '12345', '10-06-2023';

--2. Creating a stored procedure to delete a user and their associated data from the database.
CREATE PROCEDURE DeleteUser
    @UserId INT
AS
BEGIN
    DELETE FROM UserLikes WHERE UserId = @UserId
    DELETE FROM Playlists WHERE UserId = @UserId
    DELETE FROM Users WHERE UserId = @UserId
END;

EXEC DeleteUser @UserId = 1006

--Trigger 