function curlName(nome) {
    if (nome.length > 19) {
        return nome.substr(0, 16) + "...";
    } else {
        return nome;
    }
}

function createCards(titulo, image, id, cat = 1) {
    let col = document.createElement("div");
    col.setAttribute("class", "col-md-2 divName showDetails");
    col.setAttribute("onclick", "showDetalhes("+id+","+cat+")");

    let card = document.createElement("div");
    card.setAttribute("class", "card");
    card.style.width = "14rem";

    let cardBody = document.createElement("div");
    cardBody.setAttribute("class", "card-body");

    let p = document.createElement("p");
    p.setAttribute("class", "card-text");
    p.innerHTML = curlName(titulo);

    let img = document.createElement("img");
    img.style.width = "222px";
    img.style.height = "333px";
    img.src = image;

    cardBody.appendChild(p);
    card.appendChild(cardBody);
    card.appendChild(img);
    col.appendChild(card);

    return col;
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

const opcoes = {
    includeScore: true,
    threshold: 0.3,
    keys: []
};

function searchEngine(pesquisa, data, key = "titulo") {
    switch (key) {
        case "artistas": opcoes.threshold = 0.2;
            break;
        case "generos": opcoes.threshold = 0;
            break;
        case "nome": opcoes.threshold = 0.2;
            break;
        case "paisNascimento": opcoes.threshold = 0.2;
            break;
        default : break;
    }

    opcoes.keys = [key];
    let fuse = new Fuse(data, opcoes);
    return fuse.search(pesquisa)
}

function search(pesquisa) {
    if (pesquisa !== texto) {
        texto = pesquisa;

        let data = (modelo == "filme") ? itens.filme : itens.artista;

        const fragDOM = document.createDocumentFragment();
        const cardsGrup = document.getElementById("cards");
        cardsGrup.innerHTML = "";
        res = searchEngine(pesquisa, data, categoria);
        switch (modelo) {
            case "filme":
                res.forEach(filtro => {
                        fragDOM.appendChild(createCards(filtro.item.titulo, filtro.item.linkCapa, filtro.item.id));
                });
                break;

            case "artista":
                res.forEach(filtro => {
                        fragDOM.appendChild(createCards(filtro.item.nome, filtro.item.fotoArtista, filtro.item.id, 2));
                });
                break;

            default:
                break;
        }

        cardsGrup.appendChild(fragDOM);
        showLink();

        
    }
}