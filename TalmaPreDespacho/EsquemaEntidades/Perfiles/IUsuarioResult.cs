using EsquemaEntidades.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace EsquemaEntidades.Perfiles
{
    public class IUsuarioResult
    {
        public beUsuario Usuario { get; set; }
        public beLog Logger { get; set; }
        public IUsuarioResult()
        {}
        public IUsuarioResult(beUsuario usuario, beLog logger) 
        {
            this.Usuario = usuario==null ? new beUsuario(): usuario;
            this.Logger = logger == null ? new beLog() : logger;
        }
    }
}
