using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2508
{
    public class Solution2508 : Interface2508
    {
        /// <summary>
        /// 遍历
        /// 是我理解错了吗？统计出每个顶点的度，如果奇数度的数量是2, 4结果就可能为true，不对吗？
        ///     这里说可能是因为，参考测试用例03
        /// 为什么通过率这么低...，大概率是可能性太多了
        /// 
        /// 首先，用一条边连接两个顶点，如果这两个顶点的度为：
        ///     (奇, 奇)，减少两个度为奇数的顶点
        ///     (奇, 偶)，度为奇数的顶点数量不变
        ///     (偶, 偶)，增加两个度为奇数的顶点
        /// 所以，无论怎样增加边，奇数度的顶点数量的奇偶性不变，且最多增加两条边就最多可以消除掉4个奇数度的顶点
        /// 所以，只需要讨论2个或4个奇数度顶点这两种情况即可
        /// 
        /// 有2个奇数度顶点
        /// 如果这两个顶点之间没有边，将这两个顶点连接即可
        /// 如果这两个顶点之间有边，需要找到一个偶数度的顶点，且这个顶点与这两个奇数度的顶点之间都没有边，那么连接即可
        /// 
        /// 有4个奇数度顶点
        /// 由于最多新增两条边，所以这四个奇数度的必须分为两对，每对内部连接
        /// </summary>
        /// <param name="n"></param>
        /// <param name="edges"></param>
        /// <returns></returns>
        public bool IsPossible(int n, IList<IList<int>> edges)
        {
            HashSet<int>[] graph = new HashSet<int>[n + 1];
            for (int i = 1; i <= n; i++) graph[i] = [];
            foreach (var edge in edges) { graph[edge[0]].Add(edge[1]); graph[edge[1]].Add(edge[0]); }

            List<int> odds = [];
            for (int i = 1; i <= n; i++) if ((graph[i].Count & 1) == 1) odds.Add(i);
            if (odds.Count == 0) return true;

            if (odds.Count == 2)
            {
                if (!graph[odds[0]].Contains(odds[1])) return true;
                for (int i = 1; i <= n; i++) if (i != odds[0] && i != odds[1])
                    {
                        if (!graph[i].Contains(odds[0]) && !graph[i].Contains(odds[1])) return true;
                    }
                return false;
            }

            if (odds.Count == 4)
            {
                if (!graph[odds[0]].Contains(odds[1]) && !graph[odds[2]].Contains(odds[3])) return true;
                if (!graph[odds[0]].Contains(odds[2]) && !graph[odds[1]].Contains(odds[3])) return true;
                if (!graph[odds[0]].Contains(odds[3]) && !graph[odds[1]].Contains(odds[2])) return true;
                return false;
            }

            return false;
        }
    }
}
