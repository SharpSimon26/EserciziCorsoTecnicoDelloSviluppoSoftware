select 
imp.codice_impianto, 
imp.nome_impianto,
cli.ragione_sociale,
fat.id_fattura
from impianti imp
left join clienti cli on cli.id_cliente = imp.id_cliente
left join fatture fat on fat.id_cliente = cli.id_cliente
order by ragione_sociale;

SELECT
    f.id_fattura,
    f.tipo,
    f.data_emissione,
    f.importo_totale_eur,
    f.id_cliente       AS id_cliente_fattura,
    cf.ragione_sociale AS cliente_fattura,
    i.id_impianto,
    i.codice_impianto,
    i.id_cliente       AS id_cliente_impianto,
    ci.ragione_sociale AS cliente_impianto
FROM dbo.fatture AS f
LEFT JOIN dbo.contratti AS c
    ON f.id_contratto = c.id_contratto
LEFT JOIN dbo.ticket AS t
    ON f.id_ticket = t.id_ticket
INNER JOIN dbo.impianti AS i
    ON i.id_impianto = COALESCE(c.id_impianto, t.id_impianto)
INNER JOIN dbo.clienti AS cf
    ON f.id_cliente = cf.id_cliente
INNER JOIN dbo.clienti AS ci
    ON i.id_cliente = ci.id_cliente
WHERE f.id_cliente <> i.id_cliente;