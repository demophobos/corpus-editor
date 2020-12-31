using Model;
using Model.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Process
{
    public class DocumentProcess
    {
        public HeaderModel Header { get; private set; }
        public DocumentProcess(HeaderModel header)
        {
            Header = header;
        }

        public async Task<List<IndexModel>> GetIndecesByHeader()
        {
            var query = new IndexByHeaderQuery { headerId = Header.Id };

            return await API.IndexAPI.GetIndeces(query);
        }

        public async Task<List<IndexModel>> GetIndecesByParent(string parentId)
        {
            var query = new IndexByParentQuery { parentId = parentId };

            return await API.IndexAPI.GetIndeces(query);
        }

        public async Task<IndexModel> SaveIndex(IndexModel inx)
        {
            return await API.IndexAPI.Save(inx);
        }

        public async Task<IndexModel> DeleteIndex(IndexModel index)
        {
            return await API.IndexAPI.Remove(index);
        }
    }
}
