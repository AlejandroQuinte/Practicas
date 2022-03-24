/*SUMA */
function suma2(){
    let numero1 = document.getElementById("num1").value;
    let numero2 = document.getElementById("num2").value;
    let respuesta = parseInt(numero1)+parseInt(numero2);
    document.getElementById("resp").value = respuesta;
    respuesta= "Ingrese un numero";
    document.getElementById("resp").value = respuesta;
    if(isNaN(numero1) || isNaN(numero2)|| numero1 == "" || numero2 == "" ){
    }
  
}/*
function pedirNum1(){
    
    var num1 = prompt("Digite el numero 1");
    if(isNaN(num1) || num1 < 0 || num1 > 100  ){
        alert("Escriba un NUMERO entre 0 y 100")
        document.getElementById("numero1").value = NaN;
    }else{
        document.getElementById("numero1").value = num1;
    }
 
}
function pedirNum2(){
    
    var num2 = prompt("Digite el numero 2");
    if(isNaN(num2) || num2 < 0 || num2 > 100){
        alert("Escriba un NUMERO entre 0 y 100")
        document.getElementById("numero2").value = NaN;
    }else{
        document.getElementById("numero2").value = num2;
    }
  
    
}*/
function respuesta(){
    var num1 = Number(document.getElementById("numero1").value);
    var num2 = Number(document.getElementById("numero2").value);
    var res = (parseInt(num1) +parseInt(num2)) ;
    alert("La suma es "+ (parseInt(num1) +parseInt(num2)));
    document.getElementById("res").value = res;
   
}
/*Fin suma----------------------------------------------------------------------------------------------------------------------------------------- */

/*PROMEDIO */
function prom(){
    let numeroP1 = document.getElementById("n1").value;
    let numeroP2 = document.getElementById("n2").value;
    let promf = (parseInt(numeroP1) + parseInt(numeroP2)) /2;
    document.getElementById("promf").value = promf;
    if(isNaN(numeroP1) || isNaN(numeroP2) ){
        promf= "Ingrese un numero";
        document.getElementById("promf").value = promf;
    }
    else  if( numeroP1 == "" || numeroP2 == "" ){
        promf= "Ingrese un numero";
        document.getElementById("promf").value = promf;
    }
}/*
function pedirprom1(){
    
    var num1 = prompt("Digite el numero 1");
    if(isNaN(num1)  || num1 < 0 || num1 > 100 ){
        alert("Escriba un NUMERO entre 0 y 100")
        document.getElementById("nprom1").value = NaN;
        
    }else{
        document.getElementById("nprom1").value = num1;
    } 
}
function pedirprom2(){
    var num2 = prompt("Digite el numero 2");
    if(isNaN(num2)  || num2 < 0 || num2 > 100 ){
        alert("Escriba un NUMERO entre 0 y 100")
        document.getElementById("nprom2").value = NaN;
        
    }else{
        document.getElementById("nprom2").value = num2;
    } 
    
    
}*/
function respuestaP(){
    var num1 = Number(document.getElementById("nprom1").value);
    var num2 = Number(document.getElementById("nprom2").value);
    var resP = (parseInt(num1) +parseInt(num2))/2;
    alert("El promedio de los dos numeros es "+ (num1 +num2)/2);
    document.getElementById("resProm").value = resP;
}
/*Fin promedio------------------------------------------------------------------------------------------------------------------------------- */

/*Multiplicacion */
function multi(){
    let numero1 = document.getElementById("numM1").value;
    let numero2 = document.getElementById("numM2").value;
    let respuesta = parseInt(numero1)*parseInt(numero2);
    document.getElementById("respM").value = respuesta;
    if(isNaN(numero1) || isNaN(numero2) || numero1 == "" || numero2== ""){
        respuesta= "Ingrese un numero";
        document.getElementById("respM").value = respuesta;
    }
  
}/*
function pedirNumM1(){
    
    var num1 = prompt("Digite el numero 1");
    if(isNaN(num1)  || num1 < 0 || num1 > 100 ){
        alert("Escriba un NUMERO entre 0 y 100")
        document.getElementById("numeroM1").value = NaN;
    }else{
        document.getElementById("numeroM1").value = num1;
    }
  
    
   
    
}
function pedirNumM2(){
    
    var num2 = prompt("Digite el numero 2");
    if(isNaN(num2)  || num2 < 0 || num2 > 100 ){
        alert("Escriba un NUMERO entre 0 y 100")
        document.getElementById("numeroM2").value = NaN;
    }else{
        document.getElementById("numeroM2").value = num2;
    }
  
    
}*/
function respuestaM(){
    var num1 = Number(document.getElementById("numeroM1").value);
    var num2 = Number(document.getElementById("numeroM2").value);
    var res = (parseInt(num1) +parseInt(num2)) ;
    alert("La multiplicacion es "+ (parseInt(num1) *parseInt(num2)));
    document.getElementById("resM").value = res;
   
}
/*Fin multiplicacion------------------------------------------------------------------------------------------------------------------------- */

/*Division */
function div(){
    let numeroD1 = document.getElementById("nd1").value;
    let numeroD2 = document.getElementById("nd2").value;
    let divf = (parseInt(numeroD1) / parseInt(numeroD2));
    document.getElementById("divf").value = divf;
    if(isNaN(numeroD1) || isNaN(numeroD2) || numeroD1 == "" || numeroD2 == ""){
        divf= "Ingrese un numero";
        document.getElementById("divf").value = divf;
    }
}/*
function pedirdiv1(){
    
    var num1 = prompt("Digite el numero 1");
    if(isNaN(num1)  || num1 < 0 || num1 > 100 ){
        alert("Escriba un NUMERO entre 0 y 100")
        document.getElementById("ndiv1").value = NaN;
        
    }else{
        document.getElementById("ndiv1").value = num1;
    } 
}
function pedirdiv2(){
    var num2 = prompt("Digite el numero 2");
    if(isNaN(num2)  || num2 < 0 || num2 > 100 ){
        alert("Escriba un NUMERO entre 0 y 100")
        document.getElementById("ndiv2").value = NaN;
        
    }else{
        document.getElementById("ndiv2").value = num2;
    } 
    
    
}*/
function respuestaD(){
    var num1 = Number(document.getElementById("ndiv1").value);
    var num2 = Number(document.getElementById("ndiv2").value);
    var resP = (parseInt(num1) /parseInt(num2));
    alert("La division de los dos numeros es "+ (num1 /num2));
    document.getElementById("resDiv").value = resP;
}