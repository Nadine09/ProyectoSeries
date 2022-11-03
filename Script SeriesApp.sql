
-- Users
CREATE TABLE NAD_Users(
	id INT IDENTITY(1,1),
	username NVARCHAR(30),
	email NVARCHAR(50),
	[password] NVARCHAR(20),
	CONSTRAINT PK_Users PRIMARY KEY (id),
	CONSTRAINT UQ_Email_Users UNIQUE (email)	
)