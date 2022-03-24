
SubProceso juegoNuevo(Matriz)
	Definir azaar, i,j,x,contador Como Entero
	Definir continuar Como Logico
	x=1
	contador=0
	Dimension azaar[15]
	
	Para i=0 hasta 14 Hacer//guardamos los numeros en orden
		azaar[i]=x
		x = x+1
	FinPara
	Para i=0 hasta 3 Hacer
		Para j=0 hasta 3 Hacer
			x=azar(15) // x representa el índice del vector ordenado
			Repetir
				si azaar[x]<>0 Entonces//aqui colcoamos los numeros desordenadamente con el azar
					Matriz[i,j]= azaar[x] //
					azaar[x]=0//volvemos el valor del vector a 0 para que no se repita el dato en la matriz
					continuar=Verdadero
					contador=contador+1
				SiNo
					continuar=Falso//se vuelve a repetir el repetir
					x=x+1//se le suma 1 al iterador
					si x>=15 Entonces//si es mayor o igual significa que se encuentra en la ultima posicion que es donde se encuentra el blanco
						x=0
					FinSi
				FinSi
			Hasta Que continuar= verdadero o contador >= 15 
		FinPara
	FinPara
	
FinSubProceso

SubProceso imprimeMatriz(Matriz) //muestra la matriz
	Definir i,j Como Entero
	Definir espacios Como Caracter
	
	Para i=0 hasta 3 Hacer
		Para j=0 hasta 3 Hacer
			si Matriz[i,j] > 9 Entonces
				espacios= "     "
			SiNo
				espacios= "      "
			FinSi
			si matriz[i,j]  <> 0 Entonces
				escribir Sin Saltar espacios, Matriz[i,j]
			SiNo
				Escribir Sin Saltar espacios, "-"
			FinSi
		FinPara
		Escribir ""
		Escribir ""
	FinPara
FinSubProceso

SubProceso HacerMovimiento (Matriz,movimientos)//movimientos de la matriz
	Definir i,j,FBlanco,CBlanco, mov Como Entero
	Definir arriba,abajo,derecha,izquierda Como Logico
	
	Limpiar Pantalla
	Escribir "Ha realizado ", movimientos, " movimientos"
	Escribir ""
	imprimeMatriz(Matriz)
	
	Para i=0 hasta 3 Hacer
		Para j=0 hasta 3 Hacer
			si Matriz[i,j] =0 Entonces
				FBlanco= i //contiene la cantidad de filas donde se ubica el blanco
				CBlanco=j//contiene la cantidad de columnas donde se ubica el blanco
			FinSi
		FinPara
	FinPara
	Escribir "La posición del blanco es ", FBlanco "," CBlanco
	
	//Evalua donde se encuentra el blanco, y de ahi saca que movimientos tiene
	Si FBlanco= 0 //si es 0 significa que esta en la parte de arriba
		abajo=Falso
	SiNo
		abajo=Verdadero
	FinSi
	//Evalua si se puede mover hacia arriba
	Si FBlanco=3 //si es 3 significa que esta todo hacia abajo
		arriba=Falso
	SiNo
		arriba= Verdadero
	FinSi
	//Evalua si se puede mover hacia la derecha
	si CBlanco =0 //si es 0 significa que esta todo a la izquierda
		derecha=Falso
	SiNo
		derecha= Verdadero
	FinSi
	//Evalua si se puede mover hacia la izquierda
	si CBlanco =3 //si es 3 significa que esta todo a la derecha
		izquierda=Falso
	SiNo
		izquierda= Verdadero
	FinSi
	
	Escribir "Sus posibles movimientos en este momento son: " //controla donde se encuentra blanco, y pone los movimientos posibles
	si (arriba = Verdadero) 
		Escribir "-Mover el número ", Matriz[FBlanco+1,CBlanco], " hacia arriba. Presione el número 2"
	FinSi
	Si (abajo = Verdadero) 
		Escribir "-Mover el número ", Matriz[FBlanco-1,CBlanco], " hacia abajo. Presione el número 8"
	FinSi
	Si (derecha = Verdadero)
		Escribir "-Mover el número ", Matriz[FBlanco,CBlanco-1], " hacia la derecha. Presione el número 4"
	FinSi
	Si (izquierda = Verdadero)
		Escribir "-Mover el número ", Matriz[FBlanco,CBlanco+1], " hacia la izquierda. Presione el número 6"
	FinSi
	
	Escribir ""
	Escribir Sin Saltar "Escoja su movimiento"
	Leer mov
	
	Segun mov Hacer
		8:
			si (abajo=Verdadero)
				Matriz[FBlanco,CBlanco]= Matriz[FBlanco-1,CBlanco] //donde se encuentra blanco se iguala al de la izquierda
				Matriz[FBlanco-1,CBlanco]=0 // se iguala y luego donde estaba el numero antes, se iguala al valor de blanco
			FinSi
		6:
			si (izquierda=Verdadero)
				Matriz[FBlanco,CBlanco]= Matriz[FBlanco,CBlanco+1] //donde se encuentra blanco se iguala al de la derecha
				Matriz[FBlanco,CBlanco+1]=0 // se iguala y luego donde estaba el numero antes, se iguala al valor de blanco
			FinSi
		4:
			si (derecha=Verdadero)
				Matriz[FBlanco,CBlanco]= Matriz[FBlanco,CBlanco-1] //donde se encuentra blanco se iguala al de abajo
				Matriz[FBlanco,CBlanco-1]=0// se iguala y luego donde estaba el numero antes, se iguala al valor de blanco
			FinSi
		2:
			si (arriba=Verdadero)
				Matriz[FBlanco,CBlanco]= Matriz[FBlanco+1,CBlanco] //donde se encuentra blanco se iguala al de arriba
				Matriz[FBlanco+1,CBlanco]=0 // se iguala y luego donde estaba el numero antes, se iguala al valor de blanco
			FinSi
		De Otro Modo:
			Escribir "Número equivocado. Movimiento inválido"
	FinSegun
