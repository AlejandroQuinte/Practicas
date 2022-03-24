using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio03
{
    internal class Program
    {
        static void Main(string[] args){

            int num = 0, aprobaron = 0, reprobaron = 0;
            double num1;
            while (num != 10)
            {

                Console.WriteLine("Digite la nota " + num + " ");
                num1 = double.Parse(Console.ReadLine());
                if (num1 >= 70)
                {
                    aprobaron++;
                }
                else if (num1 < 70)
                {
                    reprobaron++;
                }

                if (num1>=1 && num1<=100) {
                    

                    num++;
                }
                else {
                    Console.WriteLine(" El numero digitado debe ser entre 1 o 100");
                    Console.WriteLine(" ");
                }

                
                
            }

            Console.WriteLine("Estudiantes aprobados: " + aprobaron + " Estudiantes reprobados: " + reprobaron);
            Console.ReadKey();

        }
    }
}
