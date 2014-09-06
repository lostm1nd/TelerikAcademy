CREATE TABLE People(
  PersonId int NOT NULL PRIMARY KEY IDENTITY,
  Name varchar(100),
  Birthday datetime
)

===========================================================================
===========================================================================

INSERT INTO People(Name, Birthday) VALUES ('Nikolay Kostov', '1985-05-05')
INSERT INTO People(Name, Birthday) VALUES ('Doncho Minkov', '1988-04-04')
INSERT INTO People(Name, Birthday) VALUES ('Ivaylo Kenov', '1989-03-03')
INSERT INTO People(Name, Birthday) VALUES ('Evlogi Hristov', '1987-02-02')
INSERT INTO People(Name, Birthday) VALUES ('Bay Ivan', '1980-01-01')
INSERT INTO People(Name, Birthday) VALUES ('Kaka Penka', '1982-05-15')
INSERT INTO People(Name, Birthday) VALUES ('Bate Goyko', '1985-12-12')
INSERT INTO People(Name, Birthday) VALUES ('Bash Maistora', '1983-11-11')
INSERT INTO People(Name, Birthday) VALUES ('Lelya Ginka', '1981-09-10')
INSERT INTO People(Name, Birthday) VALUES ('Chicho Mitko', '1980-06-16')

===========================================================================
===========================================================================

DECLARE @Counter int = 0
WHILE (SELECT COUNT(*) FROM People) < 1000000
BEGIN
  INSERT INTO People(Name, Birthday)
  SELECT Name + CONVERT(varchar, @Counter), DATEADD(MINUTE, RAND(CHECKSUM(NEWID())) * @Counter, Birthday)
  FROM People
  SET @Counter = @Counter + 1
END

===========================================================================
===========================================================================

CHECKPOINT; DBCC DROPCLEANBUFFERS;
SELECT *
FROM People
WHERE Birthday BETWEEN '1981-01-01' AND '1985-12-31'

===========================================================================
===========================================================================

CREATE INDEX IDX_People_Birthday
ON People(Birthday)

===========================================================================
===========================================================================

CHECKPOINT; DBCC DROPCLEANBUFFERS;
SELECT *
FROM People
WHERE Birthday BETWEEN '1981-01-01' AND '1985-12-31'

===========================================================================
===========================================================================

ALTER TABLE People
ADD Remarks text

===========================================================================
===========================================================================

UPDATE People
SET Remarks = 'The data types varchar and text are incompatible in the add operator.'
WHERE PersonId LIKE '%1';

===========================================================================
===========================================================================

UPDATE People
SET Remarks = 'Be careful when updating records. If we had omitted the WHERE clause it would go boom.'
WHERE PersonId LIKE '%3';

===========================================================================
===========================================================================

UPDATE People
SET Remarks = 'The idea is to generate a random offset from the start datetime, and add the offset to the start datetime to get a new datetime in between the start datetime and the end datetime.'
WHERE Name LIKE 'Iv%';

===========================================================================
===========================================================================

SELECT *
FROM People
WHERE Remarks LIKE '%data%'