/*Questão 3 início*/
var array03 = ["1","2","3"];

var array = array03;

var domMain = document.getElementById("main");

var lista = document.createElement("ul");

domMain.appendChild(lista);

var liLista = document.createElement("li")
lista.appendChild(liLista);
liLista.innerHTML = "Número".bold();

lista.style.fontFamily = "Arial";
lista.style.fontSize = "16px";
lista.style.color = "blue";

var ulLista = document.createElement("ul");
liLista.appendChild(ulLista);

array.forEach(PreencheLista);

function PreencheLista(item, index, arr){
    var li = document.createElement("li"); 
    li.innerText = item;
    ulLista.appendChild(li);
}
/*Questão 3 fim*/

/*Questão 4 início*/
var obj1 = {titulo : "Homem de Ferro", ano : "2017", genero : "Ação"};
var obj2 = {titulo : "Homem de Ferro 2", ano : "2018", genero : "Ação"};
var obj3 = {titulo : "Homem de Ferro 3", ano : "2019", genero : "Ação"};

var arrayObj = [obj1, obj2, obj3];

var listaFilmes = document.createElement("ul");
domMain.appendChild(listaFilmes);

listaFilmes.className = "textoFilme";

var liFilmes = document.createElement("li");
listaFilmes.appendChild(liFilmes);
liFilmes.innerText = "Filmes";

arrayObj.forEach(PreencheFilmes);

function PreencheFilmes(item, index, arr){
    var ul = document.createElement("ul");
    var li = document.createElement("li");
    li.innerText = "Título: " + item.titulo + " ano: " + item.ano + " gênero: " + item.genero;
    ul.appendChild(li);
     
    liFilmes.appendChild(ul); 
}
/*Questão 4 fim*/
