-- SOLAROPS - SOLUZIONI DOCENTE - SQL Server 2025 (T-SQL)
-- Da eseguire solo dopo 00_schema_base.sql e 01_caricamento_dati.sql.
-- La Q14 termina con ROLLBACK. Q15 contiene DDL e comandi di piano fuori transazione.

-- ======================================================================
-- Q01: Vincoli, integrità e modello logico (70 min; 14 pt)
-- ======================================================================
ALTER TABLE ricambi ADD CONSTRAINT uq_ricambi_codice UNIQUE (codice);

ALTER TABLE consumi_ricambi ADD CONSTRAINT ck_consumo_quantita
  CHECK (quantita > 0);

ALTER TABLE ticket ADD CONSTRAINT ck_ticket_stato_chiusura CHECK (
  (stato IN ('RISOLTO','ANNULLATO')
   AND data_chiusura IS NOT NULL
   AND data_chiusura >= data_apertura)
  OR
  (stato IN ('APERTO','IN_LAVORAZIONE')
   AND data_chiusura IS NULL)
);

ALTER TABLE fatture ADD CONSTRAINT ck_fattura_origine CHECK (
  (tipo = 'CANONE' AND id_contratto IS NOT NULL AND id_ticket IS NULL)
  OR
  (tipo = 'INTERVENTO' AND id_ticket IS NOT NULL AND id_contratto IS NULL)
);

ALTER TABLE fatture ADD CONSTRAINT ck_fattura_importo_scad CHECK (
  importo_totale_eur > 0 AND data_scadenza >= data_emissione
);

ALTER TABLE pagamenti ADD CONSTRAINT ck_pagamento_importo
  CHECK (importo_eur > 0);
GO

-- ======================================================================
-- Q02: Caricamento e controlli di qualità (30 min; 6 pt)
-- ======================================================================
SELECT 'CLIENTI' AS tabella, COUNT(*) AS righe FROM clienti
UNION ALL SELECT 'IMPIANTI', COUNT(*) FROM impianti
UNION ALL SELECT 'CONTRATTI', COUNT(*) FROM contratti
UNION ALL SELECT 'TECNICI', COUNT(*) FROM tecnici
UNION ALL SELECT 'TICKET', COUNT(*) FROM ticket
UNION ALL SELECT 'INTERVENTI', COUNT(*) FROM interventi
UNION ALL SELECT 'RICAMBI', COUNT(*) FROM ricambi
UNION ALL SELECT 'CONSUMI_RICAMBI', COUNT(*) FROM consumi_ricambi
UNION ALL SELECT 'FATTURE', COUNT(*) FROM fatture
UNION ALL SELECT 'PAGAMENTI', COUNT(*) FROM pagamenti;

SELECT stato, COUNT(*) AS numero_ticket
FROM ticket 
GROUP BY stato 
ORDER BY stato;

SELECT f.id_fattura, f.tipo, f.id_cliente AS cliente_fattura,
       CASE WHEN f.tipo = 'INTERVENTO' THEN ip.id_cliente
            ELSE ic.id_cliente END AS cliente_origine
FROM fatture f
LEFT JOIN ticket t ON t.id_ticket = f.id_ticket
LEFT JOIN impianti ip ON ip.id_impianto = t.id_impianto
LEFT JOIN contratti ct ON ct.id_contratto = f.id_contratto
LEFT JOIN impianti ic ON ic.id_impianto = ct.id_impianto
WHERE (f.tipo = 'INTERVENTO'
       AND (ip.id_impianto IS NULL OR f.id_cliente <> ip.id_cliente))
   OR (f.tipo = 'CANONE'
       AND (ic.id_impianto IS NULL OR f.id_cliente <> ic.id_cliente));
GO

-- ======================================================================
-- Q03: Filtri, ordinamento e funzioni built-in (30 min; 6 pt)
-- ======================================================================
SELECT id_ticket, priorita, categoria,
       FORMAT(data_apertura, 'yyyy-MM-dd HH:mm') AS apertura
       -- Alternativa più performante su grandi volumi: CONVERT(varchar(16), data_apertura, 120)
