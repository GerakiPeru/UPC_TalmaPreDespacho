using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EsquemaEntidades.PreDespacho;
using EsquemaEntidades.Log;
using AccesoDatos.PreDespacho;
using System.Configuration;
using System.IO;

namespace LogicaNegocio.PreDespacho
{
    public class blTransaccion
    {
        public List<beTransaccion> GetTransacciones(string ID_GUIA, int ID_ARCH, out beLogger logger)
        {
            List<beTransaccion> ocol = new List<beTransaccion>();
            logger = new beLogger();
            try
            {
                daTransaccion da = new daTransaccion();
                ocol = da.GetTransacciones(ID_GUIA, ID_ARCH);
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

        public bool UpSert_Transaccion(beTransaccion be, out beLogger logger)
        {
            bool result;
            logger = new beLogger();
            try
            {
                if (be.BT_ARCH.Length > 0)
                {
                    string Base = ConfigurationManager.AppSettings["DIR_IMG_TRANS"].ToString();
                    string Web = ConfigurationManager.AppSettings["WEB_IMG_TRANS"].ToString();

                    DirectoryInfo dirInfo = new DirectoryInfo(string.Format(@"{0}\{1}", Base, be.ID_GUIA));
                    if (!dirInfo.Exists) dirInfo.Create();

                    if (be.RT_ARCH_FILE != null)
                    {
                        FileInfo fileInfo = new FileInfo(be.RT_ARCH_FILE);
                        if (!fileInfo.Exists) fileInfo.Delete();
                    }
                    else
                    {
                        string id = "0";
                        if (dirInfo.GetFiles().Count() > 0)
                            id = dirInfo.GetFiles().Max(f => f.Name.Split('.')[0]).ToString();
                        id = (Convert.ToInt32(id) + 1).ToString();
                        FileInfo fileInfo = new FileInfo(string.Format(@"{0}\{1}\{2}.{3}", Base, be.ID_GUIA, id, be.EX_ARCH));
                        if (fileInfo.Exists) fileInfo.Delete();
                        FileStream oFileStream = new FileStream(string.Format(@"{0}\{1}\{2}.{3}", Base, be.ID_GUIA, id, be.EX_ARCH), FileMode.Create);
                        oFileStream.Write(be.BT_ARCH, 0, be.BT_ARCH.Length - 1);
                        oFileStream.Close();
                        be.ID_ARCH = Convert.ToInt32(id);
                        be.RT_ARCH_FILE = "{0}" + string.Format(@"\{1}\{2}.{3}", Base, be.ID_GUIA, id, be.EX_ARCH);
                        be.RT_ARCH_WEB = "{0}" + string.Format(string.Format(@"/{1}/{2}.{3}", Web, be.ID_GUIA, id, be.EX_ARCH));
                    }
                }
                result = true;
                List<AccesoDatos.Configuracion.QueueTransact> queues = new List<AccesoDatos.Configuracion.QueueTransact>();
                daTransaccion da = new daTransaccion();
                queues.Add(da.UpSert_Transaccion(be));
                logger.Registros = da.ExecuteQueueTransactions(queues);
                logger.Estado = EstadoLogger.OK;
            }
            catch (Exception ex)
            {
                result = false;
                logger.Estado = EstadoLogger.ERROR;
                try
                {
                    if (be.BT_ARCH.Length > 0)
                    {
                        FileInfo fileInfo = new FileInfo(be.RT_ARCH_FILE);
                        if (fileInfo.Exists) fileInfo.Delete();
                    }
                }
                catch (Exception exception) { string step = exception.Message; }
                
                logger.Mensaje = ex.Message;
            }
            return result;
        }
    }
}
