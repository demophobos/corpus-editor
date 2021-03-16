using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Report
{
    public class ChunkStatReportModel
    {
        public int Done { get; set; }
        public int InProgress { get; set; }
        public int Total
        {
            get
            {
                return Done + InProgress;
            }
        }
    }
}
