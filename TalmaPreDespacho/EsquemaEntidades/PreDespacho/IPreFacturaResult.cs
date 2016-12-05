using EsquemaEntidades.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EsquemaEntidades.PreDespacho
{
    public class IPreFacturaResult
    {
        public bePreFactura Prefactura { get; set; }
        public beLog Logger { get; set; }
        public IPreFacturaResult()
        {}
        public IPreFacturaResult(bePreFactura prefactura, beLog logger) 
        {
            this.Prefactura = prefactura == null ? new bePreFactura() : prefactura;
            this.Logger = logger == null ? new beLog() : logger;
        }
    }
}
