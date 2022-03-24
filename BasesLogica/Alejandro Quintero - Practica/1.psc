
Algoritmo sin_titulo
	//variables
	entero = menu
	menu = 1
	real = lado
	real = lado2
	real = lado3
	real = perimetro
	real = area
	real = base
	real = altura
	real = diagMayor
	real = diagMenor
	
	
	//cuadrado=lado
	//rectangulo base x altura
	//triangulo base x altura /2
	//rombo diagonal mayor x diagonal menor / 2
	
	//menu en el que si digita 1 se escoje el cuadrado
	
	Mientras menu > 0 y menu < 5
		Escribir "Digite la figura que desea saber el area y el perimetro"
		Escribir "1-Cuadrado"
		Escribir "2-Rectangulo"
		Escribir "3-Rombo"
		Escribir "4-Triangulo"
		Escribir "5-Salir"
		leer menu
		
		segun menu
			1:
				Escribir "Digite el lado"
				leer lado
				perimetro = lado * 4
				area = lado * lado
				
				Escribir "El perimetro del cuadrado es: " perimetro
				Escribir "El area del cuadrado es: " area
				Escribir ""
				
			2:
				Escribir "Digite la base del rectangulo: "
				leer base
				Escribir "Digite la altura del rectangulo: "
				leer altura
				perimetro = 2 * (base+altura)
				area = base * altura
				
				Escribir "El perimetro del rectangulo es: " perimetro
				Escribir "El area del rectangulo es: " area
				Escribir ""
				
			3:
				Escribir "Digite la diagonal mayor: "
				leer diagMayor
				Escribir "Digite la diagonal menor: "
				leer diagMenor
				Escribir "Digite un lado del rombo: "
				leer lado
				perimetro = 4 * lado
				area = diagMayor * diagMenor / 2
				
				Escribir "El perimetro del rombo es: " perimetro
				Escribir "El area del rombo es: " area
				Escribir ""
				
			4:
				Escribir "Digite el lado 1 del triangulo: "
				leer lado
				Escribir "Digite el lado 2 del triangulo: "
				leer lado2
				Escribir "Digite el lado 3 del triangulo: "
				leer lado3
				Escribir "Digite la base del triangulo: "
				leer base
				Escribir "Digite la altura del triangulo: "
				leer altura
				
				perimetro = lado+lado2+lado3
				area = base * altura / 2
				
				Escribir "El perimetro del triangulo es: " perimetro
				Escribir "El area del triangulo es: " area
				Escribir ""
				
		FinSegun
		
		
	FinMientras
	
FinAlgoritmo
