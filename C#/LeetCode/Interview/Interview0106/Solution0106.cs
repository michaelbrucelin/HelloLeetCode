using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0106
{
    public class Solution0106 : Interface0106
    {
        public string CompressString(string S)
        {
            StringBuilder result = new StringBuilder();
            int pl = 0, pr, len = S.Length;
            while (pl < len)
            {
                pr = pl;
                while (pr + 1 < len && S[pr + 1] == S[pl]) pr++;
                result.Append(S[pl]); result.Append((pr - pl + 1).ToString());
                if (result.Length >= len) return S;
                pl = pr + 1;
            }

            return result.ToString();
        }
    }
}
