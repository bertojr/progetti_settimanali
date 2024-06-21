const apiUrl = "https://striveschool-api.herokuapp.com/api/product/";
const apiKey =
  "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJfaWQiOiI2NjNkZDJmODgxODQ0MjAwMTUzNzU4N2IiLCJpYXQiOjE3MTUzMjc3MzYsImV4cCI6MTcxNjUzNzMzNn0.FQHc9irMiDmzXzQNQCHhnvCH4ZDO4PlsVcXz5XIsots";
const addressBarContent = new URLSearchParams(location.search);
const articleId = addressBarContent.get("id");
console.log(articleId);

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
      generateArticle(art);
    })
    .catch((err) => {
      console.log("ERRORE", err);
    });
};

const generateArticle = function (article) {
  const col = document.getElementById("col-article");
  col.innerHTML = `
            <div class="col-2 me-5 ">
                <img src="${article.imageUrl}" class="card-img-top" alt="Foto articolo">
            </div>
            <div class="col-10">
                <div>
                    <p class="card-title">${article.name}</p>
                    <h3>Descrizione</h3>
                    <p class="card-title">${article.description}</p>
                    <h6 class="card-text mb-4">Prezzo: <b>${article.price} €</b></h6>
                </div
                <div class="d-flex">
                    <a href="#" class="btn btn-primary">Aggiungi al carrello</a>
                    <a href="./backoffice.html?id=${article._id}" class="btn btn-primary">MODIFICA</a>
                    <a href="#" class="btn btn-primary" onclick="deleteArticle()">ELIMINA</a>
                </div>
            </div>
            
    `;
};

const deleteArticle = function () {
  fetch(apiUrl + articleId, {
    method: "DELETE",
    headers: {
      Authorization: "Bearer " + apiKey,
    },
  })
    .then((response) => {
      if (response.ok) {
        alert("ARTICOLO ELIMINATO");
        location.assign("./index.html");
      } else {
        throw new Error("Il server non è stato raggiunto");
      }
    })
    .then((art) => {
      console.log(art);
      generateArticle(art);
    })
    .catch((err) => {
      console.log("ERRORE", err);
    });
};

getArticleWithId();
