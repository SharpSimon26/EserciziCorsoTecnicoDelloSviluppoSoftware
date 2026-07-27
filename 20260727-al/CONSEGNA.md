# Esercitazione: progettazione di un database relazionale da un CSV denormalizzato

## Scenario
Un'azienda italiana di forniture tecnologiche esporta dal proprio gestionale un file CSV già validato e pulito. Il file contiene 20.000 righe di dettaglio ordine. I dati sono corretti, completi e coerenti, ma fortemente denormalizzati: clienti, venditori, prodotti e magazzini sono ripetuti su molte righe.

L'obiettivo non è fare data cleaning, ma trasformare il file in una buona architettura relazionale su SQL Server.

## Durata prevista
6-8 ore.

## Obiettivi
- analizzare un dataset denormalizzato;
- individuare entità e dipendenze funzionali;
- progettare uno schema in terza forma normale;
- creare tabelle, PK, FK, vincoli e indici;
- importare i dati senza duplicazioni;
- verificare integrità e cardinalità;
- realizzare query di analisi e una vista riepilogativa.

## Fase 1 - Analisi del file (45-60 min)
1. Esaminare le colonne e classificare attributi anagrafici, transazionali e descrittivi.
2. Individuare le entità principali.
3. Identificare le dipendenze funzionali, ad esempio CustomerID -> dati cliente.
4. Proporre un diagramma ER con cardinalità.
5. Motivare perché il CSV non è una buona tabella definitiva.

## Fase 2 - Progettazione logica (60-90 min)
Progettare almeno le seguenti entità, con libertà di migliorarle:
- Customers
- SalesReps
- Products
- Warehouses
- Orders
- OrderLines

Definire:
- chiavi primarie;
- chiavi esterne;
- tipi SQL appropriati;
- nullability;
- vincoli CHECK;
- vincoli UNIQUE;
- strategia per valori monetari e percentuali.

## Fase 3 - Creazione fisica (60 min)
Scrivere uno script idempotente o chiaramente rieseguibile che:
1. crea il database;
2. crea una tabella di staging;
3. crea lo schema normalizzato;
4. aggiunge PK, FK, UNIQUE e CHECK;
5. crea almeno quattro indici motivati.

Vincoli minimi consigliati:
- Quantity > 0;
- UnitPriceEUR >= 0;
- DiscountPct BETWEEN 0 AND 100;
- ShippingCostEUR >= 0;
- DeliveryDate >= OrderDate quando valorizzata;
- email cliente e venditore univoche;
- codici di prodotto, cliente, venditore e magazzino univoci.

## Fase 4 - Importazione e popolamento (90-120 min)
1. Importare il CSV nella staging.
2. Popolare prima le tabelle anagrafiche con SELECT DISTINCT.
3. Popolare Orders evitando una riga per ogni linea.
4. Popolare OrderLines.
5. Gestire l'ordine corretto degli inserimenti rispetto alle FK.
6. Racchiudere il caricamento in transazione.

## Fase 5 - Verifiche (45 min)
Produrre query che dimostrino:
- 20.000 righe in OrderLines;
- nessun OrderLineID duplicato;
- nessun record orfano;
- totale righe per entità;
- uguaglianza tra ricavo importato e ricavo ricalcolato;
- assenza di duplicati nelle anagrafiche;
- corretta relazione tra ordine e righe ordine.

## Fase 6 - Analisi SQL (90 min)
Realizzare almeno queste query:
1. fatturato mensile;
2. fatturato per regione cliente;
3. top 10 prodotti per ricavi;
4. top 10 clienti per ricavi;
5. performance dei venditori;
6. valore medio ordine per canale;
7. tasso di reso e annullamento;
8. tempo medio di consegna per magazzino;
9. categoria più venduta per regione;
10. clienti senza ordini negli ultimi 180 giorni rispetto alla data massima del dataset;
11. confronto tra ricavo lordo, sconti e ricavo netto;
12. ranking mensile dei venditori con una window function.

Creare inoltre una vista `vw_OrderAnalysis` che esponga ordine, cliente, prodotto, venditore, magazzino e misure economiche.

## Consegne
- diagramma ER;
- script DDL;
- script di importazione e popolamento;
- script di verifica;
- script delle analisi;
- breve relazione tecnica di 1-2 pagine.

## Valutazione suggerita
- analisi e modello ER: 15 punti;
- qualità dello schema e normalizzazione: 20 punti;
- DDL, vincoli e tipi: 20 punti;
- caricamento corretto: 20 punti;
- verifiche e integrità: 10 punti;
- analisi SQL: 10 punti;
- documentazione: 5 punti.
