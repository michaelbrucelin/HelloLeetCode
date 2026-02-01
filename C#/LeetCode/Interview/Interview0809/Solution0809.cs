using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0809
{
    public class Solution0809 : Interface0809
    {
        /// <summary>
        /// dfs
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<string> GenerateParenthesis(int n)
        {
            if (n == 0) return [];
            if (n == 1) return ["()"];

            List<string> result = [];
            int N = n << 1;
            char[] init = new char[N];
            Array.Fill(init, ')');
            dfs(init, 0, 0);

            return result;

            void dfs(char[] chars, int lcnt, int rcnt)
            {
                if (lcnt == n)
                {
                    result.Add(new string(chars));
                }
                else
                {
                    char[] _chars = new char[N];
                    Array.Copy(chars, _chars, N);
                    _chars[lcnt + rcnt] = '(';
                    dfs(_chars, lcnt + 1, rcnt);
                    if (lcnt > rcnt) dfs(chars, lcnt, rcnt + 1);
                }
            }
        }
    }
}
