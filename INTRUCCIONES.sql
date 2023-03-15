
/* ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
       BORRAR DATOS
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// */

-- UsersEpisodes
DELETE FROM NAD_UsersEpisodes

-- UsersSeriesAdd
DELETE FROM NAD_UsersSeriesAdd

-- UsersSeriesAdd
DELETE FROM NAD_Users



/* ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
       INTRUCCIONES DELETE
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// */



/* ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
       INTRUCCIONES INSERT
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// */


/* Insertar episodios vistos (AÑADIR SERIE) */
---------------------------------------------------------------------------------------------
DECLARE @userId INT
SET @userId = 1

DECLARE @idSerie INT
SET @idSerie = 1

DECLARE @season INT
SET @season = 2

DECLARE @episode INT
SET @episode = 2


DECLARE @idEpisode int 

DECLARE MY_CURSOR CURSOR LOCAL STATIC READ_ONLY FORWARD_ONLY 
FOR 
SELECT EPI.id 
FROM NAD_Series AS SER 
INNER JOIN NAD_Seasons AS SEA ON SER.id = SEA.serieId 
INNER JOIN NAD_Episodes AS EPI ON SEA.id = EPI.seasonId 
WHERE SER.id = @idSerie AND (SEA.[order] < @season) OR ((SEA.[order] = @season) AND (EPI.[order] <= @episode)) 
ORDER BY SEA.[order], EPI.[order] 

OPEN MY_CURSOR 
FETCH NEXT FROM MY_CURSOR INTO @idEpisode 
WHILE @@FETCH_STATUS = 0 
BEGIN    
	INSERT INTO NAD_UsersEpisodes (episodeId, userId) VALUES (@idEpisode, @userId) 
	FETCH NEXT FROM MY_CURSOR INTO @idEpisode 
END 
CLOSE MY_CURSOR 
DEALLOCATE MY_CURSOR
---------------------------------------------------------------------------------------------

GO

/* Insertar nuevos episodios vistos (DE LA MISMA TEMPORADA) */
---------------------------------------------------------------------------------------------
DECLARE @userId INT
SET @userId = 1

DECLARE @idSerie INT
SET @idSerie = 1

DECLARE @season INT
SET @season = 2

DECLARE @minEpisode INT
SET @minEpisode = 2

DECLARE @maxEpisode INT
SET @maxEpisode = 6


DECLARE @idEpisode int

DECLARE MY_CURSOR CURSOR LOCAL STATIC READ_ONLY FORWARD_ONLY FOR

-- Consulta
SELECT EPI.id
FROM NAD_Series AS SER 
INNER JOIN NAD_Seasons AS SEA ON SER.id = SEA.serieId 
INNER JOIN NAD_Episodes AS EPI ON SEA.id = EPI.seasonId 
WHERE SER.id = @idSerie AND SEA.[order] = @season AND EPI.[order] BETWEEN @minEpisode+1 AND @maxEpisode
ORDER BY SEA.[order], EPI.[order]

OPEN MY_CURSOR 
FETCH NEXT FROM MY_CURSOR INTO @idEpisode 

WHILE @@FETCH_STATUS = 0 
BEGIN    
	INSERT INTO NAD_UsersEpisodes (episodeId, userId) VALUES (@idEpisode, @userId) FETCH NEXT FROM MY_CURSOR INTO @idEpisode 
END 

CLOSE MY_CURSOR 
DEALLOCATE MY_CURSOR
---------------------------------------------------------------------------------------------

GO

/* Insertar nuevos episodios vistos (VARIAS TEMPORADA) */
---------------------------------------------------------------------------------------------
DECLARE @userId INT
SET @userId = 1

DECLARE @idSerie INT
SET @idSerie = 1

DECLARE @minSeason INT
SET @minSeason = 2

DECLARE @maxSeason INT
SET @maxSeason = 4

DECLARE @minEpisode INT
SET @minEpisode = 6

DECLARE @maxEpisode INT
SET @maxEpisode = 1


DECLARE @idEpisode int

DECLARE MY_CURSOR CURSOR LOCAL STATIC READ_ONLY FORWARD_ONLY FOR

-- Consulta
SELECT EPI.id 
FROM NAD_Series AS SER 
INNER JOIN NAD_Seasons AS SEA ON SER.id = SEA.serieId 
INNER JOIN NAD_Episodes AS EPI ON SEA.id = EPI.seasonId 
WHERE SER.id = @idSerie AND ( (SEA.[order] = @minSeason AND EPI.[order] > @minEpisode) OR (SEA.[order] = @maxSeason AND EPI.[order] <= @maxEpisode) OR (SEA.[order] > @minSeason AND SEA.[order] < @maxSeason) )
ORDER BY SEA.[order], EPI.[order]

