using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Portafolio_10_AlejandroQuintero {
	internal class Program {
		static void Main(string[] args) {
			
			Libro libro = new Libro();
			Libro libro1 = new Libro();
			//Colocando setters
			//libro
			libro.setNombre("Don Quijote");
			libro.setAutor("Henry Fielding");
			libro.setColor("Rojo");
			libro.setCantidadPaginas(1365);
			//libro1
			libro1.setNombre("El Pato Viajero");
			libro1.setColor("Verde");
			libro1.setAutor("Pancho Lucas");
			libro1.setCantidadPaginas(400);
			//mostrando Getters
			//libro
			Console.WriteLine($"\nNombre Libro: {libro.getNombre()}");
			Console.WriteLine($"Libro Autor: {libro.getAutor()}");
			Console.WriteLine($"Color: {libro.getColor()}");
			Console.WriteLine($"Cantidad de Paginas: {libro.getCantidadPaginas()}");
			//libro1
			Console.WriteLine($"\nNombre Libro: {libro1.getNombre()}");
			Console.WriteLine($"Libro Autor: {libro1.getAutor()}");
			Console.WriteLine($"Color: {libro1.getColor()}");
			Console.WriteLine($"Cantidad de Paginas: {libro1.getCantidadPaginas()}");
			Console.ReadKey();

			Cliente cliente = new Cliente();
			Cliente cliente1 = new Cliente();

			//Colocando Setter
			//cliente
			cliente.setNombre("Paco");
			cliente.setApellido("Carrazco");
			cliente.setEdad(16);
			cliente.setFechaNacimiento("06/05/2005");
			//cliente1
			cliente1.setNombre("Lucas");
			cliente1.setApellido("Cambronero");
			cliente1.setEdad(18);
			cliente1.setFechaNacimiento("06/05/2003");

			//mostrando Getters
			//cliente
			Console.WriteLine($"\nNombre: {cliente.getNombre()}");
			Console.WriteLine($"Apellido: {cliente.getApellidos()}");
			Console.WriteLine($"Edad: {cliente.getEdad()}");
			Console.WriteLine($"Fecha de Nacimiento: {cliente.getFechaNacimiento()}");
			//cliente1
			Console.WriteLine($"\nNombre: {cliente1.getNombre()}");
			Console.WriteLine($"Apellido: {cliente1.getApellidos()}");
			Console.WriteLine($"Edad: {cliente1.getEdad()}");
			Console.WriteLine($"Fecha de Nacimiento: {cliente1.getFechaNacimiento()}");
			Console.ReadKey();


			}
		}
	


		public class Libro {
			//attributos
			private string nombre;
			private string color;
			private string autor;
			private int cantidadPaginas;

			//metodos
		//setter
			public void setNombre(string nombre) {
				this.nombre = nombre;
			}
			public void setColor(string color) {
				this.color = color;
			}
			public void setAutor(string autor) {
				this.autor = autor;
			}
			public void setCantidadPaginas(int cantidadPaginas) {
				this.cantidadPaginas = cantidadPaginas;
			}

		//getter
			public string getAutor() {
				return this.autor;
			}
			public string getColor() {
				return this.color;
            }
			public string getNombre() {
				return this.nombre;
            }
			public int getCantidadPaginas() {
				return this.cantidadPaginas;
            }
		

		}
		public class Cliente {
			//atributos
			private string nombre;
			private string apellidos;
			private int edad;
			private string fechaNacimiento;


			//metodos
		//setter
			public void setNombre(string nombre) {
				this.nombre = nombre;
			}
			
			public void setApellido(string apellidos) {
				this.apellidos = apellidos;
			}
			public void setEdad(int edad) {
				this.edad = edad;
			}
			public void setFechaNacimiento(string fechaNacimiento) {
				this.fechaNacimiento = fechaNacimiento;
			}
			public void setNombreCompleto(string nombre, string apellidos) {
				this.nombre = nombre;
				this.apellidos=apellidos;
			}

		//----Sobrecarga
			public void setInformacion(String nombre) {
				this.nombre=nombre;
			}

			public void setInformacion(string nombre, string apellidos, int edad) {
				this.nombre = nombre;
				this.apellidos = apellidos;
				this.edad = edad;
			} 
			public void setInformacion(string nombre, string apellidos, int edad,string fechaNacimiento) {
				this.nombre=nombre;
				this.apellidos=apellidos;
				this.edad=edad;
				this.fechaNacimiento=fechaNacimiento;
			}

		//metodo Con 3 sobrecarga
			public void cambioInformacion(string nombre, string apellidos, int edad,string fechaNacimiento) {
				if (edad > this.edad) {
					this.nombre=nombre;
					this.apellidos=apellidos;
					this.edad=edad;
					this.fechaNacimiento=fechaNacimiento;
				}
				else {
					Console.WriteLine("La edad nueva es menor a la edad que tenia no se puede editar ");
					Console.ReadKey();
				}

				if (apellidos != this.apellidos) {
					this.nombre=nombre;
					this.apellidos=apellidos;
					this.edad=edad;
					this.fechaNacimiento=fechaNacimiento;
				}
				else {
					Console.WriteLine("El apellido es igual al anterior no se puede editar");
					Console.ReadKey();
				}	
				if (nombre != this.nombre) {
					this.nombre=nombre;
					this.apellidos=apellidos;
					this.edad=edad;
					this.fechaNacimiento=fechaNacimiento;
				}
				else {
					Console.WriteLine("El nombre es igual al anterior no se puede editar");
					Console.ReadKey();
				}	
				
			}



		//getter
			public string getNombre() {
				return nombre;
			}
			public string getApellidos() {
				return apellidos;
			}
			public int getEdad() {
				return edad;
			}
			public string getFechaNacimiento() {
				return fechaNacimiento;
			}
			public string getNombreCompleto() {
				return $"Nombre Completo: {this.nombre} {this.apellidos}";
			}
			
			public string informacion() {
				return $"Nombre Completo: {this.nombre} {this.apellidos}\nEdad: {this.edad}\nFecha de Nacimiento {this.fechaNacimiento}";
			}
			
			
		}
		
	}
