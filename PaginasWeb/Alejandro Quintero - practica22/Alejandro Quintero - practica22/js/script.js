$(function () {
    var mostrado = false;
    //ocultar
    $("#ocultar").click(function () {
        $(".prueba").hide(1000);
        mostrado = true;
    });
    //mostrar
    $("#mostrar").click(function () {
        $(".prueba").show(1000);
        mostrado = false;
    });
    //mostrado y ocultado
    $("#ocultarMostrar").click(function () {

        if (mostrado == true) {
            $(".prueba").show(1000);
            mostrado = false;
        } else {
            $(".prueba").hide(1000);
            mostrado = true;
        }
        //mostrado == true ?  $(".prueba").show(1000)  : $(".prueba").hide(1000) 
    });
    //ocultar fadeOut
    $("#ocultarFOut").click(function () {
        $(".prueba").fadeOut();
        mostrado = true;
    });
    //ocultar fadeIn
    $("#ocultarFIn").click(function () {
        $(".prueba").fadeIn();
        mostrado = false;
    });



    //Mover el cuadro
    $("#mover").click(function () {
        var primer = true;

        if (primer == true) {
            $(".prueba").css(
                "animation-name", "movimiento",
                "border", "solid 6px black"
            );
            //primer = false;
        }

        if (primer == false) {
            $(".prueba").css(
                "animation-name", "movimientos",
                "border", "solid 6px black"
            );
        }

    });

    //Copiado
    $("#copia").click(function () {
        var informacion = $(".h1").html();
        $("#spanCopiar").text(informacion);
    });
    //clonado
    $("#clonar").click(function () {
        var informacion = $(".h1").html();
        $("#spanClonar").text(informacion);
        $("#spanClonar").addClass("h1");
    });


    //mostrado o ocultado
    $(".prueba2").click(function () {
        $(".prueba2").hide(1000, function () {
            $(".prueba2").show(2000);
        });
    });

    //fondo
    $(".fondoA").mouseover(function () {
        $(".fondoA").css(
            "background-color", "yellow",
        );
    });
    $(".fondoA").mouseout(function () {
        $(".fondoA").css(
            "background-color", "white",
        );
    });

    //conteo de letras
    function conteo() {

        var textArea = $("#textarea").html();
        var numeroCaracteres = textArea.length;

        $("#cantidad").text(numeroCaracteres);
        /*
        var textoAreaDividido = textoArea.split(" ");
        var numeroPalabras = textoAreaDividido.length;

        var primerBlanco = /^ /;
        var ultimoBlanco = / $/;
        var variosBlancos = /[ ]+/g;

        texto = texto.replace(variosBlancos, " ");
        texto = texto.replace(primerBlanco, "");
        texto = texto.replace(ultimoBlanco, "");
        textoTroceado = texto.split(texto, " ");
        numeroPalabras = textoTroceado.length;
        */
    };
    $("#textarea").click(function () {
        setTimeout(conteo(), 1000);
    });


    //mostrar contenido
    $("#externo").click(function () {
        $("#contenido").css(
            "display", "grid",
        );
    });
    //ocultar contenido
    $("#OContenido").click(function () {
        $("#contenido").css(
            "display", "none",
        );
    });

    //version de jQuery
    $("#version").click(function () {
        alert("La version de jQuery es 3.6.0");
    })


});