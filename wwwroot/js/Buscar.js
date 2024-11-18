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
    if (pesquisa != texto) {
        document.getElementById("cards").innerHTML = "";
        texto = pesquisa;
        console.log(indice);
        switch (indice) {
            case "titulo":
                itens.filme.forEach(item => {
                    console.log(pesquisa + "==" + item.titulo);
                    if (pesquisa == item.titulo) {
                        createCards(item.titulo, item.linkCapa);
                    }
                });
                break;
            default: break;
        }



    }
}


/*

            case "artistas":
                ats = [];
                itens.filme.forEach(pgFilme => {
                    pgFilme.artistas.forEach(item => {
                        ats.push(item);
                    });
                });
                ats = [...new Set(ats)];
                ats.forEach(item => {
                    createSubs(subs, item);
                });
                break;
            case "generos":
                ats = [];
                itens.filme.forEach(pgFilme => {
                    pgFilme.generos.forEach(item => {
                        ats.push(item);
                    });
                });
                ats = [...new Set(ats)];
                ats.forEach(item => {
                    createSubs(subs, item);
                });
                break;
            case "nome":
                itens.artista.forEach(item => {
                    createSubs(subs, item.nome);
                });
                break;
            case "paisNascimento":
                itens.artista.forEach(item => {
                    ats.push(item.paisNascimento);
                });
                ats = [...new Set(ats)];
                ats.forEach(item => {
                    createSubs(subs, item);
                });

*/