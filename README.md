# SeTestsVS

Automatizált Web tesztek Seleniummal (VS)

### Options

---

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

### Actions

---

**goto**:

1 paraméter: `url`
A megadott URL-re navigál

Az URL-ben benne **KELL** lennie a protokollnak (`https://` stb.)
Például:

    Jó:`"https://google.com"`
    Rossz: `"google.com"`

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
