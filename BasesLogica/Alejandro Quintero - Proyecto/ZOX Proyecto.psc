
SubProceso mostrarTablero(tablero) //mostrar tablero
	definir i,j Como Entero
	para i=0 hasta 7
		para j=0 hasta 7
			Escribir Sin Saltar " | " tablero[i,j]
		FinPara
		Escribir " | "
	FinPara
FinSubProceso

SubProceso buscarMov(tablero,mov Por Referencia) //busqueda de movimiento real que existe
	definir i,j Como Entero
	para i=0 hasta 7 //revisa donde se encuentra el movimiento
		para j=0 hasta 7
			si(tablero[i,j]=mov) //encontrado el dato de movimiento es que hay movimiento
				mov=""
			FinSi
		FinPara
	FinPara
	
	si(mov<>"")
		para i=0 hasta 7 //borra los movimientos que habrian o que mostró la pieza dicha
			para j=0 hasta 7
				si(tablero[i,j]="1 " o tablero[i,j]="2 "  o tablero[i,j]="3 " o tablero[i,j]="4 ") 
					tablero[i,j]="  "
				FinSi
			FinPara
		FinPara
	FinSi
FinSubProceso

SubProceso posPieza(tablero,indiceF Por Referencia,indiceC Por Referencia,op) //busqueda de posicion de pieza
	definir i,j Como Entero
	para i=0 hasta 7 //revisa donde se encuentra la pieza
		para j=0 hasta 7
			si(tablero[i,j]=op) //para encontrar el dato
				indiceF=i
				indiceC=j
			FinSi
		FinPara
	FinPara
FinSubProceso

SubProceso BorrarMov(tablero)
	definir i,j Como Entero
	para i=0 hasta 7 //borra los movimientos que habrian o que mostró la pieza dicha
		para j=0 hasta 7
			si(tablero[i,j]="1 " o tablero[i,j]="2 "  o tablero[i,j]="3 " o tablero[i,j]="4 ") 
				tablero[i,j]="  "
			FinSi
		FinPara
	FinPara
FinSubProceso

SubProceso opcionX(tablero,op,indiceC,indiceF,izquierda,derecha,ceroM,mov,movimiento,jugador Por Referencia) // envia datos a los demas subprocesos en los que hace
	// que cada SubProceso  haga sus partes luego al final muestra los datos, todos los movimientos de x son iguales y por eso es mejor en SubProceso 
	definir i,j Como Entero
	//donde se encuntra la posicion digitada
	para i=0 hasta 7 //revisa donde se encuentra la pieza
		para j=0 hasta 7
			si(tablero[i,j]=op) //para encontrar el dato
				indiceF=i
				indiceC=j
			FinSi
		FinPara
	FinPara
	//si hay dato en derecha o izquierda
	si(indiceC<>0 y indiceC<>8 y indiceF<>7) //evalua si hay un dato a la izquierda
		si(Subcadena(tablero[indiceF+1,indiceC-1],0,0)="X" o Subcadena(tablero[indiceF+1,indiceC-1],0,0)="Z")
			izquierda=Verdadero
		FinSi
	FinSi
	si(indiceC>=0 y indiceC<>7 y indiceF<>7) //evalua si hay un dato a la derecha
		si(Subcadena(tablero[indiceF+1,indiceC+1],0,0)="X" o Subcadena(tablero[indiceF+1,indiceC+1],0,0)="Z") 
			derecha=Verdadero 
		FinSi
	FinSi
	
	si(indiceF<>7) //si es diferente al final, entonces entra aqui
		//muestra los movimientos de x
		si(indiceC<>7 y indiceF<>7 y tablero[indiceF+1,indiceC+1]="  ") //abajo derecha
			tablero[indiceF+1,indiceC+1]="1 "
		FinSi
		si(indiceC<>0 y indiceF<>7 y tablero[indiceF+1,indiceC-1]="  ") // abajo izquierda
			tablero[indiceF+1,indiceC-1]="2 "
		FinSi
		
		si(derecha=Verdadero y izquierda=Verdadero o indiceC=7 y izquierda=Verdadero o derecha=Verdadero y indiceC=0) //evalua si tiene datos a los dos lados
			ceroM=Verdadero
		FinSi
		
		Limpiar Pantalla
		mostrarTablero(tablero) //muestra el tablero despues de colocar los movimientos
		
		si(ceroM=falso)
			Escribir "Digite hacia donde desea moverse"
			leer movimiento
			mov=convertirATexto(movimiento)+" " //le agrega un espacio porque en el tablero el dato 1 lleva un espacio a la derecha
			
			para i=0 hasta 7 //revisa donde se encuentra el movimiento
				para j=0 hasta 7
					si(tablero[i,j]=mov) //encontrado el dato de movimiento es que hay movimiento
						mov=""
					FinSi
				FinPara
			FinPara
			
			si(mov<>"")
				Escribir "Digitó un número incorrecto" 
				Esperar Tecla
				
				BorrarMov(tablero) //borra los movimientos creados
				jugador=1
			SiNo
				si(movimiento=1)
					tablero[indiceF,indiceC]="  "
					tablero[indiceF+1,indiceC+1]=op
					
					si(indiceC-1<>-1 y izquierda=falso) //solo borra sino esta a la izquierda izquierda
						tablero[indiceF+1,indiceC-1]="  " //borra el movimiento
					FinSi
					izquierda=falso
					mostrarTablero(tablero) //muestra el tablero
				FinSi
				si(movimiento=2) //si es dos ira hacia la izquierda e ira a cambiar los datos
					tablero[indiceF,indiceC]="  "
					tablero[indiceF+1,indiceC-1]=op
					
					si(indiceC+1<>8 y derecha=falso) //solo borra si no esta a la derecha derecha
						tablero[indiceF+1,indiceC+1]="  " //borra el movimiento
					FinSi
					derecha=Falso
					mostrarTablero(tablero) //muestra el tablero
				FinSi
				jugador=2
			FinSi
		SiNo
			Escribir ""
			Escribir "La pieza seleccionada no tiene mas movimientos"
			Escribir ""
			Esperar Tecla
		FinSi	
	SiNo
		Escribir ""
		Escribir "La pieza llego al final"
		Escribir ""
		Esperar Tecla	
	FinSi
