using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using EsquemaEntidades.Perfiles;
using EsquemaEntidades.Log;

namespace ComunicaServicioWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IsrvSeguridad" in both code and config file together.
    [ServiceContract]
    public interface IsrvSeguridad
    {
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "Session")]
        IUsuarioResult Valida_Usuario(string Usuario, string Clave);
        
    }
}
