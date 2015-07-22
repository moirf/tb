using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamBook.BO
{
    public class Feedback : IDisposable
    {
        public long FeedbackId { get; set; }
        public long TaskId { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public int StatusId { get; set; }



        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
