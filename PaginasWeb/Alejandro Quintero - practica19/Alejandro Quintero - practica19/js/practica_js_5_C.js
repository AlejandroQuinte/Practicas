
var pares = 0;
var impares = 0;

function valor() {
    var cantidad = prompt("Digite la cantidad de numeros a ingresar");
    var num = false;
    var i = 0;
    if (isNaN(cantidad)) {
        alert("Numero digitado no es un numero")
        num = true;
    }
    while (num = false || i < cantidad) {
        numero = prompt("Digite un numero");
        if (isNaN(numero)) {
            alert("Numero digitado no es un numero")
            i = 10;
        } else if (numero % 2 == 0) {
            pares++;
        } else {
            impares++;
        }
        i++;
    }

    document.getElementById("cantP").innerHTML = pares;
    document.getElementById("cantI").innerHTML = impares;


}

valor();