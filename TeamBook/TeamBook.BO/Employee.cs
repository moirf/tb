using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamBook.BO
{
    public class Employee : IDisposable
    {
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int RoleId { get; set; }
        public string ManagerId { get; set; }
        public int StatusId { get; set; }



        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
