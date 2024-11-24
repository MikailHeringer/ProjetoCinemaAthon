// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



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