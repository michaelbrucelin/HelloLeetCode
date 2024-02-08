using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2848
{
    public class Solution2848 : Interface2848
    {
        /// <summary>
        /// 暴力
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int NumberOfPoints(IList<IList<int>> nums)
        {
            bool[] mask = new bool[101];
            foreach (var arr in nums) for (int i = arr[0]; i <= arr[1]; i++) mask[i] = true;

            int result = 0;
            for (int i = 0; i < 101; i++) if (mask[i]) result++;

            return result;
        }
    }
}
