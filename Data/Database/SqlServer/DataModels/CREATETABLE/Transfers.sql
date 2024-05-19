CREATE TABLE Transfers
(
	TransfersId         INT           NOT NULL UNIQUE,
	BudgetLevel         NVARCHAR(150) NULL DEFAULT ('NS'),
	DocPrefix           NVARCHAR(150) NULL DEFAULT ('NS'),
	DocType             NVARCHAR(150) NULL DEFAULT ('NS'),
	BFY                 NVARCHAR(150) NULL DEFAULT ('NS'),
	EFY                 NVARCHAR(150) NULL DEFAULT ('NS'),
	RpioCode            NVARCHAR(150) NULL DEFAULT ('NS'),
	RpioName            NVARCHAR(150) NULL DEFAULT ('NS'),
	FundCode            NVARCHAR(150) NULL DEFAULT ('NS'),
	FundName            NVARCHAR(150) NULL DEFAULT ('NS'),
	ReprogrammingNumber NVARCHAR(150) NULL DEFAULT ('NS'),
	ControlNumber       NVARCHAR(150) NULL DEFAULT ('NS'),
	ProcessedDate       DATETIME      NULL,
	Quarter             NVARCHAR(150) NULL DEFAULT ('NS'),
	Line                NVARCHAR(150) NULL DEFAULT ('NS'),
	Subline             NVARCHAR(150) NULL DEFAULT ('NS'),
	AhCode              NVARCHAR(150) NULL DEFAULT ('NS'),
	AhName              NVARCHAR(150) NULL DEFAULT ('NS'),
	OrgCode             NVARCHAR(150) NULL DEFAULT ('NS'),
	OrgName             NVARCHAR(150) NULL DEFAULT ('NS'),
	RcCode              NVARCHAR(150) NULL DEFAULT ('NS'),
	RcName              NVARCHAR(150) NULL DEFAULT ('NS'),
	AccountCode         NVARCHAR(150) NULL DEFAULT ('NS'),
	ProgramAreaCode     NVARCHAR(150) NULL DEFAULT ('NS'),
	ProgramAreaName     NVARCHAR(150) NULL DEFAULT ('NS'),
	ProgramProjectName  NVARCHAR(150) NULL DEFAULT ('NS'),
	ProgramProjectCode  NVARCHAR(150) NULL DEFAULT ('NS'),
	FromTo              NVARCHAR(150) NULL DEFAULT ('NS'),
	BocCode             NVARCHAR(150) NULL DEFAULT ('NS'),
	BocName             NVARCHAR(150) NULL DEFAULT ('NS'),
	NpmCode             NVARCHAR(150) NULL DEFAULT ('NS'),
	Amount              FLOAT         NULL DEFAULT (0.0),
	Purpose             NVARCHAR(MAX) NULL,
	ResourceType        NVARCHAR(150) NULL DEFAULT ('NS'),
	CONSTRAINT TransfersPrimaryKey PRIMARY KEY
		(
		  TransfersId ASC
			)
);
