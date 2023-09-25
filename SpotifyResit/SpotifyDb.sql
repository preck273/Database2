CREATE DATABASE SpotifyDatabaseResit

USE SpotifyDatabaseResit;
GO

CREATE TABLE Users
(
    UserId INT PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL,
    Email NVARCHAR(50) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL,
    RegisteredDate DATETIME NOT NULL
);

CREATE TABLE Artists
(
    ArtistId INT PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL,
    Biography NVARCHAR(250) NOT NULL,
    Origin NVARCHAR(50) NOT NULL
);

CREATE TABLE Genre
(
    GenreId INT PRIMARY KEY,
    GenreName NVARCHAR(20) NOT NULL
);

CREATE TABLE Songs
(
    SongId INT PRIMARY KEY,
    Title NVARCHAR(50) NOT NULL,
    Duration TIME NOT NULL,
    ReleaseDate DATETIME NOT NULL,
    ArtistId INT NOT NULL,
    FOREIGN KEY (ArtistId) REFERENCES Artists (ArtistId) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE SongGenre
(
    SongGenerId INT NOT NULL,
    SongId INT NOT NULL,
    GenreId INT NOT NULL,
    FOREIGN KEY (SongId) REFERENCES Songs (SongId) ON DELETE NO ACTION ON UPDATE NO ACTION
    FOREIGN KEY (GenreId) REFERENCES Genre (GenreId) ON DELETE NO ACTION ON UPDATE NO ACTION
    UNIQUE (SongId, GenreId)
);


CREATE TABLE Albums
(
    AlbumId INT PRIMARY KEY,
    Title NVARCHAR(50) NOT NULL,
    ReleaseDate DATETIME NOT NULL,
    SongId INT NOT NULL,
    ArtistId INT NOT NULL,
    FOREIGN KEY (SongId) REFERENCES Songs (SongId) ON DELETE NO ACTION ON UPDATE NO ACTION,
    FOREIGN KEY (ArtistId) REFERENCES Artists (ArtistId) ON DELETE NO ACTION ON UPDATE NO ACTION
);

CREATE TABLE Playlists
(
    PlaylistId INT PRIMARY KEY,
    Title NVARCHAR(50) NOT NULL,
    CreationDate DATETIME NOT NULL,
    UserId INT NOT NULL,
    FOREIGN KEY (UserId) REFERENCES Users (UserId) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE PlaylistSongs
(
    PlaylistSongId INT PRIMARY KEY,
    Position INT NOT NULL,
    PlaylistId INT NOT NULL,
    SongId INT NOT NULL,
    FOREIGN KEY (PlaylistId) REFERENCES Playlists (PlaylistId) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (SongId) REFERENCES Songs (SongId) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE UserLikes
(
    UserLikesId INT PRIMARY KEY,
    UserId INT NOT NULL,
    SongId INT NOT NULL,
    FOREIGN KEY (UserId) REFERENCES Users (UserId) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (SongId) REFERENCES Songs (SongId) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Adding CHECK constraints
ALTER TABLE Songs
ADD CONSTRAINT CHK_Duration CHECK (Duration >= '00:00:00');

-- Adding an index on UserId in the Playlists table for faster queries
CREATE INDEX IDX_Playlists_UserId ON Playlists (UserId);

-- Adding an index on PlaylistId in the PlaylistSongs table for faster queries
CREATE INDEX IDX_PlaylistSongs_PlaylistId ON PlaylistSongs (PlaylistId);

-- Adding an index on SongId in the UserLikes table for faster queries
CREATE INDEX IDX_UserLikes_SongId ON UserLikes (SongId);

-- Create an index on SongId in the SongGenre table for faster queries
CREATE INDEX idx_SongGenre_SongId ON SongGenre (SongId);

GO
