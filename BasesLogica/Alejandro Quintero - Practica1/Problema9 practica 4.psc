//9.	Determine el valor de un pasaje en avi�n, conociendo la distancia a recorrer, 
//el n�mero de d�as de estancia, y sabiendo que, si la distancia a recorrer es 
//superior a 1000 Km y el n�mero de d�as de estancia es superior a 7, la l�nea 
//a�rea le hace un descuento del 30%. (el precio por km. es de $35.00) 

Algoritmo sin_titulo
	//Variables
	real = distancia
	entero = dias
	real = precio
	
	
	//Cuerpo
	escribir( "introduzca la distancia a recorrer(km) " )
	leer distancia 
	escribir( "introduzca los dias " )
	leer dias 
	
	si(dias > 7 Y distancia > 1000)
		distancia = distancia * 35.00
		distancia = distancia / 100 * 30
	sino
		Distancia = distancia *35.00
	finsi
	
	escribir "El precio por el viaje es: " distancia " dolares"
			

FinAlgoritmo
