using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0219
{
    public class Solution0219_2 : Interface0219
    {
        /// <summary>
        /// Hash表
        /// 借助Hash表记录每个元素最后出现的id
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            if (k == 0 || nums.Length == 1) return false;

            Dictionary<int, int> buffer = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int num = nums[i];
                if (buffer.ContainsKey(num))
                {
                    if (i - buffer[num] <= k) return true;
                    buffer[num] = i;
                }
                else
                {
                    buffer.Add(num, i);
                }
            }

            return false;
        }
    }
}
