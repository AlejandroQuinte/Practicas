using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio09
{
    internal class Program
    {
        static void Main(string[] args){

            int cantidad = 0;
            Boolean entro=false;
            double num1=0;
            string eleccion = "s";


            while (eleccion == "S" || eleccion == "s" && !entro)
            {

                Console.WriteLine("Digite un numero: ");
                num1 = double.Parse(Console.ReadLine());

                if (num1%5==0) { 
                    entro= true;
                }
                else{
                    cantidad++;
                }
                

                //Console.WriteLine("Presione S si desea agregar un nuevo numero");
                //Console.WriteLine("Presione N si NO desea agregar un nuevo numero");
                //eleccion = Console.ReadLine();
            }

            Console.WriteLine("Cantidad de datos ingresados: "+cantidad);
            Console.ReadKey();

        }
    }
}
