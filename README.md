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



## PostgresSQL

Schema -- przygotować i użyć w trakcie importu danych.

### Import danych



## MongoDB

Pamiętać aby DateTime było zaimportowane jako DateTime, liczby - to samo.

### Import danych
