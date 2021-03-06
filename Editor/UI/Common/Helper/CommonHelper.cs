using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helper
{
    public class CommonHelper
    {
        public static IEnumerable<int> Sequence(int n1, int n2)
        {
            while (n1 <= n2)
            {
                yield return n1++;
            }
        }
    }
}
