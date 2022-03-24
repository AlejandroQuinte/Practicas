var cantidad = prompt("Digite la cantidad de dinero");

function cantDinero(){
    var quinientos=0;
    var cien=0;
    var cincuenta=0;
    var veinticinco=0;
    var diez=0;
    var cinco=0;
    var uno=0;
    while(cantidad!=0){
        if(cantidad>=500){
            quinientos++;
            cantidad=cantidad-500;
        }else if(cantidad>=100){
            cien++;
            cantidad=cantidad-100;
        }
        else if(cantidad>=50){
            cincuenta++;
            cantidad=cantidad-50;
        }
        else if(cantidad>=25){
            veinticinco++;
            cantidad=cantidad-25;
        }
        else if(cantidad>=10){
            diez++;
            cantidad=cantidad-10;
        }
        else if(cantidad>=5){
            cinco++;
            cantidad=cantidad-5;
        }
        else if(cantidad>=1){
            uno++;
            cantidad=cantidad-1;
        }
    }
    if(quinientos!=0){
        document.getElementById("quinientos").innerHTML ="Cantidad de quinientos: "+ quinientos;
    }
    if(cien!=0){
        document.getElementById("cien").innerHTML ="Cantidad de cien: "+ cien;
    }
    if(cincuenta!=0){
        document.getElementById("cincuenta").innerHTML ="Cantidad de cincuenta: "+ cincuenta;
    }
    if(veinticinco!=0){
        document.getElementById("veinticinco").innerHTML ="Cantidad de veinticinco: "+ veinticinco;
    }
    if(diez!=0){
        document.getElementById("diez").innerHTML ="Cantidad de diez: "+ diez;
    }
    if(cinco!=0){
        document.getElementById("cinco").innerHTML ="Cantidad de cinco: "+ cinco;
    }
    if(uno!=0){
        document.getElementById("uno").innerHTML ="Cantidad de uno: "+ uno;
    }
    
    
    
    
}
cantDinero();