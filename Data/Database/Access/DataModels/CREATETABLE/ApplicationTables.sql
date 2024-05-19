CREATE TABLE ApplicationTables
(
	ApplicationTablesId AUTOINCREMENT NOT NULL UNIQUE,
	TableName           TEXT( 150 )   NULL DEFAULT NS,
	Model               TEXT( 150 )   NULL DEFAULT NS,
	Title               TEXT( 150 )   NULL DEFAULT NS, CONSTRAINT
(
	ApplicationTablesPrimaryKey
)
	PRIMARY KEY
(
	ApplicationTablesId
)
	);
