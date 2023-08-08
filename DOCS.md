# SeTestsVS

Automatizált Web tesztek Seleniummal (VS)

Verziószám: 1.0.0

***Alapértelmezett*** beállítások ki vannak emelve **félkövéren**, illetve el vannak *döntve*

Az idő mértékenysége: ms (millisecundum) 1s = 1000ms

---

### Alap beállítások/opciók:


### **Log JS**:

A `refresh rate` és a `retry timeout` értéke alapértelmezett esetben 1s / ***1000ms***

(Mértékegység nem kell mögé...)

* Active:
  Logikai érték (***True***/False)
  Aktív-e a valós idejű JavaScript naplózás
* referesh rate:
  milyen gyakran frissíti a log-ot a program
* retry timeout:
  Hiba esetén milyen rendeszereséggel próbálkozzon újra

### Driver beállítások beállítások:

Nem nyulka piszka, mert a kurva anyád

A DefaultOptions() beolvassa ezeket



##### Page load strategy (oldal betöltési mód):

Betöltési módok:

* ***normal* **
* eager

    Nem teljesen betöltött oldalt fogja használni

* none

    Csak a HTML vagy JavaScript kódot használja fel, nem tölt be semmi mást



##### Accept insecure cert:

Logikai érték: 

* ***False***

    nagy- vagy kisbetű nincs befolyással rá

* True

    van hatással rá a nagy-/kisbetű


##### Timeout:

Type(s):

* pageLoad(**alapértelmezet**)

    megvárja, hogy teljesen betöltsön az oldal és utána számol vissza

* impilicit

    az eager-höz hasonló betöltési módhoz hasnónló státusz után kezd el visszaszámolni

* script

    amint lekérte a weboldal kódját, onnantól kezd ek visszaszámolni


Value (Értéke):

    A timeout-ot miliszekundumban megadott értékének letelése feljemében csatlakoztat le



##### Unhandled prompt behavior:

Módjai:

* dismiss
* accept
* dismiss and notify (**alapértelmezet**)
* accept and notify
* ignore



term = gui action (pl breake)



##### Keep the browser open (Böngésző nyitva tartása):

Logikai érték:

* **True**:

Nyitvatartja a böngészőablakot

* False:

Nem tartja nyitva


##### Browser arguments (Böngésző végrehajtandó elemei):

Minden elemét átadja a böngészőnek a böngésző indításakor

A kettő böngésző átadási metódusa különbözik

Az alábbi linkeken le van írva a kommandok listásja:

* [Chrome argumentumok](https://peter.sh/experiments/chromium-command-line-switches/)
* [Firefox argumentumok](https://wiki.mozilla.org/Firefox/CommandLineOptions)

**Alapértelemezett** értéke: [ ] (üres lista)


##### Service:

`log_path` mögötti *út* illetve fájlnév(+fájlfomátum, de ez elég egyértelmű) határozza meg azt, hogy a log-ot hova írja.


Units: 

Units-on (AKA egységeken) belül Unit-okat (egységeket) tudnunk létre hozni.

A Unit-ot bárminek el lehet nevezni (csak tudd meghívni).

Minden unit-ot egy másikhoz tudnunk binding-olni (hozzákötni).

Ezzel el tudjuk érni azt, hogy a követkető/többi Unit-ot ne futtassa
