// API https://striveschool-api.herokuapp.com/api/product/
// Api Key eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJfaWQiOiI2NjNkZDJmODgxODQ0MjAwMTUzNzU4N2IiLCJpYXQiOjE3MTUzMjc3MzYsImV4cCI6MTcxNjUzNzMzNn0.FQHc9irMiDmzXzQNQCHhnvCH4ZDO4PlsVcXz5XIsots

const apiUrl = "https://striveschool-api.herokuapp.com/api/product/";
const apiKey =
  "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJfaWQiOiI2NjNkZDJmODgxODQ0MjAwMTUzNzU4N2IiLCJpYXQiOjE3MTUzMjc3MzYsImV4cCI6MTcxNjUzNzMzNn0.FQHc9irMiDmzXzQNQCHhnvCH4ZDO4PlsVcXz5XIsots";

// funzione per ricevere gli elementi dal server
const getElements = function () {
  fetch(apiUrl, {
    headers: {
      Authorization: "Bearer " + apiKey,
    },
  })
    .then((response) => {
      if (response.ok) {
        console.log("Server raggiunto");
        return response.json();
      } else {
        throw new Error("Il server non è stato raggiunto");
      }
    })
    .then((array) => {
      console.log(array);
      generateArticles(array);
    })
    .catch((err) => {
      console.log("ERRORE", err);
    });
};

const generateArticles = function (arrayArticles) {
  // prendo il riferimento a row-articles
  const rowArticles = document.getElementById("row-articles");
  arrayArticles.forEach((article) => {
    const newCol = document.createElement("col");
    newCol.classList.add("col", "mb-4");
    newCol.innerHTML = `
        <a href="./details.html?id=${article._id}" class="text-white text-decoration-none">
            <div class="card h-100 border-0">
                <div class="d-flex justify-content-center">
                    <img src="${article.imageUrl}" class="card-img-top w-75" alt="Foto articolo">
                </div>
                <div class="card-body">
                    <p class="card-title">${article.name}</p>
                    <h6 class="card-text"><b>${article.price} €</b></h6>
                    <button type="button" class="btn border text-danger bg-danger-hover text-light-hover">Aggiungi al carrello</button>
                </div>
            </div>
        </a>
        `;
    rowArticles.appendChild(newCol);
  });
};

getElements();
