Algoritmo sin_titulo
	caracter = a
	a= ""
	caracter= m
	m= ""
	caracter = suma
	verdadero1= Verdadero
	caracter= l
	caracter= b
	entero= largo
	entero= k
	k = 0
	Mientras  verdadero1= Verdadero
		Escribir  ("Digite la palabra")
		Leer b
		a= Mayusculas(b)
		
		largo = Longitud(a)
		// PARA COGER LA ULTIMA LETRA E IR GUARDANDOLA EN UNA VARIABLE
		Para i=0 Hasta largo Con Paso 1
			suma= Subcadena(a,largo-k, largo-k)
			m= m+suma
			k=k+1
		FinPara
		// PARA VER SI LAS PALABRAS SON IGUALES O NO
		si a=m 
			Escribir "Son iguales"
		SiNo
			Escribir  "Las palabras no son iguales"
			
		FinSi
		Escribir "Digite Y si desea ingresar otra palabra"
		Leer l
		// POR SI SE QUIERE INGRESAR UNA PALABRA OTRA VEZ
		si l= "Y" o l= "y" 
			
		SiNo
			verdadero1 = Falso
			
		FinSi
		//SE REINICIAN, LO QUE UNA VEZ SE GUARDÓ COMO VARIABLE, SINO, 
		//CUANDO SE VUELVEN A COMPARAR... "B" "A" NO IMPORTA REINICIARLAS PORQUE SE VUELVE A CONVERTIR EN OTRO DATO
		b= ""    
		a= ""
		k= 0
		m= ""
	FinMientras
	
		
		
	
	
FinAlgoritmo
