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
      <td><a href="https://www.kaggle.com/silicon99/dft-accident-data"><b>UK Car Accidents 2005-2015</b></a></td>
    </tr>
  </tbody>
</table>






## Przedstawienie danych
Przykładowy rekord. Ile tego jest/będzie? (w sztukach, w GB)

json
{
	"x": "raz dwa trzy".
	"lation": [23,23].
}


## Przykładowe zapytania

Czego szukam? (np. restauracje w obrębie iluś km)

## Mapki
Zapytania mapkowe. (np. Ile jest kuchni chińskich?)

curl localhost:9200/... | jq.hits.hits[] | przerabiamy na GEOJson-a za pomocą programu, który wyszukujemy w Internecie, np. TopoJSON
pokazujemy wynik i umieszczamy go na mapce

[mapki-es](mapki-es) -- link do mapki
mapki trzymamy dla porządku w katalogu docs

dokument: mapki-es.html
<h1>Elasticsearch is Awesome!</h1>

<p>Mapka powstawały jak</p>
<p>Tytuł</p>
<p>o co chodzi w zapytaniu</p>
<-- mapka -->

<p>Tytuł</p>
<p>o co chodzi w zapytaniu</p>
<-- mapka -->

Z tych danych zrobię mapki, podsumowania.

Nie zapisywać na dysku.

## Czyszczenie danych
Zmienić nazwy pól, wybrano te pola i dlaczego.

## Elasticsearch

Mapping -- przygotować i zapisać

### Import danych

sh
gunzip -c dane.json.gz | ... #całość
... 		| #próbka / sample

Liczymy ile czasu to zajęło.



## PostgreSQL

Schema -- przygotować i użyć w trakcie importu danych.

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
<code>48025,663 ms</code>

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

Pamiętać aby DateTime było zaimportowane jako DateTime, liczby - to samo.

<h6>Utworzenie bazy danych</h6>
<code>use nosql</code>

<h6>Import danych z pliku CSV</h6>
<code>mongoimport -d nosql -c crimes --type csv --file C:\Users\PC\Desktop\crimes_m.csv --headerline</code>

<h6>Zliczenie ilości zaimportowanych rekordów</h6>
<code>db.crimes.count()</code>

<h6>Liczba rekordów</h6>
<code>1000977</code>

<h6>Obliczenie czasu importu danych</h6>
<code>powershell "Measure-Command{mongoimport -d nosql -c crimes --type csv --file C:\Users\PC\Desktop\crimes_m.csv --headerline}"</code>

<h6>Czas importu danych</h6>
<code>59460,6697 ms</code>

<h2>Mapy</h2>

<h6>Import danych z pliku JSON</h6>
<code>mongoimport -d nosql -c twitchjson streamers.json</code>

<h6>Zliczenie ilości zaimportowanych rekordów</h6>
<code>db.twitchjson.count()</code>

<h6>Liczba rekordów</h6>
<code>36</code>

<h6>Przykładowy rekord</h6>
<code>db.twitchjson.findOne()</code>

<--wkleić obrazek-->

<code>{
        "_id" : ObjectId("58cbbfdb89f63fa5435978b4"),
        "type" : "Feature",
        "properties" : {
                "marker-color" : "#f00",
                "marker-size" : "medium",
                "marker-symbol" : "",
                "channel_login" : "sing_sing",
                "geo" : "NL",
                "viewers" : "17281"
        },
        "geometry" : {
                "type" : "Point",
                "coordinates" : [
                        "4.8896900",
                        "52.3740300"
                ]
        }
}</code>

![alt tag](https://github.com/pseroka/nosql/blob/master/photos/ameryka.PNG)