FROM ticket
WHERE data_apertura >= '2026-04-01'
  AND data_apertura < '2026-07-01'
  AND priorita IN ('ALTA','CRITICA')
  AND categoria LIKE 'IN%'
ORDER BY data_apertura, id_ticket;

SELECT id_cliente,
       UPPER(TRIM(ragione_sociale)) AS ragione_sociale_norm,
       SUBSTRING(provincia, 1, 2) AS provincia
FROM clienti
WHERE stato = 'ATTIVO'
  AND LOWER(ragione_sociale) LIKE '%industr%'
ORDER BY id_cliente;
GO

-- ======================================================================
-- Q04: Volumi mensili di ticket (25 min; 6 pt)
-- ======================================================================
SELECT DATETRUNC(month, data_apertura) AS mese,
       categoria, COUNT(*) AS numero_ticket
FROM ticket
WHERE data_apertura >= '2026-01-01'
  AND data_apertura < '2026-10-01'
GROUP BY DATETRUNC(month, data_apertura), categoria
HAVING COUNT(*) >= 3
ORDER BY mese, numero_ticket DESC, categoria;
GO

-- ======================================================================
-- Q05: KPI operativi per cliente senza duplicazioni (40 min; 8 pt)
-- ======================================================================
WITH materiali AS (
  SELECT id_intervento,
         SUM(quantita * prezzo_unitario_eur) AS valore_ricambi
  FROM consumi_ricambi
  GROUP BY id_intervento
), attivita_ticket AS (
  SELECT i.id_ticket, COUNT(*) AS n_interventi,
         SUM(i.durata_ore) AS ore_lavorate,
         SUM(ISNULL(m.valore_ricambi, 0)) AS valore_ricambi
  FROM interventi i
  LEFT JOIN materiali m ON m.id_intervento = i.id_intervento
  GROUP BY i.id_ticket
)
SELECT c.id_cliente, c.ragione_sociale,
       COUNT(*) AS ticket_risolti,
       ISNULL(SUM(a.n_interventi), 0) AS numero_interventi,
       ISNULL(SUM(a.ore_lavorate), 0) AS ore_lavorate,
       ISNULL(SUM(a.valore_ricambi), 0) AS valore_ricambi_eur
FROM ticket t
JOIN impianti p ON p.id_impianto = t.id_impianto
JOIN clienti c ON c.id_cliente = p.id_cliente
LEFT JOIN attivita_ticket a ON a.id_ticket = t.id_ticket
WHERE t.stato = 'RISOLTO'
  AND t.data_chiusura >= '2026-01-01'
  AND t.data_chiusura < '2026-10-01'
GROUP BY c.id_cliente, c.ragione_sociale
ORDER BY ore_lavorate DESC, c.id_cliente;
GO

-- ======================================================================
-- Q06: Misurazione del rispetto SLA (40 min; 9 pt)
-- ======================================================================
WITH misure AS (
  SELECT co.piano, t.id_ticket,
         DATEDIFF(SECOND, t.data_apertura, t.data_chiusura) / 3600.0 AS ore_risoluzione,
         co.sla_ore
  FROM ticket t
  JOIN contratti co ON co.id_contratto = t.id_contratto
  WHERE t.stato = 'RISOLTO'
    AND t.data_chiusura >= '2026-01-01'
    AND t.data_chiusura < '2026-10-01'
)
SELECT piano, COUNT(*) AS n_ticket_risolti,
       SUM(CASE WHEN ore_risoluzione <= sla_ore THEN 1 ELSE 0 END) AS in_sla,
       SUM(CASE WHEN ore_risoluzione > sla_ore THEN 1 ELSE 0 END) AS fuori_sla,
       ROUND(100.0 * SUM(CASE WHEN ore_risoluzione <= sla_ore
                              THEN 1 ELSE 0 END) / COUNT(*), 1)
         AS percentuale_in_sla
FROM misure
GROUP BY piano
ORDER BY piano;
GO

-- ======================================================================
-- Q07: Impianti privi di segnalazioni recenti (25 min; 5 pt)
-- ======================================================================
SELECT p.id_impianto, p.codice_impianto,
       c.ragione_sociale, p.provincia
