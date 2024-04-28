/*
REGOLE
- Tutte le risposte devono essere scritte in JavaScript
- Se sei in difficoltà puoi chiedere aiuto a un Teaching Assistant
- Puoi usare Google / StackOverflow ma solo quanto ritieni di aver bisogno di qualcosa che non è stato spiegato a lezione
- Puoi testare il tuo codice in un file separato, o de-commentando un esercizio alla volta
- Per farlo puoi utilizzare il terminale Bash, quello di VSCode o quello del tuo sistema operativo (se utilizzi macOS o Linux)
*/

// JS Basics

/* ESERCIZIO A
  Crea una variabile chiamata "sum" e assegnaci il risultato della somma tra i valori 10 e 20.
*/
console.log("*****************************************************");
console.log("******************** ESERCIZIO A ********************");
console.log("*****************************************************");

let sum, a, b;
a=10;
b=20;
sum=a+b;

console.log("La somma tra "+a+" e "+b+" equivale a: "+sum);

console.log("\n\n");

/* ESERCIZIO B
  Crea una variabile chiamata "random" e assegnaci un numero casuale tra 0 e 20 (deve essere generato dinamicamente a ogni esecuzione).
*/
console.log("*****************************************************");
console.log("******************** ESERCIZIO B ********************");
console.log("*****************************************************");


let range;
range=20
const random=Math.round(Math.random()*range);

console.log("Il numero generato tra 0 e "+range+" è: "+random);

console.log("\n\n");


/* ESERCIZIO C
  Crea una variabile chiamata "me" e assegnaci un oggetto contenente le seguenti proprietà: name = il tuo nome, surname = il tuo cognome, age = la tua età.
*/
console.log("*****************************************************");
console.log("******************** ESERCIZIO C ********************");
console.log("*****************************************************");

let me={
  name: "Daniele",
  surname: "Bertone",
  age: "22"
}
console.log(me);

console.log("\n\n");
/* ESERCIZIO D
  Crea del codice per rimuovere programmaticamente la proprietà "age" dall'oggetto precedentemente creato.
*/
console.log("*****************************************************");
console.log("******************** ESERCIZIO D ********************");
console.log("*****************************************************");

delete me.age;
console.log(me);


console.log("\n\n");
/* ESERCIZIO E
  Crea del codice per aggiungere programmaticamente all'oggetto precedentemente creato un array chiamato "skills", contenente i linguaggi di programmazione che conosci.
*/
console.log("*****************************************************");
console.log("******************** ESERCIZIO E ********************");
console.log("*****************************************************");
me.skills=["javascript", "java", "c++"];
console.log(me);


console.log("\n\n");
/* ESERCIZIO F
  Crea un pezzo di codice per aggiungere un nuovo elemento all'array "skills" contenuto nell'oggetto "me".
*/
console.log("*****************************************************");
console.log("******************** ESERCIZIO F ********************");
console.log("*****************************************************");


me.skills.push("php");
console.log(me);

console.log("\n\n");
/* ESERCIZIO G
  Crea un pezzo di codice per rimuovere programmaticamente l'ultimo elemento dall'array "skills" contenuto nell'oggetto "me".
*/
console.log("*****************************************************");
console.log("******************** ESERCIZIO G ********************");
console.log("*****************************************************");
me.skills.pop();
console.log(me);


console.log("\n\n");
// Funzioni

/* ESERCIZIO 1
  Crea una funzione chiamata "dice": deve generare un numero casuale tra 1 e 6.
*/
console.log("*****************************************************");
console.log("******************** ESERCIZIO 1 ********************");
console.log("*****************************************************");

let n;
n=6;

const dice=function(range) {
  let random;

  random=Math.floor(Math.random()*range+1);
  return random;
}

console.log(dice(n));


console.log("\n\n");
/* ESERCIZIO 2
  Crea una funzione chiamata "whoIsBigger" che riceve due numeri come parametri e ritorna il maggiore dei due.
*/
console.log("*****************************************************");
console.log("******************** ESERCIZIO 2 ********************");
console.log("*****************************************************");

