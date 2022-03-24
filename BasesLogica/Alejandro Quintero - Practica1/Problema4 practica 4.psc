//4.	Dada las tres notas de un estudiante en la asignatura de algoritmos, 
//calcule su nota final teniendo en cuenta que las dos primeras notas 
//equivalen al 60% y la última nota el 40% restante. 

Algoritmo CalcularNotas
	
	//Variables
	real = nota1
	real = nota2
	real = nota3
	real = notaFinal
	
	//Cuerpo
	escribir( "Introduzca lo que se gano en la primera nota:")
	leer nota1 
	
	escribir( "Introduzca lo que se gano en la segunda nota:")
	leer nota2
	
	escribir( "Introduzca lo que se gano en la tercera nota:")
	leer nota3
	
	nota1 = nota1 / 100 * 30
	
	nota2 = nota2 / 100 * 30
	
	nota3 = nota3 / 100 * 40
	
	notaFinal = nota1 + nota2 + nota3
	
escribir "La nota final es de: " notaFinal "%"

	
	
FinAlgoritmo
