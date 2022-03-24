
function verhora() {
    var fechahora = new Date();
    var hora = fechahora.getHours();
    var minutos = fechahora.getMinutes();
    var segundos = fechahora.getSeconds();

    var horaR = 23 - hora;
    var minutosR = 60 - minutos;
    var segundosR = 60 - segundos;

    if (hora < 10) {
        hora = "0" + hora;
    } if (minutos < 10) {
        minutos = "0" + minutos;
    }
    if (segundos < 10) {
        segundos = "0" + segundos;
    }
    //reversa
    if (horaR < 10) {
        horaR = "0" + horaR;
    } if (minutosR < 10) {
        minutosR = "0" + minutosR;
    }
    if (segundosR < 10) {
        segundosR = "0" + segundosR;
    }

    var sufijo = " am";
    if (hora >= 12) {
        if (hora > 12) {
            hora = hora - 12;
        }
        sufijo = " pm"
    }
    document.getElementById("reloj").innerHTML = "Hora Actual\n" + hora + ":" + minutos + ":" + segundos + sufijo;
    document.getElementById("fecha").innerHTML = "Fecha Actual\n" + fechahora.getDate() + "/" + (fechahora.getMonth() + 1) + "/" + fechahora.getFullYear();
    document.getElementById("relojreverza").innerHTML = "Hora Actual\n" + horaR + ":" + minutosR + ":" + segundosR;
}

window.onload = function () {
    setInterval(verhora, 1000);
}