FROM impianti p
JOIN clienti c ON c.id_cliente = p.id_cliente
WHERE NOT EXISTS (
  SELECT 1 FROM ticket t
  WHERE t.id_impianto = p.id_impianto
    AND t.data_apertura >= '2026-01-01'
    AND t.data_apertura < '2026-10-01'
)
ORDER BY p.id_impianto;

-- Variante equivalente per il solo insieme degli ID (EXCEPT al posto di MINUS):
SELECT id_impianto FROM impianti
EXCEPT
SELECT id_impianto FROM ticket
WHERE data_apertura >= '2026-01-01'
  AND data_apertura < '2026-10-01';
GO

-- ======================================================================
-- Q08: Carichi di lavoro superiori alla media di specializzazione (30 min; 7 pt)
-- ======================================================================
WITH carico AS (
  SELECT tec.id_tecnico, tec.cognome, tec.specializzazione,
         SUM(i.durata_ore) AS ore_lavorate
  FROM tecnici tec
  JOIN interventi i ON i.id_tecnico = tec.id_tecnico
  WHERE tec.attivo = 'S'
    AND i.data_intervento >= '2026-01-01'
    AND i.data_intervento < '2026-10-01'
  GROUP BY tec.id_tecnico, tec.cognome, tec.specializzazione
)
SELECT c.id_tecnico, c.cognome, c.specializzazione, c.ore_lavorate,
       ROUND((SELECT AVG(x.ore_lavorate) FROM carico x
              WHERE x.specializzazione = c.specializzazione), 2)
         AS media_specializzazione
FROM carico c
WHERE c.ore_lavorate > (
  SELECT AVG(x.ore_lavorate) FROM carico x
  WHERE x.specializzazione = c.specializzazione
)
ORDER BY c.specializzazione, c.ore_lavorate DESC, c.id_tecnico;
GO

-- ======================================================================
-- Q09: Crediti commerciali e fatture scadute (40 min; 9 pt)
-- ======================================================================
WITH incassi AS (
  SELECT id_fattura, SUM(importo_eur) AS totale_incassato
  FROM pagamenti
  WHERE data_pagamento < '2026-10-01'
  GROUP BY id_fattura
), dettaglio AS (
  SELECT f.id_fattura, f.id_cliente, f.importo_totale_eur,
         ISNULL(i.totale_incassato, 0) AS incassato,
         GREATEST(f.importo_totale_eur - ISNULL(i.totale_incassato, 0), 0)
           AS saldo,
         CASE WHEN f.data_scadenza < '2026-10-01'
           THEN GREATEST(f.importo_totale_eur - ISNULL(i.totale_incassato, 0), 0)
           ELSE 0 END AS saldo_scaduto
  FROM fatture f
  LEFT JOIN incassi i ON i.id_fattura = f.id_fattura
  WHERE f.data_emissione < '2026-10-01'
), riepilogo AS (
  SELECT c.id_cliente, c.ragione_sociale,
         COUNT(d.id_fattura) AS numero_fatture,
         SUM(d.importo_totale_eur) AS fatturato_eur,
         SUM(d.incassato) AS incassato_eur,
         SUM(d.saldo) AS saldo_aperto_eur,
         SUM(d.saldo_scaduto) AS saldo_scaduto_eur
  FROM clienti c
  JOIN dettaglio d ON d.id_cliente = c.id_cliente
  GROUP BY c.id_cliente, c.ragione_sociale
)
SELECT TOP (10) * 
FROM riepilogo
WHERE saldo_aperto_eur > 0
ORDER BY saldo_scaduto_eur DESC, saldo_aperto_eur DESC, id_cliente;
GO

