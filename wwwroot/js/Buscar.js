function curlName(nome) {
    if (nome.length > 19) {
        return nome.substr(0, 16) + "...";
    } else {
        return nome;
    }
}

function createCards(titulo, image) {
    let col = document.createElement("div");
    col.setAttribute("class", "col-md-2 divName showDetails apareceu");

    let card = document.createElement("div");
    card.setAttribute("class", "card");
    card.style.width = "14rem";

    let cardBody = document.createElement("div");
    cardBody.setAttribute("class", "card-body");

    let p = document.createElement("p");
    p.setAttribute("class", "card-text");
    p.innerHTML = curlName(titulo);

    let img = document.createElement("img");
    img.src = image;

    cardBody.appendChild(p);
    card.appendChild(cardBody);
    card.appendChild(img);
    col.appendChild(card);

    return col;
}


function search(pesquisa) {
    if (pesquisa === "") {
        texto = "";
        efeitoRemover(() => {
            document.getElementById("cards").innerHTML = "";
        });
    }

    if (pesquisa !== texto) {
        texto = pesquisa;

        const fragDOM = document.createDocumentFragment();
        const cardsGrup = document.getElementById("cards");
        cardsGrup.innerHTML = "";
        
        

        switch (indice) {
            case "titulo":
                itens.filme.forEach(item => {
                    if (compare(pesquisa, item.titulo)) {
                        fragDOM.appendChild(createCards(item.titulo, item.linkCapa));
                    }
                });
                break;

            case "artistas":
                itens.filme.forEach(pgFilme => {
                    if (pgFilme.artistas.some(artista => compare(pesquisa, artista))) {
                        fragDOM.appendChild(createCards(pgFilme.titulo, pgFilme.linkCapa));
                    }
                });
                break;

            case "generos":
                itens.filme.forEach(pgFilme => {
                    if (pgFilme.generos.some(genero => compare(pesquisa, genero))) {
                        fragDOM.appendChild(createCards(pgFilme.titulo, pgFilme.linkCapa));
                    }
                });
                break;

            case "nome":
                itens.artista.forEach(item => {
                    if (compare(pesquisa, item.nome)) {
                        fragDOM.appendChild(createCards(item.nome, item.fotoArtista));
                    }
                });
                break;

            case "paisNascimento":
                itens.artista.forEach(item => {
                    if (compare(pesquisa, item.paisNascimento)) {
                        fragDOM.appendChild(createCards(item.nome, item.fotoArtista));
                    }
                });
                break;

            default:
                break;
        }

            cardsGrup.appendChild(fragDOM);
    }
}

function compare(pesquisa, nome) {
    return nome.toLowerCase().startsWith(pesquisa.toLowerCase());
}

function atrasarBusca(func, wait) {
    let timeout;
    return function (...args) {
        clearTimeout(timeout);
        timeout = setTimeout(() => func.apply(this, args), wait);
    };
}

const tempoBusca = atrasarBusca(search, 300);

document.getElementById("inputSearch").addEventListener("input", (e) => {
    tempoBusca(e.target.value);
});



function efeitoRemover(callback) {
    const cards = document.querySelectorAll("#cards .col-md-2");

    cards.forEach(card => {
        card.classList.add("sumiu");
    });

    setTimeout(() => {
        callback();
    }, 500);
}