using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3
{
    internal class Program
    {
        static void Main(string[] args){ 

            double ancho,largo,total;

            Console.WriteLine("Digite el Ancho del terreno");
            ancho = Console.ReadLine();

            largo = ancho+ancho;

            total = (largo*ancho)/2;

            Console.WriteLine("Los postes necesarios para cercar el terreno son: "+total);

        }
    }
}
