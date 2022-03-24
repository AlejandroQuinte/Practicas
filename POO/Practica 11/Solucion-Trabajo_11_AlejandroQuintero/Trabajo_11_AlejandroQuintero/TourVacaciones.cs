using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_11_AlejandroQuintero {
    internal class TourVacaciones {
        //Atributos
        private int _idTour;
        private string _destino;
        private double _precio;
        private string _fechaSalida;
        private string _fechaRegreso;
        private string _descripcion;
        private static int cantidad=0;


        //Constructor
        public TourVacaciones( string destino, double precio, string fechaSalida, string fechaRegreso, string descripcion) {
            cantidad++;
            _idTour = cantidad;
            _destino = destino;
            _precio = precio;
            _fechaSalida = fechaSalida;
            _fechaRegreso = fechaRegreso;
            _descripcion = descripcion;
        }
        //Constructor vacio
        public TourVacaciones() {
            cantidad++;
            _idTour = cantidad;
            _destino = "";
            _precio = 0;
            _fechaSalida = "";
            _fechaRegreso = "";
            _descripcion = "";
        }
           
        //Setter / getter
        public int IdTour {
            get{ return _idTour; }
           
        }
        public string Destino { 
            get{ return _destino; } 
            set{ _destino = value; }
        }

        //Getter setter de precio
        
        public double precio {

            get{ return _precio; }
            
            set{ _precio = value; }
        }
        //Comprobar si el precio es = o != a cero
        public bool comprobar(double precio){
            
            bool cero;

            if (precio == 0) {
                cero = true;
            }
            else {
                cero = false;
            }
            return cero;
        }

        public string FechaSalida { get => _fechaSalida; set => _fechaSalida = value; }
        public string FechaRegreso { get => _fechaRegreso; set => _fechaRegreso = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }

        //metodo
        public void mostrado(){
            Console.WriteLine($"El id del tour es: {_idTour}\nEl destino del viaje es: {_destino}" +
            $"\nEl precio del viaje es: {_precio}\nLa fecha de salida es: {_fechaSalida}\nLa fecha de regreso es: {_fechaRegreso}" +
            $"\nY la descripcion del viaje es: {_descripcion}\n");
            Console.ReadKey();
        }
        public void mostradoDatos(TourVacaciones[] viajes) {
            for (int i = 0; i < viajes.Length; i++) {
                Console.WriteLine($"El id del tour es: {viajes[i].IdTour}\nEl destino del viaje es: {viajes[i].Destino}" +
                $"\nEl precio del viaje es: {viajes[i].precio}\nLa fecha de salida es: {viajes[i].FechaSalida}\nLa fecha de regreso es: {viajes[i].FechaRegreso}" +
                $"\nY la descripcion del viaje es: {viajes[i].Descripcion}\n");
                Console.ReadKey();
            }
            
        }

        //metodo statico
        public static void MostrarCantidadObjetos(){
            Console.WriteLine($"La cantidad de objetos existentes son: {cantidad}");
        }

    }//TourVacaciones
}//namespace
