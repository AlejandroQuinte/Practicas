using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Proyecto_LINQ_Clase {
    internal class Program {
        static void Main(string[] args) {

            ////Paso 1:dedfinir el origen de datos => arreglo
            //int[] valores = new int[] { 10, 20, 30 };

            ////paso 2: definir la consulta => creamops una variable que el tipo lo
            ////defina el compilador(definimos con la palabra VAR)
            //var consulta = from numeros in valores
            //               where numeros > 10
            //               select numeros;

            ////Paso 3: Ejecuutar consulta => for each
            //foreach (int numero in consulta) {
            //Console.WriteLine("Valor: "+numero);
            //}
            //    Console.ReadKey();


            //var productos = new[] {
            //new {id=1,descripcion="Arroz",precio=10000 },
            //new {id=3,descripcion="Frijoles",precio=10000},
            //new {id=4,descripcion="Atun",precio=10000 },
            //new {id=5,descripcion="cebolla",precio=10000 }

            //};
            //var consulta = from products in productos
            //               where products.id > 2
            //               select new { nombre = products.descripcion };

            //foreach (var i in consulta) {
            //    Console.WriteLine(i);
            //}
            //Console.ReadKey();



            var materias = new[] {
            new {cod="1",nombre="Español",creditos="11111111" },
            new {cod="2",nombre="Matematicas",creditos="11111111" },
            new {cod="3",nombre="Ingles",creditos="11111111" },
            new {cod="4",nombre="Religion",creditos="11111111" },
            new {cod="5",nombre="Frances",creditos="11111111" },
            new {cod="6",nombre="Estudios Sociales",creditos="11111111" }
            };
        
            //----
            var estudiantes = new[] {
            new {id="1",nombre="Luis",telefono=84878584 },
            new {id="2",nombre="Carlos",telefono=84878584  },
            new {id="3",nombre="Ana",telefono=84878584  },
            new {id="4",nombre="Alex",telefono=84878584  }
            };
          
            //-----

            var matricula = new[] {
            new {codMatricula="1",id_estudiante="1",cod_materia="1" },
            new {codMatricula="2",id_estudiante="2",cod_materia="2"},
           
            };

            var consultaMatricula = from matricula1 in matricula
                from estudiante in estudiantes
                where matricula1.id_estudiante == estudiante.id
                select new {
                    nombre = estudiante.nombre
                };

            foreach (var i in consultaMatricula) {
                Console.WriteLine(i);
            }
            Console.ReadKey();


            var consultaMatriculaNombre = from matricula1 in matricula
                from estudiante in estudiantes
                from materia in materias
                where matricula1.cod_materia == materia.cod
                select new {
                    nombre = estudiante.nombre,
                    materia = materia.nombre
                };

            foreach (var i in consultaMatriculaNombre) {
                Console.WriteLine(i);
            }
            Console.ReadKey();


            var consulta = from matri in matricula
                           join materia in materias
                           on matri.cod_materia equals materia.cod
                           group materia by materia.cod into Materia
                           select new {
                               ID = Materia.Key,
                               TotalMatriculas = matricula.Count()
                           };

            foreach (var i in consulta) {
                Console.WriteLine(i);
            }
            Console.ReadKey();




            //----------6


            var autos = new[] {
            new {cod=1,marca="Toyota",precio=40000,modelo=2020 },
            new {cod=2,marca="Honda",precio=30000,modelo=2020 },
            new {cod=3,marca="Toyota",precio=50000,modelo=2022 },
            new {cod=4,marca="Honda",precio=35000,modelo=2022 },
            new {cod=5,marca="Toyota",precio=45000,modelo=2021 },
            new {cod=6,marca="Toyota",precio=37000,modelo=2019 }
            };

            var consultaA = from aut in autos
                            select new {
                               
                            };

            foreach (var i in consultaA) {
                Console.WriteLine(i);
            }
            Console.ReadKey();

        }
    }
}
