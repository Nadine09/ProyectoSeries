-- Script base de datos Leteo
-- Nadine Rufo Riscardo

-- Users
CREATE TABLE NAD_Users(
	id INT IDENTITY(1,1) NOT NULL,
	username NVARCHAR(30) NOT NULL,
	email NVARCHAR(50) NOT NULL,
	[password] NVARCHAR(20)NOT NULL,
	CONSTRAINT PK_Users PRIMARY KEY (id),
	CONSTRAINT UQ_Email_Users UNIQUE (email)	
)

-- Series
CREATE TABLE NAD_Series(
	id INT IDENTITY(1,1) NOT NULL,
	[name] NVARCHAR(300) NOT NULL,
	synopsis NTEXT NULL,
	[state] TINYINT NULL,
	launchDate DATE NULL,
	mra TINYINT NULL,
	valuation DECIMAL(3, 2) NULL,
	imageUrl NVARCHAR(1000) NULL,
	CONSTRAINT PK_Series PRIMARY KEY (id)
)

-- Genres
CREATE TABLE NAD_Genres(
	id INT IDENTITY(1,1) NOT NULL,
	[name] NVARCHAR(300) NOT NULL,
	CONSTRAINT PK_Genres PRIMARY KEY (id)
)

GO

-- Seasons
CREATE TABLE NAD_Seasons(
	id INT IDENTITY(1,1) NOT NULL,
	[order] SMALLINT NULL,
	[name] NVARCHAR(300) NOT NULL,
	synopsis NTEXT NULL,
	[state] TINYINT NULL,
	launchDate DATE NULL,	
	imageUrl NVARCHAR(1000) NULL,
	serieId INT NOT NULL,
	CONSTRAINT PK_Seasons PRIMARY KEY (id),
	CONSTRAINT FK_Seasons_Series FOREIGN KEY (serieId) REFERENCES NAD_Series (id) ON DELETE CASCADE ON UPDATE NO ACTION
)

-- Episodes
CREATE TABLE NAD_Episodes(
	id INT IDENTITY(1,1) NOT NULL,
	[order] SMALLINT NULL,
	[name] NVARCHAR(300) NOT NULL,
	synopsis NTEXT NULL,
	launchDate DATE NULL,	
	imageUrl NVARCHAR(1000) NULL,
	seasonId INT NOT NULL,
	CONSTRAINT PK_Episodes PRIMARY KEY (id),
	CONSTRAINT FK_Episodes_Seasons FOREIGN KEY (seasonId) REFERENCES NAD_Seasons (id) ON DELETE CASCADE ON UPDATE NO ACTION
)

-- SeriesGenres
CREATE TABLE NAD_SeriesGenres(
	serieId INT NOT NULL,
	genreId INT NOT NULL,
	CONSTRAINT PK_SeriesGenres PRIMARY KEY (serieId, genreId),
	CONSTRAINT FK_SeriesGenres_Series FOREIGN KEY (serieId) REFERENCES NAD_Series (id) ON DELETE CASCADE ON UPDATE NO ACTION,
	CONSTRAINT FK_SeriesGenres_Genres FOREIGN KEY (genreId) REFERENCES NAD_Genres (id) ON DELETE CASCADE ON UPDATE NO ACTION
)

-- UsersSeriesValuation
CREATE TABLE NAD_UsersSeriesValuation(
	serieId INT NOT NULL,
	userId INT NOT NULL,
	valuation DECIMAL(3, 2) NOT NULL,
	comment NTEXT NULL,
	CONSTRAINT PK_UsersSeriesValuation PRIMARY KEY (serieId, userId),
	CONSTRAINT FK_UsersSeriesValuation_Series FOREIGN KEY (serieId) REFERENCES NAD_Series (id) ON DELETE CASCADE ON UPDATE NO ACTION,
	CONSTRAINT FK_UsersSeriesValuation_Users FOREIGN KEY (userId) REFERENCES NAD_Users (id) ON DELETE NO ACTION ON UPDATE NO ACTION
)

GO

-- UsersEpisodes
CREATE TABLE NAD_UsersEpisodes(
	episodeId INT NOT NULL,
	userId INT NOT NULL,
	CONSTRAINT PK_UsersEpisodes PRIMARY KEY (episodeId, userId),
	CONSTRAINT FK_UsersEpisodes_Episodes FOREIGN KEY (episodeId) REFERENCES NAD_Episodes (id) ON DELETE CASCADE ON UPDATE NO ACTION,
	CONSTRAINT FK_UsersEpisodes_Users FOREIGN KEY (userId) REFERENCES NAD_Users (id) ON DELETE NO ACTION ON UPDATE NO ACTION
)