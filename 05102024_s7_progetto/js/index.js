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
    newCol.classList.add("col");
    newCol.innerHTML = `
        <a href="./details.html?id=${article._id}" class="text-dark text-decoration-none ">
            <div class="card">
                <img src="${article.imageUrl}" class="card-img-top" alt="Foto articolo">
                <div class="card-body">
                    <p class="card-title">${article.name}</p>
                    <h6 class="card-text"><b>${article.price} €</b></h6>
                    <a href="#" class="btn btn-primary">Aggiungi al carrello</a>
                </div>
            </div>
        </a>
        `;
    rowArticles.appendChild(newCol);
  });
};

getElements();
