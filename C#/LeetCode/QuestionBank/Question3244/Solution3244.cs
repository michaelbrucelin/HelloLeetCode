using LeetCode.QuestionBank.Question3243;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3244
{
    public class Solution3244 : Interface3244
    {
        /// <summary>
        /// BFS
        /// 纯暴力，BFS解法，逻辑没问题，TLE，参考测试用例03
        /// </summary>
        /// <param name="n"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public int[] ShortestDistanceAfterQueries(int n, int[][] queries)
        {
            Solution3243 solution = new Solution3243();
            return solution.ShortestDistanceAfterQueries(n, queries);
        }
    }
}