OPEN MY_CURSOR 
FETCH NEXT FROM MY_CURSOR INTO @idEpisode 

WHILE @@FETCH_STATUS = 0 
BEGIN    
	INSERT INTO NAD_UsersEpisodes (episodeId, userId) VALUES (@idEpisode, @userId) 
	FETCH NEXT FROM MY_CURSOR INTO @idEpisode 
END 

CLOSE MY_CURSOR 
DEALLOCATE MY_CURSOR
---------------------------------------------------------------------------------------------

GO

/* Borrar progreso (DE UNA MISMA TEMPORADA) */
---------------------------------------------------------------------------------------------
DECLARE @userId INT
SET @userId = 2

DECLARE @idSerie INT
SET @idSerie = 1

DECLARE @season INT
SET @season = 1

DECLARE @minEpisode INT
SET @minEpisode = 1

DECLARE @maxEpisode INT
SET @maxEpisode = 2


DECLARE @idEpisode int

DECLARE MY_CURSOR CURSOR LOCAL STATIC READ_ONLY FORWARD_ONLY FOR

-- Consulta
SELECT EPI.id
FROM NAD_Series AS SER 
INNER JOIN NAD_Seasons AS SEA ON SER.id = SEA.serieId 
INNER JOIN NAD_Episodes AS EPI ON SEA.id = EPI.seasonId 
WHERE SER.id = @idSerie AND SEA.[order] = @season AND EPI.[order] BETWEEN @minEpisode+1 AND @maxEpisode
ORDER BY SEA.[order], EPI.[order]

OPEN MY_CURSOR 
FETCH NEXT FROM MY_CURSOR INTO @idEpisode 

WHILE @@FETCH_STATUS = 0 
BEGIN    
	DELETE FROM NAD_UsersEpisodes WHERE episodeId = @idEpisode AND userId = @userId
	FETCH NEXT FROM MY_CURSOR INTO @idEpisode 
END 

CLOSE MY_CURSOR 
DEALLOCATE MY_CURSOR
---------------------------------------------------------------------------------------------

GO

/* Borrar progreso (VARIAS TEMPORADAS) */
---------------------------------------------------------------------------------------------
DECLARE @userId INT
SET @userId = 1

DECLARE @idSerie INT
SET @idSerie = 1

DECLARE @minSeason INT
SET @minSeason = 2

DECLARE @maxSeason INT
SET @maxSeason = 4

DECLARE @minEpisode INT
SET @minEpisode = 6

DECLARE @maxEpisode INT
SET @maxEpisode = 1


DECLARE @idEpisode int

DECLARE MY_CURSOR CURSOR LOCAL STATIC READ_ONLY FORWARD_ONLY FOR

-- Consulta
SELECT EPI.id 
FROM NAD_Series AS SER 
INNER JOIN NAD_Seasons AS SEA ON SER.id = SEA.serieId 
INNER JOIN NAD_Episodes AS EPI ON SEA.id = EPI.seasonId 
WHERE SER.id = @idSerie AND ( (SEA.[order] = @minSeason AND EPI.[order] > @minEpisode) OR (SEA.[order] = @maxSeason AND EPI.[order] <= @maxEpisode) OR (SEA.[order] > @minSeason AND SEA.[order] < @maxSeason) )
ORDER BY SEA.[order], EPI.[order]

OPEN MY_CURSOR 
FETCH NEXT FROM MY_CURSOR INTO @idEpisode 

WHILE @@FETCH_STATUS = 0 
BEGIN    
	DELETE FROM NAD_UsersEpisodes WHERE episodeId = @idEpisode AND userId = @userId
	FETCH NEXT FROM MY_CURSOR INTO @idEpisode 
END 

CLOSE MY_CURSOR 
DEALLOCATE MY_CURSOR
---------------------------------------------------------------------------------------------

/* ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
       AÑADIR DATOS
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// */


/* Crear N episodios de una temporada */
---------------------------------------------------------------------------------------------
DECLARE @maxEpisodes INT
DECLARE @seasonId INT

SET @maxEpisodes = 12
SET @seasonId = 10

DECLARE @count INT
SET @count = 1

WHILE(@count <= @maxEpisodes)
BEGIN
	INSERT INTO NAD_Episodes ([order], [name], seasonId) VALUES (@count, '-', @seasonId)
	SET @count = @count + 1
END
---------------------------------------------------------------------------------------------