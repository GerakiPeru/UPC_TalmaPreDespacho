using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace EsquemaEntidades.PreDespacho
{
    public class bePreFactura_Detalle
    {

        public string ID_GUIA { get; set; }

        public string CO_CPTO { get; set; }

        public string DE_CPTO { get; set; }

        public double IM_VENT { get; set; }

        public double PC_DCTO { get; set; }

        public double IM_DCTO { get; set; }

        public double PC_IGVS { get; set; }

        public double IM_IGVS { get; set; }

        public string CO_USUA_CREA { get; set; }

        public DateTime FE_USUA_CREA { get; set; }
    }
}