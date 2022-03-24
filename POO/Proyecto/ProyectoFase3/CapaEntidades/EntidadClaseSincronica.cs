using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace CapaEntidades {
    public class EntidadClaseSincronica {

        #region atributos
        private int id_claseSincronica;
        private int id_estudiante;
        private int id_profesor;
        private string id_curso;
        private DateTime fechaClase;
        private DateTime horaInicio;
        private DateTime horaFinal;
        private bool existe;

        #endregion atributos

        #region propiedades
        public int Id_claseSincronica { get => id_claseSincronica; set => id_claseSincronica = value; }
        public int Id_estudiante { get => id_estudiante; set => id_estudiante = value; }
        public int Id_profesor { get => id_profesor; set => id_profesor = value; }
        public string Id_curso { get => id_curso; set => id_curso = value; }
        public DateTime FechaClase { get => fechaClase; set => fechaClase = value; }
        public DateTime HoraInicio { get => horaInicio; set => horaInicio = value; }
        public DateTime HoraFinal { get => horaFinal; set => horaFinal = value; }
        public bool Existe { get => existe; set => existe = value; }
        #endregion propiedades


        #region constructor
        public EntidadClaseSincronica(int id_claseSincronica, int id_estudiante, int id_profesor, string id_curso, DateTime fechaClase, DateTime horaInicio, DateTime horaFinal, bool existe) {
            this.id_claseSincronica = id_claseSincronica;
            this.id_estudiante = id_estudiante;
            this.id_profesor = id_profesor;
            this.id_curso = id_curso;
            this.fechaClase = fechaClase;
            this.horaInicio = horaInicio;
            this.horaFinal = horaFinal;
            this.existe = existe;
        }
        public EntidadClaseSincronica() {
            this.id_claseSincronica = 0;
            this.id_estudiante = 0;
            this.id_profesor = 0;
            this.id_curso = string.Empty;
            this.fechaClase = DateTime.Now;
            this.horaInicio = DateTime.Now;
            this.horaFinal = DateTime.Now;
            this.existe = false;
        }
        #endregion constructor
    }
}
