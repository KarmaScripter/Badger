PARAMETERS BudgetLevelArgs Text ( 255 ), RpioCodeArgs Text ( 255 ), AhCodeArgs Text ( 255 ), FiscalYearArgs Text ( 255 ), FundCodeArgs Text ( 255 ), OrgCodeArgs Text ( 255 ), AccountCodeArgs Text ( 255 ), BocCodeArgs Text ( 255 ), RcCodeArgs Text ( 255 ), AmountArgs IEEEDouble;
INSERT INTO Allocations (RPIO, BudgetLevel, AhCode, BFY, FundCode, OrgCode, AccountCode,
						 ActivityCode, BocCode, RcCode, Amount, FundName, BocName, Division,
						 NpmCode, ProgramProjectCode, ProgramAreaCode, GoalCode, ObjectiveCode,
						 DivisionName, NpmName, ProgramProjectName, ProgramAreaName, GoalName,
						 ObjectiveName, AllocationRatio, ChangeDate)
SELECT Allocations.RPIO,
	   Allocations.BudgetLevel,
	   Allocations.AhCode,
	   Allocations.BFY,
	   Allocations.FundCode,
	   Allocations.OrgCode,
	   Allocations.AccountCode,
	   Nz( IIf( Len( [AccountCode] ) > 7, Right( [AccountCode], 2 ), "NS" ) ) AS ActivityCode,
	   Allocations.BocCode,
	   Allocations.RcCode,
	   Allocations.Amount,
	   Nz( DLookUp( "FundName", "Funds", "Funds.Code=[FundCodeArgs]" ),
		   "NS" )                                                             AS FundName,
	   Nz( DLookUp( "BocName", "Allocations", "Allocations.BocCode=[BocCodeArgs]" ),
		   "NS" )                                                             AS BocName,
	   Nz( DLookUp( "Division", "Allocations", "Allocations.RcCode=[RcCodeArgs]" ),
		   "NS" )                                                             AS Division,
	   Nz( Mid( [AccountCodeArgs], 4, 1 ), "NS" )                             AS NpmCode,
	   Nz( Mid( [AccountCodeArgs], 5, 2 ), "NS" )                             AS ProgramProjectCode,
	   Nz( DLookUp( "ProgramAreaName", "Allocations",
					"Allocations.ProgramProjectCode=Mid([AccountCodeArgs],5,2)" ),
		   "NS" )                                                             AS ProgramAreaCode,
	   Nz( Left( [AccountCodeArgs], 1 ), "NS" )                               AS GoalCode,
	   Nz( Mid( [AccountCodeArgs], 1, 2 ), "NS" )                             AS ObjectiveCode,
	   Nz( DLookUp( "Name", "Divisions", "Divisions.Code=[RcCodeArgs]" ),
		   "NS" )                                                             AS DivisionName,
	   Nz( DLookUp( "Name", "NationalPrograms",
					"NationalPrograms.Code=Mid([AccountCodeArgs],4,1)" ),
		   "NS" )                                                             AS NpmName,
	   Nz( DLookUp( "Name", "ProgramProjects", "ProgramProjects.Code=Mid([AccountCodeArgs],5,2)" ),
		   "NS" )                                                             AS ProgramProjectName,
	   Nz( DLookUp( "ProgramAreaName", "Allocations",
					"Allocations.ProgramProjectCode=[ProgramProjectCode]" ),
		   "NS" )                                                             AS ProgramAreaName,
	   Nz( DLookUp( "GoalName", "Allocations", "Allocations.GoalCode=[GoalCode]" ),
		   "NS" )                                                             AS GoalName,
	   Nz( DLookUp( "ObjectiveName", "Allocations", "Allocations.ObjectiveCode=[ObjectiveCode]" ),
		   "NS" )                                                             AS ObjectiveName,
	   Nz( Switch( [BudgetLevel] = '7', 1, [BudgetLevel] = '8', 0 ),
		   0 )                                                                AS AllocationRatio,
	   Date( )                                                                AS ChangeDate
FROM Allocations
WHERE (((Allocations.RPIO) = "06") AND ((Allocations.BudgetLevel) = [BudgetLevelArgs]) AND
	   ((Allocations.AhCode) = [AhCodeArgs]) AND ((Allocations.BFY) = [FiscalYearArgs]) AND
	   ((Allocations.FundCode) = [FundCodeArgs]) AND ((Allocations.OrgCode) = [OrgCodeArgs]) AND
	   ((Allocations.AccountCode) = [AccountCodeArgs]) AND
	   ((Allocations.BocCode) = [BocCodeArgs]) AND ((Allocations.RcCode) = [RcCodeArgs]));