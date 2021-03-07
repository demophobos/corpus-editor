using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Process.Helper
{
    internal class BetaCodeConverter
    {
        Dictionary<string, string> _map = new Dictionary<string, string>();

        internal BetaCodeConverter()
        {
            _map = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(@"unicode_to_beta_code_wd.json"));
        }
        internal string UnicodeToGreekBetaCode(string unicodeInput)
        {

            var sb = new StringBuilder();

            foreach (var item in unicodeInput)
            {
                string value;

                _map.TryGetValue(item.ToString(), out value);

                sb.Append(value);
            }

            var res = sb.ToString().Normalize();

            return res;
        }
    }
}
