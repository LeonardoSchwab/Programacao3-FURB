var registroNovo = true;
var idCarro = 0;

function Inserir(){
    var xhttp = new XMLHttpRequest();

    xhttp.onreadystatechange = function() {
        if (this.readyState == 4 && this.status == 200) {
            var json = this.responseText;
            var resposta = JSON.parse(json);
            var dados = resposta.data;

            var carroTeste = dados;

            console.log(carroTeste);
            console.log(resposta.status);
        }
      };
    
    var carro = { nome:"", marca:"", modelo:"" };

    carro.nome = $("#nome").val();
    carro.marca = $("#marca").val();
    carro.modelo = $("#modelo").val();
    
    xhttp.open("POST", "http://localhost:5000/api/carro", true);
    xhttp.setRequestHeader("Content-Type", "application/json");
    xhttp.send(JSON.stringify(carro));   
};

function Listar(){
    var xhttp = new XMLHttpRequest();
    
    xhttp.onreadystatechange = function() {
        if (this.readyState == 4 && this.status == 200) {
            var json = this.responseText;
            var resposta = JSON.parse(json);
            var dados = resposta.data;

            console.log(resposta.status);

            var corpo = $("#tabela-carros tbody");

            $("#tabela-carros tbody").children().remove();

            for(var i = 0; i < dados.length; i++){
                var carroTeste = dados[i];                

                var linha = $("<tr>");
                
                var td = $("<td>").text(carroTeste.id);
                var td1 = $("<td>").text(carroTeste.nome);
                var td2 = $("<td>").text(carroTeste.marca);                
                var td3 = $("<td>").text(carroTeste.modelo);
                                
                var td4 = $("<td>");
                var a = $("<a>").attr("href", "#")
                                .attr("onclick", "PreencherFormulario(this)")
                                .addClass("espaco");
                a.text("Editar");                

                var a1 = $("<a>").attr("href", "#")
                                 .attr("onclick", "Excluir(this)");
                a1.text("Excluir");

                td4.append(a,a1);

                linha.append(td,td1,td2,td3,td4);

                corpo.append(linha);
            }
        }
      };
    
    xhttp.open("GET", "http://localhost:5000/api/carro", true);
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

                var carroTeste = dados;

                console.log(carroTeste);
                console.log(resposta.status);

                Listar();
            }
        };
                
        var linha = a.parentElement.parentElement;
        
        var tdId = linha.children[0]; 
        
        var id = tdId.textContent;

        var url = "http://localhost:5000/api/carro";
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

            var carroTeste = dados;

            console.log(carroTeste);
            console.log(resposta.status);
        }
      };    

    var carro = { nome:"", preco:"" };

    carro.nome = $("#nome").val();
    carro.marca = $("#marca").val();
    carro.modelo = $("#modelo").val();
    
    var url = "http://localhost:5000/api/carro";
    url += idCarro;

    xhttp.open("PUT", url, true);
    xhttp.setRequestHeader("Content-Type", "application/json");
    xhttp.send(JSON.stringify(carro));   
};

function PreencherFormulario(a){
    var linha = a.parentElement.parentElement;
    
    var tdId = linha.children[0]; 
      
    idCarro = tdId.textContent;

    var tr = linha.children;    

    $("#nome").val(tr[1].textContent);
    $("#marca").val(tr[2].textContent);
    $("#modelo").val(tr[3].textContent);
    
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
    $("#marca").val("");    
    $("#modelo").val("");
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