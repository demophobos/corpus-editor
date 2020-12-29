using Newtonsoft.Json;

namespace Model.Query
{
    public class BaseQuery
    {
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
