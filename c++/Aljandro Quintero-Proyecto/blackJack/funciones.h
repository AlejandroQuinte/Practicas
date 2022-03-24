
#include <stdio.h>
#include <stdlib.h>
#include <algorithm>
#include <cmath>
#include "estructuras.h"
#include <vector>
#include <time.h>


void llenado(cartas arreglo[52]) {
	int num = 1;
	for (int i = 0; i < 52; i++) {
		if (num < 15) {
			if (num == 14) {
				num = 1;
			}
			arreglo[i].numero = num;
			
			num++;
			if (i < 13) {
				arreglo[i].signo = "♣";
			}
			else if (i < 26) {
				arreglo[i].signo = "♠";
			}
			else if (i < 39) {
				arreglo[i].signo = "♥";
			}
			else {
				arreglo[i].signo = "♦";
			}
		}
	}
	
}
