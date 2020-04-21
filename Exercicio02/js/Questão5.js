function soma(){
    var v1 = document.getElementById("numero1").value;    
    var v2 = document.getElementById("numero2").value;
    var v3 = document.getElementById("numero3").value;

    var resultado = parseInt(v1) + parseInt(v2) + parseInt(v3);

    if ((resultado%2) == 0) {
        alert(resultado + "(Par)");
    } else {
        alert(resultado + "(Ímpar)");   
    }    
}


function fatorial(){
    var n1 = parseInt(document.getElementById("numero1").value);
    var txtarea = document.getElementById("resultado");
    var contador = 1;
    resultado = 1;

    while(contador <= n1){
        resultado *= contador;
        contador++;
    }

    txtarea.value = n1 + "! = " + resultado;    
}
