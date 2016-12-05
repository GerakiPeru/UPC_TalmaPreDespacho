using System;
using System.IO;
using System.Text;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Collections.Generic;
using EsquemaEntidades.Perfiles;
using EsquemaEntidades.Log;

namespace ComunicaServicioWCF
{

    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class srvSeguridad : IsrvSeguridad
    {
        public IUsuarioResult Valida_Usuario(string Usuario, string Clave)
        {
            List<beUsuario> lista = new List<beUsuario>();
            beUsuario be;
            beLog logger = null;
            be = new beUsuario() { CO_USUA = "00000000000001", AL_USUA = "agrey", NO_USUA = "Allan Davis", AP_USUA = "Grey", AM_USUA = "Ferrari", PW_USUA="12345678" };
            lista.Add(be);
            be = new beUsuario() { CO_USUA = "00000000000002", AL_USUA = "jjara", NO_USUA = "Julisa", AP_USUA = "Jara", AM_USUA = "Garro", PW_USUA = "02345678" };
            lista.Add(be);
            be = new beUsuario() { CO_USUA = "00000000000003", AL_USUA = "hvega", NO_USUA = "Hector", AP_USUA = "Vega", AM_USUA = "Gonzales", PW_USUA = "92345678" };
            lista.Add(be);

            be = null;
            foreach (var o in lista.Where(o => o.AL_USUA == Usuario.ToLower()).ToList())
            {
                if (o.PW_USUA != Clave) 
                {
                    logger = new beLog("ERROR", "La clave ingresada no pertenese al usuario", 0);
                    break;
                }
                logger = new beLog("OK", "", 1);
                be = o;
            }
            if (be == null)
                logger = new beLog("ERROR", "El usuario ingresado no se encuentra en la base de datos", 0);

            IUsuarioResult result = new IUsuarioResult(be, logger);
            return result;
        }
    }
}
