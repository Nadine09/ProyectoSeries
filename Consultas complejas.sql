-- Instrucciones de la app

/* Actualizar progreso */
---------------------------------------------------------------------------------------------
DECLARE @idEpisode int

DECLARE MY_CURSOR CURSOR LOCAL STATIC READ_ONLY FORWARD_ONLY FOR
@query

OPEN MY_CURSOR 
FETCH NEXT FROM MY_CURSOR INTO @idEpisode 

WHILE @@FETCH_STATUS = 0 
BEGIN    
	@instruction
	FETCH NEXT FROM MY_CURSOR INTO @idEpisode
END 

CLOSE MY_CURSOR 
DEALLOCATE MY_CURSOR

-------------------------
--> EN UNA LÍNEA
DECLARE @idEpisode int DECLARE MY_CURSOR CURSOR LOCAL STATIC READ_ONLY FORWARD_ONLY FOR @query OPEN MY_CURSOR FETCH NEXT FROM MY_CURSOR INTO @idEpisode WHILE @@FETCH_STATUS = 0 BEGIN @instruction FETCH NEXT FROM MY_CURSOR INTO @idEpisode END CLOSE MY_CURSOR DEALLOCATE MY_CURSOR

----------- @query

---- 1 Temporada
SELECT EPI.id
FROM NAD_Series AS SER 
INNER JOIN NAD_Seasons AS SEA ON SER.id = SEA.serieId 
INNER JOIN NAD_Episodes AS EPI ON SEA.id = EPI.seasonId 
WHERE SER.id = @idSerie AND SEA.[order] = @season AND EPI.[order] BETWEEN @minEpisode+1 AND @maxEpisode
ORDER BY SEA.[order], EPI.[order]

--> EN UNA LÍNEA
SELECT EPI.id FROM NAD_Series AS SER INNER JOIN NAD_Seasons AS SEA ON SER.id = SEA.serieId INNER JOIN NAD_Episodes AS EPI ON SEA.id = EPI.seasonId WHERE SER.id = @idSerie AND SEA.[order] = @season AND EPI.[order] BETWEEN @minEpisode+1 AND @maxEpisode ORDER BY SEA.[order], EPI.[order]

---- Varias temporadas
SELECT EPI.id 
FROM NAD_Series AS SER 
INNER JOIN NAD_Seasons AS SEA ON SER.id = SEA.serieId 
INNER JOIN NAD_Episodes AS EPI ON SEA.id = EPI.seasonId 
WHERE SER.id = @idSerie AND ( (SEA.[order] = @minSeason AND EPI.[order] > @minEpisode) OR (SEA.[order] = @maxSeason AND EPI.[order] <= @maxEpisode) OR (SEA.[order] > @minSeason AND SEA.[order] < @maxSeason) )
ORDER BY SEA.[order], EPI.[order]

--> EN UNA LÍNEA
SELECT EPI.id FROM NAD_Series AS SER INNER JOIN NAD_Seasons AS SEA ON SER.id = SEA.serieId INNER JOIN NAD_Episodes AS EPI ON SEA.id = EPI.seasonId WHERE SER.id = @idSerie AND ( (SEA.[order] = @minSeason AND EPI.[order] > @minEpisode) OR (SEA.[order] = @maxSeason AND EPI.[order] <= @maxEpisode) OR (SEA.[order] > @minSeason AND SEA.[order] < @maxSeason) ) ORDER BY SEA.[order], EPI.[order]


----------- @instruction
-- Insertar
INSERT INTO NAD_UsersEpisodes (episodeId, userId) VALUES (@idEpisode, @userId)

-- Borrar
DELETE FROM NAD_UsersEpisodes WHERE episodeId = @idEpisode AND userId = @userId
---------------------------------------------------------------------------------------------