FinSubProceso


Algoritmo JuegoZX
	//variables
	definir i,j,indiceC,indiceF,movimiento,p1,jugador Como Entero
	definir tablero,op,color,pos,mov Como Caracter
	definir derecha,izquierda,abajoI,abajoD,ceroM,gano Como Logico
	gano=falso
	op=""
	mov=""
	color=""
	pos=""
	movimiento=0
	jugador=1
	dimension tablero[8,8]
	//desarrollo
	mientras op=""
		para i=0 hasta 7 //llenado de tablero en datos vacios
			para j=0 hasta 7
				tablero[i,j]="  "
			FinPara
		FinPara
		
		Limpiar Pantalla
		Escribir "Digite que color desea ir, posicion 0.0 es blanco(B)"
		Escribir "Digite el color que desea ir posicion 0.1 es negro(N)"
		leer color
		color=Mayusculas(color)
		
		si(color="B")
			tablero[0,0]= "X "
			tablero[0,2] = "X1"
			tablero[0,4] = "X2"
			tablero[0,6] = "X3"
			mostrarTablero(tablero)
			
			Escribir "Digite la posicion del zorro(7.1 - 7.3 - 7.5 - 7.7)"
			leer pos
			segun pos
				"7.1":tablero[7,1] = "ZO" 
					  op="x"
				"7.3":tablero[7,3] = "ZO"
					  op="x"
				"7.5":tablero[7,5] = "ZO"
					  op="x"
				"7.7":tablero[7,7] = "ZO" 
					  op="x"
				De Otro Modo:
					Escribir "Digito una posicion incorrecta"
					Esperar Tecla
					op=""
			FinSegun
		SiNo
			si(color="N")
				tablero[0,1]= "X "
				tablero[0,3] = "X1"
				tablero[0,5] = "X2"
				tablero[0,7] = "X3"
				mostrarTablero(tablero)
				
				Escribir "Digite la posicion del zorro(7.0 - 7.2 - 7.4 - 7.6)"
				leer pos
				segun pos
					"7.0":tablero[7,0] = "ZO" 
						  op="x"
					"7.2":tablero[7,2] = "ZO" 
						  op="x"
					"7.4":tablero[7,4] = "ZO" 
						  op="x"
					"7.6":tablero[7,6] = "ZO" 
						  op="x"
					De Otro Modo:
						Escribir "Digito una posicion incorrecta"
						Esperar Tecla
						op=""
				FinSegun
			sino 
				Escribir "Digitó una letra incorrecta"
				Esperar Tecla
				op=""
			FinSi
		FinSi //revisa que posiciones escoje el jugador
	FinMientras 
	
	
	mientras op<>"S" y gano=falso
		abajoI=Falso //se reinicia el dato
		abajoD=Falso //se reinicia el dato
		izquierda=Falso //se reinicia el dato
		derecha=falso //se reinicia el dato
		ceroM=falso //se reinicia el dato
		
		Limpiar Pantalla
		mostrarTablero(tablero)
		
		op="ZO"
		posPieza(tablero,indiceF,indiceC,op)
		
		para i=0 hasta 7 //revisa donde se encuentra el primer x
			para j=0 hasta 7
				si(Subcadena(tablero[i,j],0,0)="X")
					p1=i
					i=7
					j=7
				FinSi
			FinPara
		FinPara
		
		si(indiceF<=p1) //revisa si gano debe ser menor porque el movimiento del ZO es hacia arriba
			gano=Verdadero
		FinSi
		
		si(gano=falso)//compara que gano, sino gano no escribe nada
			si(jugador=1)
				Escribir "Jugador 1"
				Escribir "Digite la pieza que desea mover(Xs)"
				Escribir "Digite S si desea salir"
				leer op
				op=Mayusculas(op)
			SiNo
				op="zo"
				op=Mayusculas(op)
			FinSi
		FinSi
		
		si(op="ZO" y jugador<>1)//datos del zorro, movimientos 4 posibles
			 
			posPieza(tablero,indiceF,indiceC,op)//define donde se encuentra la pieza seleccionada
			
			si(indiceC<>0 y indiceC<>8 y indiceF<>0) //evalua si hay un dato a la izquierda
				si(Subcadena(tablero[indiceF-1,indiceC-1],0,0)="X")
					izquierda=Verdadero
				FinSi
			FinSi
			
			si(indiceC>=0 y indiceC<>7 y indiceF<>0) //evalua si hay un dato a la derecha
				si(Subcadena(tablero[indiceF-1,indiceC+1],0,0)="X")
					derecha=Verdadero
				FinSi
			FinSi
			
			si(indiceC<>0 y indiceC<>8 y indiceF<>7) //evalua si hay un dato abajo a la izquierda
				si(Subcadena(tablero[indiceF+1,indiceC-1],0,0)="X")
					abajoI=Verdadero
				FinSi
			FinSi
			
			si(indiceC>=0 y indiceC<>7 y indiceF<>7) //evalua si hay un dato abajo a la derecha
				si(Subcadena(tablero[indiceF+1,indiceC+1],0,0)="X")
					abajoD=Verdadero
				FinSi
			FinSi
			
			si(indiceF<>0) //si es diferente al final, entonces entra aqui
				//muestra de movimientos posibles
				si(indiceC<>0 y indiceF<>7 y tablero[indiceF+1,indiceC-1]="  ") // abajo izquierda
					tablero[indiceF+1,indiceC-1]="4 "
				FinSi
				si(indiceC<>7 y indiceF<>7 y tablero[indiceF+1,indiceC+1]="  ") //abajo derecha
					tablero[indiceF+1,indiceC+1]="3 "
				FinSi
				si(indiceC<>0 y tablero[indiceF-1,indiceC-1]="  ") //izquierda
					tablero[indiceF-1,indiceC-1]="1 "
				FinSi
				si(indiceC<>7 y tablero[indiceF-1,indiceC+1]="  ") //derecha
					tablero[indiceF-1,indiceC+1]="2 "
				FinSi
				
				si(derecha=Verdadero y izquierda=Verdadero y abajoD=Verdadero y abajoI=Verdadero o indiceC=0 y derecha=Verdadero y abajoD=Verdadero o indiceC=7 y izquierda=Verdadero y abajoI=Verdadero) //evalua si tiene datos a los dos lados
					ceroM=Verdadero
				FinSi//comparaciones si perdio
				
				si(indiceF=7 y derecha=Verdadero y izquierda=Verdadero o indiceF=7 y indiceC=7 y izquierda=Verdadero o indiceF=7 y indiceC=0 y derecha=Verdadero)
					ceroM=Verdadero
				FinSi//mas comparaciones si perdio
				
				Limpiar Pantalla
				mostrarTablero(tablero) //muestra el tablero despues de colocar los movimiento
				
				si(ceroM=falso) //si es falto tiene algun movimiento puede derecha o izquierda
					Escribir "Jugador 2"
					Escribir "Digite donde desea mover"
					leer movimiento
					mov=convertirATexto(movimiento)+" " //le agrega un espacio porque en el tablero el dato 1 lleva un espacio a la derecha
					
					buscarMov(tablero,mov) //busqueda de si el movimiento dicho está en el tablero
					
					si(mov<>"") //si movimiento es diferente de "" es porque digito una pieza incorrecta
						Escribir "Digitó un número incorrecto" //pero debe volver a digitar movimiento y la pieza
						Esperar Tecla
						jugador=2
					SiNo				//el movimiento es posible
						si(movimiento=1)
							tablero[indiceF,indiceC]="  "
							tablero[indiceF-1,indiceC-1]="ZO" 
							
							BorrarMov(tablero) //borra los movimientos creados
							
							mostrarTablero(tablero) //muestra el tablero
						FinSi
						
						si(movimiento=2) //si es dos ira hacia la izquierda e ira a cambiar los datos
							tablero[indiceF,indiceC]="  "
							tablero[indiceF-1,indiceC+1]="ZO"
							
							BorrarMov(tablero) //borra los movimientos creados
							
							mostrarTablero(tablero) //muestra el tablero
						FinSi
						
						si(movimiento=3) //si es dos ira hacia la izquierda e ira a cambiar los datos
							tablero[indiceF,indiceC]="  "
							tablero[indiceF+1,indiceC+1]="ZO"
							
							BorrarMov(tablero) //borra los movimientos creados
							
							mostrarTablero(tablero) //muestra el tablero
						FinSi
						
						si(movimiento=4) //si es dos ira hacia la izquierda e ira a cambiar los datos
							tablero[indiceF,indiceC]="  "
							tablero[indiceF+1,indiceC-1]="ZO"
							
							BorrarMov(tablero) //borra los movimientos creados
							
							mostrarTablero(tablero) //muestra el tablero
						FinSi
						jugador=1
					FinSi
				SiNo //sino es asi, la pieza no tiene movimientos
					gano=Verdadero
				FinSi	
			SiNo //ya llego al final y gano
				gano=Verdadero
			FinSi
		FinSi //op="ZO"
		
		//movimientos del jugador 1 o las X
		si(op="X" y jugador=1)
			op=op+" "
			opcionX(tablero,op,indiceC,indiceF,izquierda,derecha,ceroM,mov,movimiento,jugador) //el dato mas importante que envia es el op, luego hace los cambios
		SiNo
			si(op="X1" y jugador=1)
				opcionX(tablero,op,indiceC,indiceF,izquierda,derecha,ceroM,mov,movimiento,jugador) //el dato mas importante que envia es el op, luego hace los cambios
			SiNo
				si(op="X2" y jugador=1)
					opcionX(tablero,op,indiceC,indiceF,izquierda,derecha,ceroM,mov,movimiento,jugador) //el dato mas importante que envia es el op, luego hace los cambios
				SiNo
					si(op="X3" y jugador=1)
						opcionX(tablero,op,indiceC,indiceF,izquierda,derecha,ceroM,mov,movimiento,jugador) //el dato mas importante que envia es el op, luego hace los cambios
					FinSi //op="X3"
				FinSi //op="X2"
			FinSi //op="X1"
		FinSi //op="X"
	FinMientras
	
	si(gano=Verdadero y jugador<>1)// el jugador 1 siempre es las X por lo que cuando gane siginifica que fue el quehizo el ultimo movimiento
		Limpiar Pantalla		// por lo que el jugador=2 entonces por eso el jugador<>1 para que funcione correctamente
		mostrarTablero(tablero)
		Escribir ""
		Escribir "Felicidades, gano el jugador 1 con las X"
		Escribir "" 
	SiNo
		si(gano=Verdadero y jugador=1)// el jugador 2 siempre es las ZO por lo que cuando gane siginifica que fue el que hizo el ultimo movimiento
			Limpiar Pantalla		// por lo que el jugador=1 entonces por eso el jugador=1 para que funcione correctamente
			mostrarTablero(tablero)
			Escribir ""
			Escribir "Felicidades, gano el jugador 2 con las ZO"
			Escribir "" 
		SiNo
			Escribir ""
			Escribir "El programa finalizo correctamente"
			Escribir ""
		FinSi
	FinSi
	
FinAlgoritmo
