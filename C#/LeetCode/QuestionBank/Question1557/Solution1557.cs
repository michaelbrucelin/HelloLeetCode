using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1557
{
    public class Solution1557 : Interface1557
    {
        /// <summary>
        /// 遍历
        /// 找入度为0的结点即可，题目限定有唯一解，即没有环
        /// </summary>
        /// <param name="n"></param>
        /// <param name="edges"></param>
        /// <returns></returns>
        public IList<int> FindSmallestSetOfVertices(int n, IList<IList<int>> edges)
        {
            int[] indegs = new int[n];
            foreach (IList<int> edge in edges) indegs[edge[1]]++;

            List<int> result = [];
            for (int i = 0; i < n; i++) if (indegs[i] == 0) result.Add(i);

            return result;
        }
    }
}
