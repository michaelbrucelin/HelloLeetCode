using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3159
{
    public class Solution3159 : Interface3159
    {
        /// <summary>
        /// 预处理
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="queries"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public int[] OccurrencesOfElement(int[] nums, int[] queries, int x)
        {
            List<int> pos = new List<int>();
            for (int i = 0; i < nums.Length; i++) if (nums[i] == x) pos.Add(i);

            int len = queries.Length, cnt = pos.Count;
            int[] result = new int[len];
            for (int i = 0; i < len; i++) result[i] = queries[i] <= cnt ? pos[queries[i] - 1] : -1;

            return result;
        }
    }
}
