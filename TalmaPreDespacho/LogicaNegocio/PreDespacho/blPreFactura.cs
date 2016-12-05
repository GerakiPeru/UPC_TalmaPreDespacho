using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EsquemaEntidades.Log;
using EsquemaEntidades.PreDespacho;
using AccesoDatos.PreDespacho;

namespace LogicaNegocio.PreDespacho
{
    public class blPreFactura
    {
        public List<bePreFactura> GetPreFactura(string ID_GUIA, out beLog logger)
        {
            List<bePreFactura> ocol = new List<bePreFactura>();
            logger = new beLog();
            try
            {
                daPreFactura da = new daPreFactura();
                ocol = da.GetPreFactura(ID_GUIA);
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

        public bool SetGeneraPreFactura(string ID_GUIA, DateTime? FE_SALI, string CO_USUA, out beLogger logger)
        {
            bool result;
            logger = new beLogger();
            try
            {
                result = true;
                List<AccesoDatos.Configuracion.QueueTransact> queues = new List<AccesoDatos.Configuracion.QueueTransact>();
                daPreFactura da = new daPreFactura();
                queues.Add(da.SetGeneraPreFactura(ID_GUIA, FE_SALI, CO_USUA));
                logger.Registros = da.ExecuteQueueTransactions(queues);
                logger.Estado = EstadoLogger.OK;
            }
            catch (Exception ex)
            {
                result = false;
                logger.Estado = EstadoLogger.ERROR;
                logger.Mensaje = ex.Message;
            }
            return result;
        }

    }
}
