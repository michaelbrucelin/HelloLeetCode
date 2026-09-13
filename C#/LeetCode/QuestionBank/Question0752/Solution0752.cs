using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0752
{
    public class Solution0752 : Interface0752
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

            int result = 0, tar = int.Parse(target);
            bool[] visited = new bool[10000];
            foreach (string s in deadends) if (s == "0000") return -1; else visited[int.Parse(s)] = true;
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(0); visited[0] = true;
            int x; int[] nexts;
            while (queue.Count > 0)
            {
                result++;
                for (int i = queue.Count - 1; i >= 0; i--)
                {
                    visited[x = queue.Dequeue()] = true;
                    nexts = next(x);
                    for (int j = 0, y; j < 8; j++)
                    {
                        if ((y = nexts[j]) == tar) return result;
                        if (!visited[y]) { queue.Enqueue(y); visited[y] = true; }
                    }
                }
            }

            return -1;

            static int[] next(int x)
            {
                int[] nexts = new int[8];
                int id = 0, left, mid, right, _mid;
                for (int i = 1, j = 10; i < 10000; i *= 10, j *= 10)
                {
                    left = x / j * j;
                    right = x % i;
                    mid = x / i % 10;
                    _mid = (mid + 1) % 10;
                    nexts[id++] = left + right + _mid * i;
                    _mid = (mid - 1 + 10) % 10;
                    nexts[id++] = left + right + _mid * i;
                }
                return nexts;
            }
        }
    }
}
