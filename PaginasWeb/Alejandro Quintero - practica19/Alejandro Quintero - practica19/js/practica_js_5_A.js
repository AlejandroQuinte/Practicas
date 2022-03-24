
var pares=0;
var cincos=0;
var cantLeida = 0;
var repite = false;

function valor() {
    do{
        numero = prompt("Digite un numero");
        cantLeida++;
        if (isNaN(numero)) {
            alert("Numero digitado no es un numero")
            repite = true;
        }else if(numero==5){
            cincos++;
            if(cincos==3){
                numero=-1;
            }
        }else if(numero%2==0){
            pares++;
            if(pares==10){
                numero=-1;
            }
        }

    }while(repite = false || numero > 0 )

    document.getElementById("cantidad").innerHTML =cantLeida;
    document.getElementById("cantPares").innerHTML =pares;
    document.getElementById("cantCincos").innerHTML =cincos;

}

valor();
//document.getElementById("").innerHTML ;