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

<h5>Agregacja 1. Rozkład liczby przestępstw w latach</h5>
<code>SELECT COUNT(*), EXTRACT(year FROM Dispatch_Date) AS year FROM myschema.crimes GROUP BY year HAVING EXTRACT(year FROM Dispatch_Date) >= 2006 ORDER BY year ASC;</code>
<br><br>
<table>
  <thead>
    <tr>
      <th>Rok</th>
      <th>Liczba</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>2006</td>
      <td>7055</td>
    </tr>
    <tr>
      <td>2007</td>
      <td>290</td>
    </tr>
    <tr>
      <td>2008</td>
      <td>248</td>
    </tr>
    <tr>
      <td>2009</td>
      <td>70794</td>
    </tr>
    <tr>
      <td>2010</td>
      <td>199262</td>
    </tr>
    <tr>
      <td>2011</td>
      <td>195359</td>
    </tr>
    <tr>
      <td>2012</td>
      <td>196603</td>
    </tr>
    <tr>
      <td>2013</td>
      <td>186339</td>
    </tr>
    <tr>
      <td>2014</td>
      <td>50643</td>
    </tr>
    <tr>
      <td>2015</td>
      <td>93541</td>
    </tr>
    <tr>
      <td>2016</td>
      <td>843</td>
    </tr>
  </tbody>
</table>

<h5>Agregacja 2. 7 dzielnic z liczbą przestępstw większą niż 50000</h5>
<code>SELECT Dc_Dist, COUNT(*) AS ile FROM myschema.crimes GROUP BY Dc_Dist HAVING COUNT(*) > 50000 ORDER BY ile ASC LIMIT 7;</code>
<br><br>
<table>
  <thead>
    <tr>
      <th>Numer dzielnicy</th>
      <th>Liczba przestępstw</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>3</td>
      <td>50591</td>
    </tr>
    <tr>
      <td>14</td>
      <td>52684</td>
    </tr>
    <tr>
      <td>35</td>
      <td>57684</td>
    </tr>
    <tr>
      <td>2</td>
      <td>59032</td>
    </tr>
    <tr>
      <td>12</td>
      <td>59574</td>
    </tr>
    <tr>
      <td>22</td>
      <td>62856</td>
    </tr>
    <tr>
      <td>19</td>
      <td>63642</td>
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
