using Newtonsoft.Json;

namespace Model.Query
{
    public class BaseQuery : IQuery
    {
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
