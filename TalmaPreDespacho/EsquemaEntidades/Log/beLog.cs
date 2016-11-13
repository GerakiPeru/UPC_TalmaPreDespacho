using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace EsquemaEntidades.Log
{
    [Serializable]
    [DataContract(IsReference = true)]
    public class beLogger
    {
        [DataMember]
        private string mensaje;
        [DataMember]
        public EstadoLogger Estado { get; set; }
        [DataMember]
        public int Registros { get; set; }

        [DataMember]
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

    [DataContract(Name = "EstadoLogger")]
    public enum EstadoLogger {
        [EnumMember]
        OK,
        [EnumMember]
        ERROR 
    };
}
