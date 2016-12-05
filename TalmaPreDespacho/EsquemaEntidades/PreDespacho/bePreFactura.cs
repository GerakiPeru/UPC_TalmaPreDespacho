using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Runtime.Serialization;

namespace EsquemaEntidades.PreDespacho
{
    public class bePreFactura
    {

        public string ID_GUIA { get; set; }

        public DateTime FE_EMISION { get; set; }

        public int NU_DIAS { get; set; }

        public double TI_CAMB { get; set; }

        public string CO_CLIE_FACT { get; set; }

        public string NO_CLIE_FACT { get; set; }

        public string DE_DIRE { get; set; }

        public double IM_VENT { get; set; }

        public double PC_DCTO { get; set; }

        public double IM_DCTO { get; set; }

        public double PC_IGVS { get; set; }

        public double IM_IGVS { get; set; }

        public double IM_TOTAL { get; set; }

        public double IM_TOTAL_DOL { get; set; }

        public string CO_USUA_CREA { get; set; }

        public DateTime FE_USUA_CREA { get; set; }

        public List<bePreFactura_Detalle> OB_DETALLE { get; set; }
    }
}