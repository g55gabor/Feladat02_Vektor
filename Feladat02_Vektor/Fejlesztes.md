# Pénzfeldobó fejlesztése

- készítünk egy objektumot, amely egy pénzfeldobás esemnyt generál
- a főprogramban készítünk egy logikai tömböt itt fogjuk tárolni a pénzfeldobások eredményét. (feladat 60 esemény tárolása)
- készítünk eljárásokat, amelyek 
  - a.) feltöltenek egy tömböt
  - b.) kiszámítják a hamis események százalékát
  - c.) az igaz események százalékát
  - d.) kiírja a képernyőre az eredményeket.
 

## Érmefeldobó objektum

Az objektum egy érmefeldobást emulál.
felhasználja a Random eljárást a véletlen esemény generálásához.

- létrehozunk egy új **Random** objektumot
- készítünk egy **FeldobasEredmenye** metódust, amely logikai értéket ad vissza.
- A véletlen objektum **Next** metódusát úgy használjuk, hogy [0,2) intervallumban generáljon egész számokat.


## Logikai tömb létrehozása a Main eljárásban

bool[] sorozat = new bool[60];

60 elemű logikai tömböt definiál;
erre a tömbre fogunk cím szerint hivatkozni az eljárásokban.

## függévények készítése

### tömb feltöltése

` 
        public static void sorozatGeneralas(ref bool[] tomb)
        {
            ErmeFeldobo ermeDobas = new ErmeFeldobo();

            for (int i = 0; i < tomb.Length; i++)
            {
                bool dobas = ermeDobas.FeldobasEredmenye();
                tomb[i] = dobas;
            }            
        }
`

A sorozatGeneralas eljárás cím szerint (ref) hivatkozik a Main-ben generált tömbre.
Létrehozunk egy ermeDobas objektumpéldányt felhasználva az ErmeFeldobo objektumot.

A for ciklus a paraméterben átadott tömb hosszának mebfelelő számban fut le, és a dobás értékével tölti fel a tömböt.

### Az írás (hamis tömb elemek) százalékának meghatározása

a hamisakSzazaleka double típusú függvény az összegzés tételét felhasználva számolja az írás dobásának százalékát a dobási sorozatból.

`
        public static double hamisakSzazaleka(ref bool[] tomb)
        {
            int szam = 0;
            double szazalek = 0;
            for (int i = 0; i < tomb.Length; i++)
            {
                if (!tomb[i]) { szam++; }
            }
            szazalek =(double)szam * 100 / tomb.Length;
            return szazalek;
        }
`

mivel a hamis események számát egész (int) szám formátumban tároltuk, ezért a százalék számításánál kénytelenek vagyunk castolni 
double tipussá, ugyanis ha ezt nem tennénk, akkor a százalék értéke is egész lenne. - nem tudnánk 2 tizedes pontossággal megjeleníteni.

### A fej dobások százalékának meghatározása

itt külön függvényt írtunk rá (ezt meg lehetne kerülni hiszen az írás eseméynből is számolhatnánk).
Az igazakSzazaleka függvény az előzőtől csupán az elágazás feltételében különbözik a hamisakSzazaleka függvényben leírtaktól.
if (tomb[i]) ...

### A sorozat és a százalékok képernyőre írása

Végig kell mennünk a tömb összes elemén, és a kiírás során 
- ha az fej (igaz), akkor piros háttéren sárgával,
- ha írás (igaz), akkor  kék háttéren fehérrel írunk a képernyőre.

a tömb eleme kiírása közben egy-egy kötőjelet írunk fekete háttérrel és szürke előtér színnel.



## A főprogram felépítése

- meghívjuk a sorozatGeneralas eljárást,
- kiírjuk a képernyőre a sorozatKiiras eljárással,
- meghatározzuk az írások és a fejek számát, amit formázottan kiírunk a képernyőre.
  - a formázás a string.Format segítségével történik
  - `Console.WriteLine(string.Format("Az írások száma  : {0:F2}%", hamisakSzazaleka(ref sorozat)));`
ahol a F2 jelöli, hogy 2 tizedes pontosságal fogjuk kiírni az eredményt.
