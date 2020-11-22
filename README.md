# BokstuGynybaSplitScreen

Šį projektą kūriau vienas. Projektas buvo kuriamas multimedijos sistemų projektavimo modulio metu. Modulio pagrindinis tikslas išmokti apie šablonus ir sistemų diagramas, tačiau projektą galima sugalvoti pačiam. Šio projekto metu buvo kuriamas trečio asmens kovos sistema, kurioje veikėjas ir priešai turi ne tik paprastą atakavimą, bet ir sugebėjimus.

Paleidus žadimą pradžioje bus paleistas 15 pav. pavizduotas ekranas, jame yra du mygtukai:
 Start game – Paleidžia žaidėją į žemėlapį.
 Exit – Išjungia žaidimą.

15 pav. Pagrindinis meniu.
Perėjus iš pagrindinio meniu į žemėlapį bus matyti 16 pav. žaidėjo interfeisas:
 1 – Rodo kiek žaidėjas turi dabar gyvybių;
 2 – Rodo kiek žaidėjas turi dabar mana;
 3 – Rodo kiek žaidėjas turi staminos dar;
 4 – Prie to objekto prijungtas burbuliukas rodo raidę i, tai reiškia, kad paspaudus mygtuką i atidarys duomenų ir įgūdžių langą. Atidarys langą jeigu priešų skaičius (12) bus lygus 0;
 5 – Panašiai kaip 4, tik rodo jei paspausi raide j, tai atidaryts parduotuvę. Atidarys langą jeigu priešų skaičius (12) bus lygus 0;
 6 – Rodo kiek procentų turi patirties iki kito lygio;
 7 – Mažesneme apskritime rodo skaičių 1, tai reiškia, kad 1 panaudoja stiporios atakos įgūdį. Jeigu bus atlikta stipri ataka, turi užsipildyti apskritimas mėlyna spalva. Mėlyna spalva rodo kiek procentaliai dar liko laiko iki bus galima atlikti stiprios atakos judesį.
 8 – Mažesneme apskritime rodo skaičių 2, tai reiškia, kad 2 trenkia masinę ataką. Jeigu bus atlikta „multiple attack“, turi užsipildyti apskritimas mėlyna spalva. Mėlyna spalva rodo kiek procentaliai dar liko laiko iki bus galima atlikti „multiple attack“, judesį.
 9 – Mažesneme apskritime rodo skaičių 3, tai reiškia, kad 3 trenkia su apsvaiginimo ataka. Jeigu bus atlikta apsvaiginimo ataka, turi užsipildyti apskritimas mėlyna spalva. Mėlyna spalva rodo kiek procentaliai dar liko laiko iki bus galima atlikti apsvaiginimo atakos judesį.
 10 – jeigu šitas langas yra aktyvus, reiškia kad nėra daugiau priešų ir reik spausti „Enter“ tam, kad paleisti daugiau priešų;
 11 – rodo kelinta puolimo banga dabar yra, jeigu priešų skaičius nulis, tada rodo koks yra kitas puolimo bangos numeris;
 12 – rodo kiek liko dar priešų.
Orkas laiko didelį plaktuką.
16 pav. HUD
Langas pavaizduotas 17 paveikslėlyje yra iškviečiamas paspaudus „esc“ mygtuką, tuo metu veiksmas žaidime nevyksta. Pauzės lange matyti du mygtukai:
 Resume – pratęsia žadimą toliau;
 Leave to main menu – grįžtama į pradinį langą ( žr. 15 pav.)
17 pav. Pauzė.
Kiekvienas „Upgrade“ mygtukas 18 pav, jeigu gali keičia horzontaliai esančius duomenis iš „current“ į „After upgrade“. „Unused stat points“ rodo, kad galimą atlikti pagerinimą gyvybės, manos arba staminos. „Unused skill points“ yra analogiškas „Unused stat point“ tik tai, kad jis leidžia pagerinti įgūdžius, o ne pvz.: gyvybę.
18 pav. žaidėjo duomenų ir įgūdžių langas
19 pav. pavaizduotame parduotuvės lange esantys „Upgrade“ mygtukai tobulina kalavijo ir šablono duomenis, jeigu turi pakankamai pinigų, tai yra „current money“ yra daugiau arba lygu patobulinimo kainai. Pinigai gaunami užmušant priešus.
19 pav. parduotuvė
Žaidėjo kontrolės:
 Vaikščiojimas – valdomas su mygtukais „w“, „s“, „d“, „a“.
 Bėgimas – reikia laikyti bent vien iš vaikščiojimo mygtukų ir tuo pačiu metu laikyti „Lshift“ mygtuką.
 Paprasta ataka – tai atlieka kairys mygtuko paspaudimas.
 Blokuot – žaidėjas gali blokuoti priešo žalą, išskyrus orko apsvaiginimo ataką. Norint blokuoti reikia turėti pakankamai staminos.
 Išvengimas (angl. „dodge“) – norint atlikti šį veiksmą reikai kartu spausti „space“ mygtuką ir viena iš vaikščiojimo mygtukų. Į kurią puse darys išvenimgą priklasuo nuo vaikščiojimo mygtuko paspaudimo.
 Stipri ataka – tai yra žaidėjo įgūdis, kuris daro daugiau žalos negu paprasta ataka. Norint šį įgūdį aktyvuoti reikia spausti „1“ viršuje klaviatūros. Taip pat reikia turėti pakankamai manos ir tas įgūdis turi atsikrauti.
 Sukimosi ataka – tai yra žaidėjo įgūdis, kuris daro daugiau žalos negu paprasta ataka, tačiau dar daro žalos jeigu yra kas nors pvz. : už nugaros. Norint šį įgūdį aktyvuoti reikia spausti „2“ viršuje klaviatūros. Taip pat reikia turėti pakankamai manos ir tas įgūdis turi atsikrauti.
 Apsvaiginimo ataka - tai yra žaidėjo įgūdis, kuris daro daugiau žalos negu paprasta ataka, tačiau tuo pačius ši ataka dar apsvaigina prieša, tai yra jis negali daryt nieko trumpą laiką. Norint šį įgūdį aktyvuoti reikia spausti „3“ viršuje klaviatūros. Taip pat reikia turėti pakankamai manos ir tas įgūdis turi atsikrauti.
Priešų tipai:
 Skeletas – tai yra silpniausias priešas, jis turi mažiausiai gyvybių ir daro mažiausiai žalos. Šis priešas neturi jokių įgūdžių.
 Vilkas – šis priešas turi įgūdį, kuris kai trenkia primą kartą daro tam tikrą žalą, tada trenkdamas antrą kartą daro daugiau žalos ir kai prieina trečią kartą trenkti jis padaro daugiausiai kiek gali ir restartuoja šią atakų seką.
 Orkas – šis priešas nešiojasi plaktuką su kuriuo gali apsvaiginti trumpam žaidėją. Šį veiksmą gali atlikti jeigu atsikrauna jam šis įgūdis, jeigu neatsikrovęs tada orkas trenkia iš paprastų atakų.
