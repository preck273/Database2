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

