// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    var multipleCancelButton = new Choices('.choicesMultipleGenero', {
        removeItemButton: true,
        placeholderValue: "Selecione os gêneros",
        noResultsText: "Sem resultados encontrados",
        noChoicesText: "Nenhuma opção disponível",
        itemSelectText: "Pressione para selecionar"
    });
});


$(document).ready(function () {
    var multipleCancelButton = new Choices('.choicesMultipleAtor', {
        removeItemButton: true,
        placeholderValue: "Selecione os Atores",
        noResultsText: "Sem resultados encontrados",
        noChoicesText: "Nenhuma opção disponível",
        itemSelectText: "Pressione para selecionar"
    });
});

function showDetalhes(id) {
    let url = document.location.href;
    document.location.href = url + "RegistrarFilmes/Details/" + id;
}

const elements = document.querySelectorAll(".showDetails");
const detalhes = document.getElementById("detalhes");

elements.forEach(element => {
    element.addEventListener("mousemove", (e) => {
        detalhes.classList.remove("displayStyleOut");
        detalhes.classList.add("text-center", "displayStyle");
        detalhes.style.top = (e['pageY'] - 35) + "px";
        detalhes.style.left = (e['pageX'] + 10) + "px";
    });

    element.addEventListener("mouseout", () => {
        detalhes.classList.remove("text-center", "displayStyle");
        detalhes.classList.add("displayStyleOut");
        detalhes.style.top = "1px";
        detalhes.style.left = "1px";
    });
});