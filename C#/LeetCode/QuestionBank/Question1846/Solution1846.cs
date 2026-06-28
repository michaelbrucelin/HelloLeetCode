using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1846
{
    public class Solution1846 : Interface1846
    {
        /// <summary>
        /// 排序 + 贪心
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int MaximumElementAfterDecrementingAndRearranging(int[] arr)
        {
            Array.Sort(arr);

            int result = 0, len = arr.Length;
            for (int i = 0; i < len; i++) result = Math.Min(result + 1, arr[i]);

            return result;
        }
    }
}
