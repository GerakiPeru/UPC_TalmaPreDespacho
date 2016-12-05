using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace EsquemaEntidades.PreDespacho
{
    public class beGuia
    {
        public string ID_GUIA { get; set; }
        public string CO_ENTI_LINE { get; set; }
        public string NO_ENTI_LINE { get; set; }
        public string NU_VUEL { get; set; }
        public DateTime FE_LLEG_VUEL { get; set; }
        public string NU_MANI_HER { get; set; }
        public string NU_GUIA_MADR { get; set; }
        public string NU_GUIA_HIJA { get; set; }
        public int NU_BULT_RECI { get; set; }
        public double KG_RECI { get; set; }
        public string DE_CONTENIDO { get; set; }
        public string CO_CIUD_ORI { get; set; }
        public string CO_CIUD_DES { get; set; }
        public string NO_ENTI_CONC { get; set; }
        public string NO_ENTI_AGRE { get; set; }
        public DateTime FE_PRIMER_BULTO { get; set; }
        
    }
}
