# SeTestsVS

Automatizált Web tesztek Seleniummal (VS)

Verziószám: 1.0.0

***Alapértelmezett*** beállítások ki vannak emelve **félkövérrel**, illetve el vannak *döntve*

Az idő mértékenysége: ms (millisecundum) 1s = 1000ms

---

### Alap beállítások/opciók:

---

### **Log JS**:

A `refresh rate` és a `retry timeout` értéke alapértelmezett esetben 1s / ***1000ms***

(Mértékegység nem kell mögé...)

* Active:
  Logikai érték (***True***/False)
  Aktív-e a valós idejű JavaScript naplózás.
* referesh rate:
  Milyen gyakran frissíti a log-ot a program.
* retry timeout:
  Hiba esetén milyen rendeszereséggel próbálkozzon újra.

### Driver beállítások beállítások:

Nem nyulka piszka, mert a kurva anyád!

A `DefaultOptions()` beolvassa ezeket.

##### Page load strategy:

Betöltési módok:

* ***normal***

  Alapvető módon tölti be a weboldalt.
* eager

  Nem teljesen betöltött oldalt fogja használni.
* none

  Csak a weboldal kódját használja fel, nem tölt be semmi mást.

##### Accept insecure cert:

Logikai érték:

* ***False***

  nagy- vagy kisbetű nincs befolyással rá
* True

  van hatással rá a nagy-/kisbetű

##### Timeout:

Type(s):

* ***pageLoad***

  megvárja, hogy teljesen betöltsön az oldal és utána számol vissza.
* impilicit

  az eager-höz hasonló betöltési módhoz hasnónló státusz után kezd el visszaszámolni.
* script

  amint lekérte a weboldal kódját, onnantól kezd ek visszaszámolni.

Value (Értéke):

    A timeout-ot miliszekundumban megadott értékének letelése feljemében csatlakoztat le.

##### Unhandled prompt behavior:

Módjai:

* dismiss
* accept
* ***dismiss and notify***
* accept and notify
* ignore

##### Keep the browser open:

Logikai érték:

* ***True:***

Nyitvatartja a böngészőablakot

* False:

Nem tartja nyitva

##### Browser arguments (Böngésző végrehajtandó elemei):

Minden elemét átadja a böngészőnek a böngésző indításakor.

A kettő böngésző átadási metódusa különbözik.

Az alábbi linkekentalálhatók a kommandok teljes listásja:

