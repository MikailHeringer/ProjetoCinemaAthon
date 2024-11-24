async function searchPhoto(nome, tipo = "person") {
    return fetch("/Api/BuscarImagens?query=" + nome + "&type="+tipo)
        .then(response => response.json())
        .then(data => {
            return data;
        })
        .catch(error => {
            return false;
        });
}