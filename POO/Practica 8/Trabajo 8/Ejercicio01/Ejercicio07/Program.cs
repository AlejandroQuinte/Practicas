using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio07
{
    internal class Program
    {
        static void Main(string[] args){

            int num = 0;
            double total = 0, num1;
            while (num != 10)
            {
                Console.WriteLine(num + "-Digite un numero: ");
                num1 = double.Parse(Console.ReadLine());
                if (num1%2==0) {
                    total += num1;
                }
                

                num++;
            }

            Console.WriteLine("La suma total de pares es : " + total);
            Console.ReadKey();

        }
    }
}
