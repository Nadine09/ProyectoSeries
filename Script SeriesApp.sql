
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

-- UsersSeriesAdd
CREATE TABLE NAD_UsersSeriesAdd(
	serieId INT NOT NULL,
	userId INT NOT NULL,
	CONSTRAINT PK_UsersSeriesAdd PRIMARY KEY (serieId, userId),
	CONSTRAINT FK_UsersSeriesAdd_Series FOREIGN KEY (serieId) REFERENCES NAD_Series (id) ON DELETE CASCADE ON UPDATE NO ACTION,
	CONSTRAINT FK_UsersSeriesAdd_Users FOREIGN KEY (userId) REFERENCES NAD_Users (id) ON DELETE NO ACTION ON UPDATE NO ACTION
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

GO

--- DATOS ------------------------------------------------------------------------------------------------------------------------------------------

SET IDENTITY_INSERT [dbo].[NAD_Users] ON 
GO
INSERT [dbo].[NAD_Users] ([id], [username], [email], [password]) VALUES (1, N'admin', N'admin', N'admin')
GO
INSERT [dbo].[NAD_Users] ([id], [username], [email], [password]) VALUES (2, N'Nadine', N'nadine@gmail.com', N'123')
GO
INSERT [dbo].[NAD_Users] ([id], [username], [email], [password]) VALUES (3, N'Alvaro', N'alvaro@gmail.com', N'123')
GO
SET IDENTITY_INSERT [dbo].[NAD_Users] OFF
GO
SET IDENTITY_INSERT [dbo].[NAD_Series] ON 
GO
INSERT [dbo].[NAD_Series] ([id], [name], [synopsis], [state], [launchDate], [mra], [valuation], [imageUrl]) VALUES (1, N'Haikyuu!!', NULL, NULL, NULL, NULL, NULL, N'https://w0.peakpx.com/wallpaper/574/104/HD-wallpaper-haikyuu-anime-all-characters-anime.jpg')
GO
INSERT [dbo].[NAD_Series] ([id], [name], [synopsis], [state], [launchDate], [mra], [valuation], [imageUrl]) VALUES (2, N'Chainsaw Man', NULL, NULL, NULL, NULL, NULL, N'https://www.anmosugoi.com/wp-content/uploads/2022/07/Chainsaw-Man-anime-Crunchyroll.jpg')
GO
INSERT [dbo].[NAD_Series] ([id], [name], [synopsis], [state], [launchDate], [mra], [valuation], [imageUrl]) VALUES (3, N'Kanojo, Okarishimasu', NULL, NULL, NULL, NULL, NULL, N'https://1.bp.blogspot.com/-p2-bPVQWiSg/X0iRqCZLe_I/AAAAAAADYfA/mJkSJmaD_goGPslmQRfiEPX5LcQ-mKkyACLcBGAsYHQ/s1600/mj8.jpg')
GO
INSERT [dbo].[NAD_Series] ([id], [name], [synopsis], [state], [launchDate], [mra], [valuation], [imageUrl]) VALUES (4, N'Boku no Hero Academia', NULL, NULL, NULL, NULL, NULL, N'https://ramenparados.com/wp-content/uploads/2016/03/MHA_key02.jpg')
GO
INSERT [dbo].[NAD_Series] ([id], [name], [synopsis], [state], [launchDate], [mra], [valuation], [imageUrl]) VALUES (5, N'Spy x Family', NULL, NULL, NULL, NULL, NULL, N'https://pbs.twimg.com/media/FP6PHptX0AY3_GA?format=jpg&name=medium')
GO
INSERT [dbo].[NAD_Series] ([id], [name], [synopsis], [state], [launchDate], [mra], [valuation], [imageUrl]) VALUES (6, N'Otra vida', NULL, NULL, NULL, NULL, NULL, N'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQET91Met8mreP-eIorcQpcdx5iQEZJLoK4R7jiffx9CLkvfFAM')
GO
SET IDENTITY_INSERT [dbo].[NAD_Series] OFF
GO
INSERT [dbo].[NAD_UsersSeriesValuation] ([serieId], [userId], [valuation], [comment]) VALUES (3, 2, CAST(4.50 AS Decimal(3, 2)), NULL)
GO
INSERT [dbo].[NAD_UsersSeriesValuation] ([serieId], [userId], [valuation], [comment]) VALUES (4, 2, CAST(4.50 AS Decimal(3, 2)), NULL)
GO
INSERT [dbo].[NAD_UsersSeriesValuation] ([serieId], [userId], [valuation], [comment]) VALUES (4, 3, CAST(4.00 AS Decimal(3, 2)), NULL)
GO
INSERT [dbo].[NAD_UsersSeriesValuation] ([serieId], [userId], [valuation], [comment]) VALUES (6, 2, CAST(5.00 AS Decimal(3, 2)), NULL)
GO
INSERT [dbo].[NAD_UsersSeriesAdd] ([serieId], [userId]) VALUES (1, 2)
GO
INSERT [dbo].[NAD_UsersSeriesAdd] ([serieId], [userId]) VALUES (2, 3)
GO
INSERT [dbo].[NAD_UsersSeriesAdd] ([serieId], [userId]) VALUES (3, 2)
GO
INSERT [dbo].[NAD_UsersSeriesAdd] ([serieId], [userId]) VALUES (4, 2)
GO
INSERT [dbo].[NAD_UsersSeriesAdd] ([serieId], [userId]) VALUES (4, 3)
GO
SET IDENTITY_INSERT [dbo].[NAD_Seasons] ON 
GO
INSERT [dbo].[NAD_Seasons] ([id], [order], [name], [synopsis], [state], [launchDate], [imageUrl], [serieId]) VALUES (3, 1, N'Haikyuu!!', NULL, NULL, NULL, N'https://w0.peakpx.com/wallpaper/574/104/HD-wallpaper-haikyuu-anime-all-characters-anime.jpg', 1)
GO
INSERT [dbo].[NAD_Seasons] ([id], [order], [name], [synopsis], [state], [launchDate], [imageUrl], [serieId]) VALUES (4, 2, N'Haikyuu!! Second Season', NULL, NULL, NULL, N'https://image.tmdb.org/t/p/original/3TUUTiiuvjKg8BcnrGbuuj2Ov5L.jpg', 1)
GO
INSERT [dbo].[NAD_Seasons] ([id], [order], [name], [synopsis], [state], [launchDate], [imageUrl], [serieId]) VALUES (5, 4, N'Haikyuu!!: Riku vs. Kuu', NULL, NULL, NULL, N'https://c4.wallpaperflare.com/wallpaper/689/710/331/character-haikyuu-kenma-kozume-wallpaper-preview.jpg', 1)
GO
INSERT [dbo].[NAD_Seasons] ([id], [order], [name], [synopsis], [state], [launchDate], [imageUrl], [serieId]) VALUES (6, 3, N'Haikyuu!! Third Season', NULL, NULL, NULL, N'https://www.selecta-vision.com/wp-content/uploads/haikyuu-t3.jpg', 1)
GO
INSERT [dbo].[NAD_Seasons] ([id], [order], [name], [synopsis], [state], [launchDate], [imageUrl], [serieId]) VALUES (8, 1, N'Chainsaw Man', NULL, NULL, NULL, N'https://www.anmosugoi.com/wp-content/uploads/2022/07/Chainsaw-Man-anime-Crunchyroll.jpg', 2)
GO
INSERT [dbo].[NAD_Seasons] ([id], [order], [name], [synopsis], [state], [launchDate], [imageUrl], [serieId]) VALUES (9, 1, N'Kanojo, Okarishimasu', NULL, NULL, NULL, N'https://1.bp.blogspot.com/-p2-bPVQWiSg/X0iRqCZLe_I/AAAAAAADYfA/mJkSJmaD_goGPslmQRfiEPX5LcQ-mKkyACLcBGAsYHQ/s1600/mj8.jpg', 3)
GO
INSERT [dbo].[NAD_Seasons] ([id], [order], [name], [synopsis], [state], [launchDate], [imageUrl], [serieId]) VALUES (10, 2, N'Kanojo, Okarishimasu 2nd Season', NULL, NULL, NULL, N'https://img1.ak.crunchyroll.com/i/spire4/a7613be29eb931802a64ca283afba22d1659688713_main.jpg', 3)
GO
INSERT [dbo].[NAD_Seasons] ([id], [order], [name], [synopsis], [state], [launchDate], [imageUrl], [serieId]) VALUES (11, 1, N'Spy x Family', NULL, NULL, NULL, N'https://pbs.twimg.com/media/FP6PHptX0AY3_GA?format=jpg&name=medium', 5)
GO
SET IDENTITY_INSERT [dbo].[NAD_Seasons] OFF
GO
SET IDENTITY_INSERT [dbo].[NAD_Genres] ON 
GO
INSERT [dbo].[NAD_Genres] ([id], [name]) VALUES (1, N'Comedia')
GO
INSERT [dbo].[NAD_Genres] ([id], [name]) VALUES (2, N'Deportes')
GO
INSERT [dbo].[NAD_Genres] ([id], [name]) VALUES (3, N'Drama')
GO
INSERT [dbo].[NAD_Genres] ([id], [name]) VALUES (4, N'Escolares')
GO
INSERT [dbo].[NAD_Genres] ([id], [name]) VALUES (5, N'Shounen')
GO
INSERT [dbo].[NAD_Genres] ([id], [name]) VALUES (6, N'Acción')
GO
INSERT [dbo].[NAD_Genres] ([id], [name]) VALUES (7, N'Superpoderes')
GO
SET IDENTITY_INSERT [dbo].[NAD_Genres] OFF
GO
INSERT [dbo].[NAD_SeriesGenres] ([serieId], [genreId]) VALUES (1, 1)
GO
INSERT [dbo].[NAD_SeriesGenres] ([serieId], [genreId]) VALUES (1, 2)
GO
INSERT [dbo].[NAD_SeriesGenres] ([serieId], [genreId]) VALUES (1, 3)
GO
INSERT [dbo].[NAD_SeriesGenres] ([serieId], [genreId]) VALUES (1, 4)
GO
INSERT [dbo].[NAD_SeriesGenres] ([serieId], [genreId]) VALUES (1, 5)
GO
INSERT [dbo].[NAD_SeriesGenres] ([serieId], [genreId]) VALUES (4, 1)
GO
INSERT [dbo].[NAD_SeriesGenres] ([serieId], [genreId]) VALUES (4, 4)
GO
INSERT [dbo].[NAD_SeriesGenres] ([serieId], [genreId]) VALUES (4, 5)
GO
INSERT [dbo].[NAD_SeriesGenres] ([serieId], [genreId]) VALUES (4, 6)
GO
INSERT [dbo].[NAD_SeriesGenres] ([serieId], [genreId]) VALUES (4, 7)
GO
