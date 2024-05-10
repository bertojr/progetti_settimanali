// API https://striveschool-api.herokuapp.com/api/product/
// Api Key eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJfaWQiOiI2NjNkZDJmODgxODQ0MjAwMTUzNzU4N2IiLCJpYXQiOjE3MTUzMjc3MzYsImV4cCI6MTcxNjUzNzMzNn0.FQHc9irMiDmzXzQNQCHhnvCH4ZDO4PlsVcXz5XIsots

class Article {
  constructor(_name, _description, _brand, _imageUrl, _price) {
    this.name = _name;
    this.description = _description;
    this.brand = _brand;
    this.imageUrl = _imageUrl;
    this.price = _price;
  }
}
let apiUrl = "https://striveschool-api.herokuapp.com/api/product/";
const apiKey =
  "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJfaWQiOiI2NjNkZDJmODgxODQ0MjAwMTUzNzU4N2IiLCJpYXQiOjE3MTUzMjc3MzYsImV4cCI6MTcxNjUzNzMzNn0.FQHc9irMiDmzXzQNQCHhnvCH4ZDO4PlsVcXz5XIsots";
const addressBarContent = new URLSearchParams(location.search);
const articleId = addressBarContent.get("id");
console.log(articleId);
let methodToUse;

// prendo il riferimento al form
const submitEvent = document.getElementById("submit-event");

// prendo il riferimento a btn-submit
const btnSubmit = document.getElementById("btn-submit");

// prendo i riferimenti agli input del form
const nameInput = document.getElementById("name");
const descriptionInput = document.getElementById("description");
const urlImageInput = document.getElementById("url-image");
const brandInput = document.getElementById("brand");
const priceInput = document.getElementById("price");

const createEmodifyArticle = function () {
  const articleFromForm = new Article(
    nameInput.value,
    descriptionInput.value,
    brandInput.value,
    urlImageInput.value,
    priceInput.value
  );
  if (!articleId) {
    methodToUse = "POST";
  } else {
    apiUrl = apiUrl + articleId;
    methodToUse = "PUT";
  }

  fetch(apiUrl, {
    method: methodToUse,
    body: JSON.stringify(articleFromForm),
    headers: {
      "Content-type": "application/json",
      Authorization: "Bearer " + apiKey,
    },
  })
    .then((response) => {
      if (response.ok) {
        if (articleId) {
          alert(`Articolo modificato`);
          location.assign("./index.html");
        } else {
          let result = confirm(
            `Articolo creato! 
            Vuoi creare un altro articolo?`
          );
          if (result) {
            location.assign("./backoffice.html");
          } else {
            location.assign("./index.html");
          }
        }
      } else {
        throw new Error("Il server non è stato raggiunto");
      }
    })
    .catch((err) => {
      console.log("ERRORE", err);
    });
};

const getArticleWithId = function () {
  fetch(apiUrl + articleId, {
    headers: {
      Authorization: "Bearer " + apiKey,
    },
  })
    .then((response) => {
      if (response.ok) {
        return response.json();
      } else {
        throw new Error("Il server non è stato raggiunto");
      }
    })
    .then((art) => {
      console.log(art);
      nameInput.value = art.name;
      descriptionInput.value = art.description;
      urlImageInput.value = art.imageUrl;
      brandInput.value = art.brand;
      priceInput.value = art.price;
    })
    .catch((err) => {
      console.log("ERRORE", err);
    });
};
if (articleId) {
  getArticleWithId();
  btnSubmit.innerHTML = "Modifica";
}
submitEvent.addEventListener("submit", function (e) {
  e.preventDefault();
  createEmodifyArticle();
});
