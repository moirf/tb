using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamBook.BO
{
    public class Project : IDisposable
    {
        public int ProjectID { get; set; }
        public string Name { get; set; }
        public string ProjectManagerId { get; set; }
        public int StatusId { get; set; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
