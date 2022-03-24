
Algoritmo sin_titulo
	//variable
	entero= num
	entero = azaar
	entero = cantidad
	gano = Verdadero
	azaar= azar(40)
	
	si(azaar = 0)
		azaar = 1
	FinSi
	//inicio
	mientras cantidad <= 10 y gano = Verdadero
		Escribir "Digite el numero entre 1 y 40"
		leer num
		
		si(num<0 o num >40)
			Escribir "El numero no esta en el rango"
		SiNo
			si(azaar=num)
				Escribir ""
				Escribir "FELICIDADES tome mil"
				gano = Falso
			SiNo
				si(num<azaar)
					Escribir "El numero al azar es mas alto"
				SiNo
					Escribir "El numero al azar es mas bajo"
				FinSi
			FinSi
		FinSi
		Escribir ""
		cantidad=cantidad +1
	FinMientras
	
	Escribir ""
	Escribir "El numero a adivinar es " azaar
	
FinAlgoritmo