let num1, num2;

num1=109209;
num2=198764;

const whoIsBigger=function(a, b){

  if(a>b){
    return "Il maggiore tra "+a+" e "+b+" è: "+a;
  }else{
    return "Il maggiore tra "+a+" e "+b+" è: "+b;
  }
}

console.log(whoIsBigger(num1, num2));


console.log("\n\n");
/* ESERCIZIO 3
  Crea una funzione chiamata "splitMe" che riceve una stringa come parametro e ritorna un'array contenente ogni parola della stringa.

  Es.: splitMe("I love coding") => ritorna ["I", "Love", "Coding"]
*/
console.log("*****************************************************");
console.log("******************** ESERCIZIO 3 ********************");
console.log("*****************************************************");
var string;

string="I love coding";

const splitMe=function(str){
  let split=[];

  split=str.split(" ");

  return split;
}

console.log(splitMe(string));


console.log("\n\n");
/* ESERCIZIO 4
  Crea una funzione chiamata "deleteOne" che riceve una stringa e un booleano come parametri.
  Se il valore booleano è true la funzione deve ritornare la stringa senza il primo carattere, altrimenti la deve ritornare senza l'ultimo.
*/
console.log("*****************************************************");
console.log("******************** ESERCIZIO 4 ********************");
console.log("*****************************************************");

var string, boolean;

string="I love coding";
boolean=true;

const deleteOne=function(str, bool){
  if(bool===true){
    return str.slice(1);
  }else{
    return str.slice(0, -1);
  }
}

console.log(deleteOne(string, boolean));

console.log("\n\n");
/* ESERCIZIO 5
  Crea una funzione chiamata "onlyLetters" che riceve una stringa come parametro e la ritorna eliminando tutte le cifre numeriche.

  Es.: onlyLetters("I have 4 dogs") => ritorna "I have dogs"
  
*/

console.log("*****************************************************");
console.log("******************** ESERCIZIO 5 ********************");
console.log("*****************************************************");

var string="I have 4 dogs";

const onlyLetters=function(str) {

  return str.replace(/[0-9]/g, "");
}

console.log(onlyLetters(string));


console.log("\n\n");
/* ESERCIZIO 6
  Crea una funzione chiamata "isThisAnEmail" che riceve una stringa come parametro e ritorna true se la stringa è un valido indirizzo email.
*/
console.log("*****************************************************");
console.log("******************** ESERCIZIO 6 ********************");
console.log("*****************************************************");

var string="Paulo Dybala"

/*
const isThisAnEmail=function(str) {
  return str=str.checkValidity();
}
console.log(isThisAnEmail(string));
*/

console.log("\n\n");
/* ESERCIZIO 7
  Scrivi una funzione chiamata "whatDayIsIt" che ritorna il giorno della settimana corrente.
*/
console.log("*****************************************************");
console.log("******************** ESERCIZIO 7 ********************");
console.log("*****************************************************");

const whatDayIsIt=function(){
  let date, giorno_sett, array;

  date=new Date();
  giorno_sett=date.getDay();
  array=["Domenica", "Lunedì", "Martedì", "Mercoledì", "Giovedì", "Venerdì", "Sabato"];


  return "Oggi siamo: "+array[giorno_sett];
}

console.log(whatDayIsIt());

console.log("\n\n");

/* ESERCIZIO 8
  Scrivi una funzione chiamata "rollTheDices" che riceve un numero come parametro.
  Deve invocare la precedente funzione dice() il numero di volte specificato nel parametro, e deve tornare un oggetto contenente una proprietà "sum":
  il suo valore deve rappresentare il totale di tutti i valori estratti con le invocazioni di dice().
  L'oggetto ritornato deve anche contenere una proprietà "values", contenente un array con tutti i valori estratti dalle invocazioni di dice().

  Example:
  rollTheDices(3) => ritorna {
      sum: 10
      values: [3, 3, 4]
  }
*/

