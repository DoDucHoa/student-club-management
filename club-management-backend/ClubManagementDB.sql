Create DATABASE ClubManagementDB
GO

USE ClubManagementDB
GO

CREATE TABLE University (
	id VARCHAR(32) PRIMARY KEY,
	name NVARCHAR(256) NOT NULL,
	logo NVARCHAR(256) NOT NULL,
	address NVARCHAR(256)
)
CREATE INDEX i ON dbo.University (id)
GO

CREATE TABLE UserInfo (
	id INT IDENTITY PRIMARY KEY,
	university_id VARCHAR(32) NOT NULL,
	email NVARCHAR(256) NOT NULL,
	password VARCHAR(256) NOT NULL,
	name NVARCHAR(256) NOT NULL,
	phone VARCHAR(32),
	birthday DATE,
	gender TINYINT,
	photo NVARCHAR(256)

    CONSTRAINT FK_UserInfoUniversity FOREIGN KEY (university_id) REFERENCES dbo.University(id)
)
GO

CREATE TABLE Club
(
    id VARCHAR(32) PRIMARY KEY,
	university_id VARCHAR(32) NOT NULL,
	name NVARCHAR(256) NOT NULL,
	balance NUMERIC(19, 5),
	logo NVARCHAR(256) NOT NULL

	CONSTRAINT FK_ClubUniversity FOREIGN KEY (university_id) REFERENCES dbo.University(id)
)
CREATE INDEX i ON dbo.Club (id)
GO

CREATE TABLE Role
(
    id INT PRIMARY KEY,
	name NVARCHAR(256) NOT NULL
)
GO
CREATE INDEX i ON dbo.Role (id)

CREATE TABLE Member
(
	id INT IDENTITY PRIMARY KEY,
    user_id INT NOT NULL,
	club_id VARCHAR(32) NOT NULL,
	role_id INT NOT NULL

	CONSTRAINT FK_MemberUserInfo FOREIGN KEY (user_id) REFERENCES dbo.UserInfo(id),
	CONSTRAINT FK_MemberClub FOREIGN KEY (club_id) REFERENCES dbo.Club(id),
	CONSTRAINT FK_MemberRole FOREIGN KEY (role_id) REFERENCES dbo.Role(id)
)
GO

CREATE TABLE Wallet
(
    id INT IDENTITY PRIMARY KEY,
	member_id INT NOT NULL,
	point NUMERIC(19, 5) DEFAULT 0

	CONSTRAINT FK_WalletUserInfo FOREIGN KEY (member_id) REFERENCES dbo.Member(id)
)
GO

CREATE TABLE TransactionDetail
(
    id INT IDENTITY PRIMARY KEY,
	wallet_id INT NOT NULL,
	trans_point NUMERIC(19, 5) DEFAULT 0,
	content NVARCHAR(256) DEFAULT '',
	create_date DATE DEFAULT GETDATE()

	CONSTRAINT FK_TransactionDetailUserInfo FOREIGN KEY (wallet_id) REFERENCES dbo.Wallet(id)
)
GO

CREATE TABLE TaskType
(
    id VARCHAR(32) PRIMARY KEY NOT NULL,
	name NVARCHAR(256) NOT NULL,
)
CREATE INDEX i ON dbo.TaskType(id)
GO

CREATE TABLE Task
(
    id INT IDENTITY PRIMARY KEY,
	type_id VARCHAR(32) NOT NULL,
	creator_id INT NOT NULL,
	award_point NUMERIC(19, 5),
	pennalty_point NUMERIC(19, 5),
	create_date DATE DEFAULT GETDATE(),
	begin_date DATE NOT NULL,
	due_date DATE NOT NULL,
	title NVARCHAR(256) NOT NULL,
	content NVARCHAR(3000),
	limit_join INT,
	status BIT

	CONSTRAINT FK_TaskTaskType FOREIGN KEY (type_id) REFERENCES dbo.TaskType(id),
	CONSTRAINT FK_TaskUser FOREIGN KEY (creator_id) REFERENCES dbo.Member(id)
)
GO

CREATE TABLE MemberTask
(
	id INT PRIMARY KEY,
    task_id INT NOT NULL,
	member_id INT NOT NULL,
	complete_date DATE,
	award_point NUMERIC(19, 5),
	evidence NVARCHAR(256),
	isFinish BIT

	CONSTRAINT FK_MemberTaskUserInfo FOREIGN KEY (member_id) REFERENCES dbo.Member(id),
	CONSTRAINT FK_MemberTaskIdInfo FOREIGN KEY (task_id) REFERENCES dbo.Task(id)
)
GO

CREATE TABLE TicketType
(
    id VARCHAR(32) PRIMARY KEY,
	name NVARCHAR(256) NOT NULL,
	bonus_point NUMERIC(19, 5) DEFAULT 0,
	price NUMERIC(19, 5) DEFAULT 0
)
CREATE INDEX i ON dbo.TicketType(id)
GO

CREATE TABLE EventInfo
(
    id INT IDENTITY PRIMARY KEY,
	creator_id INT NOT NULL,
	title NVARCHAR(256) NOT NULL,
	content NVARCHAR(3000) NOT NULL,
	create_date DATE DEFAULT GETDATE(),
	regis_date DATE NOT NULL,
	end_regis_date DATE NOT NULL,
	begin_date DATE NOT NULL,
	due_date DATE NOT NULL,
	bonus_point NUMERIC(19, 5),
	limit_join INT,
	image NVARCHAR(256),
	location NVARCHAR(256),
	status BIT

	CONSTRAINT FK_EventUser FOREIGN KEY (creator_id) REFERENCES dbo.Member(id)
)
GO

CREATE TABLE Participant
(
    id INT IDENTITY PRIMARY KEY,
	event_id INT NOT NULL,
	member_id INT NOT NULL,
	regis_date DATE,
	bonus_point NUMERIC(19, 5),
	attendance BIT

	CONSTRAINT FK_ParticipantEvent FOREIGN KEY (event_id) REFERENCES dbo.EventInfo(id),
	CONSTRAINT FK_ParticipantUser FOREIGN KEY (member_id) REFERENCES dbo.Member(id)
)
GO

CREATE TABLE EventTicket
(
    id VARCHAR(32) PRIMARY KEY,
	participant_id INT NOT NULL,
	ticket_type_id VARCHAR(32) NOT NULL

	CONSTRAINT FK_EventTicketEvent FOREIGN KEY (participant_id) REFERENCES dbo.Participant(id),
	CONSTRAINT FK_EventTicketTicketType FOREIGN KEY (ticket_type_id) REFERENCES dbo.TicketType(id)
)
GO