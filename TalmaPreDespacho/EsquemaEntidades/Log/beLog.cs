using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace EsquemaEntidades.Log
{
    public class beLogger
    {
        private string mensaje;
        public EstadoLogger Estado { get; set; }
        public int Registros { get; set; }
        public string Mensaje 
        {
            get
            {
                return this.mensaje;
            }
            set
            {
                if (value.Split('|').Length > 1)
                    this.mensaje = value.Split('|')[1];
                else
                    this.mensaje = value;
            }
        }
    }

    public class beLog
    {
        private string mensaje;
        public string Estado { get; set; }
        public int Registros { get; set; }
        public string Mensaje
        {
            get
            {
                return this.mensaje;
            }
            set
            {
                if (value.Split('|').Length > 1)
                    this.mensaje = value.Split('|')[1];
                else
                    this.mensaje = value;
            }
        }

        public beLog() { }
        public beLog(string estado, string mensaje, int registros) 
        {
            this.Mensaje = mensaje;
            this.Estado = estado;
            this.Registros = registros;
        }
    }

    public enum EstadoLogger {
        OK,
        ERROR 
    };
}
