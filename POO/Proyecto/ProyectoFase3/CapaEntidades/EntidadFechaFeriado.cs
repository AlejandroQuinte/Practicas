using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades {
    public class EntidadFechaFeriado {
        #region atributos
        private string id_fecha;
        private string fecha;
        private string motivo;
        private bool existe;
        #endregion atributos

        #region propiedades
        public string Id_fecha { get => id_fecha; set => id_fecha = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public string Motivo { get => motivo; set => motivo = value; }
        public bool Existe { get => existe; set => existe = value; }
        #endregion propiedades


        #region constructor
        public EntidadFechaFeriado(string id_fecha, string fecha, string motivo, bool existe) {
            this.Id_fecha = id_fecha;
            this.Fecha = fecha;
            this.Motivo = motivo;
            this.Existe = existe;
        }
        public EntidadFechaFeriado() {
            this.Id_fecha = string.Empty;
            this.Fecha = string.Empty;
            this.Motivo = string.Empty;
            this.Existe = false;
        }
        #endregion constructor
    }
}
