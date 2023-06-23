1. What is the total number of songs liked by each user

SELECT U.UserId, U.UserName, COUNT(UserLikesId) AS TotalLikes
FROM dbo.Users AS U
LEFT JOIN dbo.UserLikes AS UL ON U.UserId = UL.UserId
GROUP BY U.UserId, U.Username;

2. List the usernames of users who have never liked any song.

 SELECT Username
FROM dbo.Users

WHERE UserId NOT IN (
	SELECT UserId 
	FROM dbo.UserLikes
);

3.List the usernames of users who have liked all songs in a specific playlist.

SELECT U.Username
FROM Users AS U
WHERE NOT EXISTS (
	SELECT PS.SongId
	FROM PlaylistSongs AS PS
	LEFT JOIN Playlists AS P ON P.PlaylistId = PS.PlaylistId
	WHERE P.Title = 'Trip'
	AND PS.SongId NOT IN (SELECT UL.SongId FROM UserLikes AS UL WHERE UL.UserId = U.UserId) 
);

4. Retrieve the top 5 most liked songs and their corresponding like counts.

SELECT TOP 5 S.SongId, S.Title, COUNT(UL.SongId) AS MostLiked
FROM Songs AS S
LEFT JOIN UserLikes AS UL ON UL.SongId = S.SongId
GROUP BY S.SongId, S.Title
HAVING COUNT(UL.SongId) > 0
ORDER BY MostLiked DESC

5. Which songs appear in more than one playlist.

SELECT P.Title AS PlaylistTitle, S.Title AS SongTitle, PS.PlaylistId, COUNT(DISTINCT PS2.PlaylistId) AS PlaylistCount
FROM PlaylistSongs AS PS
JOIN Playlists AS P ON P.PlaylistId = PS.PlaylistId
JOIN Songs AS S ON S.SongId = PS.SongId
JOIN PlaylistSongs AS PS2 ON PS2.SongId = PS.SongId
GROUP BY P.Title, S.Title, PS.PlaylistId
HAVING COUNT(DISTINCT PS2.PlaylistId) > 1
ORDER BY PlaylistCount DESC;

6. Get the total number of songs liked by each user

SELECT u.UserId, u.Username, COUNT(ul.SongId) AS TotalLikedSongs
FROM Users u
LEFT JOIN UserLikes ul ON u.UserId = ul.UserId
GROUP BY u.UserId, u.Username;

7. Which users have liked songs from the "Pop" genre and have listened to any album released
by the artist named "Ed Sheeran".

SELECT DISTINCT U.UserId, U.Username
FROM Users U
JOIN UserLikes AS UL ON u.UserId = UL.UserId
JOIN Songs AS S ON ul.SongId = S.SongId
JOIN Albums AS A ON S.ArtistId = A.ArtistId
JOIN Artists AS AR ON A.ArtistId = AR.ArtistId
WHERE S.Genre = 'Pop' AND AR.Name = 'Ed Sheeran';

