using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Collections;

namespace AccesoDatos.Configuracion
{
    [DataContract(IsReference = true)]    
    public class QueueTransact
    {
        [DataMember]
        public ArrayList param { get; set; }
        [DataMember]
        public string procedure { get; set; }
        [DataMember]
        public int Timeout { get; set; }
    }
}
