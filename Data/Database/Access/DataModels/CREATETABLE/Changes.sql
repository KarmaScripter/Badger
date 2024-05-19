CREATE TABLE Changes
(
	ChangesId AUTOINCREMENT NOT NULL UNIQUE,
	TableName TEXT( 150 )   NULL DEFAULT NS,
	FieldName TEXT( 150 )   NULL DEFAULT NS,
	Action    TEXT( 150 )   NULL DEFAULT NS,
	OldValue  TEXT( 150 )   NULL DEFAULT NS,
	NewValue  TEXT( 150 )   NULL DEFAULT NS,
	TimeStamp DATETIME      NULL,
	Message   TEXT( 150 )   NULL DEFAULT NS, CONSTRAINT
(
	ChangesPrimaryKey
)
	PRIMARY KEY
(
	ChangesId
)
	);
