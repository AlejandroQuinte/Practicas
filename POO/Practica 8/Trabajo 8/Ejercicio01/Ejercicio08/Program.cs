using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio08
{
    internal class Program
    {
        static void Main(string[] args){

            int cantidad = 0;
            double num1 = 0, promedio = 0,suma=0;
            string eleccion = "s";


            while (eleccion == "S" || eleccion == "s")
            {

                Console.WriteLine("Digite un numero: ");
                num1 = double.Parse(Console.ReadLine());

                suma += num1;
                cantidad++;
                


                Console.WriteLine("Presione S si desea agregar un nuevo numero");
                Console.WriteLine("Presione N si NO desea agregar un nuevo numero");
                eleccion = Console.ReadLine();
            }
            promedio = suma / cantidad;

            Console.WriteLine("Cantidad de datos ingresados: " + cantidad+" Promedio de numeros: "+promedio);
            Console.ReadKey();

        }
    }
}
