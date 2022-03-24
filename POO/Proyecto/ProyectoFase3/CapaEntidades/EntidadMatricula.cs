using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades {
    public class EntidadMatricula {

        #region atributos
        private int id_matricula;
        private int id_estudiantes;
        private string id_curso;
        private int intensidad;
        private DateTime fechamatricula;
        private float totalpago;
        private string estadopago;
        private bool existe;
        #endregion atributos

        #region propiedades
        public int Id_matricula { get => id_matricula; set => id_matricula = value; }
        public int Id_estudiantes { get => id_estudiantes; set => id_estudiantes = value; }
        public string Id_curso { get => id_curso; set => id_curso = value; }
        public int Intensidad { get => intensidad; set => intensidad = value; }
        public DateTime Fechamatricula { get => fechamatricula; set => fechamatricula = value; }
        public float Totalpago { get => totalpago; set => totalpago = value; }
        public string Estadopago { get => estadopago; set => estadopago = value; }
        public bool Existe { get => existe; set => existe = value; }
        #endregion propiedades


        #region constructor
        public EntidadMatricula(int id_matricula, int id_estudiantes, string id_curso, int intensidad, DateTime fechamatricula, float totalpago, string estadopago, bool existe) {
            this.id_matricula = id_matricula;
            this.id_estudiantes = id_estudiantes;
            this.id_curso = id_curso;
            this.intensidad = intensidad;
            this.fechamatricula = fechamatricula;
            this.totalpago = totalpago;
            this.estadopago = estadopago;
            this.existe = existe;
        }
        public EntidadMatricula() {
            this.id_matricula = 0;
            this.id_estudiantes = 0;
            this.id_curso = string.Empty;
            this.intensidad = 0;
            this.fechamatricula = DateTime.Now.Date;
            this.totalpago = 0;
            this.estadopago = string.Empty;
            this.existe=false;
        }

        #endregion constructor







    }
}
