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

/* ///// Otras ////////////////////////////////////////////////////////////////////////////// */

-- Episodios que ha visto un usuario (id, temporada, episodio)
SELECT E.id, SEA.[order] AS Season, E.[order] AS Episode FROM NAD_UsersEpisodes AS UE
INNER JOIN NAD_Episodes AS E ON UE.episodeId = E.id
INNER JOIN NAD_Seasons AS SEA ON E.seasonId = SEA.id
WHERE userId = 3
ORDER BY SEA.[order], E.[order]
