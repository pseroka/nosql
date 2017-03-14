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
<code>CREATE TABLE myschema.crimes (
	Dc_Dist varchar,
	Psa varchar,
	Dispatch_Date_Time varchar, 
	Dispatch_Date varchar,  
	Dispatch_Time varchar, 
	Hour varchar, 
	Dc_Key varchar, 
	Location_Block varchar, 
	UCR_General varchar, 
	Text_General_Code varchar, 
	Police_Districts varchar,
	Month varchar, 
	Lon varchar, 
	Lat varchar 
);</code>

<h6>Import danych z pliku CSV</h6>
<code>\copy myschema.crimes FROM 'C:/Users/PC/Desktop/crimes.csv' DELIMITER ',' CSV</code>

<h6>Zliczenie ilości zaimportowanych rekordów</h6>
<code>SELECT COUNT(*) FROM myschema.crimes;</code>

<h6>Liczba rekordów</h6>
<code>1000977</code>

<h6>Obliczenie czasu importu danych</h6>
<code>\timing \copy myschema.crimes FROM 'C:/Users/PC/Desktop/crimes.csv' DELIMITER ',' CSV</code>

<h6>Czas importu danych</h6>
<code>13749,464 ms</code>

<h5>Agregacja 1. Rozkład liczby przestępstw w latach</h5>
<code>SELECT COUNT(*), EXTRACT(year FROM Dispatch_Date) AS year FROM myschema.crimes GROUP BY year HAVING EXTRACT(year FROM Dispatch_Date) >= 2006 ORDER BY year ASC;</code>
<br>
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