FinSubProceso

Funcion verificarGanador(mGanadora, Matriz)//verifica al ganador, compara una matriz ordenada con la del usuario
	Definir coincidencias,i,j Como Entero
	definir gana Como Logico
	gana=falso
	coincidencias=0
	
	para i=0 hasta 3 Hacer
		para j=0 hasta 3 Hacer
			si (mGanadora[i,j]= Matriz[i,j]) // comparaacion de dos columans, una ordenada la otra no
				coincidencias= coincidencias+1 // se suman hasta que lleguen a la cantidad necesaria de coincidencias
			FinSi
		FinPara
	FinPara
	si (coincidencias= 16) Entonces//si es igual a 16 significa que todo esta en orden y gano
		gana=Verdadero
	SiNo
		gana= Falso
	FinSi
FinFuncion


Algoritmo Rompe_cabezas//algoritmos
	Definir contador, i,j,mGanadora,Matriz,movimientos Como Entero
	Dimension Matriz[4,4]
	Dimension mGanadora[4,4]
	Definir gano Como Logico
	
	contador=1
	Para i=0 hasta 3 Hacer//hacemos la matriz ordenadamente sumandole 1 al contador
		para j=0 hasta 3 Hacer
			mGanadora[i,j]= contador
			contador=contador+1
		FinPara
	FinPara
	
	mGanadora[3,3]= 0 //este valor es el valor del blanco
	juegoNuevo(Matriz) //inicia todos los valores, o los pone al azar
	matriz[3,3] = 0 //ultimo valor del blanco es igual a 0
	gano=Falso //inicia siendo falso para que siga repitiendose hasta que se vuelva verdadero
	movimientos=0 //cantodad de movimientos hechos por el usuario
	
	Repetir
		HacerMovimiento(Matriz,movimientos) //se mueve a hacer los movimientos
		movimientos=movimientos+1 //suma 1 movimiento y lo va mostrando
		verificarGanador(mGanadora,Matriz) //lo lleva a verificar
	Hasta Que gano= Verdadero
	
	si gano = Verdadero Entonces
		Escribir "GANASTE!!! Lo hizo en ", movimientos, " movimientos"
	FinSi
	
FinAlgoritmo