function createInput(nome, id, inputValue="") {
    document.getElementById("rowPersons").style.display = "flex";
    let divRow = document.createElement("div");
    divRow.setAttribute("class", "row");
    divRow.setAttribute("style", "margin-top: 5px");
    divRow.setAttribute("id", id);

    let divName = document.createElement("div");
    divName.setAttribute("class", "col-md-5 align-content-center");
    divName.innerHTML = nome;

    let divInput = document.createElement("div");
    divInput.setAttribute("class", "col-md-7");

    let input = document.createElement("input");
    input.value = inputValue;
    input.setAttribute("class", "form-control");
    input.setAttribute("placeholder", "Nome do personagem");
    input.setAttribute("name", "CadastroPersonagem");

    divInput.appendChild(input);

    divRow.appendChild(divName);
    divRow.appendChild(divInput);

    document.getElementsByClassName("personagens")[0].appendChild(divRow);
}
function removeInput(id) {
    let pers = document.getElementsByClassName("personagens")[0].children.length;
    if (pers <= 1) {
        document.getElementById("rowPersons").style.display = "none";
    }
    document.getElementById(id).remove();
}