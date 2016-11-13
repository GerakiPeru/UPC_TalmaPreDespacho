using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace AccesoDatos.Configuracion
{
    public class DAO
    {
        #region Atributos

        public Database db;

        public DAO()
        {

            db = DatabaseFactory.CreateDatabase(DAO_Temp.cnx == null ? "IMP" : DAO_Temp.cnx);
        }

        #endregion

        public int ExecuteQueueTransactions(List<QueueTransact> queues) 
        {
            int nresult = -1;
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                try
                {
                    foreach (QueueTransact queue in queues)
                    {
                        nresult = db.ExecuteNonQuery(transaction, queue.procedure, queue.param.ToArray());
                        if (nresult == -1)
                            break;
                    }
                    if (nresult == -1)
                    {
                        transaction.Rollback();
                    }
                    else
                    {
                        transaction.Commit();
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    nresult = -1;
                    throw ex;
                }
            }
            return nresult;            
        }
    }

    public static class DAO_Temp 
    {
        public static string cnx;
    }
}
