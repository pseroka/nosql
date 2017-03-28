<h1>Technologie NoSQL</h1>

projekt zaliczeniowy

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
      <td>TODO</td>
    </tr>
    <tr>
      <td>Procesor</td>
      <td>TODO</td>
    </tr>
    <tr>
      <td>Pamięć</td>
      <td>TODO</td>
    </tr>
    <tr>
      <td>Dysk</td>
      <td>TODO</td>
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

![alt tag](https://github.com/pseroka/nosql/blob/master/photos/psql-count.PNG)

<h6>Obliczenie czasu importu danych</h6>
<code>\timing \copy myschema.twitch FROM 'C:/Users/PC/Desktop/nosql/twitch.csv' DELIMITER ',' CSV HEADER</code>

<h6>Czas importu danych</h6>
<code>40422,841 ms</code>

![alt tag](https://github.com/pseroka/nosql/blob/master/photos/psql-czas.PNG)

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

![alt tag](https://github.com/pseroka/nosql/blob/master/photos/mongo-count.PNG)

<h6>Obliczenie czasu importu danych</h6>
<code>powershell "Measure-Command{mongoimport -d nosql -c crimes --type csv --file C:\Users\PC\Desktop\crimes_m.csv --headerline}"</code>

<h6>Czas importu danych</h6>
<code>88939,597 ms</code>

![alt tag](https://github.com/pseroka/nosql/blob/master/photos/mongo-czas.PNG)

<h2>Mapy</h2>

Do stworzenia mapy GeoJSON wykorzystałam narzędzie, które znajduje się pod adresem: http://geojson.io. Na potrzeby zadania za pomocą ![skryptu](https://github.com/pseroka/nosql/blob/master/geojson.js) napisanego w JavaScript wyznaczyłam 36 unikalnych rekordów ze streamerami z różnych krajów i zaznaczyłam je na mapie odmiennymi kolorami według schematu: kolor niebieski - Ameryka Północna, kolor zielony - Ameryka Południowa, kolor czerwony - Europa, kolor żółty - Azja, kolor różowy - Australia i Oceania.

![Mapa](https://github.com/pseroka/nosql/blob/master/streamers.geojson)

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
Aby móc tworzyć zapytania do bazy danych należało dodać do stworzonej wcześniej kolekcji geo-indeks.

<code>db.twitchjson.ensureIndex({"geometry" : "2dsphere"})</code>

## Point
Zapytanie dotyczy streamerów, którzy mieszkają w odległości 500 mil (804,672 km) od Gdańska (dł. 18.6463700; szer. 54.3520500).

<code>db.twitchjson.find({geometry: {$geoWithin: {$centerSphere: [[18.6463700,54.3520500],500/3963.2]}}}).toArray()</code>

Wynik zapytania:

![Mapa](https://github.com/pseroka/nosql/blob/master/gdansk.geojson)

![alt tag](https://github.com/pseroka/nosql/blob/master/photos/gdansk.PNG)

## Polygon
Za pomocą narzędzia http://geojson.io stworzyłam obiekt Polygon o kształcie Ameryki Południowej i za jego pomocą sprawdziłam, którzy streamerzy mieszkają na terenie tego kontynentu.

Kod źródłowy zapytania dostępny w ![pliku](https://github.com/pseroka/nosql/blob/master/polygon.txt).

![alt tag](https://github.com/pseroka/nosql/blob/master/photos/polygon.PNG)

Wynik zapytania:

![Mapa](https://github.com/pseroka/nosql/blob/master/ameryka.geojson)

![alt tag](https://github.com/pseroka/nosql/blob/master/photos/ameryka.PNG)

## LineString
Za pomocą narzędzia http://geojson.io stworzyłam obiekt LineString odzwierciedlający przebieg Wisły i sprawdziłam, którzy streamerzy mieszkają na przecięciu tego obiektu.

Kod źródłowy zapytania dostępny w ![pliku](https://github.com/pseroka/nosql/blob/master/linestring.txt).

![alt tag](https://github.com/pseroka/nosql/blob/master/photos/linestring-query.PNG)

Wynik zapytania w bazie MongoDB:

![alt tag](https://github.com/pseroka/nosql/blob/master/photos/linestring-output.PNG)

Wynik zapytania w postaci pliku GeoJSON:

![Mapa](https://github.com/pseroka/nosql/blob/master/wisla.geojson)

![alt tag](https://github.com/pseroka/nosql/blob/master/photos/linestring.PNG)

## Elasticsearch

![Plik](https://github.com/pseroka/nosql/blob/master/elastic/mapp.json) z wykonanym mappingiem danych.

<h6>Utworzenie indeksu "twitch"</h6>
<code>curl -XPUT "localhost:9200/twitch"</code>

<h6>Ustawienie mapping typu "streamers"</h6>
<code>curl -XPUT "localhost:9200/twitch/_mapping/streamers" --data-binary @C:\Users\PC\Desktop\nosql\mapp.json</code>

<h6>Import danych z ![pliku]() JSON</h6>
<code>curl -XPOST "localhost:9200/_bulk" --data-binary @C:/Users/PC/Desktop/nosql/elastic.json</code>

## Zapytania do bazy danych

## Point
Tak jak w przypadku MongoDB zapytanie dotyczy streamerów, którzy mieszkają w odległości 500 mil od Gdańska.

<code>curl -g -X GET "http://localhost:9200/twitch/streamers/_search?pretty=true" -d "{\"query\": { \"bool\" : { \"must\" : {\"match_all\" : {} },\"filter\" : { \"geo_distance\" : { \"distance\" : \"500mi\", \"coordinates\": [18.6463700,54.3520500] }}}}}"</code>

Wynik zapytania dostępny w ![pliku](https://github.com/pseroka/nosql/blob/master/elastic/point.json).

## Polygon
Zapytanie o streamerów mieszkających na terenie Ameryki Połudiowej.

<code>curl -g -X GET "http://localhost:9200/twitch/streamers/_search?pretty=true" -d "{\"query\": { \"bool\" : { \"must\" : {\"match_all\" : {} },\"filter\" : { \"geo_polygon\" : { \"coordinates\": { \"points\" : [[-75.5859375,11.005904459659451],[-76.81640625,9.275622176792112],[-77.87109375,7.710991655433217],[-78.57421875,5.441022303717974],[-78.92578124999999,2.986927393334876],[-79.98046875,1.2303741774326145],[-81.5625,-0.17578097424708533],[-81.5625,-2.108898659243126],[-81.73828125,-4.565473550710278],[-80.68359375,-7.536764322084078],[-79.27734374999999,-10.487811882056683],[-76.81640625,-14.093957177836224],[-74.70703125,-16.467694748288956],[-72.59765625,-18.312810846425442],[-71.015625,-22.105998799750566],[-71.54296874999999,-26.588527147308614],[-72.7734375,-30.751277776257812],[-73.65234375,-35.6037187406973],[-74.70703125,-41.50857729743933],[-75.76171875,-46.07323062540835],[-75.76171875,-50.06419173665909],[-74.35546875,-53.85252660044951],[-72.0703125,-55.27911529201561],[-68.5546875,-56.36525013685607],[-65.390625,-55.67758441108951],[-65.91796875,-53.85252660044951],[-67.32421875,-51.508742458803326],[-66.09375,-48.80686346108517],[-65.390625,-45.95114968669139],[-64.16015624999999,-43.83452678223682],[-61.34765625,-41.37680856570234],[-55.1953125,-36.17335693522159],[-50.09765625,-31.203404950917385],[-47.8125,-29.22889003019423],[-47.4609375,-26.11598592533351],[-44.29687499999999,-24.367113562651262],[-40.42968749999999,-23.079731762449878],[-38.67187499999999,-18.646245142670598],[-37.96875,-15.28418511407642],[-36.73828124999999,-12.726084296948184],[-34.1015625,-8.928487062665504],[-34.453125,-5.44102230371796],[-37.44140625,-2.986927393334863],[-40.42968749999999,-1.9332268264771106],[-43.2421875,-1.4061088354351594],[-46.7578125,0.5273363048115169],[-49.39453125,2.1088986592431382],[-50.9765625,5.61598581915534],[-54.31640625,6.489983332670651],[-57.65624999999999,7.36246686553575],[-60.29296874999999,9.622414142924805],[-63.28125,11.350796722383672],[-65.56640625,11.523087506868514],[-68.203125,11.867350911459308],[-69.9609375,12.554563528593656],[-72.421875,12.554563528593656],[-74.35546875,12.039320557540572],[-75.5859375,11.005904459659451]]}}}}}}"</code>

Wynik zapytania dostępny w ![pliku](https://github.com/pseroka/nosql/blob/master/elastic/polygon.json).
