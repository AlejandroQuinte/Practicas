using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio5
{
    internal class Program
    {
        static void Main(string[] args){

            double horas=0, minutos=0, segundos=0, total;

            Console.WriteLine("Digite la cantidad de segundos");
            total = double.Parse(Console.ReadLine());


            horas = (int) total/3600;

            total = total % 3600;

            minutos = (int) total/60;

            total = total % 60;

            segundos += total;

            Console.WriteLine("Horas: "+horas+" Minutos: "+minutos+" Segundos: "+segundos);
            Console.ReadKey();
        }
    }
}
