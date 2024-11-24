// Configuração do Fuse.js
const options = {
    includeScore: true,
    threshold: 0.4,
    keys: ["titulo"]
};

const fuse = new Fuse(itens.filme, options);


const resultados = fuse.search(pesquisa);

console.log(resultados.map(result => result.item));