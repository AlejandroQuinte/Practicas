using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio10
{
    internal class Program
    {
        static void Main(string[] args){

            int  adultos = 0, mayores = 0, niños = 0, jovenes=0,adolecentes=0;
            double num1 = 0;
            string eleccion = "s";


            while (eleccion == "S" || eleccion == "s")
            {

                Console.WriteLine("Digite la edad del asistente: ");
                num1 = double.Parse(Console.ReadLine());

                if (num1>=1 && num1<=10) {
                    niños++;
                }
                else if(num1 >= 11 && num1 <= 15)
                {
                adolecentes++;
                }
                else if (num1 >= 16 && num1 <= 22)
                {
                    jovenes++;
                }
                else if (num1 >= 23 && num1 <= 65)
                {
                    adultos++;
                }
                else if (num1 >= 66 && num1<120)
                {
                    mayores++;
                }
                else
                {
                    Console.WriteLine("Digito una edad incorrecta");
                }



                Console.WriteLine("Presione S si desea agregar un nuevo asistente");
                Console.WriteLine("Presione N si NO desea agregar un nuevo asistente");
                eleccion = Console.ReadLine();
            }

            Console.WriteLine("Niños: " + niños +" Adolecentes: "+adolecentes+ " Jovenes: " + jovenes+" Adultos: "+adultos+" Adultos Mayores: "+mayores);
            Console.ReadKey();

        }
    }
}
