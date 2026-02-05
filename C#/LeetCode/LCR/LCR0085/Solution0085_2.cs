using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0085
{
    public class Solution0085_2 : Interface0085
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<string> GenerateParenthesis(int n)
        {
            List<string> result = new List<string>();
            Queue<(char[], int, int)> queue = new Queue<(char[], int, int)>();
            char[] init = new char[n << 1];
            Array.Fill(init, ')');
            queue.Enqueue((init, 0, 0));
            char[] chars; int cnt, lcnt, rcnt;
            while ((cnt = queue.Count) > 0) for (int i = 0; i < cnt; i++)
                {
                    (chars, lcnt, rcnt) = queue.Dequeue();
                    if (lcnt == n) { result.Add(new string(chars)); continue; }
                    if (lcnt > rcnt) queue.Enqueue(([.. chars], lcnt, rcnt + 1));
                    chars[lcnt + rcnt] = '(';
                    queue.Enqueue((chars, lcnt + 1, rcnt));
                }

            return result;
        }
    }
}
