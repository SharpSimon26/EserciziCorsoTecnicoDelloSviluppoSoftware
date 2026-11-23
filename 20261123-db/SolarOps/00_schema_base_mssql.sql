-- SolarOps: schema base - MS SQL Server 2025 (T-SQL)
-- Eseguire in un database vuoto con privilegi CREATE TABLE.

SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

USE SolarOpsDB;
GO

CREATE TABLE dbo.clienti (
    id_cliente         INT          NOT NULL CONSTRAINT pk_clienti PRIMARY KEY,
    ragione_sociale    VARCHAR(100) NOT NULL,
    settore            VARCHAR(40)  NOT NULL,
    regione            VARCHAR(40)  NOT NULL,
    provincia          CHAR(2)      NOT NULL,
    data_registrazione DATE         NOT NULL,
    stato              VARCHAR(10)  NOT NULL
);
GO

CREATE TABLE dbo.impianti (
    id_impianto      INT           NOT NULL CONSTRAINT pk_impianti PRIMARY KEY,
    id_cliente       INT           NOT NULL,
    codice_impianto  VARCHAR(16)   NOT NULL,
    nome_impianto    VARCHAR(110)  NOT NULL,
    tecnologia       VARCHAR(35)   NOT NULL,
    potenza_kwp      DECIMAL(10,2) NOT NULL,
    comune           VARCHAR(60)   NOT NULL,
    provincia        CHAR(2)       NOT NULL,
    data_attivazione DATE          NOT NULL,
    stato            VARCHAR(20)   NOT NULL,
    CONSTRAINT fk_impianti_clienti FOREIGN KEY (id_cliente) REFERENCES dbo.clienti(id_cliente)
);
GO

CREATE TABLE dbo.contratti (
    id_contratto     INT           NOT NULL CONSTRAINT pk_contratti PRIMARY KEY,
    id_impianto      INT           NOT NULL,
    piano            VARCHAR(10)   NOT NULL,
    data_inizio      DATE          NOT NULL,
    data_fine        DATE          NOT NULL,
    canone_annuo_eur DECIMAL(12,2) NOT NULL,
    sla_ore          SMALLINT      NOT NULL,
    CONSTRAINT fk_contratti_impianti FOREIGN KEY (id_impianto) REFERENCES dbo.impianti(id_impianto),
    CONSTRAINT uq_contratto_impianto UNIQUE (id_contratto, id_impianto)
);
GO

CREATE TABLE dbo.tecnici (
    id_tecnico       INT          NOT NULL CONSTRAINT pk_tecnici PRIMARY KEY,
    nome             VARCHAR(50)  NOT NULL,
    cognome          VARCHAR(50)  NOT NULL,
    specializzazione VARCHAR(25)  NOT NULL,
    data_assunzione  DATE         NOT NULL,
    id_responsabile  INT          NULL,
    costo_orario_eur DECIMAL(9,2) NOT NULL,
    attivo           CHAR(1)      NOT NULL,
    CONSTRAINT fk_tecnici_responsabile FOREIGN KEY (id_responsabile) REFERENCES dbo.tecnici(id_tecnico)
);
GO

CREATE TABLE dbo.ticket (
    id_ticket     INT          NOT NULL CONSTRAINT pk_ticket PRIMARY KEY,
    id_impianto   INT          NOT NULL,
    id_contratto  INT          NULL,
    data_apertura DATETIME2(0) NOT NULL,
    priorita      VARCHAR(10)  NOT NULL,
    categoria     VARCHAR(20)  NOT NULL,
    stato         VARCHAR(20)  NOT NULL,
    data_chiusura DATETIME2(0) NULL,
    descrizione   VARCHAR(250) NOT NULL,
    CONSTRAINT fk_ticket_impianto FOREIGN KEY (id_impianto) REFERENCES dbo.impianti(id_impianto),
    CONSTRAINT fk_ticket_contratto_impianto FOREIGN KEY (id_contratto, id_impianto)
        REFERENCES dbo.contratti(id_contratto, id_impianto)
);
GO

CREATE TABLE dbo.interventi (
    id_intervento   INT          NOT NULL CONSTRAINT pk_interventi PRIMARY KEY,
    id_ticket       INT          NOT NULL,
    id_tecnico      INT          NOT NULL,
    data_intervento DATETIME2(0) NOT NULL,
    durata_ore      DECIMAL(6,2) NOT NULL,
    esito           VARCHAR(25)  NOT NULL,
    note            VARCHAR(200) NULL,
    CONSTRAINT fk_interventi_ticket FOREIGN KEY (id_ticket) REFERENCES dbo.ticket(id_ticket),
    CONSTRAINT fk_interventi_tecnici FOREIGN KEY (id_tecnico) REFERENCES dbo.tecnici(id_tecnico)
);
GO

CREATE TABLE dbo.ricambi (
    id_ricambio        INT           NOT NULL CONSTRAINT pk_ricambi PRIMARY KEY,
    codice             VARCHAR(20)   NOT NULL,
    descrizione        VARCHAR(120)  NOT NULL,
    categoria          VARCHAR(25)   NOT NULL,
    costo_acquisto_eur DECIMAL(12,2) NOT NULL,
    prezzo_listino_eur DECIMAL(12,2) NOT NULL,
    giacenza           INT           NOT NULL,
    scorta_minima      INT           NOT NULL
);
GO

CREATE TABLE dbo.consumi_ricambi (
    id_consumo          INT           NOT NULL CONSTRAINT pk_consumi PRIMARY KEY,
    id_intervento       INT           NOT NULL,
    id_ricambio         INT           NOT NULL,
    quantita            INT           NOT NULL,
    costo_unitario_eur  DECIMAL(12,2) NOT NULL,
    prezzo_unitario_eur DECIMAL(12,2) NOT NULL,
    CONSTRAINT fk_consumi_interventi FOREIGN KEY (id_intervento) REFERENCES dbo.interventi(id_intervento),
    CONSTRAINT fk_consumi_ricambi FOREIGN KEY (id_ricambio) REFERENCES dbo.ricambi(id_ricambio),
    CONSTRAINT uq_consumo_intervento_ricambio UNIQUE (id_intervento, id_ricambio)
);
GO

CREATE TABLE dbo.fatture (
    id_fattura         INT           NOT NULL CONSTRAINT pk_fatture PRIMARY KEY,
    id_cliente         INT           NOT NULL,
    id_ticket          INT           NULL,
    id_contratto       INT           NULL,
    tipo               VARCHAR(20)   NOT NULL,
    data_emissione     DATE          NOT NULL,
    data_scadenza      DATE          NOT NULL,
    importo_totale_eur DECIMAL(12,2) NOT NULL,
    CONSTRAINT fk_fatture_clienti FOREIGN KEY (id_cliente) REFERENCES dbo.clienti(id_cliente),
    CONSTRAINT fk_fatture_ticket FOREIGN KEY (id_ticket) REFERENCES dbo.ticket(id_ticket),
    CONSTRAINT fk_fatture_contratti FOREIGN KEY (id_contratto) REFERENCES dbo.contratti(id_contratto)
);
GO

CREATE TABLE dbo.pagamenti (
    id_pagamento   INT           NOT NULL CONSTRAINT pk_pagamenti PRIMARY KEY,
    id_fattura     INT           NOT NULL,
    data_pagamento DATE          NOT NULL,
    importo_eur    DECIMAL(12,2) NOT NULL,
    metodo         VARCHAR(20)   NOT NULL,
    CONSTRAINT fk_pagamenti_fatture FOREIGN KEY (id_fattura) REFERENCES dbo.fatture(id_fattura)
);
GO