console.log("*****************************************************");
console.log("******************** ESERCIZIO 8 ********************");
console.log("*****************************************************");

let numero_volte;

numero_volte=10;

const rollTheDices=function(n){  
  let range, inv, sum, obj;

  range=100;          // range del generatore di numeri
  inv=[];             // creazione array dei numeri generati
  sum=0;              // varibile della somma di tutti i numeri generati
  obj={};             // creazione oggetto con la somma e i valori generati

  for(i=0; i<n; i++){
    inv[i]=dice(range);
    sum=inv[i]+sum;
    obj.values=inv;
  }
  obj.sum=sum;

  return obj;
}

console.log(rollTheDices(numero_volte));


console.log("\n\n");
/* ESERCIZIO 9
  Scrivi una funzione chiamata "howManyDays" che riceve una data come parametro e ritorna il numero di giorni trascorsi da tale data.
*/
console.log("*****************************************************");
console.log("******************** ESERCIZIO 9 ********************");
console.log("*****************************************************");

let date;

date="2/10/2023"; // impostare nel formato mm/gg/aaaa

const hoManyDays=function (data){
  let data_corrente, data_impostata, differenzaTempoInMillisecondi, differenzaTempoInSecondi;
  let differenzaTempoInMinuti, differenzaTempoInOre, differenzaTempoInGiorni;

  data_corrente=new Date();
  data_impostata=new Date(data);

  differenzaTempoInMillisecondi=data_corrente-data_impostata;
  differenzaTempoInSecondi=Math.floor(differenzaTempoInMillisecondi/1000);
  differenzaTempoInMinuti=Math.floor(differenzaTempoInSecondi/60);
  differenzaTempoInOre=Math.floor(differenzaTempoInMinuti/60);
  differenzaTempoInGiorni=Math.floor(differenzaTempoInOre/24);
  

  return "Sono passati "+differenzaTempoInGiorni+" giorni dal "+data;
}

console.log(hoManyDays(date));


console.log("\n\n");
/* ESERCIZIO 10
  Scrivi una funzione chiamata "isTodayMyBirthday" che deve ritornare true se oggi è il tuo compleanno, falso negli altri casi.
*/

console.log("******************************************************");
console.log("******************** ESERCIZIO 10 ********************");
console.log("******************************************************");

const isTodayMyBirthday=function() {
  let date, mm, gg;

  date=new Date();
  mm=3;
  gg=27;

  if(date.getDate()==gg && date.getMonth()+1==mm){
    return "Oggi è il mio compleanno!"
  }else{
    return "Oggi non è il mio compleanno!";
  }
}

console.log(isTodayMyBirthday());

// Arrays & Oggetti

/* Questo array viene usato per gli esercizi. Non modificarlo. */

