CREATE TABLE StateGrantObligations
(
	StateGrantObligationsId AUTOINCREMENT NOT NULL UNIQUE,
	BFY                     TEXT( 150 )   NULL DEFAULT NS,
	EFY                     TEXT( 150 )   NULL DEFAULT NS,
	RpioCode                TEXT( 150 )   NULL DEFAULT NS,
	RpioName                TEXT( 150 )   NULL DEFAULT NS,
	AhCode                  TEXT( 150 )   NULL DEFAULT NS,
	AhName                  TEXT( 150 )   NULL DEFAULT NS,
	FundCode                TEXT( 150 )   NULL DEFAULT NS,
	FundName                TEXT( 150 )   NULL DEFAULT NS,
	Approp                  Code TEXT(150) NULL DEFAULT NS,
	Approp                  Code Short TItle TEXT (150) NULL DEFAULT NS,
	OrgCode                 TEXT( 150 )   NULL DEFAULT NS,
	OrgName                 TEXT( 150 )   NULL DEFAULT NS,
	AccountCode             TEXT( 150 )   NULL DEFAULT NS,
	ProgramProjectCode      TEXT( 150 )   NULL DEFAULT NS,
	ProgramProjectName      TEXT( 150 )   NULL DEFAULT NS,
	BocCode                 TEXT( 150 )   NULL DEFAULT NS,
	BocName                 TEXT( 150 )   NULL DEFAULT NS,
	RcCode                  TEXT( 150 )   NULL DEFAULT NS,
	RcName                  TEXT( 150 )   NULL DEFAULT NS,
	StateCode               TEXT( 150 )   NULL DEFAULT NS,
	StateName               TEXT( 150 )   NULL DEFAULT NS,
	Amount                  DOUBLE        NULL DEFAULT 0.0,
	WholeDollars            DOUBLE        NULL DEFAULT 0.0, CONSTRAINT
(
	StateGrantObligationsPrimaryKey
)
	PRIMARY KEY
(
	StateGrantObligationsId
)
	);
