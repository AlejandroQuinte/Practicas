
var positivos = 0;
var negativos = 0;

function valor() {

    for (var i = 0; i < 10; i++) {
        numero = prompt("Digite un numero");
        if (isNaN(numero)) {
            alert("Numero digitado no es un numero")
            i = 10;
        } else if (numero >= 0) {
            positivos++;
        } else if (numero < 0) {
            negativos++;
        }
    }

    document.getElementById("cantP").innerHTML = positivos;
    document.getElementById("cantN").innerHTML = negativos;


}

valor();