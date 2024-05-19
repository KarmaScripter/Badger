INSERT INTO Reprogrammings
SELECT ReprogrammingNumber     AS ReprogrammingNumber,
	   ProcessedDate           AS ProcessedDate,
	   RPIO                    AS RPIO,
	   AhCode                  AS AhCode,
	   BFY                     AS BFY,
	   FundCode                AS FundCode,
	   AccountCode             AS AccountCode,
	   OrgCode                 AS OrgCode,
	   BocCode                 AS BocCode,
	   RcCode                  AS RcCode,
	   DivisionName            AS DivisionName,
	   Amount                  AS Amount,
	   FundName                AS FundName,
	   BocName                 AS BocName,
	   SPIO                    AS SPIO,
	   Right( AccountCode, 2 ) AS ProgramProjectCode,
	   ProgramProjectName      AS ProgramProjectName,
	   ProgramAreaCode         AS ProgramAreaCode,
	   ProgramAreaName         AS ProgramAreaName,
	   Purpose                 AS Purpose,
	   ExtendedPurpose         AS ExtendedPurpose,
	   FromTo                  AS FromTo,
	   DocType                 AS DocType,
	   DocPrefix               AS DocPrefix,
	   NpmCode                 AS NpmCode,
	   Line                    AS Line,
	   Subline                 AS Subline
FROM RegionalTransfers;
