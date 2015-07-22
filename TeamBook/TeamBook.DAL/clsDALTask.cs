using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBook.BO;
namespace TeamBook.DAL
{
   public class clsDALTask:IDisposable

    {
       public void Dispose()
       { }
       public ResultModel SaveTasks(string xmlTasks, string CreatedBy, string AssignedTo)
       {

           ResultModel model = new ResultModel();

           ResultModel ReturnValue = new ResultModel();
           //string ReturnValue = string.Empty;
           Database objDB = DatabaseFactory.CreateDatabase("TBConnectionSQL");
           using (DbCommand objCMD = objDB.GetStoredProcCommand("SaveTasks"))
           {

               objDB.AddInParameter(objCMD, "@XmlTasks", System.Data.DbType.Xml, xmlTasks);
               objDB.AddInParameter(objCMD, "@CreatedBy", System.Data.DbType.String, CreatedBy);
               objDB.AddInParameter(objCMD, "@AssignedTo", System.Data.DbType.String, AssignedTo);
               objDB.AddOutParameter(objCMD, "@ReturnID", DbType.String, 100);
               objDB.AddOutParameter(objCMD, "@ReturnStatus", DbType.Int32, 100);
               try
               {
                   objDB.ExecuteNonQuery(objCMD);
                   ReturnValue.Id = Convert.ToString(objDB.GetParameterValue(objCMD, "@ReturnID"));
                   ReturnValue.Message = Convert.ToString(objDB.GetParameterValue(objCMD, "@ReturnStatus"));
               }

               catch (Exception objEx)
               {
                   ReturnValue.Message = "0";
               }  // exeception 
           }
           return ReturnValue;
       }
    }
}
