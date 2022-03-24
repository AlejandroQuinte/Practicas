//Escribir un algoritmo en el cual a partir de una fecha ingresada 
//por el teclado con formato día, mes, se obtenga la fecha del 
//día siguiente. 

Algoritmo Devolucion 
	//ene 31 feb 28 mar 31 abr 30 may 31 jun 30 jul 31 ago 31 
	//sep 30 oct 31 nov 30 dic 31
	
	//Variables
	entero= dia
	entero = mes
	entero = comparacion
	
	
	//Cuerpo
	escribir( "introduzca numero de día: " )
	leer dia
	escribir( "introduzca numero de mes " )
	leer mes 
	
	comparacion = 1
	
	si(mes = 1 Y dia <= 31)
		si(dia = 31 Y mes = 1)
			mes = mes + 1
			dia = 1
		SiNo
			dia = dia + 1
		FinSi	
	comparacion = 0
	FinSi

	si(mes = 2 Y dia <= 28 y comparacion = 1)
		si(dia = 28 Y mes = 2)
			mes = mes + 1
			dia = 1
			comparacion = 0
		SiNo
			dia = dia + 1
			comparacion = 0
		FinSi	
	FinSi
	
	si(mes = 3 Y dia <= 31 y comparacion = 1)
		si(dia = 31 Y mes = 3)
			mes = mes + 1
			dia = 1
			comparacion = 0
		SiNo
			dia = dia + 1
			comparacion = 0
		FinSi	
	FinSi
	
	si(mes = 4 Y dia <= 30 y comparacion = 1)
		si(dia = 30 Y mes = 4)
			mes = mes + 1
			dia = 1
			comparacion = 0
		SiNo
			dia = dia + 1
			comparacion = 0
		FinSi	
	FinSi
	
	si(mes = 5 Y dia <= 31 y comparacion = 1)
		si(dia = 31 Y mes = 5)
			mes = mes + 1
			dia = 1
			comparacion = 0
		SiNo
			dia = dia + 1
			comparacion = 0
		FinSi	
	FinSi
	
	si(mes = 6 Y dia <= 30 y comparacion = 1)
		si(dia = 30 Y mes = 6)
			mes = mes + 1
			dia = 1
			comparacion = 0
		SiNo
			dia = dia + 1
			comparacion = 0
		FinSi	
	FinSi
	
	si(mes = 7 Y dia <= 31 y comparacion = 1)
		si(dia = 31 Y mes = 7)
			mes = mes + 1
			dia = 1
			comparacion = 0
		SiNo
			dia = dia + 1
			comparacion = 0
		FinSi	
	FinSi
	
	si(mes = 8 Y dia <= 31 y comparacion = 1)
		si(dia = 31 Y mes = 8)
			mes = mes + 1
			dia = 1
			comparacion = 0
		SiNo
			dia = dia + 1
			comparacion = 0
		FinSi	
	FinSi
	
	si(mes = 9 Y dia <= 30 y comparacion = 1)
		si(dia = 30 Y mes = 9)
			mes = mes + 1
			dia = 1
			comparacion = 0
		SiNo
			dia = dia + 1
			comparacion = 0
		FinSi	
	FinSi
	
	si(mes = 10 Y dia <= 3 y comparacion = 1)
		si(dia = 3 Y mes = 10)
			mes = mes + 1
			dia = 1
			comparacion = 0
		SiNo
			dia = dia + 1
			comparacion = 0
		FinSi	
	FinSi
	
	si(mes = 11 Y dia <= 30 y comparacion = 1)
		si(dia = 30 Y mes = 11)
			mes = mes + 1
			dia = 1
			comparacion = 0
		SiNo
			dia = dia + 1
			comparacion = 0
		FinSi	
	FinSi
	
	si(mes = 12 Y dia <= 31 y comparacion = 1)
		si(dia = 31 Y mes = 12)
			mes = 1
			dia = 1
			comparacion = 0
		SiNo
			dia = dia + 1
			comparacion = 0
		FinSi	
	FinSi
	
	si(dias > 0 y dias < 32 y mes > 0 y mes < 13 y comparacion = 0)
		Escribir "Es el mes es " mes " y el día siguiente seria " dia
	FinSi
	
	m = falso
	
	Si(mes < 0 o mes > 12)
		escribir "El mes dicho es erroneo"
		
		si(dia > 0 o dia < 32)
			m = verdadero
		FinSi
		
	FinSi
	
	si(dia > 31 o dia < 1 o comparacion = 1 y m = falso)
		Escribir "Dias incorrectos"	
	FinSi
	
	//uufff me saco todo este problema, pero ya esta perfecto, no deberia haber ni un solo fallo si trabajamos... con numeros enteros... 
	//pero estuvo demasiado bueno tengo que admitirlo, me gusto demasiado
	
FinAlgoritmo
