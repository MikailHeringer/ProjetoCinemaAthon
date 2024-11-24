const filmes = [
    { titulo: "Paraíso Vermelho" },
    { titulo: "Aventura no Azul" },
    { titulo: "Vermelho Escarlate" }
];

// Configuração do Fuse.js
const options = {
    includeScore: true,
    threshold: 0.4,
    keys: ["titulo"]
};

const fuse = new Fuse(itens.filme, options);

// Pesquisa
const pesquisa = "Vrmelho";
const resultados = fuse.search(pesquisa);

console.log(resultados.map(result => result.item));