-- Nadine Rufo Riscardo

-- CONSULTAS ---------------------------------------------------------------------------------------

/* ///// Básicas ////////////////////////////////////////////////////////////////////////////// */
-- Users
SELECT * FROM NAD_Users

-- Series
SELECT * FROM NAD_Series

-- Season
SELECT * FROM NAD_Seasons

-- UsersEpisodes
SELECT * FROM NAD_UsersEpisodes

-- UsersSeriesAdd
SELECT * FROM NAD_UsersSeriesAdd

/* ///// Otras ////////////////////////////////////////////////////////////////////////////// */

/* Episodios que ha visto un usuario */
---------------------------------------------------------------------------------------------
DECLARE @userId INT
SET @userId = 2

-- Episodios que ha visto un usuario (episodio, temporada, serie, EpisodeId, SeasonId, SeriesId)
SELECT E.[order] AS Episode, SEA.[order] AS Season, SER.name AS Series, E.id AS EpisodeId, SEA.id AS SeasonId, SER.id AS SeriesId 
FROM NAD_UsersEpisodes AS UE
INNER JOIN NAD_Episodes AS E ON UE.episodeId = E.id
INNER JOIN NAD_Seasons AS SEA ON E.seasonId = SEA.id
INNER JOIN NAD_Series AS SER ON SEA.serieId = SER.id
WHERE userId = @userId
ORDER BY SER.id, SEA.[order], E.[order]
---------------------------------------------------------------------------------------------


/* Obtener último episodio visto por un usuario de una serie (Episode, Season) */
---------------------------------------------------------------------------------------------
DECLARE @userId INT
DECLARE @serieId INT

SET @userId = 3
SET @serieId = 1

-- Obtener último episodio visto (Episode, Season)
SELECT MAX(E.[order]) AS Episode, SEA.[order] AS Season FROM NAD_UsersEpisodes AS UE
INNER JOIN NAD_Episodes AS E ON UE.episodeId = E.id
INNER JOIN NAD_Seasons AS SEA ON E.seasonId = SEA.id
WHERE UE.userId = @userId AND SEA.serieId = @serieId AND SEA.[order] = (
	SELECT MAX(SEA.[order]) AS Season FROM NAD_UsersEpisodes AS UE
	INNER JOIN NAD_Episodes AS E ON UE.episodeId = E.id
	INNER JOIN NAD_Seasons AS SEA ON E.seasonId = SEA.id
	WHERE UE.userId = @userId AND SEA.serieId = @serieId
)
GROUP BY SEA.[order]
---------------------------------------------------------------------------------------------

/* Ver los episodios (id, order del episodio, order de la temporada) que ha visto un usuario de una serie  */
---------------------------------------------------------------------------------------------
DECLARE @idSerie INT
SET @idSerie = 1

DECLARE @userId INT
SET @userId = 2

SELECT EPI.id, EPI.[order] AS Episode, SEA.[order] AS Season 
FROM NAD_UsersEpisodes AS UE 
INNER JOIN NAD_Episodes AS EPI ON UE.episodeId = EPI.id
INNER JOIN NAD_Seasons AS SEA ON EPI.seasonId = SEA.id 
WHERE SEA.serieId = @idSerie AND UE.userId = @userId
ORDER BY SEA.[order], EPI.[order]
---------------------------------------------------------------------------------------------

/* Consultar episodios de una serie en un rango de UNA SOLA temporada */
---------------------------------------------------------------------------------------------
DECLARE @idSerie INT
SET @idSerie = 1

DECLARE @season INT
SET @season = 2

DECLARE @minEpisode INT
SET @minEpisode = 3

DECLARE @maxEpisode INT
SET @maxEpisode = 4

SELECT EPI.id, EPI.[order] AS Episode, SEA.[order] AS Season 
FROM NAD_Series AS SER 
INNER JOIN NAD_Seasons AS SEA ON SER.id = SEA.serieId 
INNER JOIN NAD_Episodes AS EPI ON SEA.id = EPI.seasonId 
WHERE SER.id = @idSerie AND SEA.[order] = @season AND EPI.[order] BETWEEN @minEpisode+1 AND @maxEpisode
ORDER BY SEA.[order], EPI.[order]

---------------------------------------------------------------------------------------------

/* Consultar episodios de una serie en un rango de VARIAS temporada */
---------------------------------------------------------------------------------------------
DECLARE @idSerie INT
SET @idSerie = 1

DECLARE @minSeason INT
SET @minSeason = 3

DECLARE @maxSeason INT
SET @maxSeason = 4

DECLARE @minEpisode INT
SET @minEpisode = 8

DECLARE @maxEpisode INT
SET @maxEpisode = 1

SELECT EPI.id, EPI.[order] AS Episode, SEA.[order] AS Season 
FROM NAD_Series AS SER 
INNER JOIN NAD_Seasons AS SEA ON SER.id = SEA.serieId 
INNER JOIN NAD_Episodes AS EPI ON SEA.id = EPI.seasonId 
WHERE SER.id = @idSerie AND ( (SEA.[order] = @minSeason AND EPI.[order] > @minEpisode) OR (SEA.[order] = @maxSeason AND EPI.[order] <= @maxEpisode) OR (SEA.[order] > @minSeason AND SEA.[order] < @maxSeason) )
ORDER BY SEA.[order], EPI.[order]

---------------------------------------------------------------------------------------------