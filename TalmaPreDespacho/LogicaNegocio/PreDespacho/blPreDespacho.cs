using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EsquemaEntidades.Log;
using EsquemaEntidades.PreDespacho;
using AccesoDatos.PreDespacho;


namespace LogicaNegocio.PreDespacho
{
    public class blPreDespacho
    {
        public List<bePreDespacho> GetPreDespachos(string ID_GUIA, string CO_USUA, string ST_PRE_DESPACHO, out beLogger logger)
        {
            List<bePreDespacho> ocol = new List<bePreDespacho>();
            logger = new beLogger();
            try 
            {
                daPreDespacho da = new daPreDespacho();
                ocol = da.GetPreDespachos(ID_GUIA, CO_USUA, ST_PRE_DESPACHO);
                logger.Registros = ocol.Count;
                logger.Estado = EstadoLogger.OK;
            }
            catch (Exception ex) 
            {
                logger.Estado = EstadoLogger.ERROR;
                if (ex.Message.Split('|').Length > 1)
                    logger.Mensaje = ex.Message.Split('|')[1];
                else
                    logger.Mensaje = ex.Message;
                
            }
            return ocol;
        }

        public bool SetGeneraPreDespacho(string ID_GUIA, string CO_USUA, DateTime? FE_RETI, out beLogger logger)
        {
            bool result;
            logger = new beLogger();
            try 
            {
                result = true;
                List<AccesoDatos.Configuracion.QueueTransact> queues = new List<AccesoDatos.Configuracion.QueueTransact>();
                daPreDespacho da = new daPreDespacho();
                queues.Add(da.SetGeneraPreDespacho(ID_GUIA, CO_USUA));
                queues.Add(new daPreFactura().SetGeneraPreFactura(ID_GUIA, FE_RETI, CO_USUA));
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

        public bool SetCancelaPreDespacho(string ID_GUIA, string CO_USUA, out beLogger logger)
        {
            bool result;
            logger = new beLogger();
            try
            {
                result = true;
                List<AccesoDatos.Configuracion.QueueTransact> queues = new List<AccesoDatos.Configuracion.QueueTransact>();
                daPreDespacho da = new daPreDespacho();
                queues.Add(da.SetCancelaPreDespacho(ID_GUIA, CO_USUA));
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
