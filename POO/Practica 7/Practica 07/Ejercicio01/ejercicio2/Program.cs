using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio2
{
    internal class Program
    {
        static void Main(string[] args){

            double salarioBase, comision,salarioTotal;

            Console.WriteLine("Digite el Salario base");
            salarioBase = Double.Parse(Console.ReadLine());

            Console.WriteLine("Digite las ventas totales");
            comision = Double.Parse(Console.ReadLine());

            salarioTotal = salarioBase + (comision / 100 * 10);

            Console.WriteLine("El salario bruto es: "+salarioTotal);

        }
    }
}
