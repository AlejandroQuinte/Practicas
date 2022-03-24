var marcas = [5];
var nombre = [5];
//"Mitsubishi","Toyota","Toyota","Montero","Hilux"
//"Alejandro","Alexander","Paco","Pancho","Patricio"
function llenado() {
    for (var i = 0; i < 5; i++) {
        marcas[i] = prompt("Digite una marca");
    }
    for (var i = 0; i < 5; i++) {
        nombre[i] = prompt("Digite un nombre");
    }
}

function mostrado() {
    var cantidad = prompt("Digite el usuario y marca a buscar");
    cantidad = cantidad - 1;
    if (isNaN(cantidad)) {
        alert("Numero digitado no es un numero");
    } else if (cantidad < 0 || cantidad > 4) {
        alert("El numero digitado no se encuentra en el arreglo");
    } else {
        switch (cantidad) {
            case 0:alert("Nombre: "+nombre[cantidad]+"\n"+"Marca: "+marcas[cantidad])
                break;
            case 1:alert("Nombre: "+nombre[cantidad]+"\n"+"Marca: "+marcas[cantidad])
                break;
            case 2:alert("Nombre: "+nombre[cantidad]+"\n"+"Marca: "+marcas[cantidad])
                break;
            case 3:alert("Nombre: "+nombre[cantidad]+"\n"+"Marca: "+marcas[cantidad])
                break;
            case 4:alert("Nombre: "+nombre[cantidad]+"\n"+"Marca: "+marcas[cantidad])
                break;
    
        }
    }

    //document.getElementById("marca").innerHTML = marcas[cantidad];
    //document.getElementById("nombre").innerHTML = nombre[cantidad];
}

llenado();
mostrado();