const movies = [
  {
    Title: 'The Lord of the Rings: The Fellowship of the Ring',
    Year: '2001',
    imdbID: 'tt0120737',
    Type: 'movie',
    Poster:
      'https://m.media-amazon.com/images/M/MV5BN2EyZjM3NzUtNWUzMi00MTgxLWI0NTctMzY4M2VlOTdjZWRiXkEyXkFqcGdeQXVyNDUzOTQ5MjY@._V1_SX300.jpg',
  },

  {
    Title: 'The Lord of the Rings: The Return of the King',
    Year: '2003',
    imdbID: 'tt0167260',
    Type: 'movie',
    Poster:
      'https://m.media-amazon.com/images/M/MV5BNzA5ZDNlZWMtM2NhNS00NDJjLTk4NDItYTRmY2EwMWZlMTY3XkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg',
  },
  {
    Title: 'The Lord of the Rings: The Two Towers',
    Year: '2002',
    imdbID: 'tt0167261',
    Type: 'movie',
    Poster:
      'https://m.media-amazon.com/images/M/MV5BNGE5MzIyNTAtNWFlMC00NDA2LWJiMjItMjc4Yjg1OWM5NzhhXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg',
  },
  {
    Title: 'Lord of War',
    Year: '2005',
    imdbID: 'tt0399295',
    Type: 'movie',
    Poster:
      'https://m.media-amazon.com/images/M/MV5BMTYzZWE3MDAtZjZkMi00MzhlLTlhZDUtNmI2Zjg3OWVlZWI0XkEyXkFqcGdeQXVyNDk3NzU2MTQ@._V1_SX300.jpg',
  },
  {
    Title: 'Lords of Dogtown',
    Year: '2005',
    imdbID: 'tt0355702',
    Type: 'movie',
    Poster:
      'https://m.media-amazon.com/images/M/MV5BNDBhNGJlOTAtM2ExNi00NmEzLWFmZTQtYTZhYTRlNjJjODhmXkEyXkFqcGdeQXVyNDk3NzU2MTQ@._V1_SX300.jpg',
  },
  {
    Title: 'The Lord of the Rings',
    Year: '1978',
    imdbID: 'tt0077869',
    Type: 'movie',
    Poster:
      'https://m.media-amazon.com/images/M/MV5BOGMyNWJhZmYtNGQxYi00Y2ZjLWJmNjktNTgzZWJjOTg4YjM3L2ltYWdlXkEyXkFqcGdeQXVyNTAyODkwOQ@@._V1_SX300.jpg',
  },
  {
    Title: 'Lord of the Flies',
    Year: '1990',
    imdbID: 'tt0100054',
    Type: 'movie',
    Poster:
      'https://m.media-amazon.com/images/M/MV5BOTI2NTQyODk0M15BMl5BanBnXkFtZTcwNTQ3NDk0NA@@._V1_SX300.jpg',
  },
  {
    Title: 'The Lords of Salem',
    Year: '2012',
    imdbID: 'tt1731697',
    Type: 'movie',
    Poster:
      'https://m.media-amazon.com/images/M/MV5BMjA2NTc5Njc4MV5BMl5BanBnXkFtZTcwNTYzMTcwOQ@@._V1_SX300.jpg',
  },
  {
    Title: 'Greystoke: The Legend of Tarzan, Lord of the Apes',
    Year: '1984',
    imdbID: 'tt0087365',
    Type: 'movie',
    Poster:
      'https://m.media-amazon.com/images/M/MV5BMTM5MzcwOTg4MF5BMl5BanBnXkFtZTgwOTQwMzQxMDE@._V1_SX300.jpg',
  },
  {
    Title: 'Lord of the Flies',
    Year: '1963',
    imdbID: 'tt0057261',
    Type: 'movie',
    Poster:
      'https://m.media-amazon.com/images/M/MV5BOGEwYTlhMTgtODBlNC00ZjgzLTk1ZmEtNmNkMTEwYTZiM2Y0XkEyXkFqcGdeQXVyMzU4Nzk4MDI@._V1_SX300.jpg',
  },
  {
    Title: 'The Avengers',
    Year: '2012',
    imdbID: 'tt0848228',
    Type: 'movie',
    Poster:
      'https://m.media-amazon.com/images/M/MV5BNDYxNjQyMjAtNTdiOS00NGYwLWFmNTAtNThmYjU5ZGI2YTI1XkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_SX300.jpg',
  },
  {
    Title: 'Avengers: Infinity War',
    Year: '2018',
    imdbID: 'tt4154756',
    Type: 'movie',
    Poster:
      'https://m.media-amazon.com/images/M/MV5BMjMxNjY2MDU1OV5BMl5BanBnXkFtZTgwNzY1MTUwNTM@._V1_SX300.jpg',
  },
  {
    Title: 'Avengers: Age of Ultron',
    Year: '2015',
    imdbID: 'tt2395427',
    Type: 'movie',
    Poster:
      'https://m.media-amazon.com/images/M/MV5BMTM4OGJmNWMtOTM4Ni00NTE3LTg3MDItZmQxYjc4N2JhNmUxXkEyXkFqcGdeQXVyNTgzMDMzMTg@._V1_SX300.jpg',
  },
  {
    Title: 'Avengers: Endgame',
    Year: '2019',
    imdbID: 'tt4154796',
    Type: 'movie',
    Poster:
      'https://m.media-amazon.com/images/M/MV5BMTc5MDE2ODcwNV5BMl5BanBnXkFtZTgwMzI2NzQ2NzM@._V1_SX300.jpg',
  },
]

