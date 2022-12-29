# Starbucks API & StarbucksBalance

## Starbucks API (backend)
### Áttekintő
A backend Python nyelven készült, Flask és beautifulsoup4 könyvtárak segítségével. Gyakorlatilag az történik, hogy minden API lekérdezésnél felmegy a Starbucks Rewards kártya oldalára, bejelentkezik és a visszakapott oldalt átfésüli, a pénznemet, egyenleget és csillagok számát kiszedi, majd JSON-ként visszaadja.
### Elindulás
A következő könyvtáraknak kell telepítve lennie: `configparser, requests, bs4, json, flask`

A szkriptet elindítani így tudod Linux alól:
```bash
export FLASK_APP=starbucksapi.py
flask run -p <port> -h 0.0.0.0
```

Indítás előtt ellenőrizd a `settings.ini` fájlt, hogy biztosan jó felhasználónevet és jelszavat adtál meg a `[Credentials]` szekcióban!

Példa a JSON válaszra melyet az API előállít:
```json
{
    "currency": "HUF",
    "currentStars": "25",
    "currentAmount": "1440"
}
```

## StarbucksBalance / Rewards (app)
Az alkalmazást Xamarin Forms-ban írtam, egyelőre csak Android operációs rendszerre szabva.

Az appot megnyitva, a bal alsó sarokban lévő **fogaskerékkel** hívható elő a beállítások oldal, melyen a saját beüzemelt API endpointodat kell megadnod, mellyel tud dolgozni a program. Gyárilag `NA` érték esetén dummy adatokat dob ki a képernyőre, illetve bármikor vissza lehet állítani az appot erre az értékre.

Az alkalmazás gyárilag követi, hogy a telefon sötét vagy világos módot használ-e és annak megfelelően állítja a színeket.

## Utóirat
Ötleteket, hibákat, észrevételeket várom az 'Issues' oldalon! Köszi! Starbucks fejlesztők, légyszi ne haragudjatok rám. :D