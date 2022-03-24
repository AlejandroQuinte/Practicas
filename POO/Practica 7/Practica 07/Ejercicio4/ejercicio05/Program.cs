using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int MB;
            int Bit;
            int Byte;
            int Kilobyte;
           

            Console.WriteLine("Escriba los MB");
            MB = Int32.Parse(Console.ReadLine());

            Bit = (MB * 8000000); //info sacada de google
            Byte = (MB * 1048576);
            Kilobyte = (MB * 1000);
            double Gigabyte = ((double)MB / 1000);

            Console.WriteLine(MB + " MB son: " + Bit + " bit/s");
            Console.WriteLine(MB + " MB son: " + Byte + " byte/s");
            Console.WriteLine(MB + " MB son: " + Kilobyte + " kilobyte/s");
            Console.WriteLine(MB + " MB son: " + Gigabyte + " gigabyte/s");

            Console.ReadKey();
        }
    
    }
}
