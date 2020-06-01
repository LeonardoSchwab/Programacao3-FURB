function ValidaCampos(){
    var elements = document.getElementsByTagName("INPUT");
    var spanErros = document.getElementById("ERRO");
    for (var i = 0; i < elements.length - 1; i++) {
        if(elements[i].value == "") {
            spanErros.textContent = "CAMPO OBRIGATÓRIO NÃO PREENCHIDO!";               
        }
                        
    }

    var texta = document.getElementById("mensagem");
    if(texta.value == "") {
        spanErros.textContent = "CAMPO OBRIGATÓRIO NÃO PREENCHIDO!";               
    }
};