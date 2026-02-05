using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0085
{
    public class Solution0085 : Interface0085
    {
        /// <summary>
        /// DFS
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<string> GenerateParenthesis(int n)
        {
            List<string> result = new List<string>();
            char[] chars = new char[n << 1];
            Array.Fill(chars, ')');
            dfs(chars, 0, 0);

            return result;

            void dfs(char[] buffer, int lcnt, int rcnt)
            {
                if (lcnt == n) { result.Add(new string(buffer)); return; }
                if (lcnt > rcnt) dfs([.. buffer], lcnt, rcnt + 1);
                buffer[lcnt + rcnt] = '(';
                dfs(buffer, lcnt + 1, rcnt);
            }
        }

        /// <summary>
        /// 逻辑完全同GenerateParenthesis()，改为回溯
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<string> GenerateParenthesis2(int n)
        {
            List<string> result = new List<string>();
            char[] buffer = new char[n << 1];
            Array.Fill(buffer, ')');
            backtrack(0, 0);

            return result;

            void backtrack(int lcnt, int rcnt)
            {
                if (lcnt == n) { result.Add(new string(buffer)); return; }
                if (lcnt > rcnt) backtrack(lcnt, rcnt + 1);
                buffer[lcnt + rcnt] = '(';
                backtrack(lcnt + 1, rcnt);
                buffer[lcnt + rcnt] = ')';
            }
        }
    }
}
