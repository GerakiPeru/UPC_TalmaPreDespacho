using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EsquemaEntidades.Log;
using AccesoDatos.PreDespacho;
using EsquemaEntidades.PreDespacho;

namespace LogicaNegocio.PreDespacho
{
    public class blGuia
    {
        public List<beGuia> GetGetGuia_Resumen(string ID_GUIA, out beLog logger)
        {
            List<beGuia> ocol = new List<beGuia>();
            logger = new beLog();
            try
            {
                daGuia da = new daGuia();
                ocol = da.GetGuia_Resumen(ID_GUIA);
                logger.Registros = ocol.Count;
                logger.Estado = "OK";
            }
            catch (Exception ex)
            {
                logger.Estado = "ERROR";
                if (ex.Message.Split('|').Length > 1)
                    logger.Mensaje = ex.Message.Split('|')[1];
                else
                    logger.Mensaje = ex.Message;

            }
            return ocol;
        }
    }
}
