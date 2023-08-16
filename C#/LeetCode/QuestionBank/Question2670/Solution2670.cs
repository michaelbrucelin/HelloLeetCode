using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2670
{
    public class Solution2670 : Interface2670
    {
        /// <summary>
        /// 暴力模拟
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] DistinctDifferenceArray(int[] nums)
        {
            int len = nums.Length;
            int[] result = new int[len];
            HashSet<int> set_l = new HashSet<int>(), set_r = new HashSet<int>();
            for (int i = 0; i < len; i++)
            {
                set_l.Clear(); set_r.Clear();
                for (int j = 0; j <= i; j++) set_l.Add(nums[j]);
                for (int j = i + 1; j < len; j++) set_r.Add(nums[j]);
                result[i] = set_l.Count - set_r.Count;
            }

            return result;
        }
    }
}
