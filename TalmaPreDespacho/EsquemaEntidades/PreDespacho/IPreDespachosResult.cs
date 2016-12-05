using EsquemaEntidades.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EsquemaEntidades.PreDespacho
{
    public class IPreDespachosResult
    {
        public List<bePreDespacho> Predespachos { get; set; }
        public beLog Logger { get; set; }
        public IPreDespachosResult()
        {}
        public IPreDespachosResult(List<bePreDespacho> predespachos, beLog logger) 
        {
            this.Predespachos = predespachos == null ? new List<bePreDespacho>() : predespachos;
            this.Logger = logger == null ? new beLog() : logger;
        }
    }
}
