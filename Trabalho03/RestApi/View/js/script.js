var registroNovo = true;
var idProduto = 0;

function Inserir(){
    var xhttp = new XMLHttpRequest();

    xhttp.onreadystatechange = function() {
        if (this.readyState == 4 && this.status == 200) {
            var json = this.responseText;
            var resposta = JSON.parse(json);
            var dados = resposta.data;

            var produtoTeste = dados;

            console.log(produtoTeste);
            console.log(resposta.status);
        }
      };
    
    var produto = { nome:"", preco:"" };

    produto.nome = $("#nome").val();
    produto.preco = $("#preco").val();
    
    xhttp.open("POST", "http://localhost:5000/api/produto", true);
    xhttp.setRequestHeader("Content-Type", "application/json");
    xhttp.send(JSON.stringify(produto));   
};

function Listar(){
    var xhttp = new XMLHttpRequest();
    
    xhttp.onreadystatechange = function() {
        if (this.readyState == 4 && this.status == 200) {
            var json = this.responseText;
            var resposta = JSON.parse(json);
            var dados = resposta.data;

            console.log(resposta.status);

            var corpo = $("#tabela-produtos tbody");

            $("#tabela-produtos tbody").children().remove();

            for(var i = 0; i < dados.length; i++){
                var produtoTeste = dados[i];                

                var linha = $("<tr>");
                
                var td = $("<td>").text(produtoTeste.id);
                var td1 = $("<td>").text(produtoTeste.nome);
                var td2 = $("<td>").text(produtoTeste.preco);                
                                
                var td3 = $("<td>");
                var a = $("<a>").attr("href", "#")
                                .attr("onclick", "PreencherFormulario(this)")
                                .addClass("espaco");
                a.text("Editar");                

                var a1 = $("<a>").attr("href", "#")
                                 .attr("onclick", "Excluir(this)");
                a1.text("Excluir");

                td3.append(a,a1);

                linha.append(td,td1,td2,td3);

                corpo.append(linha);
            }
        }
      };
    
    xhttp.open("GET", "http://localhost:5000/api/usuario/Get", true);
    xhttp.setRequestHeader("Content-Type", "application/json");    
    xhttp.send();   
};

function Excluir(a){
    if(confirm("Tem certeza que quer excluir o registro?")){
        var xhttp = new XMLHttpRequest();

        xhttp.onreadystatechange = function() {
            if (this.readyState == 4 && this.status == 200) {
                var json = this.responseText;
                var resposta = JSON.parse(json);
                var dados = resposta.data;

                var produtoTeste = dados;

                console.log(produtoTeste);
                console.log(resposta.status);

                Listar();
            }
        };
                
        var linha = a.parentElement.parentElement;
        
        var tdId = linha.children[0]; 
        
        var id = tdId.textContent;

        var url = "http://localhost:5000/api/produto";
        url += id;

        xhttp.open("DELETE", url, true);
        xhttp.setRequestHeader("Content-Type", "application/json");
        xhttp.send();   
    }
};

function Alterar(){
    var xhttp = new XMLHttpRequest();

    xhttp.onreadystatechange = function() {
        if (this.readyState == 4 && this.status == 200) {
            var json = this.responseText;
            var resposta = JSON.parse(json);
            var dados = resposta.data;

            var produtoTeste = dados;

            console.log(produtoTeste);
            console.log(resposta.status);
        }
      };    

    var produto = { nome:"", preco:"" };

    produto.nome = $("#nome").val();
    produto.preco = $("#preco").val();
    
    var url = "http://localhost:5000/api/produto";
    url += idProduto;

    xhttp.open("PUT", url, true);
    xhttp.setRequestHeader("Content-Type", "application/json");
    xhttp.send(JSON.stringify(produto));   
};

function PreencherFormulario(a){
    var linha = a.parentElement.parentElement;
    
    var tdId = linha.children[0]; 
      
    idProduto = tdId.textContent;

    var tr = linha.children;    

    $("#nome").val(tr[1].textContent);
    $("#preco").val(tr[2].textContent);
    
    registroNovo = false;
}

function Enviar(){
    if(formValido()){
        
        if(registroNovo){
            Inserir();
        }else{
            Alterar();
        }

        registroNovo = true;

        LimparForm();
        Listar();
    }
}

$(document).ready(function(){
    Listar();
});

function LimparForm(){
    $("#nome").val("");
    $("#preco").val("");    
}

function formValido(){
    var inputsCadastro = $("#cadastro input");

    var retorno = true;

    inputsCadastro.each(function(index, element){
        if (!this.checkValidity()) {
            //alert($(this).prop('name') + ' is not valid');
            retorno = false;
        }          
    });

    return retorno;
}