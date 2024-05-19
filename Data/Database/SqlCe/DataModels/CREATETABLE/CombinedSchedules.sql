CREATE TABLE dbo.CombinedSchedules
(
	CombinedSchedulesId INT IDENTITY(1,1) NOT NULL,
	ReportingYear NVARCHAR(150) NULL DEFAULT ('NS'),
	MainAccount NVARCHAR(150) NULL DEFAULT ('NS'),
	LineNumber NVARCHAR(150) NULL DEFAULT ('NS'),
	LineName NVARCHAR(255) NULL DEFAULT ('NS'),
	SplitNumber NVARCHAR(150) NULL DEFAULT ('NS'),
	PriorYear FLOAT NULL DEFAULT(0.0),
	CurrentYear FLOAT NULL DEFAULT(0.0),
	BudgetYear FLOAT NULL DEFAULT(0.0),
	BudgetYear1 FLOAT NULL DEFAULT(0.0),
	BudgetYear2 FLOAT NULL DEFAULT(0.0),
	BudgetYear3 FLOAT NULL DEFAULT(0.0),
	BudgetYear4 FLOAT NULL DEFAULT(0.0),
	BudgetYear5 FLOAT NULL DEFAULT(0.0),
	BudgetYear6 FLOAT NULL DEFAULT(0.0),
	BudgetYear7 FLOAT NULL DEFAULT(0.0),
	BudgetYear8 FLOAT NULL DEFAULT(0.0),
	BudgetYear9 FLOAT NULL DEFAULT(0.0),
	AccountName NVARCHAR(255) NULL DEFAULT ('NS'),
	TreasuryAccount NVARCHAR(255) NULL DEFAULT ('NS'),
	Subfunction NVARCHAR(150) NULL DEFAULT ('NS'),
	Classification NVARCHAR(150) NULL DEFAULT ('NS'),
	BudgetEnforcementCategory NVARCHAR(150) NULL DEFAULT ('NS'),
 	CONSTRAINT CombinedSchedulesPrimaryKey PRIMARY KEY
	(
		CombinedSchedulesId ASC
	)
);

