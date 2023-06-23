--1. Full Backup backs up everything and can retore a database exactly in the same form
BACKUP DATABASE SpotifyDatabase
TO DISK = 'C:\Users\Pepelito\SpotifyDb_full.bak'
WITH FORMAT,
MEDIANAME = 'Native_SQLServerFullBackup',
      NAME = 'Full-SpotifyDatabase backup';

--2. Differential Backup is the superset of the last full backup and contains all changes that have been made since the last full backup.
BACKUP DATABASE SpotifyDatabase
TO DISK = 'C:\Users\Pepelito\SpotifyDb_diff.bak'
WITH DIFFERENTIAL,
MEDIANAME = 'Native_SQLServerDiffBackup',
      NAME = 'Diff-SpotifyDatabase backup';

--3. Tracsactional Log:  This backup type is possible only with full or bulk-logged recovery models. A transaction log file stores a series of the logs that provide the history of every modification of data, in a database.

BACKUP LOG SpotifyDatabase
TO DISK = 'C:\Users\Pepelito\SpotifyDb_log.trn'
WITH INIT, FORMAT, NAME = 'Log-SpotifyDatabase backup';


--ran into some erros saying database is in use and error suggests using the WITH MOVE option to specify a valid location for the database files to restore
--RESTORE FILELISTONLY
--FROM DISK = 'C:\Users\Pepelito\SpotifyDb_full.bak';

--Restore Backup
--1. Restore full backup

USE master;
RESTORE DATABASE SpotifyDatabaseNew
FROM DISK = 'C:\Users\Pepelito\SpotifyDb_full.bak'
WITH REPLACE,
MOVE 'SpotifyDatabase' TO 'C:\Backup2\SpotifyDatabase.mdf',
MOVE 'SpotifyDatabase_log' TO 'C:\Backup2\SpotifyDatabase_log.ldf';

--2. Restore Diffrencial backup, a transactional log backup has to be restore before restoring differential backup



Concurrency

--first set to Transaction isolation level SERIALIZATTION. It ensures that concurrent transactions cannot read or modify data that has been read which prevent phantom read

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

1. Transaction: Reading data from table

BEGIN TRANSACTION;

SELECT U.UserId, U.UserName, COUNT(UserLikesId) AS TotalLikes
FROM dbo.Users AS U
LEFT JOIN dbo.UserLikes AS UL ON U.UserId = UL.UserId
GROUP BY U.UserId, U.Username;

COMMIT;

2. Transaction: To update Genre from pop to rock where Artist name is Ed Sheeran. This transaction will acquire appropriate locks to prevent conflicts and minimize the chances of deadlocks.

BEGIN TRANSACTION;

UPDATE Albums
SET Genre = 'Rock'
FROM Albums AS A
JOIN Songs AS S ON A.SongId = S.SongId
JOIN Artists AS AR ON A.ArtistId = AR.ArtistId
WHERE S.Genre = 'Pop' AND AR.Name = 'Ed Sheeran';

COMMIT;






2.

