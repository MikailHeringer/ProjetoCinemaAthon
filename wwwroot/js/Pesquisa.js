function setType(tipo) {
    let msg = "Digite o nome do filme";
    switch (tipo) {
        case 1:
            msg = "Digite o nome do filme";
            break;
        case 2:
            msg = "Digite o nome do Artista";
            break;
        case 3:
            msg = "Digite o gênero do filme";
            break;
        case 4:
            msg = "Digite o país do filme";
            break;
    }

    document.getElementById("inputSearch").setAttribute("placeholder", msg);
}