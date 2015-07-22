using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBook.BO;
using TeamBook.DAL;

namespace TeamBook.BAL
{
 public class clsBALTask:IDisposable
    {
     public void Dispose()
     { }
     public static ResultModel SaveTasks(string xmlTasks, string CreatedBy, string AssignedTo)
     {
         using (clsDALTask objclsDAL = new clsDALTask())
         {
             return objclsDAL.SaveTasks(xmlTasks, CreatedBy, AssignedTo);
         }

     }

    }
}
