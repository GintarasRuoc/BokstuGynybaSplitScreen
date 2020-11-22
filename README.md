# BokstuGynybaSplitScreen

Projektas atliktas Multimedijos technologijų projektas moduliui. 

Projektą atliko 3 asmenys: Paulius Jadenkus, Rokas Raulonis, Gintaras Ruočkus(aš).

Paulius Jadenkus - atsakingas už žaidėjo interfeisą
Rokas Raulonis - atsakingas už 3D modelių kūrimą
Gintaras Ruočkus - atsakingas už žaidimo logiką

Projekto bendrą aprašą ir vartotojo vadovą galima matyti Bokstu_gynyba.pdf

Vaikščiojimo logika - 

kadangi žemėlapiai nėra generuojami, tai buvo nuspręsta tiesiog sudėti kiekvienam žemėlapiui vaikščiojimo laukus ir nurodyti juose laukelius, kuriuose negalima dėti boškto. Vaikščiojimui per laukelius reikia nurodyti kiek yra laukelių stupelyje ir eilėje. Programoje saugomas dabartinis laukelis ir ėjimas skaičiuojamas pagal esamą laukelį naudojant žinomą laukelių stulpelių ir eilučių skaičių. (movement.cs)


Vaikščiojančių žmogeliukų logika -

kuriant žemėlapį sudedami taškai (waypoints) pagal kuriuos iš eilės žmogeliukui eina. Pasiekus paskutinį tašką žaidėjui atimama gyvybė (HeyImWalkingHere.cs)


Žmogeliukų atsiradimas -

juos paleidžia automatiškai ir dar gali juos paleisti priešininkas už pinigus. (WaveSpawner.cs)

Bokšto logika -

atsiradęs bokštas visada kviečia funkciją, kuri ieško artimiausio priešo. Jeigu bokštas turi žmogeliuką, kuris yra pakankamai arti šauna į žmogeliuką. (Tower.cs) Jeigu bokštas gali masiškai trenkti priešams, šūviui atsitrenkus į žmogeliuką papildomai iškviečia apskritimą, kuris aptinka esančius šalia žmogeliukus ir padaro dar jiems žalos. (Bullet.cs)

