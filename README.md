<h1>Technologie NoSQL</h1>

<p>Informacje o komputerze, na którym były wykonywane obliczenia:</p>

<table>
  <thead>
    <tr>
      <th>Nazwa</th>
      <th>Wartość</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>System operacyjny</td>
      <td>Windows 7 64bit</td>
    </tr>
    <tr>
      <td>Procesor</td>
      <td>Intel(R) Pentium(R) CPU G360</td>
    </tr>
    <tr>
      <td>Pamięć RAM</td>
      <td>4GB</td>
    </tr>
    <tr>
      <td>Baza danych</td>
      <td><a href="http://dash.ipv6.enstb.fr/dataset/live-sessions/"><b>Twitch Dataset</b></a></td>
    </tr>
  </tbody>
</table>






## Przedstawienie danych
Na potrzeby projektu zaimportowałam do PostgreSQL i MongoDB znalezioną w Internecie bazę danych streamerów serwisu Twitch oraz wykonałam na niej szereg zapytań i pomiarów czasu. Dane wymagały obróbki, ponieważ wszystkie pola zawierały cudzysłowy. Należało również każdemu rekordowi przypisać lokalizację, by móc tworzyć do nich zapytania mapkowe. Posłużył mi do tego ![program](https://github.com/pseroka/nosql/blob/master/Program.cs) napisany w języku C#. Wybrałam rekordy z 36 krajów, resztę pominęłam. W obecnym kształcie baza danych posiada 960987 rekordów. Dane o rekordach przechowywane są w 31 kolumnach. Zawierają one m.in. informacje na temat nazwy kanału, ilości widzów oglądających dany stream, lokalizacji streamera, czasu trwania streamu i kategorii.

<h6>Przykładowy rekord</h6>

![alt tag](https://github.com/pseroka/nosql/blob/master/photos/przykladowy.PNG)

## PostgreSQL

<h6>Utworzenie schematu</h6>
<code>CREATE SCHEMA myschema;</code>

<h6>Utworzenie tabeli</h6>
<code>CREATE TABLE myschema.twitch (
	accessed_at_utc DATE, 
	accessed_at_utc_std DATE, 
	session_id BIGINT, 
	channel_id INTEGER,  
	channel_login VARCHAR,  
	viewers INTEGER,  
	geo VARCHAR,  
	category VARCHAR,  
	video_bitrate NUMERIC, 
	uptime VARCHAR, 
	uptime_sec NUMERIC, 
	language_channel VARCHAR,
	language_session VARCHAR,
	video_height INTEGER,
	video_width INTEGER,
	embed_count INTEGER,
	site_count INTEGER,
	timezone VARCHAR,
	session_count INTEGER,
	video_codec VARCHAR,
	channel_view_count INTEGER,
	broadcaster VARCHAR,
	broadcast_part INTEGER,
	featured VARCHAR,
	channel_subscription VARCHAR,
	audio_codec VARCHAR,
	producer VARCHAR,
	mature VARCHAR,
	lon VARCHAR,
	lat VARCHAR
);</code>

<h6>Import danych z pliku CSV</h6>
<code>\copy myschema.twitch FROM 'C:/Users/PC/Desktop/nosql/twitch.csv' DELIMITER ',' CSV HEADER</code>

<h6>Zliczenie ilości zaimportowanych rekordów</h6>
<code>SELECT COUNT(*) FROM myschema.twitch;</code>

<h6>Liczba rekordów</h6>
<code>960987</code>

<h6>Obliczenie czasu importu danych</h6>
<code>\timing \copy myschema.twitch FROM 'C:/Users/PC/Desktop/nosql/twitch.csv' DELIMITER ',' CSV HEADER</code>

<h6>Czas importu danych</h6>
<code>40422,841 ms</code>

<h5>Agregacja 1. Liczba streamerów z każdego kraju</h5>
<code>SELECT geo, COUNT(*) AS ile FROM myschema.twitch GROUP BY geo ORDER BY ile DESC;</code>

<h6>Czas wykonania zapytania</h6>
<code>748,291 ms</code>

<h6>Wynik zapytania</h6>
<br>
<table>
  <thead>
    <tr>
      <th>Kraj</th>
      <th>Liczba streamerów</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>US</td>
      <td>417780</td>
    </tr>
    <tr>
      <td>TW</td>
      <td>57181</td>
    </tr>
    <tr>
      <td>DE</td>
      <td>56129</td>
    </tr>
    <tr>
      <td>GB</td>
      <td>47606</td>
    </tr>
    <tr>
      <td>CA</td>
      <td>43490</td>
    </tr>
    <tr>
      <td>None</td>
      <td>43250</td>
    </tr>
    <tr>
      <td>RU</td>
      <td>38989</td>
    </tr>
    <tr>
      <td>SE</td>
      <td>38623</td>
    </tr>
    <tr>
      <td>FR</td>
      <td>21828</td>
    </tr>
    <tr>
      <td>JP</td>
      <td>16476</td>
    </tr>
    <tr>
      <td>BR</td>
      <td>16369</td>
    </tr>
    <tr>
      <td>PL</td>
      <td>15617</td>
    </tr>
    <tr>
      <td>AU</td>
      <td>13394</td>
    </tr>
    <tr>
      <td>NL</td>
      <td>13215</td>
    </tr>
    <tr>
      <td>AR</td>
      <td>11615</td>
    </tr>    
    <tr>
      <td>ES</td>
      <td>10344</td>
    </tr>
    <tr>
      <td>NO</td>
      <td>9857</td>
    </tr>
    <tr>
      <td>DK</td>
      <td>9856</td>
    </tr>
    <tr>
      <td>FI</td>
      <td>9583</td>
    </tr>
    <tr>
      <td>MX</td>
      <td>8726</td>
    </tr>
    <tr>
      <td>UA</td>
      <td>8534</td>
    </tr>
    <tr>
      <td>KR</td>
      <td>6790</td>
    </tr>
    <tr>
      <td>BE</td>
      <td>5992</td>
    </tr>
    <tr>
      <td>AT</td>
      <td>5402</td>
    </tr>
    <tr>
      <td>IT</td>
      <td>5288</td>
    </tr>
    <tr>
      <td>PT</td>
      <td>5224</td>
    </tr>
    <tr>
      <td>CO</td>
      <td>4830</td>
    </tr>
    <tr>
      <td>CH</td>
      <td>4178</td>
    </tr>
    <tr>
      <td>CN</td>
      <td>2982</td>
    </tr>
    <tr>
      <td>CL</td>
      <td>2844</td>
    </tr>
    <tr>
      <td>NZ</td>
      <td>1921</td>
    </tr>
    <tr>
      <td>VN</td>
      <td>1838</td>
    </tr>
    <tr>
      <td>IE</td>
      <td>1471</td>
    </tr>
    <tr>
      <td>IN</td>
      <td>1181</td>
    </tr>
    <tr>
      <td>PR</td>
      <td>1136</td>
    </tr>
    <tr>
      <td>SA</td>
      <td>996</td>
    </tr>
    <tr>
      <td>PK</td>
      <td>452</td>
    </tr>
  </tbody>
</table>

<h5>Agregacja 2. 7 streamerów z największą liczbą widzów</h5>
<code>SELECT channel_login, MAX(viewers) AS viewers, category FROM myschema.twitch GROUP BY channel_login, category ORDER BY viewers DESC LIMIT 7;</code>

<h6>Czas wykonania zapytania</h6>
<code>15174,471 ms</code>

<h6>Wynik zapytania</h6>
<br>
<table>
  <thead>
    <tr>
      <th>Streamer</th>
      <th>Liczba widzów</th>
      <th>Kategoria</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>speeddemosarchivesda</td>
      <td>77075</td>
      <td>gaming</td>
    </tr>
    <tr>
      <td>phantoml0rd</td>
      <td>52764</td>
      <td>gaming</td>
    </tr>
    <tr>
      <td>nightblue3</td>
      <td>38106</td>
      <td>gaming</td>
    </tr>
    <tr>
      <td>nl_kripp</td>
      <td>29350</td>
      <td>gaming</td>
    </tr>
    <tr>
      <td>rekkles</td>
      <td>27964</td>
      <td>gaming</td>
    </tr>
    <tr>
      <td>beyondthesummit</td>
      <td>22992</td>
      <td>gaming</td>
    </tr>
    <tr>
      <td>bestrivenna</td>
      <td>21373</td>
      <td>gaming</td>
    </tr>
  </tbody>
</table>

## MongoDB

<h6>Utworzenie bazy danych</h6>
<code>use nosql</code>

<h6>Import danych z pliku CSV</h6>
<code>mongoimport -d nosql -c twitch --type csv --file C:\Users\PC\Desktop\nosql\twitch.csv --headerline</code>

<h6>Zliczenie ilości zaimportowanych rekordów</h6>
<code>db.twitch.count()</code>

<h6>Liczba rekordów</h6>
<code>960987</code>

<h6>Obliczenie czasu importu danych</h6>
<code>powershell "Measure-Command{mongoimport -d nosql -c twitch --type csv --file C:\Users\PC\Desktop\nosql\twitch.csv --headerline}"</code>

<h6>Czas importu danych</h6>
<code>88939,597 ms</code>

<h2>Mapy</h2>

Do stworzenia mapy GeoJSON wykorzystałam narzędzie, które znajduje się pod adresem: http://geojson.io. Na potrzeby zadania za pomocą ![skryptu](https://github.com/pseroka/nosql/blob/master/geojson.js) napisanego w JavaScript wyznaczyłam 36 unikalnych rekordów ze streamerami z różnych krajów i zaznaczyłam je na mapie odmiennymi kolorami według schematu: kolor niebieski - Ameryka Północna, kolor zielony - Ameryka Południowa, kolor czerwony - Europa, kolor żółty - Azja, kolor różowy - Australia i Oceania.

![Zobacz mapę](https://github.com/pseroka/nosql/blob/master/streamers.geojson)

![alt tag](https://github.com/pseroka/nosql/blob/master/photos/streamers.PNG)

<h6>Import danych z pliku JSON</h6>
<code>mongoimport -d nosql -c twitchjson streamers.json</code>

<h6>Zliczenie ilości zaimportowanych rekordów</h6>
<code>db.twitchjson.count()</code>

<h6>Liczba rekordów</h6>
<code>36</code>

![alt tag](https://github.com/pseroka/nosql/blob/master/photos/twitchjson-count.PNG)

<h6>Przykładowy rekord</h6>
<code>db.twitchjson.findOne()</code>

![alt tag](https://github.com/pseroka/nosql/blob/master/photos/twitchjson-example.PNG)

## Zapytania do bazy danych

<h4>Wszystkie mapy można obejrzeć na stronie: https://pseroka.github.io/</h4>

Aby móc tworzyć zapytania do bazy danych należało dodać do stworzonej wcześniej kolekcji geo-indeks.

<code>db.twitchjson.ensureIndex({"geometry" : "2dsphere"})</code>

## Point
Zapytanie dotyczy streamerów, którzy mieszkają w odległości 500 mil (804,672 km) od Gdańska (dł. 18.6463700; szer. 54.3520500).

<code>db.twitchjson.find({geometry: {$geoWithin: {$centerSphere: [[18.6463700,54.3520500],500/3963.2]}}}).toArray()</code>

Wynik zapytania:

![Zobacz mapę](https://github.com/pseroka/nosql/blob/master/gdansk.geojson)

## Polygon
Za pomocą narzędzia http://geojson.io stworzyłam obiekt Polygon o kształcie Ameryki Południowej i za jego pomocą sprawdziłam, którzy streamerzy mieszkają na terenie tego kontynentu.

Kod źródłowy zapytania dostępny w ![pliku](https://github.com/pseroka/nosql/blob/master/polygon.txt).

![alt tag](https://github.com/pseroka/nosql/blob/master/photos/polygon.PNG)

Wynik zapytania:

![Zobacz mapę](https://github.com/pseroka/nosql/blob/master/ameryka.geojson)

## LineString
Za pomocą narzędzia http://geojson.io stworzyłam obiekt LineString odzwierciedlający przebieg Wisły i sprawdziłam, którzy streamerzy mieszkają na przecięciu tego obiektu.

Kod źródłowy zapytania dostępny w ![pliku](https://github.com/pseroka/nosql/blob/master/linestring.txt).

![alt tag](https://github.com/pseroka/nosql/blob/master/photos/linestring-query.PNG)

Wynik zapytania w bazie MongoDB:

![alt tag](https://github.com/pseroka/nosql/blob/master/photos/linestring-output.PNG)

Wynik zapytania w postaci pliku GeoJSON:

![Zobacz mapę](https://github.com/pseroka/nosql/blob/master/wisla.geojson)

## Elasticsearch

![Plik](https://github.com/pseroka/nosql/blob/master/elastic/mapp.json) z wykonanym mappingiem danych.

<h6>Utworzenie indeksu "twitch"</h6>
<code>curl -XPUT "localhost:9200/twitch"</code>

<h6>Ustawienie mapping typu "streamers"</h6>
<code>curl -XPUT "localhost:9200/twitch/_mapping/streamers" --data-binary @C:\Users\PC\Desktop\nosql\mapp.json</code>

<h6>Import danych z pliku JSON</h6>
<code>curl -XPOST "localhost:9200/_bulk" --data-binary @C:/Users/PC/Desktop/nosql/elastic.json</code>


![Plik z danymi](https://github.com/pseroka/nosql/blob/master/elastic/elastic.json)

## Zapytania do bazy danych

## Point
Tak jak w przypadku MongoDB zapytanie dotyczy streamerów, którzy mieszkają w odległości 500 mil od Gdańska.

<code>curl -g -X GET "http://localhost:9200/twitch/streamers/_search?pretty=true" -d "{\"query\": { \"bool\" : { \"must\" : {\"match_all\" : {} },\"filter\" : { \"geo_distance\" : { \"distance\" : \"500mi\", \"coordinates\": [18.6463700,54.3520500] }}}}}"</code>

Wynik zapytania dostępny w ![pliku](https://github.com/pseroka/nosql/blob/master/elastic/point.json).

## Polygon
Zapytanie o streamerów mieszkających na terenie Ameryki Południowej.

Kod źródłowy zapytania dostępny w ![pliku](https://github.com/pseroka/nosql/blob/master/elastic/query2.txt).

<h6>Wywołanie zapytania</h6>
<code>curl -g -X GET "http://localhost:9200/twitch/streamers/_search?pretty=true" --data-binary @C:\Users\PC\Desktop\nosql\query2.txt</code>
<br><br>

Wynik zapytania dostępny w ![pliku](https://github.com/pseroka/nosql/blob/master/elastic/polygon.json).

## Bounding Box
Zapytanie o streamerów mieszkających na terenie wyznaczonym przez prostokąt ograniczający.

Kod źródłowy zapytania dostępny w ![pliku](https://github.com/pseroka/nosql/blob/master/elastic/query3.txt).

<h6>Wywołanie zapytania</h6>
<code>curl -g -X GET "http://localhost:9200/twitch/streamers/_search?pretty=true" --data-binary @C:\Users\PC\Desktop\nosql\query3.txt</code>
<br><br>

Wynik zapytania dostępny w ![pliku](https://github.com/pseroka/nosql/blob/master/elastic/boundingbox.json).

![Zobacz mapę](https://github.com/pseroka/nosql/blob/master/elastic/bound.geojson)
