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
const apiUrl = "https://striveschool-api.herokuapp.com/api/product/";
const apiKey =
  "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJfaWQiOiI2NjNkZDJmODgxODQ0MjAwMTUzNzU4N2IiLCJpYXQiOjE3MTUzMjc3MzYsImV4cCI6MTcxNjUzNzMzNn0.FQHc9irMiDmzXzQNQCHhnvCH4ZDO4PlsVcXz5XIsots";
const addressBarContent = new URLSearchParams(location.search);
const articleId = addressBarContent.get("id");
console.log(articleId);

// prendo il riferimento al form
const submitEvent = document.getElementById("submit-event");

const createArticle = function () {
  // prendo i riferimetni agli input del form
  const nameInput = document.getElementById("name");
  const descriptionInput = document.getElementById("description");
  const urlImageInput = document.getElementById("url-image");
  const brandInput = document.getElementById("brand");
  const priceInput = document.getElementById("price");

  const articleFromForm = new Article(
    nameInput.value,
    descriptionInput.value,
    brandInput.value,
    urlImageInput.value,
    priceInput.value
  );
  fetch(apiUrl, {
    method: "POST",
    body: JSON.stringify(articleFromForm),
    headers: {
      "Content-type": "application/json",
      Authorization: "Bearer " + apiKey,
    },
  })
    .then((response) => {
      if (response.ok) {
        console.log("Articolo creato");
      } else {
        throw new Error("Il server non è stato raggiunto");
      }
    })
    .catch((err) => {
      console.log("ERRORE", err);
    });
};

submitEvent.addEventListener("submit", function (e) {
  e.preventDefault();
  createArticle();
});
