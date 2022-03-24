using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades {
    public class EntidadCurso {

        #region atributos
        private string id_curso;
        private int id_nota;
        private string id_idioma;
        private string nombreCurso;
        private int cantidadCursos;
        private int horasCurso;
        private int horasSincronicas;
        private int horasAsincronicas;
        private float precio;
        private bool existe;

        #endregion atributos

        #region propiedades
        public string Id_curso { get => id_curso; set => id_curso = value; }
        public int Id_nota { get => id_nota; set => id_nota = value; }
        public string Id_idioma { get => id_idioma; set => id_idioma = value; }
        public string NombreCurso { get => nombreCurso; set => nombreCurso = value; }
        public int CantidadCursos { get => cantidadCursos; set => cantidadCursos = value; }
        public int HorasCurso { get => horasCurso; set => horasCurso = value; }
        public int HorasSincronicas { get => horasSincronicas; set => horasSincronicas = value; }
        public int HorasAsincronicas { get => horasAsincronicas; set => horasAsincronicas = value; }
        public float Precio { get => precio; set => precio = value; }
        public bool Existe { get => existe; set => existe = value; }

        #endregion propiedades

        #region constructor
        public EntidadCurso(string id_curso, int id_nota, string id_idioma, string nombreCurso, int cantidadCursos, int horasCurso, int horasSincronicas, int horasAsincronicas, float precio, bool existe) {
            this.id_curso = id_curso;
            this.id_nota = id_nota;
            this.id_idioma = id_idioma;
            this.nombreCurso = nombreCurso;
            this.cantidadCursos = cantidadCursos;
            this.horasCurso = horasCurso;
            this.horasSincronicas = horasSincronicas;
            this.horasAsincronicas = horasAsincronicas;
            this.precio = precio;
            this.existe = existe;
        }

        public EntidadCurso() {
            this.id_curso = "";
            this.id_nota = 0;
            this.id_idioma = "";
            this.nombreCurso = "";
            this.cantidadCursos = 0;
            this.horasCurso = 0;
            this.horasSincronicas = 0;
            this.horasAsincronicas = 0;
            this.precio = 0;
            this.existe = false;
        }
        #endregion constructor


    }
}
