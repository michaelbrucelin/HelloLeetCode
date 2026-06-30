using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0433
{
    public class Solution0433 : Interface0433
    {
        /// <summary>
        /// BFS
        /// 数据量不大，直接暴力BFS
        /// 本质上就是一个图，每个基因序列是一个顶点，如果两个顶点只有一个字符不同，那么这两个顶点之间就有一条无向边，然后求两个顶点的最短路
        /// </summary>
        /// <param name="startGene"></param>
        /// <param name="endGene"></param>
        /// <param name="bank"></param>
        /// <returns></returns>
        public int MinMutation(string startGene, string endGene, string[] bank)
        {
            if (startGene == endGene) return 0;
            HashSet<string> set = [.. bank];
            if (!set.Contains(endGene)) return -1;

            int result = 0, len = bank.Length;
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(startGene);
            string gene;
            while (queue.Count > 0)
            {
                result++;
                for (int i = queue.Count; i > 0; i--)
                {
                    gene = queue.Dequeue();
                    if (diff(gene, endGene) == 1) return result;
                    foreach (string next in set) if (diff(gene, next) == 1)
                        {
                            queue.Enqueue(next);
                            set.Remove(next);
                        }
                }
            }

            return -1;

            static int diff(string s1, string s2)
            {
                int cnt = 0;
                for (int i = 0; i < 8; i++) if (s1[i] != s2[i]) cnt++;
                return cnt;
            }
        }
    }
}
