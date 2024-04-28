/*
REGOLE
- Tutte le risposte devono essere scritte in JavaScript
- Puoi usare Google / StackOverflow ma solo quanto ritieni di aver bisogno di qualcosa che non è stato spiegato a lezione
- Puoi testare il tuo codice in un file separato, o de-commentando un esercizio alla volta
- Per visualizzare l'output, lancia il file HTML a cui è collegato e apri la console dagli strumenti di sviluppo del browser. 
- Utilizza dei console.log() per testare le tue variabili e/o i risultati delle espressioni che stai creando.
*/

/* ESERCIZIO 1
    Dato il seguente array, scrivi del codice per stampare ogni elemento dell'array in console.
*/
const pets = ['dog', 'cat', 'hamster', 'redfish'];

var i, pets_copia;

console.log("********** ESERCIZIO 1 **********");

for(i=0; i<pets.length; i++){
  pets_copia=pets;
  console.log("Posizione "+i+": "+pets_copia[i]);
}

/* ESERCIZIO 2
    Scrivi del codice per ordinare alfabeticamente gli elementi dell'array "pets".
*/
console.log("********** ESERCIZIO 2 **********");

var ordinaA;
ordinaA=pets_copia;
ordinaA.sort();
for(i=0; i<ordinaA.length; i++){
  console.log("Posizione "+i+": "+ordinaA[i]);
}



/* ESERCIZIO 3
    Scrivi del codice per stampare nuovamente in console gli elementi dell'array "pets", questa volta in ordine invertito.
*/
console.log("********** ESERCIZIO 3 **********");
var ordine_invertito;
ordine_invertito=ordinaA;
ordine_invertito.reverse();

for(i=0; i<ordine_invertito.length; i++){
  console.log("Posizione "+i+": "+ordine_invertito[i]);
}


/* ESERCIZIO 4
    Scrivi del codice per spostare il primo elemento dall'array "pets" in ultima posizione.
*/
console.log("********** ESERCIZIO 4 **********");
var primo_elemento;

primo_elemento=pets[0];
pets.shift();
pets.push(primo_elemento);


for(i=0; i<pets.length; i++){
  console.log("Posizione "+i+": "+pets[i]);
}



/* ESERCIZIO 5
    Dato il seguente array di oggetti, scrivi del codice per aggiungere ad ognuno di essi una proprietà "licensePlate" con valore a tua scelta.
*/
const cars = [
  {
    brand: 'Ford',
    model: 'Fiesta',
    color: 'red',
    trims: ['titanium', 'st', 'active'],
  },
  {
    brand: 'Peugeot',
    model: '208',
    color: 'blue',
    trims: ['allure', 'GT'],
  },
  {
    brand: 'Volkswagen',
    model: 'Polo',
    color: 'black',
    trims: ['life', 'style', 'r-line'],
  },
]

console.log("********** ESERCIZIO 5 **********");
for(i=0; i<cars.length; i++){
  cars[i].licensePlate="B";
  console.log(cars[i]);
}



/* ESERCIZIO 6
    Scrivi del codice per aggiungere un nuovo oggetto in ultima posizione nell'array "cars", rispettando la struttura degli altri elementi.
    Successivamente, rimuovi l'ultimo elemento della proprietà "trims" da ogni auto.
*/
console.log("********** ESERCIZIO 6 **********");
cars.push({brand: "Ferrari", model: "purosangue", color: "grey", trims: [""], licensePlate: "B"});

for(i=0; i<cars.length; i++){
  console.log(cars[i]);
}



/* ESERCIZIO 7
    Scrivi del codice per salvare il primo elemento della proprietà "trims" di ogni auto nel nuovo array "justTrims", sotto definito.
*/
console.log("********** ESERCIZIO 7 **********");
const justTrims = []
var primo_elemento;

for(i=0; i<cars.length; i++){
  primo_elemento=cars[i].trims[0];
  justTrims.push(primo_elemento);
  console.log("Posizione "+i+": "+justTrims[i]);
}

/* ESERCIZIO 8
    Cicla l'array "cars" e costruisci un if/else statament per mostrare due diversi messaggi in console. Se la prima lettera della proprietà
    "color" ha valore "b", mostra in console "Fizz". Altrimenti, mostra in console "Buzz".
*/
console.log("********** ESERCIZIO 8 **********");

var first_char;

for(i=0; i<cars.length; i++){
  first_char=cars[i].color.slice(0, 1);
  if(first_char=="b"){
    console.log("Fizz");
  }
  else{
    console.log("Buzz");
  }
}


/* ESERCIZIO 9
    Utilizza un ciclo while per stampare in console i valori del seguente array numerico fino al raggiungimento del numero 32.
*/
const numericArray = [
  6, 90, 45, 75, 84, 98, 35, 74, 31, 2, 8, 23, 100, 32, 66, 313, 321, 105,
]

console.log("********** ESERCIZIO 9 **********");

while(numericArray[i]!=32){
  console.log(numericArray[i]);
  i++;
}

/* ESERCIZIO 10
    Partendo dall'array fornito e utilizzando un costrutto switch, genera un nuovo array composto dalle posizioni di ogni carattere all'interno
    dell'alfabeto italiano.
    es. [f, b, e] --> [6, 2, 5]
*/
console.log("********** ESERCIZIO 10 **********");

const charactersArray = ['g', 'n', 'u', 'z', 'd']
var numberArray=[];
console.log(charactersArray);

for(i=0; i<charactersArray.length; i++){
  switch(charactersArray[i]){
    case "a":{
      numberArray[i]=1;
      break;
    }
    case "b":{
      numberArray[i]=2;
      break;
    }
    case "c":{
      numberArray[i]=3;
      break;
    }
    case "d":{
      numberArray[i]=4;
      break;
    }
    case "e":{
      numberArray[i]=5;
      break;
    }
    case "f":{
      numberArray[i]=6;
      break;
    }
    case "g":{
      numberArray[i]=7;
      break;
    }
    case "h":{
      numberArray[i]=8;
      break;
    }
    case "t":{
      numberArray[i]=9;
      break;
    }
    case "j":{
      numberArray[i]=10;
      break;
    }
    case "k":{
      numberArray[i]=11;
      break;
    }
    case "l":{
      numberArray[i]=12;
      break;
    }
    case "n":{
      numberArray[i]=13;
      break;
    }
    case "o":{
      numberArray[i]=14;
      break;
    }
    case "p":{
      numberArray[i]=15;
      break;
    }
    case "q":{
      numberArray[i]=16;
      break;
    }
    case "r":{
      numberArray[i]=17;
      break;
    }
    case "s":{
      numberArray[i]=18;
      break;
    }
    case "t":{
      numberArray[i]=19;
      break;
    }
    case "u":{
      numberArray[i]=20;
      break;
    }
    case "v":{
      numberArray[i]=21;
      break;
    }
    case "w":{
      numberArray[i]=22;
      break;
    }
    case "x":{
      numberArray[i]=23;
      break;
    }
    case "y":{
      numberArray[i]=24;
      break;
    }
    case "z":{
      numberArray[i]=25;
      break;
    }
  }
  console.log(numberArray[i]);
}




