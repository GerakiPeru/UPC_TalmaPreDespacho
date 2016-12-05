using EsquemaEntidades.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EsquemaEntidades.PreDespacho
{
    public class IGuiaResult
    {
        public beGuia Guia { get; set; }
        public beLog Logger { get; set; }
        public IGuiaResult()
        {}
        public IGuiaResult(beGuia usuario, beLog logger) 
        {
            this.Guia = usuario == null ? new beGuia() : usuario;
            this.Logger = logger == null ? new beLog() : logger;
        }
    }
}
