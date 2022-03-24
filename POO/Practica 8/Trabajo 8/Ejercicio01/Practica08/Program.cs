using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica08
{
    internal class Program
    {
        static void Main(string[] args) {
            int num = 0,positivo=0,negativo=0,cero=0;
            double num1;
            while (num!=20){
                Console.WriteLine("Digite un numero: ");
                num1 = double.Parse( Console.ReadLine());
                if (num1>0) {
                    positivo++;
                }else if (num1<0) {
                    negativo++;
                }
                else {
                    cero++;
                }

                num++;
            }

            Console.WriteLine("Positivos: "+positivo+" Negativos: "+negativo+" Ceros: "+cero);
            Console.ReadKey();
        }
    }
}
