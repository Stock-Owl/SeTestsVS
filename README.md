# VisionSoft Selenium WebTeszt útmutató (WebSquid)
> **Verzió:** Az útmutató az applikáció **V1.1** verziójához készült.

Ez a *Markdown* a **Vision Software** által fejlesztett félautomatikus web-tesztelő applikációhoz készített használati útmutató, ami bemutatja az applikáció funkcióit, használatát, elemeit és a bele épített időzító rendszer alkalmazását is.


# Elindítás

Az anyakönyvtár tartalmazza a teszteléshez szükséges ***Python*** forrásfájlokat, valamint egy *README* és egy *LICENSE* fájlt és egy pár *előre összeállított példa projektet*.
 - Az anyakönyvtárban található egy ***gui*** nevű mappa, ami tartalmazza a szerkeztő applikáció fájljait.
	 >   A **WebTestGui.exe** applikációval indítható el a program.
- A példa projektek az ***example_projects*** nevű mappában találhatóak, ezek betölthetőek a szerkesztőben, mint elmentett tesztek, de csak *goto* akciókat tartalmaznak néhány breakpointtal.

# Szerkesztői felület

### **A szerkesztői felület *3* nagy panelből áll:**
- **Fő konzol:** [Konzolok](#konzolok)
	 >A futási idő alatt az applikáció ide logol minden információt, ami a futással kapcsolatos, illetve ami azalatt történik ***valós időben***.
	 Teszt végén ide kiitatásra kerül az egyes akciók és unitok futási ideje és sikeressége nyers formában, valamint az összesített **JavaScript** log is.
- **Unit panel:** [Unitok](#unitok)
	> **Ez a panel felelős az egész teszt összeállításáért**.
	> Itt lehet **Unit**okat létrehozni, összekapcsolni, rendezni és elnevezni, valamint az Unitokba a különböző **Akció**kat elhelyezni.
		
- **Mellék panel:**
A mellék panel részen 3 különböző panel jeleníthető meg, a felette található panel fülek segítségével:
	- ***Opció panelrész:*** [Opciók](#opciók)
		> Itt a tesztelés menetével, illetve a testet futtató böngészői beállítások találhatóak. Egyesek a böngésző viselkedését, mások a *Selenium Webdriver*-t határozzák meg.
	
	-	***Unit hierarchia panelrész:***
		> Ez a panelrész összesíti egy helyre az adott ***Teszt*** **Unit**jait az azonosítójukkal, illetve tesztelés után a futási idejüket is meg van jelenítve. Ez a panelrész *nem interaktálható*, csak megjelenít.
	
	-	***JavaScript log panelrész:***
		> Ez a konzol hasonló a **fő konzol** működéséhez, azzal a különbséggel, hogy itt csak a ***JavaScript*** log jelenik meg, viszont teszt futásával **valós időben**.

## Opciók
**Az opciók az *"Opciók"* füllel lehet előrehozni a mellékpanelre.**
- Opció beállításokat el lehet **menteni**, és az elmentett fájlból vissza lehet **tölteni**, ezzel lehetővé téve a gyakran használt beállítások újrahasználatát
	> Az elmentett opció beállításokat az applikáció egy **".vstestoptions"** fájlkiterjesztésű fájlba menti el, a megadott helyre és névvel.

Indítás előtt a ***"Logolási-útvonal"*** nevű opciónak meg kell adni egy létező logolási könyvtárat, ahova a blogolás fog kerülni, minden más opció alapértéke elegendő az alapértelmezett futáshoz.

## Unitok
Egy tesztben az **Akciókat** egy bizonyos **Unit** nevű kollekcióba kell összeállítani. Ezek a **Unitok** tartalmazzák az **Akciókat** megadott sorrendben.
Egy Unit az alábbiakból áll:
- **Unit név** (Szóköz nélküli, speciális azonosító)
- **Akció kollekció** [Akciók](#akciók)
	 > Egy Akció csak egy **Uniton belül lehet**, a szerkezdőben minden Unitnak van egy lenyitható listája, hogy milyen Akciókat lehet bele tenni
- **Azonosító (UID)**
	> Ennek a segítségével lehet a sorrendet változtatni, ez mindig egy szám, ami 0-tól kezdődik, és Unitonként 1-gyel növekszik.
- **Kapcsolt Unit** (Egy a tesztben lévő, másik Unit kiválasztása)
- **Biztonsági Unit** (Egy a tesztben lévő, másik Unit kiválasztása)

**Átláthatóság és egyszerűség érdekében a Unitok ki- és be nyithatóak**, ezáltal a benne tárolt Akciókat a szerkesztő nem jeleníti meg.
- Sok Unit esetén lehetőség van Unitok keresése funkcióra a Unit panel jobb felső sarkában, ahol a kilistázott Unitok közül a **kiválasztottra kattintva a panel ahhoz az Unithoz görgeti a nézetet**.

> **Fontos: (Fejlesztő)** Az applikáció készítése, debuggolása és mérése alatt, az a tendencia figyelhető meg, hogy az applikáció RAM használata, és töltési ideje a Unitok számával sokkal jobban növekszik, mint az Akciók számával.
**Így tanácsos, hogy az Unitok számát a lehető legalacsonyabban tartva készüljön a teszt, míg az Akciók száma szinte alig befolyásolja a RAM használatot és a töltési időt.**

## Akciók
***Az Akciók határozzák meg a Vezérlőnek hogy a böngészőben milyen akciókat hajtson végre.***

Akciókat Unitokhoz lehet hozzáadni a szerkezdőben az **"Akció hozzáadása..."** legördülő menüvel, ami *kilistázza az összes lehetséges Akciót*.
- Tesztelésnél a Vezérlőprogram olyan sorrendben hajtja végre az Akciókat a böngészőn, **amilyen sorrendben következnek az Akciók egymás után az Unitokban**.

- Minden Akció rendelkezik egy **Azonosítóval (ID)**, ami alapján lehet őket sorba rendezni az Uniton belül.
- Minden Akció egy **alapértékkel** rendelkezik amikor hozzáadódik egy Unithoz

Minden Akcióhoz hozzá lehet rendelni egy **Breakpointot**, amit az alapból szürke kör jelez az Akció jobb oldalán. Bekapcsolva **élénk piros** színe van.
[Breakpointok](#breakpointok)


## Konzolok

A szerkesztőben 2 konzol található meg, 2 különböző feladatra, de a kezelésük ugyanaz.
- Lehet tisztítani a konzol tartalmát a konzol panel alatt található körkörös nyilakat jelző gombbal, de ez minden leálláskor, illetve tesztelés elején megtörténik.
- A konzol panel alatt található böngészők gombjaival lehet váltani a Firefox és a Chrome böngésző logjai között.
> **Fontos:** Jelenleg csak a **Chrome** böngészőben futtatott tesztek rendelkeznek *JavaScript* loggal, így a **Firefox** *JavaScript* logja automatikusan a ***Chrome JavaScript*** logját fogja betölteni.

# Tesztek kezelése

**A szerkesztőben lehetőség van több tesztet egyszerre is szerkeszteni, *ha nem folyik éppen egy tesztelés aktívan*.**
A betöltött tesztek mindegyike egy külön fülben látható a szerkesztő felső részén lévő panelen, az adott teszt nevével ellátva.
Az egyes fülek jobb részén a kis **X** jellel látott gombbal lehet bezárni a tesztet (ilyenkor nem történik automatikus mentés).
> **Fontos:** Az applikáció a teszteket egy ***".vsteszt"*** fájlba tudja elmenteni, és azokból betölteni a szerkesztőbe. *Ez a fájl tartalmazza a teszt minden információját, amit a szerkezdőben lehet alakítani.*
- Új, üres tesztet a **Tesztkezelő panel világosabb plusz ikon jelző ikonj**ával lehet létrehozni a *Tesztkezelő panel* bal sarkában.
- Tesztet elmenteni, a **"Teszt mentése"** gombbal lehet, a szerkesztő jobb alsó sarkában.
	- Újjonnan létrehozott, tehát mentett fájllal nem rendelkező teszt első mentése alkalmával meg kell adni az új teszt nevét és helyét a számítógépen.
	- Létező, már egy fájlból betöltött teszt esetén mentéskor automatikusan a betöltött fájlba írja a változásokat.

Az adott szerkezetet teszt fájlútvonala és megadott *Logolási útvonala* látható és megnyitható az **Unit panel** alatti részen.

# Tesztelés
**A tesztelési folyamat akkor indítható el, ha az alábbiak teljesülnek az elindítani szándékozott tesztnél:**
- Legalább *1 Akciót* tartalmaz a teszt.
- Valid és létező a *Gyökér logolási útvonal Opciónál* megadott mappa útvonala.
- A kellő *Python könyvtárak* *****(Python 3.8 vagy újabb, Selenium modul, Selenium-wire modul, Regex modul)*****, és a *böngészők* ***(Chrome, Firefox)*** le vannak installálva a számítógépre

**Ha ezek a feltételek teljesülnek a tesztelés elindulhat.**
A "Tesztelés..." gomb megnyomása után a szerkesztő színsémája átvált futási sémára, valamint blokkolja a tagok közötti navigációt.
- Jelenleg nincs rá mód hogy egyszerre futtassunk több tesztet.

## Tesztelés menete

Futás indítása után rövidesen megjelenik a **Python konzol**, valamint a *Chrome* és a *Firefox* böngésző ablaka, ahol lehet látni az Akciók automatikus végrehajtását a **Selenium vezérlő** alapján.

> Tesztelés alatt egyértelműen meg lehet állapítani, hogy a **Chrome** vezérlője mindig gyorsabban fog betölteni és haladni az Akciókon át, mint a **Firefox** vezérlője.
> Azt is meg lehet állapítani, hogy teszt előrehaladtával az Akciók végrehajtása **lineárisai gyorsul**, mindkét böngésző esetén.
>  *Ezeket érdemes figyelembe venni.*

Ha a teszt tartalmaz **breakpointokat**, akkor azoknál a böngésző vezérlője megállnak, és *automatikusan feldobja a szerkesztő ablakát* a program, jelezve a breakpoint helyét **színnel**, és az **Unit panel odagörgetésével**. [Breakpointok](#breakpointok)
> **Fontos:** A breakpointok kikapcsolhatóak a **"Breakpointok figyelmen kívűl hagyása"** gombbal, ami által a tesztben futás alatt nem lesznek broakpointok. A szerkezdőben ugyanúgy megmaradnak.

A tesztelést futás közben meg lehet **állítani**, ami által a teszt félbeszakad, és a logok csak addig a pontig fogják tartalmazni az információt.

Ha a teszt lefutott a tesztelés befejeződik, és beállítástól függően a Python konzol és a böngészők bezáródnak.
A szerkesztő visszavált szerkesztői színsémára, a teszt-tanok közötti navigáció újra lehetséges, és a **tesztelési információk betöltésre kerülnek**. [Tesztelési információk](#tesztelési-információk)


## Breakpointok

Minden Akció rendelkezik Breakpoint funkcionalitással, amit az Akció paneljének a jobb oldalán lehet ki- és bekapcsolni.
- *Kikapcsolt* állapotban (létrehozáskor alapértelmezetten kikapcsolva van) **világosszürke**, *bekapcsolt* állapotban **élénkpiros** színű a Breakpointot jelző kör.

**Futás alatt egy Breakpoint akkor szakítja meg a futást, ha mindkettő böngésző elérte azt a bizonyos Akciót, amin aktív breakpoint van beállítva.** Mivel a böngészők eltérő sebességben haladnak, így ha az egyik előbb éri el azt adott breakpointot, addig *várakozik*, még a másik böngésző is eléri ugyanazt.
- Amint mindkettő böngésző elérte az adott breakpointot a teszt folyamata **megáll és felugrik a szerkesztő ablaka**.
- Ilyenkor a szerkesztő színsémája átváltozik **élénkpirosra**, és **automatikusan arra az Akcióra görgeti az Unit panelt, amelyik megszakította a tesztet**, és azt is *élénkpirossal* jelöli.
	>Ilyenkor már látható az addig lefutott **Akciók futási ideje** az Akció paneleken, illetve az Unit paneleken is.

A megállított teszt *folytatható* a **"TESZT FOLYTATÁSA"** gomb megnyomásával.
- Ilyenkor mindkét böngésző **folytatja** a tesztet ugyanonnan, és a szerkesztő színsémája visszaáll a *futási színsémába*.

> **Fontos:** Az Unit panel alatt található **"Breakpointok figyelmen kívűl hagyása:"** lehetőséggel ki lehet kapcsolni az összes breakpointot a tesztben. A szerkesztőben bekapcsolva maradnak, de futás alatt a program *figyelmen kívűl hagyja* őket.

## Tesztelési információk

**A lefutott tesztből kinyert információk több helyen és módon jelennek meg a szerkesztő felületén:**
- Tesztelés indításának ideje (Indítás gomb felett található)
- **Futási idők:** (minden futási időnél *2 érték szerepel* **milliszekundumban**, "**/**" jellel elválasztva, az első érték a Chrome-hoz, a második a Firefox-hoz tartozik)
	- A teszt komplett futási ideje, a teszt neve mellett.
	- Minden lefutott **Akció** futási ideje
	- Minden **Unit** futási ideje
		>  A Unitok futási ideje, a benne található Akciók futási idejének az **összege**.
		Ezek az futási idők a **Unit Hierarchián** is megjelennek összesítve.
- A **fő konzolon** a teszt összesített információja plusz a JavaScript konzol logja is megjelenik. [Konzolok](#konzolok)

# Időzítés
**Egy teszt időzítéséhez az alábbiakhoz van szüksége a programnak:**
- Egy valid tesztfájl (*.vsteszt*) útvonala a számítógépen
- Egy gyökér logolási mappa
	> Ebbe a logolási mappába fog kerülni minden információ az időzített teszttel kapcsolatosan. 
- **Opcionális:** Az időzített teszt megvizsgálására szolgált log fájl (*.vslog*) neve. Szóközt és speciális karaktereket nem tartalmazhat.
	> Ha a név üres, vagy nincs megadva akkor a log fájl neve automatikusan a teszt indításának időpontja lesz másodpercre pontosan.

Valamint még a beépített *Windows időzítő* programra vagy esetleg más időzítő applikációra lesz szükség.

**Az időzítést ezzel a parancsol lehet elindítani cmd-ből:**
- "> **{*A WebTestGui.exe elérési útja, vagy neve*} {*A tesztelni kívánt tesztfájl elérési útja*} {*A gyökér logolási mappa elérési útja*}**        +  *(opcionális)***{Az elvégzett teszt logfájljának neve}**
	> **Példa:** (Az opcionális név változó is kap értéket a példában)
	> `WebTestGui.exe C:/User/dev/WebTest/tests/login.vstest C:/User/dev/WebTest/logs LoginTeszt_1`

- Amint ez a parancs meghívásra kerül, akár kézileg, vagy valamilyen időzítő program által, **a szerkesztő teljesen automatikusan elindítja a tesztelést a megadott paraméterek alapján**.
	- Futás alatt a szerkesztő ablaka látható, az *élő konzolok* működnek.
	- *Breakpointokat* megüti a program, de azonnal folytatja utána, így a  tesztelés valójában nem áll meg, de **a breakpointok megütése logolásra kerül.**
	- A tesztelés végeztével a szerkesztő ablaka és vele együtt az applikáció automatikusan bezáródik.
	- Az időzített teszt információi elmentődnek egy ***.vslog*** fájlba, a megadott néven, vagy a teszt indítási idejével.
	[Időzített teszt logok](#időzített-teszt-log)
		> Ez a **.vslog** fájl a megadott gyökér logolási könyvtárba kerül egy **"/scheduled_tests"** mappába.
	- Ha futás alatt az ablakot bezárják, a tesztelés leáll, az addigi logfájlok megmaradnak.

Az **időzített teszt megvizsgálásához** a szerkesztőben jobb alul található gomb megnyomásával kiválasztható a megfelelő *.vslog* fájl, amit egy külön ablakban megnyitott szerkesztőben lehet látni.

## Időzített teszt log

Az időzített tesztelés végén a tesztelés minden információja elmentésre kerül, későbbi megtekintésre és vizsgálatra egy ***.vslog*** fájlba.
- A **.vslog** fájl mindig a megadott gyökér logolási könyvtárba kerül egy **"/scheduled_tests"** mappába.
