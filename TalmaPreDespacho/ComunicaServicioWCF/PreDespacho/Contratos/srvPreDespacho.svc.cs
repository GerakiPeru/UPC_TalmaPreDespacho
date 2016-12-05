using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Activation;
using EsquemaEntidades.PreDespacho;
using LogicaNegocio.PreDespacho;
using EsquemaEntidades.Log;
using EsquemaEntidades.Perfiles;

namespace ComunicaServicioWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "srvPreDespacho" in code, svc and config file together.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class srvPreDespacho : IsrvPreDespacho
    {
        public IGuiaResult Guia(string Id)
        {
            beGuia be = new beGuia();            
            blGuia bl = new blGuia();
            beLog logger = new beLog();
            foreach (beGuia guia in bl.GetGetGuia_Resumen(Id, out logger))
                be = guia;
            IGuiaResult result = new IGuiaResult(be, logger);
            return result;
        }
        public IPreFacturaResult GetPreFactura(string Id)
        {
            bePreFactura be = new bePreFactura();
            blPreFactura bl = new blPreFactura();
            beLog logger = new beLog();
            foreach (bePreFactura prefactura in bl.GetPreFactura(Id, out logger))
                be = prefactura;
            IPreFacturaResult result = new IPreFacturaResult(be, logger);
            return result;
        }
        public IPreDespachosResult GetPreDespachos(string IdGuia, string Membresia, string Estado)
        {
            List<bePreDespacho> ocol = new List<bePreDespacho>();
            blPreDespacho bl = new blPreDespacho();
            beLog logger = new beLog();
            ocol = bl.GetPreDespachos(IdGuia.Trim(), Membresia, Estado.Trim(), out logger);
            IPreDespachosResult result = new IPreDespachosResult(ocol, logger);
            return result;
        }














        public bool SetGeneraPreDespacho(string ID_GUIA, string CO_USUA, DateTime? FE_RETI, out beLogger logger) 
        {
            bool result;
            blPreDespacho bl = new blPreDespacho();
            result = bl.SetGeneraPreDespacho(ID_GUIA, CO_USUA, FE_RETI, out logger);
            return result;
        }

        public bool SetGeneraPreFactura(string ID_GUIA, DateTime? FE_SALI, string CO_USUA, out beLogger logger) 
        {
            bool result;
            blPreFactura bl = new blPreFactura();
            result = bl.SetGeneraPreFactura(ID_GUIA, FE_SALI, CO_USUA, out logger);
            return result;
        }

        public List<beTransaccion> GetTransacciones(string ID_GUIA, int ID_ARCH, out beLogger logger) 
        {
            List<beTransaccion> ocol = new List<beTransaccion>();
            blTransaccion bl = new blTransaccion();
            ocol = bl.GetTransacciones(ID_GUIA, ID_ARCH, out logger);
            return ocol;
        }

        public bool UpSert_Transaccion(beTransaccion be, out beLogger logger) 
        {
            bool result;
            blTransaccion bl = new blTransaccion();
            result = bl.UpSert_Transaccion(be, out logger);
            return result;
        }

        public List<bePreDespacho_Documento> GetPreDespacho_Documentos(string ID_GUIA, int ID_ARCH, out beLogger logger)
        {
            List<bePreDespacho_Documento> ocol = new List<bePreDespacho_Documento>();
            blPreDespacho_Documento bl = new blPreDespacho_Documento();
            ocol = bl.GetPreDespacho_Documentos(ID_GUIA, ID_ARCH, out logger);
            return ocol;
        }

        public bool UpSert_PreDespacho_Documento(bePreDespacho_Documento be, out beLogger logger)
        {
            bool result;
            blPreDespacho_Documento bl = new blPreDespacho_Documento();
            result = bl.UpSert_PreDespacho_Documento(be, out logger);
            return result;
        }


    }
}
