using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0078
{
    public class Solution0078 : Interface0078
    {
        /// <summary>
        /// 类BFS
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> Subsets(int[] nums)
        {
            List<IList<int>> result = new List<IList<int>>();
            result.Add(new List<int>());
            int cnt = 0;
            foreach (int num in nums)
            {
                cnt = result.Count;
                for (int i = 0; i < cnt; i++) result.Add(new List<int>(result[i]) { num });
            }

            return result;
        }
    }
}