console.log("\n\n");
/* ESERCIZIO 11
  Scrivi una funzione chiamata "deleteProp" che riceve un oggetto e una stringa come parametri; deve ritornare l'oggetto fornito dopo aver eliminato
  in esso la proprietà chiamata come la stringa passata come secondo parametro.
*/
console.log("******************************************************");
console.log("******************** ESERCIZIO 11 ********************");
console.log("******************************************************");

var obj, str;

obj={
  name: "Paulo",
  surname: "Dybala",
  squadra: "AS Roma"
};
string="squadra";
console.log("Prima: ");
console.log(obj);

const deleteProp=function(obj, str){
  delete obj[str];
  
  return obj;
}
console.log("Dopo");
console.log(deleteProp(obj, string));

console.log("\n\n");
/* ESERCIZIO 12
  Scrivi una funzione chiamata "newestMovie" che trova il film più recente nell'array "movies" fornito.
*/
console.log("******************************************************");
console.log("******************** ESERCIZIO 12 ********************");
console.log("******************************************************");

const newestMovie=function(){
  let result={Year: 1700};

  movies.forEach((movie) => {
    let year;

    year=parseInt(movie.Year);

    if(year>result.Year){
      result=movie;
    }
  })
  return result;
}
console.log("Il film più recente è:");
console.log(newestMovie());

console.log("\n\n");
/* ESERCIZIO 13
  Scrivi una funzione chiamata countMovies che ritorna il numero di film contenuti nell'array "movies" fornito.
*/
console.log("******************************************************");
console.log("******************** ESERCIZIO 13 ********************");
console.log("******************************************************");

const countMovies=function() {
  return "Il numero di film all'interno dell'array movies è: "+movies.length;
}

console.log(countMovies());

console.log("\n\n");
/* ESERCIZIO 14
  Scrivi una funzione chiamata "onlyTheYears" che crea un array con solamente gli anni di uscita dei film contenuti nell'array "movies" fornito.
*/
console.log("******************************************************");
console.log("******************** ESERCIZIO 14 ********************");
console.log("******************************************************");

const onlyTheYears=function() {
  return movies.map((movie) => movie.Year);
}

console.log("Array solamente con gli anni di uscita");
console.log(onlyTheYears());

console.log("\n\n");
/* ESERCIZIO 15
  Scrivi una funzione chiamata "onlyInLastMillennium" che ritorna solamente i film prodotto nel millennio scorso contenuti nell'array "movies" fornito.
*/
console.log("******************************************************");
console.log("******************** ESERCIZIO 15 ********************");
console.log("******************************************************");

const onlyInLastMillennium=function() {
  return movies.filter((movie) => movie.Year<2000);
}

console.log("Film prodotti solo prima dell'anno 2000");
console.log(onlyInLastMillennium());

console.log("\n\n");
/* ESERCIZIO 16
  Scrivi una funzione chiamata "sumAllTheYears" che ritorna la somma di tutti gli anni in cui sono stati prodotti i film contenuti nell'array "movies" fornito.
*/
console.log("******************************************************");
console.log("******************** ESERCIZIO 16 ********************");
console.log("******************************************************");

const sumAllTheYears=function(){
  return movies.reduce((total, movie) => total+parseInt(movie.Year), 0);
}

console.log(sumAllTheYears());

console.log("\n\n");
/* ESERCIZIO 17
  Scrivi una funzione chiamata "searchByTitle" che riceve una stringa come parametro e ritorna i film nell'array "movies" fornito che la contengono nel titolo.
*/
console.log("******************************************************");
console.log("******************** ESERCIZIO 17 ********************");
console.log("******************************************************");