* [Chrome argumentumok](https://peter.sh/experiments/chromium-command-line-switches/)
* [Firefox argumentumok](https://wiki.mozilla.org/Firefox/CommandLineOptions)

Alapértelemezett értéke: [ ] (üres lista).

##### Service:

A  `log_path` mögötti *út* illetve fájlnév (+fájlfomátum, de ez elég egyértelmű) határozza meg azt, hogy a log-ot hova írja.

---

### Units & Actions:

`Units`-on (egységeken) belül `Unit`-okat (egységeket) tudnunk létre hozni.

Egy `Unit`-ot bárminek el lehet nevezni (csak tudd meghívni).

Unit-on belül megtudjuk adni, hogy az adott `Unit` mit végezzen el.

Ezeket `action`-nek (műveletnek) hívjuk.

##### Sorrend:

1. `Units` (Csak egy lehet belőle)
2. `Unit` (Több is lehet belőle)
3. `Actions` (Egy lehet belőle `Unit`-onként)
4. `Action` (Több is lehet belőle)

#### Binding & Backup:

Minden `Unit`-ot egy másikhoz tudnunk `binding`-olni (hozzákötni).

Ezzel el tudjuk érni azt, hogy a hibás `Unit` ne futtasa a hozzá `binding`-olt `Unit`-ot, de a többi `Unit` lefuthasson. Ha ez nem lenne, akkor a hibánál leállna a program, nem futtna tovább.

Emellet van a `backup_of` funció, ami egy sikertelen `Unit` lefutása esetén át tud váltani egy másik `Unit`-ra (ha hozzáadtuk), hogy az helyetesítse őt, és a további `Unit`-ok is le tudjanak futni.

Ha nem akarunk egy `Unit`-ot `binding`-olni vagy `backup_of-olni` egy másikhoz, akkor mögé egy `null`-t kell írni.

###### Példa:

```json
"Units":
{
	"Menj_a_Youtube-ra":{
		"bindings": Példa_unit,
        	"backup_of": null,
         	"actions":
		[...]
	     }

	"Példa_unit":{
            "bindings": null,
            "backup_of": null,
            "actions":
            {
                "Példa_action_1":
                {
		    [...]
       		},

		"Példa_action_2":
                {
		    [...]
       		},
            }
            },

	"backup_unit":{
		"bindings": null,
		"backup_of": "Példa_unit",
		"actions":
		{
		    [...]
	    	}
}
```

(Ha a `Menj_a_Youtube-ra` befuccsol, akkor a `Példa_unit` nem fog lefutni. Ha a `Példa_unit` nem tud lefuni, akkor a `backup_unit` veszi át a helyét)

---

#### Műveletek:

##### Goto:

Meghatározza, hogy melyik weboldalra mennyen.

1 paramétere van: `url` (mögé megy a link)

A megadott linknek a teljes linket **kell** tartalmaznia.

###### Példa:

```json
"Példa_action":
{
	"type": "goto",
	"break": false,
	"url": "https://youtube.com"
}
```

Jó `url`:

> "url": "https://youtube.com"

Rossz `url`:

> ~~"url": "youtube.com"~~

---

##### Back:

Visszalép egyet (ha tud hova), mintha az *alt + bal nyíl* gombkombinációt használnál.

Paramétere nincs

```json
[...]
"példa_action":
{
	"type": "back",
	"break": false,
}
```

---

##### Forward:

Előrelép egyet (ha tud hova), mintha az *alt + jobb nyíl* gombkombinációt használnál.

Paramétere nincs

```json
[...]
"példa_action":
{
	"type": "forward",
	"break": false,
}
```

---

##### Refresh:

A `back` és a `forward`-hoz hasónlóan ez is egy böngészőbe beépített funkció.

Újratölti/Frissíti az adott oldalt, mintha *Crtl + R gombkombinációt* használnál.

Paramétere úgyszintén nincs.

```json
[...]
"példa_action":
{
	"type": "refresh",
	"break": false,
}
```

---

##### Wait:

Az oldal betöltési módjától függően vár.

1 paraméterrel rendelkezik: `amount`

Az várakozási `amount`-ot (mennyiséget) milliszekundumban **kell** megadni.

###### Példa:

```json
[...]
"VÁRJÁ'":{
	"type":"wait",
	"break":false,
	"amount": 10000
	}
```

(10 másodpercet fog várni)

---

##### Wait for:

Egy bizonyos állapot betöltésére vár.

Ha a  `frequency`-ből vagy a `timeout`-ból csak az egyik van megadva, a másik alapértéket vesz fel.

4 paraméterje van: `condition` , `timeout` , `frequency` , `element`

###### Condition:

Az állapot, amíg várni kell.

Típusai:

* loaded (element exists)
* alert (alert is present)
* (!) visible (invisible/visible) (element is visible)
* contains (title contains)
* is (title is)
* stale (element staleness)
* readable (visible text)

###### Timeout:

Legfeljebb meddig várjona arra, hogy a `condition` betöltsön/elérhető legyen (milliszekundumban).

###### Frequency:

A frekvencia, hogy milyen gyakorisággal ellenőrize a `condition` elérhetőségét (Milliszekundumban).

###### Element:

Find element funkció. Nem kell csesztetni.

```json
[...]
"példa_action":{
	"type": "wait_for",
	"break": false,
	"condition": "loaded",
	"frequency": 1000,
	"timeout": 10000,
	"single": true,
	"displayed": null,
	"enabled": null,
	"selected": null,
	"element": null,
}
```

---

##### Click:

Rákattint egy adott elemre.

6 paraméterrel relnedlkezik: `single` , `displayed` , `enabled` , `selected` , `locator` , `value`

###### Single:

Logikai érték: True/False

Azt határozza meg, hogy egy elemet, vagy egy elem csoportra kattintson.

###### Displayed:

A kiválsztott elem megjelenésétől függően lesz rákattintva.

###### Enabled:

Megadja a `click` funkciónak, hogy az adott elem/gomb elérhető-e számára.

###### Selected:

Kiválaszt egy adott elemet.

Hasonló ahhoz, mint egy weboldalon való `Tab` többszörös lenyomásakor kiválasztott elemre való rákattintás.

###### Locatorok-ok:

* `CSS selector`
* `Xpath`

###### Value:

`Locator`-tól függően fog rákattintani a kiválaszott elemere.

###### Példa:

```json
[...]
"Példa_action":{
	"type": "click",
	"break": false,
        "single": true,
        "displayed": null,
        "enabled": null,
        "selected": null,
        "locator": "xpath",
        "value": "/html/body/div[13]/div[7]/div[1]/div[1]/div[2]/div[1]/div[1]/div/div/form/div/div[1]/div[3]/div/div/div/div[1]"
},
```

---

##### Send keys:

A `click`-hez hasonló a megadandó értéke

Szöveget ír be a kiválasztott helyre

7 paramétere van: `single` , `displayed` , `enabled` , `selected` , `keys` , `locator` , `value`

###### Single:

Logikai érték: True/False

Azt határozza meg, hogy egy elembe, vagy egy elem csoportba írjon.

###### Displayed:

A kiválsztott elem megjelenésétől függően fog írni.

###### Enabled:

Megadja a `send_keys` funkciónak, hogy az adott elem elérhető-e számára.

###### Selected:

Kiválaszt egy adott elemet.

Hasonló ahhoz, mint egy weboldalon való `Tab` többszörös lenyomása kiválaszt egy elemet.

###### Keys:

Ide kell megadni a kiírandó szöveget.

###### Locatorok-ok:

* `CSS selector`
* `Xpath`

###### Value:

`Locator`-tól függően fog írni kiválaszott elemere.

###### Példa:

```json
[...]
"Példa_action":{
    "type": "send_keys",
    "break": false,
    "single": true,
    "displayed": null,
    "enabled": null,
    "selected": null,
    "keys": "Bojler eladó \n",
    "locator": "xpath",
    "value": "//*[@id=\"index-search\"]"
```

term = gui action (pl breake)
