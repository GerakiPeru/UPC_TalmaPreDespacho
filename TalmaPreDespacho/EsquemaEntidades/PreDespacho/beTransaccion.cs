using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace EsquemaEntidades.PreDespacho
{
    [Serializable]
    [DataContract(IsReference = true)]
    public class beTransaccion
    {
        [DataMember]
        public string ID_GUIA { get; set; }
        [DataMember]
        public int ID_ARCH { get; set; }
        [DataMember]
        public string EX_ARCH { get; set; }        
        [DataMember]
        public DateTime? FE_ARCH_UPLOAD { get; set; }
        [DataMember]
        public string RT_ARCH_FILE { get; set; }
        [DataMember]
        public string RT_ARCH_WEB { get; set; }

        [DataMember]
        public double IM_ARCH { get; set; }
        [DataMember]
        public string ST_ARCH { get; set; }        
        [DataMember]
        public string OB_ARCH { get; set; }
        [DataMember]
        public string CO_USUA_CREA { get; set; }
        [DataMember]
        public DateTime? FE_USUA_CREA { get; set; }
        [DataMember]
        public string CO_USUA_MODI { get; set; }
        [DataMember]
        public DateTime? FE_USUA_MODI { get; set; }
        [DataMember]
        public byte[] BT_ARCH { get; set; }

    }
}
