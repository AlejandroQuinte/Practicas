using System;

namespace Trabajo_11_AlejandroQuintero{
    public class Program{
        static void Main(string[] args){
            //Variables
            bool cero=true;
            double precio1 = 0;
            string destino1;
            string fechaSalida;
            string fechaRegreso;
            string descripcion;
            TourVacaciones[] ViajesAnuales = new TourVacaciones[5];

            TourVacaciones viaje1 = new TourVacaciones();

            for (int i = 0;i<5;i++){
                Console.WriteLine("Digite el Destino");
                destino1 = Console.ReadLine();

                while(cero){
                    Console.WriteLine("Introduzca el precio");
                    precio1 = Convert.ToDouble(Console.ReadLine());
                    cero = viaje1.comprobar(precio1);
                    if(cero){
                        Console.WriteLine("El precio introducido es igual a 0, debe ser otro numero, vuelva a digitarlo");
                    }
                }

                Console.WriteLine("Digite la fecha de salida");
                fechaSalida=Console.ReadLine();

                Console.WriteLine("Digite la fecha de regreso");
                fechaRegreso=Console.ReadLine();

                Console.WriteLine("Digite la descripcion del viaje");
                descripcion=Console.ReadLine();

                ViajesAnuales[i] = new TourVacaciones(destino1,precio1,fechaSalida,fechaRegreso,descripcion);
            }

            viaje1.mostradoDatos(ViajesAnuales);

            for (int i = 0; i < ViajesAnuales.Length; i++) {
                ViajesAnuales[i].mostrado();
            }

            //vehiculos

            var Vehiculos = new[]{
                new{Matricula="001122",Tipo="Automovil",Color="Verde",Año="2020" ,Fabricante="Volkswagen",Modelo="q7"},
                new{Matricula="001123",Tipo="SUB 4x2",Color="Negro",Año="2020" ,Fabricante="Volkswagen",Modelo="a21"},
                new{Matricula="001125",Tipo="Automovil",Color="Blanco",Año="2021" ,Fabricante="Toyota",Modelo="A23"},
                new{Matricula="001128",Tipo="SUB 4x2",Color="Rojo",Año="2021" ,Fabricante="Toyota",Modelo="Sa21"},
                new{Matricula="001126",Tipo="Automovil",Color="Amarillo",Año="2022" ,Fabricante="Honda",Modelo="SDA22"},
                new{Matricula="001124",Tipo="SUB 4x4",Color="Azul",Año="2022" ,Fabricante="Volkswagen",Modelo="GRFA22"}
            };

            foreach(var vehiculo in Vehiculos){
                Console.WriteLine($"La matricula del vehicula es: {vehiculo.Matricula}\nEl tipo de vehicula es: {vehiculo.Tipo}\nEl color del vehiculo es:{vehiculo.Color}" +
                $"\nEl año del vehiculo es: {vehiculo.Año}\nEl fabricante del vehiculo es: {vehiculo.Fabricante}\nEl modelo del vehiculo es: {vehiculo.Modelo}");
            }

            TourVacaciones.MostrarCantidadObjetos();

            }//Main


        }//Program
}//namespace