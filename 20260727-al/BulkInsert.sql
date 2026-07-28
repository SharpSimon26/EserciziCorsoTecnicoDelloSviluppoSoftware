BULK INSERT StagingSales 
FROM 'C:\Users\09ts-software\source\repos\SharpSimon26\EserciziCorsoTecnicoDelloSviluppoSoftware\20260727-al\vendite_pulite_20000.csv'
WITH (
	FIRSTROW = 2,
	FIELDTERMINATOR = ';',
	ROWTERMINATOR = '\n',
    CODEPAGE = '65001'
);