# SeTestsVS

Automatizált Web tesztek Seleniummal (VS)

### Options

---

**Log JS**:

* Active:
  Logikai érték (igaz/hamis)
  Aktív-e a valós idejű JavaScript naplózás
* path:
  belső paraméter, nem átállítható
* referesh rate:
  milyen gyakran frissíti a naplót a program
* retry timeout:
  ha hibába ütközik frissítés közben, milyen gyakran próbálkozzon újra

**Page Load Startegy**:

Alapérték: normal

* normal
* eager
* none

**Accept Insecure Certs**:
Logikai érték  (igaz/hamis)
Nem kapitál-érzékeny
Alapérték: hamis

**Timeouts** (milliszekundumban):

Alapérték: pageLoad

* pageLoad: alap 300,000
* script: alap 30,000
* implicit: alap 0

**Unhandled prompt behavior**:

Alapérték: dismiss and notify

* dismiss
* accept
* dismiss and notify
* accept and notify
* ignore

**Keep browser open**:
Logikai érték  (igaz/hamis)
Alapérték: igaz

A tesztek futása után nyitva tartja a böngészőt, ameddig a driver nem kap `driver.Quit` parancsot

**Browser arguments**:
Szöveg lista
Minden elemét átadja a böngészőnek a böngésző indításakor

[Chrome argumentumok](https://peter.sh/experiments/chromium-command-line-switches/)
[Firefox argumentumok](https://wiki.mozilla.org/Firefox/CommandLineOptions)

**Service log path**:
Útvonal ahol van / létrehozásra kerül a `service.log` fájl.
A driver ide írja az akciók utáni logokat

**Service arguments:**

* [1](https://gist.github.com/ntamvl/4f93bbb7c9b4829c601104a2d2f91fe5)
* [2](https://www.selenium.dev/documentation/webdriver/drivers/service/)
* [3](https://www.selenium.dev/documentation/webdriver/browsers/chrome/#service)

### Actions

---

**goto**:

1 paraméter: `url`
A megadott URL-re navigál

Az URL-ben benne **KELL** lennie a protokollnak (`https://` stb.)
Például:

    Jó:`"https://google.com"`
    Rossz: `"google.com"`

**back**:

nincs paramétere
Visszalép az előző oldalra a böngészőben, ha van

**forward**:

nincs paramétere
Előrelép a következő oldalra a böngészőben, ha van

**refresh**:

nincs paramétere
Újratölti az aktív lapot

**JS execute**:

1 paraméter: `commands`
`commands` egy lista JavaScript utasítás / kód

Sorban lefuttatja a listában szereplő JavaScript kódokat
Miért lista? Hogy pontosabb legyen a hiba-kezelés!

**wait**:

1 paraméter: `amount`
`amount` mennyi ideig várjon (milliszekundumban)

Eseménytől függetlenül vár `amount` milliszekundumot

**waitfor**:

4 paraméter: `condition`, `timeout`, `frequency`, `element` (find element funkció)
`condition`: mire várjon az akció
Elérhető `condition` típusok:

* loaded (element exists)
* alert (alert is present)
* (!) visible (element is visible)
* contains (title contains)
* is (title is)
* stale (element staleness)
* readable (visible text)

A `visible` típust lehet tagadni egy ! jellel
`timeout`: maximum mennyi ideig próbálkozzon milliszekundumban.
`frequency`: mennyit várjon két feltétel ellenőrzés között (pl.: betöltött-e az elem?)  milliszekundumban
`element`: megad egy elemet vagy elemcsoportot

Ha `frequency` és `timeout` nincs megadva, akkor addig várkaozik, ameddig be nem tölt a megadott elem vagy elemcsoport (`element`)
Ha `frequency` és `timeout` meg van adva, akkor `timeout`-ig várakozik, hogy betöltsön az elem.
Ha csak az egyik van megadva, a másik alapértéket vesz fel:

* `frequency`: 1000
* `timeout`: 10000

**click**:

5 paraméter

### Funkciók

---

**find element**:

2 paraméter: `locator`, `value`
`locator` megadja, hogy milyen módszerrel / mi után keressen

A következő lokátorok elérhetőek:

* class_name: osztálynév-attribútum alapján keres elemeket
* css_selector: CSS-selectorok (kiválasztók) alapján keres elemeket
  Például:
  * `#id1` — megtalál minden elemet `id1` id-val
  * `.center` — megtalál minden `center` osztályú elemet
  * `div.menu` — megtall minden `menu` osztályú `div` elemet
  * És így továbbb...
* id: id-attribútum alapján keres elemeket
* name: név-attribútum alapján keres elemeket
* link_text: link-elemeket keres megjelenített szöveg alapján
  Például: `<a href="https://youtube.com">YouTube</a>` — YouTube a megjelenített szöveg
* partial_link_text: link-elemeket keres megjelenített szövegrészlet alapján
  tehát, ha a megadott szöveg részlegesen szerepel a megjelenített szövegben, találatnak számít
  Például: `<a href="https://youtube.com">YouTube hivatalos oldal</a>` — 'hivatalos oldal' kereséssel találat
* tag_name: HTML tag alapján keres elemeket
* xpath: xpath alapján keres elemeket (lásd: [Selenium dokumentáció](https://www.selenium.dev/documentation/webdriver/elements/locators/#xpath))
