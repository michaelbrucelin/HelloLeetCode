using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3532
{
    public class Solution3532 : Interface3532
    {
        /// <summary>
        /// 脑筋急转弯
        /// 第一反应是并查集，再想想不对，没必要并查集
        /// 按题目描述，最终的各个连通分量一定是连续的顶点构成的，所以遍历一次就可以了
        /// </summary>
        /// <param name="n"></param>
        /// <param name="nums"></param>
        /// <param name="maxDiff"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public bool[] PathExistenceQueries(int n, int[] nums, int maxDiff, int[][] queries)
        {
            List<(int, int)> group = new List<(int, int)>();
            int p1 = 0, p2 = 0;
            while (p1 < n)
            {
                while (p2 + 1 < n && nums[p2 + 1] - nums[p2] <= maxDiff) p2++;
                group.Add((p1, p2));
                p1 = ++p2;
            }
            int[] uf = new int[n];
            foreach ((int l, int r) in group) for (int i = l; i <= r; i++) uf[i] = l;

            int len = queries.Length;
            bool[] result = new bool[len];
            for (int i = 0; i < len; i++) result[i] = uf[queries[i][0]] == uf[queries[i][1]];

            return result;
        }
    }
}
