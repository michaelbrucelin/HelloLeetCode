using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0109
{
    public class Solution0109 : Interface0109
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="deadends"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int OpenLock(string[] deadends, string target)
        {
            if (target == "0000") return 0;
            HashSet<string> block = [.. deadends];
            if (block.Contains("0000")) return -1;  // 题目限定target不在deadends中

            HashSet<string> visited = [];
            Queue<string> queue = new Queue<string>();
            queue.Enqueue("0000");
            int step = 0; string curr;
            while (queue.Count > 0)
            {
                step++;
                for (int i = queue.Count; i > 0; i--)
                {
                    curr = queue.Dequeue();
                    if (visited.Contains(curr)) continue; visited.Add(curr);
                    string[] nexts = next(curr);
                    foreach (string _next in nexts)
                    {
                        if (_next == target) return step;
                        if (block.Contains(_next) || visited.Contains(_next)) continue;
                        queue.Enqueue(_next);
                    }
                }
            }

            return -1;

            static string[] next(string curr)
            {
                string[] result = new string[8];
                char[] chars = [.. curr];
                char c;
                for (int i = 0; i < 4; i++)
                {
                    c = chars[i];
                    chars[i] = c != '9' ? (char)(c + 1) : '0';
                    result[i << 1] = new string(chars);
                    chars[i] = c != '0' ? (char)(c - 1) : '9';
                    result[(i << 1) + 1] = new string(chars);
                    chars[i] = c;
                }

                return result;
            }
        }
    }
}
