-- QUITAR
DECLARE @userId INT
DECLARE @serieId INT

SET @userId = 2
SET @serieId = 1
--

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

GO
--
DECLARE @idSerie INT
SET @idSerie = 1

DECLARE @userId INT
SET @userId = 3

DECLARE @minSeason INT
SET @minSeason = 2

DECLARE @maxSeason INT
SET @maxSeason = 2

DECLARE @minEpisode INT
SET @minEpisode = 3

DECLARE @maxEpisode INT
SET @maxEpisode = 7
--

-- Insertar nuevos episodios vistos

DECLARE @idEpisode int
DECLARE MY_CURSOR CURSOR LOCAL STATIC READ_ONLY FORWARD_ONLY FOR 
SELECT EPI.id FROM NAD_Series AS SER INNER JOIN NAD_Seasons AS SEA ON SER.id = SEA.serieId INNER JOIN NAD_Episodes AS EPI ON SEA.id = EPI.seasonId 
WHERE SER.id = @idSerie AND (SEA.[order] = @minSeason AND EPI.[order] >= @minEpisode) OR (SEA.[order] = @maxSeason AND EPI.[order] <= @maxEpisode) OR (SEA.[order] BETWEEN @minSeason+1 AND @maxSeason-1)
ORDER BY SEA.[order], EPI.[order] OPEN MY_CURSOR FETCH NEXT FROM MY_CURSOR INTO @idEpisode WHILE @@FETCH_STATUS = 0 BEGIN    INSERT INTO NAD_UsersEpisodes (episodeId, userId) VALUES (@idEpisode, @userId) FETCH NEXT FROM MY_CURSOR INTO @idEpisode END CLOSE MY_CURSOR DEALLOCATE MY_CURSOR


SELECT EPI.id, EPI.[order] AS Episode, SEA.[order] AS Season FROM NAD_Series AS SER INNER JOIN NAD_Seasons AS SEA ON SER.id = SEA.serieId INNER JOIN NAD_Episodes AS EPI ON SEA.id = EPI.seasonId 
-- WHERE SER.id = @idSerie AND (SEA.[order] < @season) OR ((SEA.[order] = @season) AND (EPI.[order] <= @episode)) 
   WHERE SER.id = @idSerie AND (SEA.[order] = @minSeason AND EPI.[order] >= @minEpisode) OR (SEA.[order] = @maxSeason AND EPI.[order] <= @maxEpisode) OR (SEA.[order] BETWEEN @minSeason+1 AND @maxSeason-1)
ORDER BY SEA.[order], EPI.[order]




