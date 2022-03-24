//grafico de muestra1
var xArray = ["Italy", "France", "Spain", "USA", "Argentina"];
var yArray = [55, 49, 44, 24, 15];

var data = [{
  x:xArray,
  y:yArray,
  type:"bar"
}];

var layout = {title:"Titulo muestra"};

Plotly.newPlot("grafico1", data, layout);

//grafico de muestra2
var xArray = ["Italy", "France", "Spain", "USA", "Argentina"];
var yArray = [55, 49, 44, 24, 15];

var layout = {title:"Titulo muestra"};

var data = [{labels:xArray, values:yArray, type:"pie"}];

Plotly.newPlot("grafico2", data, layout);


//------------------------------------------------
var boton1 = document.querySelector("#CGrafico1");

boton1.addEventListener("click", ()=>{
    var titulo1 = prompt("Digite el titulo del primer grafico");
    var cantidad1 = prompt("Digite la cantidad de datos a ingresar");

    var xGrafico1 = [cantidad1];
    var yGrafico1 = [cantidad1];
    
    for (var i = 0; i < cantidad1; i++) {
        var nombre1 = prompt("Digite el nombre del producto");
        var precio1 = prompt("Digite el precio del producto");
        xGrafico1[i] = nombre1;
        yGrafico1[i] = precio1;
    }
    
    var data = [{
        x: xGrafico1,
        y: yGrafico1,
        type: "bar"
    }];
    
    var layout = { title: titulo1 };
    
    Plotly.newPlot("grafico1", data, layout);
});


//Segundo Grafico chart
var boton2 = document.querySelector("#CGrafico2");

boton2.addEventListener("click",()=>{
    var titulo2 = prompt("Digite el titulo del segundo grafico");
    var cantidad2 = prompt("Digite la cantidad de datos a ingresar");

    var xGrafico2 = [cantidad2];
    var yGrafico2 = [cantidad2];
    
    for (var i = 0; i < cantidad2; i++) {
        var nombre2 = prompt("Digite el nombre del producto");
        var precio2 = prompt("Digite el precio del producto");
        xGrafico2[i] = nombre2;
        yGrafico2[i] = precio2;
    }
    
    var layout = { title: titulo2 };
    
    var data = [{ labels: xGrafico2, values: yGrafico2, type: "pie" }];
    
    Plotly.newPlot("grafico2", data, layout);
});