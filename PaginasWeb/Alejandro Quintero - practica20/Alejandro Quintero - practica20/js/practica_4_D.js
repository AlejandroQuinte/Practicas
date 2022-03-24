
function palindromo(str) {
    const newString = str.replace(/[\W_]/g, "").toLowerCase()
    const stringReversa = newString.split("").reverse().join("")

    return newString === stringReversa ? "es palindromo" : "no es palindromo"
    //si es igual al string alrevez se pregunta si es igual es palindromo 
    //o true sino seria false que no es palindromo
}
var palabra = prompt("Digite una palabra o frase");

alert(palindromo(palabra));


