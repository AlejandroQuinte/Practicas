using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio4
{
    internal class Program
    {
        static void Main(string[] args){

            double horas, minutos, segundos,total;

            Console.WriteLine("Digite las horas");
            horas = double.Parse( Console.ReadLine());

            Console.WriteLine("Digite los minutos");
            minutos = double.Parse( Console.ReadLine());

            Console.WriteLine("Digite los segundos");    
            segundos = double.Parse( Console.ReadLine());

            total = horas * 3600;
            total = total + (minutos * 60);
            total = total + segundos;

            Console.WriteLine("La cantidad de segundos total es: "+total);

            Console.ReadKey();
        }
    }
}
