using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio04
{
    internal class Program
    {
        static void Main(string[] args){

            int num = 0, pares = 0, impares = 0, multiploTres = 0;
            double num1;
            while (num != 10)
            {
                Console.WriteLine("Digite un numero: ");
                num1 = double.Parse(Console.ReadLine());
                if (num1%2== 0)
                {
                    pares++;
                }
                else
                {
                    impares++;
                }

                if (num1%3== 0)
                {
                    multiploTres++;
                }
                

                num++;
            }

            Console.WriteLine("Pares: " + pares + " Impares: " + impares + " Multiplo de 3: " + multiploTres);
            Console.ReadKey();


        }
    }
}