var string="Avengers: Infinity War";

const searchByTitle=function(str) {
  return movies.find((movie) => movie.Title==str);
}

console.log(searchByTitle(string));

console.log("\n\n");
/* ESERCIZIO 18
  Scrivi una funzione chiamata "searchAndDivide" che riceve una stringa come parametro e ritorna un oggetto contenente due array: "match" e "unmatch".
  "match" deve includere tutti i film dell'array "movies" fornito che contengono la stringa fornita all'interno del proprio titolo, mentre "unmatch" deve includere tutti i rimanenti.
*/
console.log("******************************************************");
console.log("******************** ESERCIZIO 17 ********************");
console.log("******************************************************");

const searchAndDivide=function (){
  let obj={
    match:[],
    unmatch:[]
  }
  
}

searchAndDivide();

/* ESERCIZIO 19
  Scrivi una funzione chiamata "removeIndex" che riceve un numero come parametro e ritorna l'array "movies" fornito privo dell'elemento nella posizione ricevuta come parametro.
*/
var i=8;

const removeIndex=function(index){
  movies.splice(index, 1);

  return movies;
}

console.log(removeIndex(i));

// DOM (nota: gli elementi che selezionerai non si trovano realmente nella pagina)

/* ESERCIZIO 20
  Scrivi una funzione per selezionare l'elemento dotato di id "container" all'interno della pagina.
*/
const function1=function(){
  let container=document.getElementById("container");
}


/* ESERCIZIO 21
  Scrivi una funzione per selezionare ogni tag <td> all'interno della pagina.
*/
const function2=function(){
  let td=document.querySelectorAll("td");
}

/* ESERCIZIO 22
  Scrivi una funzione che, tramite un ciclo, stampa in console il testo contenuto in ogni tag <td> all'interno della pagina.
*/
const function3=function() {
  let td=document.querySelectorAll("td");
  let arrTd=[];

  for(i=0; i<td.length; i++){
    arrTd.push(td[i]);
    console.log(arrTd[i]);
  }
}

/* ESERCIZIO 23
  Scrivi una funzione per aggiungere un background di colore rosso a ogni link all'interno della pagina.
*/

const function4=function() {
  let a=document.querySelectorAll("a");

  a.style.backgroundColor="red";
}

/* ESERCIZIO 24
  Scrivi una funzione per aggiungere un nuovo elemento alla lista non ordinata con id "myList".
*/
const function5=function(){
  let myList=document.getElementById("myList");
  let node=document.createElement("li");
  let nodeText=document.createTextNode("prova");

  node.appendChild(nodeText);
  myList.appendChild(node);
}

/* ESERCIZIO 25
  Scrivi una funzione per svuotare la lista non ordinata con id "myList".
*/

const function6=function() {
  let myList=document.querySelectorAll("#myList ul");

  for(i=0; i<myList.length; i++){
    myList.remove();
  }
}

/* ESERCIZIO 26
  Scrivi una funzione per aggiungere ad ogni tag <tr> la classe CSS "test"
*/

const function7=function(){
  let tr=querySelectorAll("tr");

  for(i=0; i<tr.length; i++){
    tr.classList.add("test");
  }
}

// [EXTRA] JS Avanzato

/* ESERCIZIO 27
  Crea una funzione chiamata "halfTree" che riceve un numero come parametro e costruisce un mezzo albero di "*" (asterischi) dell'altezza fornita.

  Esempio:
  halfTree(3)

  *
  **
  ***

*/

/* ESERCIZIO 28
  Crea una funzione chiamata "tree" che riceve un numero come parametro e costruisce un albero di "*" (asterischi) dell'altezza fornita.

  Esempio:
  tree(3)

    *
   ***
  *****

*/

/* ESERCIZIO 29
  Crea una funzione chiamata "isItPrime" che riceve un numero come parametro e ritorna true se il numero fornito è un numero primo.
*/


