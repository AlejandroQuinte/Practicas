using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio6
{
    internal class Program
    {
        static void Main(string[] args){

            double salario, aguinaldo,total=0;

            Console.WriteLine("Digite el salario 1 del trabajador");
            salario = double.Parse(Console.ReadLine());
            total = total + salario;

            Console.WriteLine("Digite el salario 2 del trabajador");
            salario = double.Parse(Console.ReadLine());
            total = total + salario;

            Console.WriteLine("Digite el salario 3 del trabajador");
            salario = double.Parse(Console.ReadLine());
            total = total + salario;

            Console.WriteLine("Digite el salario 4 del trabajador");
            salario = double.Parse(Console.ReadLine());
            total = total + salario;

            Console.WriteLine("Digite el salario 5 del trabajador");
            salario = double.Parse(Console.ReadLine());
            total = total + salario;

            Console.WriteLine("Digite el salario 6 del trabajador");
            salario = double.Parse(Console.ReadLine());
            total = total + salario;

            Console.WriteLine("Digite el salario 7 del trabajador");
            salario = double.Parse(Console.ReadLine());
            total = total + salario;

            Console.WriteLine("Digite el salario 8 del trabajador");
            salario = double.Parse(Console.ReadLine());
            total = total + salario;

            Console.WriteLine("Digite el salario 9 del trabajador");
            salario = double.Parse(Console.ReadLine());
            total = total + salario;

            Console.WriteLine("Digite el salario 10 del trabajador");
            salario = double.Parse(Console.ReadLine());
            total = total + salario;

            Console.WriteLine("Digite el salario 11 del trabajador");
            salario = double.Parse(Console.ReadLine());
            total = total + salario;

            Console.WriteLine("Digite el salario 12 del trabajador");
            salario = double.Parse(Console.ReadLine());
            total = total + salario;

            aguinaldo = total / 12;

            Console.WriteLine("El aguinaldo del trabajador es: "+aguinaldo);
           Console.ReadKey();
        }
    }
}
