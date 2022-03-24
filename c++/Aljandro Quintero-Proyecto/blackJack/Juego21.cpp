
#include "funciones.h"
#include <random>
#include <ctime>

bool mostrarJugador(vector<string>jugador,int sumaJugador, vector<int>&j,int movimientos) {
	int y=0,suma=0;
	bool mayor=false;
	cout << "\n\tJugador "<<movimientos<<"\n";//el dato de movimiento es el jugador que esta jugando actualmente
	for (string i : jugador) {
		cout << " | " << i;
	}

	for (int i = 0; i < j.size(); i++) {
		if (j[i] == 11) {//verifica si hay un Az si lo hay lo pone en true...
			mayor = true;
		}
		sumaJugador += j[i];

		if (mayor && sumaJugador > 21) {//comprueba si es mayor y a la vez tiene un Az entonces el Az valdria 1
			for (int k = 0; k < j.size(); k++) {
				if (j[k] == 11) {
					j[k] = 1;
				}
			}
			sumaJugador = j[0];
			i = 0;
			mayor = false;
		}
	}

	cout << "\n\nLa suma de sus cartas es: " << sumaJugador << "\n\n";

	if (sumaJugador>21) {//si una suma es mayor a 21 pierde automaticamente el juego y se termina el juego
		cout << "\n\nEl jugador "<< movimientos << " Perdio!!" << "\n\n"; 
		return true;
	}
	else if (sumaJugador==21) {
		cout << "\n\nEl jugador " << movimientos << " Gano!!!" << "\n\n";
		return true;
	}
	else {
		return false;
	}
	
}


int sumJugador(int sumaJugador, vector<int> &j, int movimientos) {//guarda los valores de las cartas
	bool mayor = false;
	for (int i = 0; i < j.size(); i++) {
		if (j[i] == 11) {//verifica si hay un Az si lo hay lo pone en true...
			mayor = true;
		}
		sumaJugador += j[i];

		if (mayor && sumaJugador > 21) {//comprueba si es mayor y a la vez tiene un Az entonces el Az valdria 1
			for (int k = 0; k < j.size(); k++) {
				if (j[k] == 11) {
					j[k] = 1;
				}
			}
			sumaJugador = j[0];
			i = 0;
			mayor = false;
		}
	}

	return sumaJugador;

}

void mostrarCartas(int movimiento, vector<string>jugador,
					vector<int>j) {//muestra las cartas de un jugador

	cout << "\nJugador "<<movimiento<<"\t\t";

		for (string i : jugador) {
			cout << " | " << i;
		}
}


string carta(int &cantidad, cartas arreglo[52],vector<int>&nums, vector<string>&signos, int &sum) {
	string dato;
	
	int ns = rand() % (cantidad);
	
	cantidad--;//resta 1 numero para cuando haga el numero random no de uno cerno al 52 cuando ya no hay tantos datos
	if (nums[ns]>10) {
		sum = 10;
	}
	else if(nums[ns]==1){
		sum = 11;//guarda un numero que se guardara en un vector que hara una suma para comprobar si da o esta cerca de 21
	}
	else {
		sum = nums[ns];
	}
	
	dato= to_string(nums[ns]) + signos[ns];//guarda lo que mostrará al jugador
	
	nums.erase(nums.begin()+ns);//borra los datos del vector
	signos.erase(signos.begin() + ns);//borra los datos del vector
	srand(time(NULL));
	return dato;

	
}

