// setType(Categoria, Indice_Procura, id)

let modelo = "filme", indice = "titulo", texto = "";

function setType(categoria, procura, id) {
    modelo = categoria;
    indice = procura;

    let msg = "Digite o nome do filme";
    switch (id) {
        case 1:
            msg = "Digite o nome do filme";
            setSubs();
            break;
        case 2:
            msg = "Digite o nome do artista";
            setSubs("artistas");
            break;
        case 3:
            msg = "Digite o gênero do filme";
            setSubs("generos");
            break;
        case 4:
            msg = "Digite o nome do artista";
            setSubs("nome");
            break;
        case 5:
            msg = "Digite o nome do pais";
            setSubs("paisNascimento");
            break;
    }

    let impSearch = document.getElementById("inputSearch");
    impSearch.setAttribute("placeholder", msg);
    impSearch.value = "";
}

function setSubs(type = "titulo") {
    let subs = document.getElementById('subs');
    subs.innerHTML = "";
    let ats = []
    switch (type) {
        case "titulo":
            itens.filme.forEach(item => {
                    createSubs(subs, item.titulo);
                });
            break;







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
        break;
        default: break;
    }
        
}


function createSubs(subs, val){
    let sub = document.createElement("option")
    sub.value = val;
    subs.appendChild(sub);
}