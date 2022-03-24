using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades {
    public class EntidadHorarioProfesor {
        #region atributos
        private int id_horarioProfesor;
        private int id_profesor;
        private string horaInicio;
        private string horaFinal;
        private string fechaInicio;
        private string fechaFinal;
        private string estado;
        private bool existe;
        #endregion atributos

        #region propiedades
        public int Id_horarioProfesor { get => id_horarioProfesor; set => id_horarioProfesor = value; }
        public int Id_profesor { get => id_profesor; set => id_profesor = value; }
        public string HoraInicio { get => horaInicio; set => horaInicio = value; }
        public string HoraFinal { get => horaFinal; set => horaFinal = value; }
        public string FechaInicio { get => fechaInicio; set => fechaInicio = value; }
        public string FechaFinal { get => fechaFinal; set => fechaFinal = value; }
        public string Estado { get => estado; set => estado = value; }
        public bool Existe { get => existe; set => existe = value; }
        #endregion propiedades


        #region constructor
        public EntidadHorarioProfesor(int id_horarioProfesor, int id_profesor, string horaInicio, string horaFinal, string fechaInicio, string fechaFinal, string estado, bool existe) {
            this.id_horarioProfesor = id_horarioProfesor;
            this.id_profesor = id_profesor;
            this.horaInicio = horaInicio;
            this.horaFinal = horaFinal;
            this.fechaInicio = fechaInicio;
            this.fechaFinal = fechaFinal;
            this.estado = estado;
            this.existe = existe;
        }

        public EntidadHorarioProfesor() {
            this.id_horarioProfesor = 0;
            this.id_profesor = 0;
            this.horaInicio = string.Empty;
            this.horaFinal = string.Empty;
            this.fechaInicio = string.Empty;
            this.fechaFinal = string.Empty;
            this.estado = string.Empty;
            this.existe = false;
        }
        #endregion constructor
    }
}
