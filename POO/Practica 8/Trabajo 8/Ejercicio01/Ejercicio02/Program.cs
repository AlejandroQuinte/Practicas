using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio02
{
    internal class Program
    {
        static void Main(string[] args) {

            int mayores = 0, menores = 0, cero = 0;
            double num1;
            string eleccion="s";


            while (eleccion == "S" || eleccion == "s"){

                Console.WriteLine("Digite un numero: ");
                num1 = double.Parse(Console.ReadLine());
                if (num1 >= 100)
                {
                    mayores++;
                }
                else if (num1 < 100)
                {
                    menores++;
                }
                Console.WriteLine("Presione S si desea agregar un nuevo numero");
                Console.WriteLine("Presione N si NO desea agregar un nuevo numero");
                eleccion=Console.ReadLine();
            }

            Console.WriteLine("Mayores a 100: " + mayores + " Menores a 100: " + menores);
            Console.ReadKey();

        }
    }
}
