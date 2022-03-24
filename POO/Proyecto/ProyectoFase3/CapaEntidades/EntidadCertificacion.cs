using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades {
    public class EntidadCertificacion {

        #region atributos
        private string id_certificado;
        private int id_profesor;
        private string materia;
        private bool existe;
        #endregion atributos

        #region propiedades
        public string Id_certificado { get => id_certificado; set => id_certificado = value; }
        public int Id_profesor { get => id_profesor; set => id_profesor = value; }
        public string Materia { get => materia; set => materia = value; }
        public bool Existe { get => existe; set => existe = value; }
        #endregion propiedades


        #region constructor
        public EntidadCertificacion(string id_certificado, int id_profesor, string materia, bool existe) {
            this.id_certificado = id_certificado;
            this.id_profesor = id_profesor;
            this.materia = materia;
            this.existe = existe;
        }
        public EntidadCertificacion() {
            this.id_certificado = string.Empty;
            this.id_profesor = 0;
            this.materia = string.Empty;
            this.existe = false;
        }
        #endregion constructor
    }
}
