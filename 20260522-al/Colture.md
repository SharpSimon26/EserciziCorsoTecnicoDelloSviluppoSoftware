# Problema periodicità asincrone

```code
+----------+  +----------+
| pomodori |  |  verze   |
|  7 mesi  |  |  3 mesi  |
+----------+  +----------+

+----------+  +----------+
| zucchine |  |  patate  |
|  3 mesi  |  |  2 mesi  |
+----------+  +----------+
```

## Ritardo nella prima semina

* Pomodori:  piantati subito
* Verze:     dopo 1 mese
* Zucchine:  dopo 3 mesi
* Patate:    dopo 5 mesi

## Raccolte

|Coltura|Ritardo|Mesi raccolta|
|:---|:---:|:---|
|Pomodori|0 + 7|7, 14, 21, 28, 35, 42, 49, 56, 63, 70|
|Verze|1 + 3|4, 7, 10, 13, 16, 19, 22, 25, 28, 31, 34, 37, 40, 43, 46, 49, 52|
|Zucchine|3 + 3|6, 9, 12, 15, 18, 21, 24, 27, 30, 33, 36, 39, 42, 45, 48, 51, 54|
|Patate|5 + 2|7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31, 33, 35, 37, 39, 41, 43, 45, 47, 49, 51|

## Sequenza

Verze e zucchine non verranno mai raccolte contemporaneamente in quanto vi è sempre un divario fisso tra le raccolte dei due ortaggi

## Caso 1: togliamo le verze

Il primo raccolto contemporaneo di pomodori, zucchine e patate si avrà dopo 21 mesi.

## Caso 2: togliamo le zucchine

Il primo raccolto contemporaneo di pomodori, verze e patate si avrò dopo 49 mesi

## Teorema cinese del resto

[Link Wikipedia](https://it.wikipedia.org/wiki/Teorema_cinese_del_resto)