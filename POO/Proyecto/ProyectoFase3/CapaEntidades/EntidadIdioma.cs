using System;

namespace CapaEntidades {
    public class EntidadIdioma {

        #region atributos
        private string idIdioma;
        private string nombreIdioma;
        private bool existe;
        #endregion atributos

        #region propiedades
        public string IdIdioma { get => idIdioma; set => idIdioma = value; }
        public string NombreIdioma { get => nombreIdioma; set => nombreIdioma = value; }
        public bool Existe { get => existe; set => existe = value; }

        #endregion propiedades


        #region constructor
        public EntidadIdioma(string idioma, string nombreIdioma) {
            this.idIdioma = idioma;
            this.nombreIdioma = nombreIdioma;
        }

        public EntidadIdioma() {
            this.idIdioma = "";
            this.nombreIdioma = "";
        }
        #endregion constructor



        //-------------------------------------------
        //Prueba de datos 
        #region Metodos Funcionales
        public override string ToString() // override es SOBREESCRIBIR
        {
            return string.Format("{0} - {1}", idIdioma, nombreIdioma);
        }
        #endregion Metodos Funcionales

    }
}
