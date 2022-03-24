
#include <iostream>
#include <string>
#include <vector>
#include <time.h>
#include <vector>
#include <array>
#include "Funciones.h"


using namespace std;

void mostrarTablero(vector<string>tablero) {
	cout << "\n";
	for (string i : tablero) {
		cout << " " << i << " ";
	}
	cout << "\n";
}

void llenadoTablero(int elegido, vector<string>&j, vector<string>&tablero,int &num) {
	
	switch (elegido) {
	case 1:
		tablero.push_back(j[elegido - 1]);
		j.erase(j.begin() + elegido - 1);
		num--;
		break;
	case 2:
		tablero.push_back(j[elegido - 1]);
		j.erase(j.begin() + elegido - 1);
		num--;
		break;
	case 3:
		tablero.push_back(j[elegido - 1]);
		j.erase(j.begin() + elegido - 1);
		num--;
		break;
	case 4:
		tablero.push_back(j[elegido - 1]);
		j.erase(j.begin() + elegido - 1);
		num--;
		break;
	case 5:
		tablero.push_back(j[elegido - 1]);
		j.erase(j.begin() + elegido - 1);
		num--;
		break;
	case 6:
		tablero.push_back(j[elegido - 1]);
		j.erase(j.begin() + elegido - 1);
		num--;
		break;
	case 7:
		tablero.push_back(j[elegido - 1]);
		j.erase(j.begin() + elegido - 1);
		num--;
		break;
	default:
		cout << "\n\nDigito un numero incorrecto\n\n";
		break;
	}
}

int main() {
	vector<int> p(28);
	vector<string>j1(7);
	vector<string>j2(7);
	vector<string>j3(7);
	vector<string>j4(7);
	int conteo = 0, k = 0;;
	int num;
	int tam = 28;
	
	vector<string>f(tam);
	vector<string>tablero;
	int elegido;
	int n = 0;

	for (int i = 0; i < 7; i++) {
		for (int j = i; j < 7; j++) {
			f[n] = "|" + to_string(i) + "|" + to_string(j) + "|";
			n++;
		}
	}
	int h=0;
	tam = 28;
	n = 0;
	srand(NULL());
	num =15+ rand() % (27-15);
	do {

		if (tam > 21) {//meter datos en j1
			if (n == 7) {
				n = 0;
			}

			if (f.size() > num) {
				j1[n] = f[num];
				f.erase(f.begin() + num);
				
			}
			else {
				j1[n] = f[h];
				h++;
			}

			f.resize(tam);
		
			n++;
		}
		else if (tam > 14 && tam < 22) {//meter datos en j2

			if (n == 7) {
				n = 0;
			}
			
			if (f.size() > num-2) {
				j2[n] = f[num];
				f.erase(f.begin() + num);
			}
			else {
				j2[n] = f[h];
				f.erase(f.begin() + h);
				h++;
			}
			if (f.size() == 17) {
				num = 0;
			}
			f.resize(tam);
			
			n++;
		}
		else if (tam > 7 && tam < 15) {//meter datos en j3

			if (n == 7) {
				n = 0;
			}

			if (f.size() > num) {
				j3[n] = f[num];
				f.erase(f.begin() + num);
			}
			else {
				j3[n] = f[h];
				f.erase(f.begin() + h);
				h++;
			}
			if (f.size() == 17) {
				num = 0;
			}
			f.resize(tam);
			
			n++;
		}
		else if (tam < 8) {//meter datos en j4
			if (n == 7) {
				n = 0;
			}

			if (f.size() > num) {
				j4[n] = f[num];
				f.erase(f.begin() + num);
			}
			else {
				j4[n] = f[h];
				f.erase(f.begin() + h);
				h++;
			}
			if (f.size() == 17) {
				num = 0;
			}
			f.resize(tam);
			n++;
		}

		tam--;
	} while (tam > -1);
	//system("cls");

	cout << "Las fichas del jugador 1 son: \n";//mostrar las piezas del jugador
	for (string i : j1) {
		cout << i << " ";
	}
	
	
	cout << "\nLas fichas del jugador 2 son: \n";//mostrar las piezas del jugador
	for (string i : j2) {
		cout << i << " ";
	}
	
	cout << "\nLas fichas del jugador 3 son: \n";//mostrar las piezas del jugador
	for (string i : j3) {
		cout << i << " ";
	}
	
	
	cout << "\nLas fichas del jugador 4 son: \n";//mostrar las piezas del jugador
	for (string i : j4) {
		cout << i << " ";
	}
	cout << "\n\n";
	for (string i : f) {
		cout << i << " ";
	}
	cout << "\n\n";
	system("pause");//aqui empieza los movimientos arriba es el mostrado

	int uno=7, dos=7, tres=7, cuatro=7,turnos=1;
	do {
		system("cls");
		mostrarTablero(tablero); //muestra el valor del tablero
		
		if (turnos==1) {
			cout << "Turno del jugador " << turnos << " son: \n";
			for (int i = 0; i < uno; i++) {
				cout << i + 1 << "- Para colocar la ficha " << j1[i] << "\n";
			}
			cout << uno + 1 << "-Pasar\n";
			cin >> elegido;
			
			if (elegido == uno+1) {//verifica si el jugador elige es para pasar de movimiento
				turnos++;
			}
			else {
				llenadoTablero(elegido, j1, tablero, uno);//llena el tablero y elimina del cout<<
				turnos++;
			}
			
			if (uno==0) {
				break;
			}
		}
		else if (turnos==2) {
			cout << "Turno del jugador 2 son: \n";
			for (int i = 0; i < dos; i++) {
				cout << i + 1 << "- Para colocar la ficha " << j2[i] << "\n";
			}
			cout << dos + 1 << "-Pasar\n";
			cin >> elegido;

			if (elegido == dos + 1) {//verifica si el jugador elige es para pasar de movimiento
				turnos++;
			}
			else {
				llenadoTablero(elegido, j2, tablero, dos);//llena el tablero y elimina del cout<<
				turnos++;
			}
			if (dos == 0) {
				break;
			}
		}
		else if (turnos == 3) {

			cout << "Turno del jugador 3 son: \n";
			for (int i = 0; i < tres; i++) {
				cout << i + 1 << "- Para colocar la ficha " << j3[i] << "\n";
			}
			cout << tres + 1 << "-Pasar\n";
			cin >> elegido;


			if (elegido == tres + 1) {//verifica si el jugador elige es para pasar de movimiento
				turnos++;
			}
			else {
				llenadoTablero(elegido, j3, tablero, tres);//llena el tablero y elimina del cout<<
				turnos++;
			}
			if (tres == 0) {
				break;
			}
		}
		else if(turnos == 4) {

			cout << "Turno del jugador 4 son: \n";
			for (int i = 0; i < cuatro; i++) {
				cout << i + 1 << "- Para colocar la ficha " << j4[i] << "\n";
			}
			cout << cuatro + 1 << "-Pasar\n";
			cin >> elegido;


			if (elegido == cuatro + 1) {//verifica si el jugador elige es para pasar de movimiento
				turnos=1;
			}
			else {
				llenadoTablero(elegido, j4, tablero, cuatro);//llena el tablero y elimina del cout<<
				turnos=1;
			}
			if (cuatro == 0) {
				break;
			}
		}

		

	} while (uno > 0 || dos > 0 || tres > 0 || cuatro > 0);
	

}