-- ======================================================================
-- Q10: Classifica dei tecnici per specializzazione (35 min; 8 pt)
-- ======================================================================
WITH prestazioni AS (
  SELECT i.id_tecnico,
         COUNT(DISTINCT i.id_ticket) AS n_ticket_distinti
  FROM interventi i
  JOIN ticket t ON t.id_ticket = i.id_ticket
  WHERE t.stato = 'RISOLTO'
    AND t.data_chiusura >= '2026-01-01'
    AND t.data_chiusura < '2026-10-01'
  GROUP BY i.id_tecnico
), classifica AS (
  SELECT tec.specializzazione, tec.id_tecnico,
         tec.nome, tec.cognome, p.n_ticket_distinti,
         DENSE_RANK() OVER (
           PARTITION BY tec.specializzazione
           ORDER BY p.n_ticket_distinti DESC
         ) AS posizione
  FROM tecnici tec
  JOIN prestazioni p ON p.id_tecnico = tec.id_tecnico
  WHERE tec.attivo = 'S'
)
SELECT specializzazione, posizione, id_tecnico,
       nome, cognome, n_ticket_distinti
FROM classifica
WHERE posizione <= 3
ORDER BY specializzazione, posizione, cognome, nome;
GO

-- ======================================================================
-- Q11: Fatturato mensile e variazioni (25 min; 6 pt)
-- ======================================================================
WITH totali AS (
  SELECT DATETRUNC(month, data_emissione) AS mese,
         SUM(importo_totale_eur) AS fatturato_eur
  FROM fatture
  WHERE data_emissione >= '2026-01-01'
    AND data_emissione < '2026-10-01'
  GROUP BY DATETRUNC(month, data_emissione)
), sequenza AS (
  SELECT mese, fatturato_eur,
         LAG(fatturato_eur) OVER (ORDER BY mese) AS precedente_eur
  FROM totali
)
SELECT FORMAT(mese, 'yyyy-MM') AS mese,
       fatturato_eur, precedente_eur,
       fatturato_eur - precedente_eur AS variazione_eur,
       ROUND(100.0 * (fatturato_eur - precedente_eur)
                     / NULLIF(precedente_eur, 0), 2) AS variazione_pct
FROM sequenza
ORDER BY mese;
GO

-- ======================================================================
-- Q12: Organigramma tecnico (20 min; 4 pt)
-- ======================================================================
WITH organigramma AS (
  -- Anchor member (radici: START WITH t.id_responsabile IS NULL)
  SELECT t.id_tecnico,
         t.cognome,
         1 AS livello,
         t.id_tecnico AS id_responsabile_radice,
         CAST(' / ' + t.cognome + ' ' + t.nome AS VARCHAR(MAX)) AS percorso
  FROM tecnici t
  WHERE t.id_responsabile IS NULL

  UNION ALL

  -- Recursive member (CONNECT BY PRIOR t.id_tecnico = t.id_responsabile)
  SELECT t.id_tecnico,
         t.cognome,
         o.livello + 1,
         o.id_responsabile_radice,
         CAST(o.percorso + ' / ' + t.cognome + ' ' + t.nome AS VARCHAR(MAX))
  FROM tecnici t
  JOIN organigramma o ON t.id_responsabile = o.id_tecnico
  -- Protezione anti-ciclo equivalente a NOCYCLE
  WHERE o.percorso NOT LIKE '% / ' + t.cognome + ' ' + t.nome + '%'
)
SELECT id_tecnico, cognome, livello, id_responsabile_radice, percorso
FROM organigramma
-- Ordinare per 'percorso' emula ORDER SIBLINGS BY t.cognome, t.nome
ORDER BY percorso;
GO

-- ======================================================================
-- Q13: Vista di costo industriale dell’intervento (20 min; 4 pt)
-- ======================================================================
CREATE OR ALTER VIEW vw_costi_interventi AS
WITH costo_ricambi AS (
  SELECT id_intervento,
         SUM(quantita * costo_unitario_eur) AS costo_ricambi_eur
  FROM consumi_ricambi
  GROUP BY id_intervento
)
SELECT i.id_intervento, i.id_ticket, i.id_tecnico,
       i.data_intervento,
       ROUND(i.durata_ore * t.costo_orario_eur, 2)
         AS costo_manodopera_eur,
       ISNULL(cr.costo_ricambi_eur, 0) AS costo_ricambi_eur,
       ROUND(i.durata_ore * t.costo_orario_eur
             + ISNULL(cr.costo_ricambi_eur, 0), 2) AS costo_totale_eur
