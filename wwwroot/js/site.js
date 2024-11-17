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