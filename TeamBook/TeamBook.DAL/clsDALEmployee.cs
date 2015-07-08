using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamBook.DAL
{
    public class clsDALEmployee : IDisposable
    {
        public void Dispose()
        { }
        /// <summary>
        /// This function used to Get the Employee Details List.
        /// all parameters are optional
        /// </summary>
        /// <param name="SearchText"></param>
        /// <param name="PageNumber"></param>
        /// <param name="PageSize"></param>
        /// <param name="SortBy"></param>
        /// <returns></returns>
        public DataTable GetEmployeeDetailsByEmployeeId(string EmployeeId)
        {
            DataTable dtDetailsList = new DataTable();
            Database objDB = DatabaseFactory.CreateDatabase("TBConnectionSQL");
            using (DbCommand objCMD = objDB.GetStoredProcCommand("GetEmployeeDetailsByEmployeeId"))
            {
                objDB.AddInParameter(objCMD, "@EmployeeId", System.Data.DbType.String, EmployeeId);
                try
                {
                    dtDetailsList = objDB.ExecuteDataSet(objCMD).Tables[0];
                }
                catch (Exception ex)
                {
                   // TeamBook.DAL.Common.clsDALErrorHandler.WriteError(ex);
                }
            }
            return dtDetailsList;

        }
    }
}
