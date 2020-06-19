var registroNovo = true;
var idEmployee = 0;

function Inserir(){
    var xhttp = new XMLHttpRequest();

    xhttp.onreadystatechange = function() {
        if (this.readyState == 4 && this.status == 200) {
            var json = this.responseText;
            var resposta = JSON.parse(json);
            var dados = resposta.data;

            var employeeTeste = dados;

            console.log(employeeTeste);
            console.log(resposta.status);
        }
      };
    
    var employee = { name:"", salary:"", age:"", profile_image:"" };

    employee.name = $("#nome").val();
    employee.age = $("#idade").val();
    employee.salary = $("#salario").val();
    employee.profile_image = $("#avatar").val();

    xhttp.open("POST", "http://rest-api-employees.jmborges.site/api/v1/create", true);
    xhttp.setRequestHeader("Content-Type", "application/json");
    xhttp.send(JSON.stringify(employee));   
};

function Listar(){
    var xhttp = new XMLHttpRequest();
    
    xhttp.onreadystatechange = function() {
        if (this.readyState == 4 && this.status == 200) {
            var json = this.responseText;
            var resposta = JSON.parse(json);
            var dados = resposta.data;

            console.log(resposta.status);

            var corpo = $("#tabela-employees tbody");

            $("#tabela-employees tbody").children().remove();

            for(var i = 0; i < dados.length; i++){
                var employeeTeste = dados[i];                

                var linha = $("<tr>");
                
                var td = $("<td>").text(employeeTeste.id);
                var td1 = $("<td>").text(employeeTeste.employee_name);
                var td2 = $("<td>").text(employeeTeste.employee_age);                
                var td3 = $("<td>").text(employeeTeste.employee_salary);
                var td4 = $("<td>");

                var img = $("<img>").attr("src", employeeTeste.profile_image)
                                    .attr("alt", employeeTeste.profile_image)
                                    .addClass("img-rounded imagem");
                td4.append(img);

                var td5 = $("<td>");
                var a = $("<a>").attr("href", "#")
                                .attr("onclick", "PreencherFormulario(this)")
                                .addClass("espaco");
                a.text("Editar");                

                var a1 = $("<a>").attr("href", "#")
                                 .attr("onclick", "Excluir(this)");
                a1.text("Excluir");

                td5.append(a,a1);

                linha.append(td,td1,td2,td3,td4,td5);

                corpo.append(linha);
            }
        }
      };
    
    xhttp.open("GET", "http://rest-api-employees.jmborges.site/api/v1/employees", true);
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

                var employeeTeste = dados;

                console.log(employeeTeste);
                console.log(resposta.status);

                Listar();
            }
        };
                
        var linha = a.parentElement.parentElement;
        
        var tdId = linha.children[0]; 
        
        var id = tdId.textContent;

        var url = "http://rest-api-employees.jmborges.site/api/v1/delete/";
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

            var employeeTeste = dados;

            console.log(employeeTeste);
            console.log(resposta.status);
        }
      };    

    var employee = { name:"", salary:"", age:"", profile_image:"" };

    employee.name = $("#nome").val();
    employee.age = $("#idade").val();
    employee.salary = $("#salario").val();
    employee.profile_image = $("#avatar").val();

    var url = "http://rest-api-employees.jmborges.site/api/v1/update/";
    url += idEmployee;

    xhttp.open("PUT", url, true);
    xhttp.setRequestHeader("Content-Type", "application/json");
    xhttp.send(JSON.stringify(employee));   
};

function PreencherFormulario(a){
    var linha = a.parentElement.parentElement;
    
    var tdId = linha.children[0]; 
      
    idEmployee = tdId.textContent;

    var tr = linha.children;    

    $("#nome").val(tr[1].textContent);
    $("#idade").val(tr[2].textContent);
    $("#salario").val(tr[3].textContent);   
    $("#avatar").val(tr[4].children[0].src);

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
    $("#idade").val("");
    $("#salario").val("");   
    $("#avatar").val("");
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