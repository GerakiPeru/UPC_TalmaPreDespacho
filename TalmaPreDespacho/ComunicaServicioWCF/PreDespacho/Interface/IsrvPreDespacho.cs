using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using EsquemaEntidades.PreDespacho;
using EsquemaEntidades.Log;
using EsquemaEntidades.Perfiles;
using System.ServiceModel.Web;

namespace ComunicaServicioWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IsrvPreDespacho" in both code and config file together.
    [ServiceContract]
    public interface IsrvPreDespacho
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Guia/{Id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        IGuiaResult Guia(string Id);
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "PreFactura/{Id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        IPreFacturaResult GetPreFactura(string Id);
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "PreDespachos/{IdGuia}/{Estado}/Usuario/{Membresia}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        IPreDespachosResult GetPreDespachos(string IdGuia, string Membresia, string Estado);











        [OperationContract]
        bool SetGeneraPreDespacho(string ID_GUIA, string CO_USUA, DateTime? FE_RETI, out beLogger logger);



        [OperationContract]
        bool SetGeneraPreFactura(string ID_GUIA, DateTime? FE_SALI, string CO_USUA, out beLogger logger);

        [OperationContract]
        List<beTransaccion> GetTransacciones(string ID_GUIA, int ID_ARCH, out beLogger logger);

        [OperationContract]
        bool UpSert_Transaccion(beTransaccion be, out beLogger logger);

        [OperationContract]
        List<bePreDespacho_Documento> GetPreDespacho_Documentos(string ID_GUIA, int ID_ARCH, out beLogger logger);

        [OperationContract]
        bool UpSert_PreDespacho_Documento(bePreDespacho_Documento be, out beLogger logger);


    }
}
