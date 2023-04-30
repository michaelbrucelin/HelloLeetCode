using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1615
{
    public class Solution1615 : Interface1615
    {
        /// <summary>
        /// 贪心法
        /// 最大城市秩的城市对，一定是直连道路最多的两个城市（有并列需要找出没有公共边的那一对）
        /// </summary>
        /// <param name="n"></param>
        /// <param name="roads"></param>
        /// <returns></returns>
        public int MaximalNetworkRank(int n, int[][] roads)
        {
            (int id, HashSet<int> set)[] buffer = new (int id, HashSet<int> set)[n];
            for (int i = 0; i < n; i++) buffer[i] = (i, new HashSet<int>());
            for (int i = 0; i < roads.Length; i++)
            {
                buffer[roads[i][0]].set.Add(roads[i][1]); buffer[roads[i][1]].set.Add(roads[i][0]);
            }
            Array.Sort(buffer, (t1, t2) => t2.set.Count - t1.set.Count);

            // 确认在哪些城市中两两配对查找，只需要在道路最多的两个城市中查找，如果第二多有并列，并列的都算
            int border = 1; while (border + 1 < n && buffer[border + 1].set.Count == buffer[1].set.Count) border++;

            int result = buffer[0].set.Count + buffer[1].set.Count - 1;
            if (border == 1) return result + (buffer[0].set.Contains(buffer[1].id) ? 0 : 1);
            if (buffer[0].set.Count == buffer[1].set.Count)        // 如果前两个相等，所有的组合都需要尝试
            {
                for (int i = 0; i <= border; i++) for (int j = i + 1; j <= border; j++)
                        if (!buffer[i].set.Contains(buffer[j].id)) return result + 1;
            }
            else  // (buffer[0].set.Count != buffer[1].set.Count)  // 如果前两个不等，固定第1个（最大的）
            {
                for (int i = 1; i <= border; i++)
                    if (!buffer[0].set.Contains(buffer[i].id)) return result + 1;
            }

            return result;
        }
    }
}
