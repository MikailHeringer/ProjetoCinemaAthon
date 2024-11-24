// setType(Categoria, Indice_Procura, id)

let modelo = "filme", categoria = "titulo", texto = "";

function setType(mod, procura, id) {
    modelo = mod;
    categoria = procura;
    let msg = "Digite o nome do filme";
    switch (id) {
        case 1:
            msg = "Digite o nome do filme";
            break;
        case 2:
            msg = "Digite o nome do artista";
            break;
        case 3:
            msg = "Digite o gênero do filme";
            break;
        case 4:
            msg = "Digite o nome do artista";
            break;
        case 5:
            msg = "Digite o nome do pais";
            break;
        default: break;
    }

    texto = "";
    document.getElementById("cards").innerHTML = "";

    let impSearch = document.getElementById("inputSearch");
    impSearch.setAttribute("placeholder", msg);
    impSearch.value = "";

}