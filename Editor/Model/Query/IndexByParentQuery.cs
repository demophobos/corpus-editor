using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Query
{
    public class IndexByParentQuery : BaseQuery
    {
        public string parentId { get; set; }
    }
}
