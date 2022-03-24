var num1 = prompt("Digite un numero");
var num2 = prompt("Digite un numero");

if (isNaN(num1) || isNaN(num2)) {
    alert("Numero Incorrecto")
} else {
    if (num1 < 20 && num1 > 0 && num2 > 0 && num2 < 20) {
        if (num1 > num2) {
            alert("El numero 1 no puede ser mayor la numero 2");
        } else {
            document.getElementById("num1").innerHTML = num1;
            document.getElementById("num2").innerHTML = num2;
            document.getElementById("elevado").innerHTML = (Math.pow(num1, num2));
        }
    } else {
        alert("Los numeros deben ser entre 0 y 20")
    }
}

var aleatorio =Math.floor(Math.random() * (20 + 1));
var numLetra;

//document.getElementById("numero").innerHTML = Math.floor(aleatorio);

switch (aleatorio) {
    case 1: numLetra = "Uno";
        break;
    case 2: numLetra = "Dos";
        break;
    case 3: numLetra = "Tres";
        break;
    case 4: numLetra = "Cuatro";
        break;
    case 5: numLetra = "Cinco";
        break;
    case 6: numLetra = "Seis";
        break;
    case 7: numLetra = "Siete";
        break;
    case 8: numLetra = "Ocho";
        break;
    case 9: numLetra = "Nueve";
        break;
    case 10: numLetra = "Diez";
        break;
    case 11: numLetra = "Once";
        break;
    case 12: numLetra = "Doce";
        break;
    case 13: numLetra = "Trece";
        break;
    case 14: numLetra = "Catorce";
        break;
    case 15: numLetra = "Quince";
        break;
    case 16: numLetra = "Diesiseis";
        break;
    case 17: numLetra = "Diesisiete";
        break;
    case 18: numLetra = "Diesiocho";
        break;
    case 19: numLetra = "Diesinueve";
        break;
    case 20: numLetra = "Veinte";
        break;
}

document.getElementById("numero").innerHTML = numLetra;