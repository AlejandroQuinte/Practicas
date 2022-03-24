using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio11
{
    internal class Program
    {
        static void Main(string[] args){

            int cinco = 0, pares = 0, cantidadLeida=0;
            double num=1;
            Boolean completo=true;


            while (completo) {

                Console.WriteLine("Digite un numero positivo");
                num = int.Parse (Console.ReadLine());

                if (num%2==0)
                {
                    pares++;
                    if (pares == 10)
                    {
                        completo = false;
                    }
                      
                }else if (num==5)
                {
                    cinco++;
                    if (cinco == 4)
                    {
                        completo=false;
                    }
                    
                }

                cantidadLeida++;

            }

            Console.WriteLine("Cantidad Leida: "+cantidadLeida);
            Console.ReadKey();


        }
    }
}