FROM interventi i
JOIN tecnici t ON t.id_tecnico = i.id_tecnico
LEFT JOIN costo_ricambi cr
  ON cr.id_intervento = i.id_intervento;
GO

SELECT TOP (5) id_intervento, id_ticket, id_tecnico,
       costo_manodopera_eur, costo_ricambi_eur, costo_totale_eur
FROM vw_costi_interventi
ORDER BY costo_totale_eur DESC, id_intervento;
GO

-- ======================================================================
-- Q14: Transazione controllata con SAVEPOINT (30 min; 5 pt)
-- ======================================================================
-- In SQL Server è necessario avviare esplicitamente la transazione
BEGIN TRANSACTION;

UPDATE ticket SET priorita = 'ALTA' WHERE id_ticket = 4001;

INSERT INTO interventi
  (id_intervento, id_ticket, id_tecnico,
   data_intervento, durata_ore, esito, note)
VALUES
  (999001, 4001, 302,
   CAST('2026-09-24T10:00:00' AS DATETIME2),
   2, 'VERIFICA', 'Simulazione esame - da annullare');

SAVE TRANSACTION sp_dopo_intervento;

INSERT INTO consumi_ricambi
  (id_consumo, id_intervento, id_ricambio, quantita,
   costo_unitario_eur, prezzo_unitario_eur)
SELECT 999001, 999001, id_ricambio, 1,
       costo_acquisto_eur, prezzo_listino_eur
FROM ricambi WHERE id_ricambio = 601;

SAVE TRANSACTION sp_dopo_consumo;

DELETE FROM consumi_ricambi WHERE id_consumo = 999001;

SELECT COUNT(*) AS consumi_dopo_delete
FROM consumi_ricambi WHERE id_consumo = 999001;

ROLLBACK TRANSACTION sp_dopo_consumo;

SELECT COUNT(*) AS consumi_ripristinati
FROM consumi_ricambi WHERE id_consumo = 999001;

ROLLBACK TRANSACTION sp_dopo_intervento;

SELECT COUNT(*) AS consumi_annullati
FROM consumi_ricambi WHERE id_consumo = 999001;

SELECT COUNT(*) AS interventi_ancora_presenti
FROM interventi WHERE id_intervento = 999001;

ROLLBACK TRANSACTION;

SELECT priorita FROM ticket WHERE id_ticket = 4001;
SELECT COUNT(*) AS interventi_finali
FROM interventi WHERE id_intervento = 999001;
SELECT COUNT(*) AS consumi_finali
FROM consumi_ricambi WHERE id_consumo = 999001;
GO

-- ======================================================================
-- Q15: Indice, piano di esecuzione e autorizzazioni (20 min; 3 pt)
-- ======================================================================
CREATE INDEX ix_ticket_impianto_data
  ON ticket (id_impianto, data_apertura);
GO

-- Equivalente di EXPLAIN PLAN (mostra il piano stimato senza eseguire la query)
SET SHOWPLAN_TEXT ON;
GO
SELECT id_ticket, data_apertura, stato
FROM ticket
WHERE id_impianto = 1001
  AND data_apertura >= '2026-01-01'
  AND data_apertura < '2026-10-01';
GO
SET SHOWPLAN_TEXT OFF;
GO

-- Esempio DCL: richiede ruolo esistente e privilegi.
-- GRANT SELECT ON vw_costi_interventi TO ruolo_reporting;
-- REVOKE SELECT ON vw_costi_interventi FROM ruolo_reporting;

-- Fine soluzioni.
```[cite: 1]

### Note di verifica per l'ambiente di test:
1. **Tipi di dato nelle tabelle base:** Nella **Q14** ho inserito `CAST('2026-09-24T10:00:00' AS DATETIME2)`; funziona correttamente sia che la colonna `data_intervento` nello schema sia `DATETIME` sia che sia `DATETIME2`.
2. **Concatenazione `NULL` (Q12):** In SQL Server, concatenare una stringa con un valore `NULL` tramite `+` restituisce `NULL`. Se `cognome` o `nome` nella tabella `tecnici` ammettono valori nulli, ti conviene sostituire `t.cognome + ' ' + t.nome` con `CONCAT(t.cognome, ' ', t.nome)`.
