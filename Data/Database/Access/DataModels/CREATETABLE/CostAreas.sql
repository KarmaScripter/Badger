CREATE TABLE CostAreas
(
	CostAreasId AUTOINCREMENT NOT NULL UNIQUE,
	Code        TEXT( 150 )   NULL DEFAULT NS,
	Name        TEXT( 150 )   NULL DEFAULT NS, CONSTRAINT
(
	CostAreasPrimaryKey
)
	PRIMARY KEY
(
	CostAreasId
)
	);
