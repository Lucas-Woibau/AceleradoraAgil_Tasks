var livros = [
    {
        "Titulo": "Como fazer sentido e bater o martelo",
        "Autor": "Alexandro Aolchique",
        "Ano": "2017",
        "Status": 1,
        "Emprestado": ""
    },
    {
        "Titulo": "Sejamos todos feministas",
        "Autor": "Chimamanda Ngozi Adichie",
        "Ano": "2015",
        "Status": 1,
        "Emprestado": ""
    },
    {
        "Titulo": "Basquete 101",
        "Autor": "Hortência Marcari",
        "Ano": "2010",
        "Status": 1,
        "Emprestado": ""
    }
];

function retirar() {
    var pai = document.getElementById('conteudo');
    var l = "";
    var count = 1;
    livros.forEach(lv => {
        l += `<div id="livro0${count}">
            <img class="livro" src="livros/Livro0${count}.png">
            <p>${lv.Titulo}<br>Autor: ${lv.Autor}<br>Ano: ${lv.Ano} </p>
        </div>`;
        count += 1;
    })
    pai.innerHTML = `<div id="livros">
        ${l}
    </div>`
}

function devolver() {
    var pai = document.getElementById('conteudo');
    pai.innerHTML = `<div id="form_area">
        <div id="formulario">
            <fieldset>
                <legend><b>FORMULÁRIO</b></legend>
                <br>
                <label>TÍTULO:</label><input class="campo_titulo" type="text" placeholder="Digite o título"><br>
                <br><br>
                <label>AUTOR:</label><input class="campo_autor" type="text" placeholder="Digite o nome do autor"><br>
                <br><br>
                <label>ANO:</label><input class="campo_ano" type="text" placeholder="Digite o ano do livro"><br>
                <br>
                <input class="doar_livro" type="submit" value="DOAR LIVRO"><br>
            </fieldset>
        </div>
    </div>`;
}

function doar() {
    var pai = document.getElementById('conteudo');
    pai.innerHTML = `<div id="form_area">
        <form id="formulario" onsubmit="return doarLivro()">
            <fieldset>
                <legend><b>FORMULÁRIO</b></legend>
                <br>
                <label>TÍTULO:</label><input id="doarTitulo" class="campo_titulo" type="text" placeholder="Digite o título"><br>
                <br><br>
                <label>AUTOR:</label><input id="doarAutor" class="campo_autor" type="text" placeholder="Digite o nome do autor"><br>
                <br><br>
                <label>ANO:</label><input id="doarAno" class="campo_ano" type="text" placeholder="Digite o ano do livro"><br>
                <br>
                <input class="doar_livro" type="submit" value="DOAR LIVRO"><br>
            </fieldset>
        </form>
    </div>`
}

function doarLivro() {
    var titulo = document.getElementById("doarTitulo").value
    var autor = document.getElementById("doarAutor").value
    var ano = document.getElementById("doarAno").value
    var lv = {
        "Titulo": titulo,
        "Autor": autor,
        "Ano": ano,
        "Status": 1,
        "Emprestado": ""
    }
    livros.push(lv);
    document.getElementById('conteudo').innerHTML = "";
    return false;
}
