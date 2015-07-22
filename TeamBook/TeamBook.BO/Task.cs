using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamBook.BO
{
    public class Task : IDisposable
    {

        public long TaskId { get; set; }
        public int ProjectId { get; set; }
        public string Description { get; set; }
        public string TimeTaken { get; set; }
        public string CreatedDate { get; set; }
        public int StatusId { get; set; }
        public string CreatedBy { get; set; }
        public string AssignedTo { get; set; }


        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
