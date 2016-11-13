using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace EsquemaEntidades.Perfiles
{
    [Serializable]
    [DataContract(IsReference = true)]
    public class beUsuario
    {
        [DataMember]
        public string CO_USUA{ get; set; }
        
        [DataMember]
        public string NO_USUA{ get; set; }

        [DataMember]
        public string AP_USUA{ get; set; }

        [DataMember]
        public string AM_USUA{ get; set; }

        [DataMember]
        public string PW_USUA{ get; set; }

        [DataMember]
        public string AL_USUA{ get; set; }

    }
}
