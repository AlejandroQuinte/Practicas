using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio05
{
    internal class Program
    {
        static void Main(string[] args){

            int cantidadLeidad=0, negativos=0, num;

            while (negativos != 5){
                Console.WriteLine("Digite un numero");
                num=int.Parse( Console.ReadLine());

                if (num < 0) {
                    negativos++;
                }
                else{

                }

                cantidadLeidad++;

            }
            Console.WriteLine("Cantidad leida : "+cantidadLeidad);
            Console.ReadKey();
        }
    }
}
