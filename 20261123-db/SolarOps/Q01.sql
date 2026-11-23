-- clienti 1 - impianti N
-- colonna primary key id_cliente
-- colonna foreign key id_cliente

-- ticket 1 - interventi N
-- colonna primary key id_ticket
-- colonna foreign key id_ticket

-- interventi 1 - consumi_ricambi N
-- colonna primary key id_intervento
-- colonna foreign key id_intervento

USE SolarOpsDB;
GO

-- a
ALTER TABLE ricambi ADD CONSTRAINT uq_codice UNIQUE (codice);

-- b
ALTER TABLE consumi_ricambi ADD CONSTRAINT ck_quantita CHECK (quantita > 0);

-- c
ALTER TABLE dbo.ticket ADD CONSTRAINT ck_ticket_stato CHECK 
(stato IN ('APERTO', 'IN_LAVORAZIONE', 'RISOLTO', 'ANNULLATO'));

ALTER TABLE dbo.ticket ADD CONSTRAINT ck_ticket_date_coerenza
CHECK (data_chiusura IS NULL OR data_chiusura >= data_apertura);

ALTER TABLE dbo.ticket
ADD CONSTRAINT ck_ticket_chiusura_stato
CHECK (
    (stato IN ('APERTO', 'IN_LAVORAZIONE') AND data_chiusura IS NULL)
    OR
    (stato IN ('RISOLTO', 'ANNULLATO') AND data_chiusura IS NOT NULL)
);

-- d
ALTER TABLE dbo.fatture ADD CONSTRAINT ck_fattura_tipo_intervento_canone
CHECK(
    (tipo IN ('CANONE') AND id_contratto IS NOT NULL AND id_ticket IS NULL)
    OR
    (tipo IN ('INTERVENTO') AND id_ticket IS NOT NULL and id_contratto IS NULL)
);

-- e
ALTER TABLE dbo.fatture ADD CONSTRAINT ck_fattura_importo CHECK(importo_totale_eur > 0);
ALTER TABLE dbo.fatture ADD CONSTRAINT ck_fattura_date CHECK(data_scadenza >= data_emissione);

-- f
ALTER TABLE dbo.pagamenti ADD CONSTRAINT ck_pagamenti_importo CHECK(importo_eur > 0);

/*
La foreign key composta fk_ticket_contratto_impianto garantisce l'integrità referenziale 
incrociata tra ticket, impianti e contratti: impedisce che un ticket aperto su un impianto 
venga associato per errore a un contratto intestato a un altro impianto.
*/
