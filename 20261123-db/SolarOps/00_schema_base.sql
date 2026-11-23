-- SolarOps: schema base - Oracle Database 19c+
-- Eseguire in uno schema vuoto con privilegi CREATE TABLE.
-- Le 5 verifiche aggiuntive richieste dalla domanda 1 non sono incluse.

CREATE TABLE clienti (
 id_cliente NUMBER(6) CONSTRAINT pk_clienti PRIMARY KEY,
 ragione_sociale VARCHAR2(100) NOT NULL, settore VARCHAR2(40) NOT NULL,
 regione VARCHAR2(40) NOT NULL, provincia CHAR(2) NOT NULL,
 data_registrazione DATE NOT NULL, stato VARCHAR2(10) NOT NULL
);
CREATE TABLE impianti (
 id_impianto NUMBER(6) CONSTRAINT pk_impianti PRIMARY KEY,
 id_cliente NUMBER(6) NOT NULL, codice_impianto VARCHAR2(16) NOT NULL,
 nome_impianto VARCHAR2(110) NOT NULL, tecnologia VARCHAR2(35) NOT NULL,
 potenza_kwp NUMBER(10,2) NOT NULL, comune VARCHAR2(60) NOT NULL,
 provincia CHAR(2) NOT NULL, data_attivazione DATE NOT NULL,
 stato VARCHAR2(20) NOT NULL,
 CONSTRAINT fk_impianti_clienti FOREIGN KEY (id_cliente) REFERENCES clienti(id_cliente)
);
CREATE TABLE contratti (
 id_contratto NUMBER(6) CONSTRAINT pk_contratti PRIMARY KEY,
 id_impianto NUMBER(6) NOT NULL, piano VARCHAR2(10) NOT NULL,
 data_inizio DATE NOT NULL, data_fine DATE NOT NULL,
 canone_annuo_eur NUMBER(12,2) NOT NULL, sla_ore NUMBER(4) NOT NULL,
 CONSTRAINT fk_contratti_impianti FOREIGN KEY (id_impianto) REFERENCES impianti(id_impianto),
 CONSTRAINT uq_contratto_impianto UNIQUE (id_contratto,id_impianto)
);
CREATE TABLE tecnici (
 id_tecnico NUMBER(6) CONSTRAINT pk_tecnici PRIMARY KEY,
 nome VARCHAR2(50) NOT NULL, cognome VARCHAR2(50) NOT NULL,
 specializzazione VARCHAR2(25) NOT NULL, data_assunzione DATE NOT NULL,
 id_responsabile NUMBER(6), costo_orario_eur NUMBER(9,2) NOT NULL,
 attivo CHAR(1) NOT NULL,
 CONSTRAINT fk_tecnici_responsabile FOREIGN KEY(id_responsabile) REFERENCES tecnici(id_tecnico)
);
CREATE TABLE ticket (
 id_ticket NUMBER(8) CONSTRAINT pk_ticket PRIMARY KEY,
 id_impianto NUMBER(6) NOT NULL, id_contratto NUMBER(6),
 data_apertura DATE NOT NULL, priorita VARCHAR2(10) NOT NULL,
 categoria VARCHAR2(20) NOT NULL, stato VARCHAR2(20) NOT NULL,
 data_chiusura DATE, descrizione VARCHAR2(250) NOT NULL,
 CONSTRAINT fk_ticket_impianto FOREIGN KEY(id_impianto) REFERENCES impianti(id_impianto),
 CONSTRAINT fk_ticket_contratto_impianto FOREIGN KEY(id_contratto,id_impianto)
  REFERENCES contratti(id_contratto,id_impianto)
);
CREATE TABLE interventi (
 id_intervento NUMBER(8) CONSTRAINT pk_interventi PRIMARY KEY,
 id_ticket NUMBER(8) NOT NULL, id_tecnico NUMBER(6) NOT NULL,
 data_intervento DATE NOT NULL, durata_ore NUMBER(6,2) NOT NULL,
 esito VARCHAR2(25) NOT NULL, note VARCHAR2(200),
 CONSTRAINT fk_interventi_ticket FOREIGN KEY (id_ticket) REFERENCES ticket(id_ticket),
 CONSTRAINT fk_interventi_tecnici FOREIGN KEY (id_tecnico) REFERENCES tecnici(id_tecnico)
);
CREATE TABLE ricambi (
 id_ricambio NUMBER(6) CONSTRAINT pk_ricambi PRIMARY KEY,
 codice VARCHAR2(20) NOT NULL, descrizione VARCHAR2(120) NOT NULL,
 categoria VARCHAR2(25) NOT NULL, costo_acquisto_eur NUMBER(12,2) NOT NULL,
 prezzo_listino_eur NUMBER(12,2) NOT NULL, giacenza NUMBER(6) NOT NULL,
 scorta_minima NUMBER(6) NOT NULL
);
CREATE TABLE consumi_ricambi (
 id_consumo NUMBER(8) CONSTRAINT pk_consumi PRIMARY KEY,
 id_intervento NUMBER(8) NOT NULL, id_ricambio NUMBER(6) NOT NULL,
 quantita NUMBER(6) NOT NULL, costo_unitario_eur NUMBER(12,2) NOT NULL,
 prezzo_unitario_eur NUMBER(12,2) NOT NULL,
 CONSTRAINT fk_consumi_interventi FOREIGN KEY(id_intervento) REFERENCES interventi(id_intervento),
 CONSTRAINT fk_consumi_ricambi FOREIGN KEY(id_ricambio) REFERENCES ricambi(id_ricambio),
 CONSTRAINT uq_consumo_intervento_ricambio UNIQUE (id_intervento,id_ricambio)
);
CREATE TABLE fatture (
 id_fattura NUMBER(8) CONSTRAINT pk_fatture PRIMARY KEY,
 id_cliente NUMBER(6) NOT NULL, id_ticket NUMBER(8), id_contratto NUMBER(6),
 tipo VARCHAR2(20) NOT NULL, data_emissione DATE NOT NULL,
 data_scadenza DATE NOT NULL, importo_totale_eur NUMBER(12,2) NOT NULL,
 CONSTRAINT fk_fatture_clienti FOREIGN KEY(id_cliente) REFERENCES clienti(id_cliente),
 CONSTRAINT fk_fatture_ticket FOREIGN KEY(id_ticket) REFERENCES ticket(id_ticket),
 CONSTRAINT fk_fatture_contratti FOREIGN KEY(id_contratto) REFERENCES contratti(id_contratto)
);
CREATE TABLE pagamenti (
 id_pagamento NUMBER(8) CONSTRAINT pk_pagamenti PRIMARY KEY,
 id_fattura NUMBER(8) NOT NULL, data_pagamento DATE NOT NULL,
 importo_eur NUMBER(12,2) NOT NULL, metodo VARCHAR2(20) NOT NULL,
 CONSTRAINT fk_pagamenti_fatture FOREIGN KEY(id_fattura) REFERENCES fatture(id_fattura)
);