int main() {//recordatorio hacerlo con vectores despues
	int num, op=4,sumaJugador = 0, y = 1, pasar = 0, sum = 0, movimientos = 1, cantidad = 52;
	int jugarOtraVez;
	bool lleno = false,ganador=false;
	string cart;
	cartas arreglo[52];
	vector<int>nums(52);
	vector<string>signos(52);

	vector<string>jugador1(2);
	vector<string>jugador2(2);
	vector<string>jugador3(2);
	vector<int>j1(2);
	vector<int>j2(2);
	vector<int>j3(2);
	
	
	
	llenado(arreglo);//invoca a la funciona que hace un llenado de informacion de las caras
	for (int i = 0; i < 52; i++) {//guardamos los numeros en un nuevo arreglo
		nums[i] = arreglo[i].numero;
	}
	for (int i = 0; i < 52; i++) {//guardamos los signos en un nuevo arreglo
		signos[i] = arreglo[i].signo;
	}

	for (int i = 0; i < 2; i++) {//llenado de vectores de jugadores y sumas

		cart = carta(cantidad, arreglo, nums, signos, sum);
		jugador1[i] = cart;
		j1[i] = sum;//final del llenado del jugador 1

		cart = carta(cantidad, arreglo, nums, signos, sum);
		jugador2[i] = cart;
		j2[i] = sum;//final del llenado del jugador 2

		cart = carta(cantidad, arreglo, nums, signos, sum);
		jugador3[i] = cart;
		j3[i] = sum;//final del llenado del jugador 3

	}//Final del llenado de las primeras dos cartas del jugador

		cout << "\n\tCartas iniciales de todos los jugadores\n";
		cout << "\n\t\t";
		mostrarCartas(1, jugador1, j1);
		cout << "\n\t\t";
		mostrarCartas(2, jugador2, j2);
		cout << "\n\t\t";
		mostrarCartas(3, jugador3, j3);
		cout << "\n";
		system("pause");
		system("cls");

		do {
			sumaJugador = 0;
			cout << "\n";
			if (movimientos == 1) {
				ganador = mostrarJugador(jugador1, sumaJugador, j1, movimientos);
			}
			else if (movimientos == 2) {
				ganador = mostrarJugador(jugador2, sumaJugador, j2, movimientos);
			}
			else {
				ganador = mostrarJugador(jugador3, sumaJugador, j3, movimientos);
			}
			cout << "\n";
			if (!ganador) {
				cout << "\n\tEscoja una opcion";
				cout << "\n1 - Pedir una carta";
				cout << "\n2 - Paso";
				cout << "\n3 - Salir\n";
				cin >> op;
			}

			switch (op) {
			case 1:
				if (movimientos == 1) {
					cart = carta(cantidad, arreglo, nums, signos, sum);
					jugador1.push_back(cart);
					j1.push_back(sum);//suma de los numeros
					ganador = mostrarJugador(jugador1, sumaJugador, j1, movimientos);
					movimientos++;
				}
				else if (movimientos == 2) {
					cart = carta(cantidad, arreglo, nums, signos, sum);
					jugador2.push_back(cart);
					j2.push_back(sum);//suma de los numeros
					ganador = mostrarJugador(jugador2, sumaJugador, j2, movimientos);
					movimientos++;
				}
				else {
					cart = carta(cantidad, arreglo, nums, signos, sum);
					jugador3.push_back(cart);
					j3.push_back(sum);//suma de los numeros
					ganador = mostrarJugador(jugador3, sumaJugador, j3, movimientos);
					movimientos = 1;
				}
				pasar = 0;
				break;
			case 2:
				if (movimientos == 3) {
					movimientos = 1;
				}
				else {
					movimientos++;
				}
				pasar++;
				break;
			case 3:

				break;

				break;
			default:
				break;
			}

			if (pasar == 3) {
				op = 3;
			}
			if (ganador) {
				op = 3;
			}

			system("pause");
			system("cls");

		} while (op != 3);
		
		//guardado para comparar quien de los 3 datos gano
		int uno, dos, tres,gan=0;
		bool empate = false;
		int numeros[3];
		uno = sumJugador(sumaJugador, j1, movimientos);
		dos = sumJugador(sumaJugador, j2, movimientos);
		tres = sumJugador(sumaJugador, j3, movimientos);
		numeros[0] = uno;
		numeros[1] = dos;
		numeros[2] = tres;
		int mayor = numeros[0];

		if (uno == dos) {
			//cout << "\nEl jugador 1 y el 2 empataron";
			empate = true;
			gan = 1;
		}
		else if (uno == tres) {
			//cout << "\nEl jugador 1 y el 3 empataron";
			empate = true;
			gan = 2;
		}
		else if (dos == tres) {
			//cout << "\nEl jugador 2 y el 3 empataron";
			empate = true;
			gan = 3;
		}

		if (pasar == 3) {

			for (int i = 1; i < 3; i++) {//verifica quien gano???
				if (numeros[i] > mayor) {
					mayor = numeros[i];
				}
			}

			if (mayor == uno) {
				if (empate) {
					if (gan==1) {
						cout << "\nEl jugador 1 y el 2 empataron";
					}
					else if (gan == 2) {
						cout << "\nEl jugador 1 y el 3 empataron";
					}
					else if(gan==3){
						cout << "\nEl jugador 2 y el 3 empataron";
					}
				}
				else {
					cout << "\nEl jugador 1 es el ganador";
				}

			}
			else if (mayor == dos) {
				if (empate) {
					if (gan == 1) {
						cout << "\nEl jugador 1 y el 2 empataron";
					}
					else if (gan == 2) {
						cout << "\nEl jugador 1 y el 3 empataron";
					}
					else if (gan == 3) {
						cout << "\nEl jugador 2 y el 3 empataron";
					}
				}
				else {
					cout << "\nEl jugador 2 es el ganador";
				}

			}
			else if (mayor == tres) {
				if (empate) {
					if (gan == 1) {
						cout << "\nEl jugador 1 y el 2 empataron";
					}
					else if (gan == 2) {
						cout << "\nEl jugador 1 y el 3 empataron";
					}
					else if (gan == 3) {
						cout << "\nEl jugador 2 y el 3 empataron";
					}
				}
				else {
					cout << "\nEl jugador 3 es el ganador";
				}
			}		
			
		}

	return 0;
}