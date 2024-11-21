function curlName(nome) {
    if (nome.length > 19) {
        return nome.substr(0, 16) + "...";
    } else {
        return nome;
    }
}

function createCards(titulo, image) {
    let cards = document.getElementById("cards");

    let col = document.createElement("div");
    col.setAttribute("class", "col-md-2 divName showDetails");

    let card = document.createElement("div");
    card.setAttribute("class", "card");
    card.style.width = "14rem";

    let cardBody = document.createElement("div");
    cardBody.setAttribute("class", "card-body");

    let p = document.createElement("p");
    p.setAttribute("class", "card-text");
    p.innerHTML = curlName(titulo)

    let img = document.createElement("img");
    img.src = image;

    cardBody.appendChild(p);
    card.appendChild(cardBody);
    card.appendChild(img);
    col.appendChild(card);

    cards.appendChild(col);
}

function search(pesquisa) {
    if (pesquisa == "") {
        texto = "";
        document.getElementById("cards").innerHTML = "";
    }
    if (pesquisa != texto) {
        document.getElementById("cards").innerHTML = "";
        texto = pesquisa;


        switch (indice) {

            // Pesquisa por filme

            case "titulo":
                itens.filme.forEach(item => {
                    if (compare(pesquisa, item.titulo)) {
                        createCards(item.titulo, item.linkCapa);
                    }
                });
                break;

            case "artistas":
                itens.filme.forEach(pgFilme => {
                    let find = false;
                    pgFilme.artistas.forEach(item => {
                        if (compare(pesquisa, item)) {

                            find = true;
                        }
                    });
                    if (find) {
                        createCards(pgFilme.titulo, pgFilme.linkCapa);
                    }
                });
                break;

            case "generos":
                itens.filme.forEach(pgFilme => {
                    let find = false;
                    pgFilme.generos.forEach(item => {
                        if (compare(pesquisa, item)) {
                            find = true;
                        }
                    });
                    if (find) {
                        createCards(pgFilme.titulo, pgFilme.linkCapa);
                    }
                });
                break;

            // Pesquisa por artista

            case "nome":
                itens.artista.forEach(item => {
                    if (compare(pesquisa, item.nome)) {
                        createCards(item.nome, item.fotoArtista);
                    }
                });
                break;

            case "paisNascimento":
                itens.artista.forEach(item => {
                    if (compare(pesquisa, item.paisNascimento)) {
                        createCards(item.nome, item.fotoArtista);
                    }
                });
                break;
            default: break;
        }
    }
}

function compare(pesquisa, nome) {
    pesquisa = pesquisa.toLowerCase();
    nome = nome.toLowerCase();
    return (pesquisa === nome.substr(0, pesquisa.length)) ? true : false;
}