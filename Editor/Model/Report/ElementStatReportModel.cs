using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Report
{
    public class ElementStatReportModel
    {
        public int Resolved { get; set; }
        public int Unresolved { get; set; }
        public int Total
        {
            get
            {
                return Resolved + Unresolved;
            }
        }
    }
}
