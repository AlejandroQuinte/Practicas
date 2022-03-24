using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades {
    public class EntidadNotaMateria {
        #region atributos
        private int id_nota;
        private float nota;
        private string estado;
        private bool existe;

       


        #endregion atributos

        #region propiedades
        public int Id_nota { get => id_nota; set => id_nota = value; }
        public float Nota { get => nota; set => nota = value; }
        public string Estado { get => estado; set => estado = value; }
        public bool Existe { get => existe; set => existe = value; }
        #endregion propiedades


        #region constructor
        public EntidadNotaMateria(int id_nota, float nota, string estado, bool existe) {
            this.Id_nota = id_nota;
            this.Nota = nota;
            this.Estado = estado;
            this.Existe = existe;
        }
        public EntidadNotaMateria() {
            this.Id_nota = 0;
            this.Nota = 0;
            this.Estado = "REPROBADO";
            this.Existe = false;
        }
        #endregion constructor
    }
}
