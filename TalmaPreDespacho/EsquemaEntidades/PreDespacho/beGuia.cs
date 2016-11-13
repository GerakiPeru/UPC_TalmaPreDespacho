using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace EsquemaEntidades.PreDespacho
{
    [Serializable]
    [DataContract(IsReference = true)]
    public class beGuia
    {
        [DataMember]
        public string ID_GUIA { get; set; }
        [DataMember]
        public string CO_ENTI_LINE { get; set; }
        [DataMember]
        public string NO_ENTI_LINE { get; set; }
        [DataMember]
        public string NU_VUEL { get; set; }
        [DataMember]
        public DateTime FE_LLEG_VUEL { get; set; }
        [DataMember]
        public string NU_MANI_HER { get; set; }
        [DataMember]
        public string NU_GUIA_MADR { get; set; }
        [DataMember]
        public string NU_GUIA_HIJA { get; set; }
        [DataMember]
        public int NU_BULT_RECI { get; set; }
        [DataMember]
        public double KG_RECI { get; set; }
        [DataMember]
        public string DE_CONTENIDO { get; set; }
        [DataMember]
        public string CO_CIUD_ORI { get; set; }
        [DataMember]
        public string CO_CIUD_DES { get; set; }
        [DataMember]
        public string NO_ENTI_CONC { get; set; }
        [DataMember]
        public string NO_ENTI_AGRE { get; set; }
        [DataMember]
        public DateTime FE_PRIMER_BULTO { get; set; }
        
    }
}
