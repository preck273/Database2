--Trigger are types of stored procedures that run in response to an event occurring in a database.

-- 1 create a trigger to deletes associated playlist songs when a playlist is deleted.

CREATE TRIGGER DeleteAssociatedPlaylistSongs
ON Playlists
AFTER DELETE
AS
BEGIN
    DELETE FROM PlaylistSongs
    WHERE PlaylistId IN (SELECT PlaylistId FROM DELETED);
END;


-- 2 create a trigger to automatically add a song to the UserLikes table when a user adds it to a playlist.

CREATE TRIGGER AddToUserLikes
ON PlaylistSongs
AFTER INSERT
AS
BEGIN
    INSERT INTO UserLikes (UserId, SongId)
    SELECT p.UserId, ps.SongId
    FROM INSERTED ps
    JOIN Playlists p ON ps.PlaylistId = p.PlaylistId;
END;


