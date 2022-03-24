

    //Iniciar materialize
    M.AutoInit();


    
    //Iniciar carrusel
    document.addEventListener('DOMContentLoaded', function () {
        var elems = document.querySelectorAll('.carousel');
        var instances = M.Carousel.init(elems, {
            indicators: true,
            duration: 100,
            noWrap: false,
            fullWidth: true
        });
    });



    //Graficos

    //hacemos el llamado para seleccionar el espacio de graficos
    const selectElement = document.querySelector("#seleccionarGraficos");

    document.addEventListener('DOMContentLoaded', function () {
        //creamos el evento cada vez que se toca un dato 
        selectElement.addEventListener('change', (event) => {
            //const resultado = document.querySelector('#myPlot');
            var seleccionado = event.target.value;

            //Llamado a arreglo escogidos al azar 
            numerosAleatorios();

            //Llamado a graficos, colocandole los datos
            grafico(seleccionado);

            //reinicia los arreglos para que no se se sumen
            for (let i = mostradoX.length; i > 0; i--) {
                mostradoX.pop();
                mostradoY.pop();
            }

        });
    });


    //se crean estas variables globales para que puedan ser usadas por otras funciones sin que los valores queden dentro de una function
    var mostradoX = [];
    var mostradoY = [];
    var tituloGrafico = "Cantidad de compras de productos por dia";

    //Funcion para crear las variables con numeros al azar
    function numerosAleatorios() {
        var productos = ["Leche", "Detergente", "Refrescos", "Pan", "Galletas", "Agua Embotellada", "Cerveza", "Aceite", "Papel Higienico", "Alimento de mascotas"]


        //Define la cantidad de numeros aleatorios.
        var cantidadNumeros = 15;
        var arreglo = [];
        var cantidad_P = [];
        while (arreglo.length < cantidadNumeros) {
            var numeroAleatorio = Math.ceil((Math.random()) * cantidadNumeros + 100);
            var existe = false;
            for (var i = 0; i < arreglo.length; i++) {
                if (arreglo[i] == numeroAleatorio) {
                    existe = true;
                    break;
                }
            }
            if (!existe) {
                arreglo[arreglo.length] = numeroAleatorio;
            }

        }
        //guardamos 10 valores de los 15 de su anterior arreglo
        for (var i = 0; i < 10; i++) {
            cantidad_P[i] = arreglo[i];
        }
        //mostramos el arreglo
        console.log(cantidad_P)


        //Conocemos los datos a mostrar osea, cantidad de productos a mostrar
        var CantDatos = Math.floor(Math.random() * (11 - 3) + 3);
        console.log(CantDatos)


        //guardamos en un nuevo arreglo los datos que se van a mostrar en la grafica
        for (var i = 0; i < CantDatos; i++) {
            mostradoX[i] = productos[i];
            mostradoY[i] = cantidad_P[i];
        }
    }

    function grafico(nombreGrafico) {

        if (nombreGrafico == "scatter") {//seleccionar el grafico linear

            // Define Data
            var data = [{
                x: mostradoX,
                y: mostradoY,
                mode: "lines",
                type: "scatter"
            }];
            // Define Layout
            var layout = {
                xaxis: { title: "Productos" },// range: [40, 160],
                yaxis: { range: [100, 115], title: "Cantidad" },
                title: tituloGrafico
            };
            // Display using Plotly
            Plotly.newPlot("myPlot", data, layout);

        } else if (nombreGrafico == "bar") {//Seleccionar el grafico de barras

            var data = [{
                x: mostradoX,
                y: mostradoY,
                type: "bar"
            }];
            var layout = { title: tituloGrafico };

            Plotly.newPlot("myPlot", data, layout);

        } else if (nombreGrafico == "barH") {//Barras horizontales

            var xArray = [55, 49, 44, 24, 15];
            var yArray = ["Italy", "France", "Spain", "USA", "Argentina"];

            var data = [{
                x: mostradoY,
                y: mostradoX,
                type: "bar",
                orientation: "h"
            }];

            var layout = { title: tituloGrafico };

            Plotly.newPlot("myPlot", data, layout);


        } else if (nombreGrafico == "pie") {//grafico modo pai

            var layout = { title: tituloGrafico };

            var data = [{ labels: mostradoX, values: mostradoY, type: "pie" }];

            Plotly.newPlot("myPlot", data, layout);


        } else if (nombreGrafico == "donut") {//grafico modo dona

            var layout = { title: tituloGrafico };

            var data = [{ labels: mostradoX, values: mostradoY, hole: .4, type: "pie" }];

            Plotly.newPlot("myPlot", data, layout);


        }
    };


    //tabla
    function genera_tabla() {
        // Crea un elemento <table> y un elemento <tbody>
        var tblBody = document.querySelector("#cuerpoTabla");

        // Crea las celdas
        var hilera = document.createElement("tr");


        // Crea un elemento <td> y un nodo de texto, haz que el nodo de
        // texto sea el contenido de <td>, ubica el elemento <td> al final
        // de la hilera de la tabla
        var nombre = document.getElementById("nombre").value;
        var apellido = document.getElementById("apellido").value;
        var edad = document.getElementById("edad").value;

        //Aqui datos si desea agregarlos de diferente forma

        if (nombre == "" || apellido == "" || edad == "0" || edad == "") {

            alert("llene los espacios en blanco correctamente")

        } else {

            var textoCelda = document.createTextNode(nombre);
            //creo la celda le agrego datos luego creo otra columna
            var celda = document.createElement("td");
            celda.appendChild(textoCelda);
            hilera.appendChild(celda);
            textoCelda = document.createTextNode(apellido)

            //
            celda = document.createElement("td");
            celda.appendChild(textoCelda);
            hilera.appendChild(celda);
            textoCelda = document.createTextNode(edad)

            //
            celda = document.createElement("td");
            celda.appendChild(textoCelda);
            hilera.appendChild(celda);


            // agrega la hilera al final de la tabla (al final del elemento tblbody)
            tblBody.appendChild(hilera);

        }
    };

    var promedio = 0;
    var cantidad = 0;
    function llenado() {

        // Crea un elemento <table> y un elemento <tbody>
        var tblBody = document.querySelector("#cuerpoTabla");

        // Crea las celdas
        var hilera = document.createElement("tr");

        var nombre = prompt("digite el nombre");
        var apellido = prompt("digite el apellido");
        var edad = prompt("digite el edad");

        if (nombre == "" || apellido == "" || edad == "0" || edad == "") {

            alert("llene los espacios en blanco correctamente")

        } else {

            var textoCelda = document.createTextNode(nombre);
            //creo la celda le agrego datos luego creo otra columna
            var celda = document.createElement("td");
            celda.appendChild(textoCelda);
            hilera.appendChild(celda);
            textoCelda = document.createTextNode(apellido)

            //
            celda = document.createElement("td");
            celda.appendChild(textoCelda);
            hilera.appendChild(celda);
            textoCelda = document.createTextNode(edad)

            //
            celda = document.createElement("td");
            celda.appendChild(textoCelda);
            hilera.appendChild(celda);


            // agrega la hilera al final de la tabla (al final del elemento tblbody)
            tblBody.appendChild(hilera);

        }

        promedio += parseInt(edad);
        cantidad++;
        console.log(cantidad)
        console.log(promedio)

        if (confirm('¿Desea agregar un nuevo cliente')) {
            llenado();

        } else {
            alert("El promedio es: " + (promedio / cantidad))
        }

    };




