using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica
{
    internal class Program
    {
        static void Main(string[] args){

            int piesFondo, piesFrente;
            double metros1,metros2, metrosC;
            Console.WriteLine("Digite el frente en pies");
            piesFrente = int.Parse( Console.ReadLine());

            metros1 = piesFrente * 0.3048;

            Console.WriteLine("Digite el Fondo en pies");
            piesFondo = int.Parse(Console.ReadLine());

            metros2 = piesFrente * 0.3048;

            metrosC = metros1 * metros2;

            Console.WriteLine("El Area en metros cuadrados es: " + metrosC);

        }
    }
}
