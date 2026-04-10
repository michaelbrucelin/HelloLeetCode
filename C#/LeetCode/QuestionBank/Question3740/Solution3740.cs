using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3740
{
    public class Solution3740 : Interface3740
    {
        /// <summary>
        /// Hash
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinimumDistance(int[] nums)
        {
            if (nums.Length < 3) return -1;

            int result = nums.Length << 1, len = nums.Length;
            List<int>[] ids = new List<int>[101];
            for (int i = 0, num; i < len; i++)
            {
                num = nums[i];
                if (ids[num] == null)
                {
                    ids[num] = [i];
                }
                else
                {
                    ids[num].Add(i);
                    if (ids[num].Count >= 3)
                    {
                        result = Math.Min(result, (i - ids[num][^3]) << 1);
                        if (result == 4) return 4;
                    }
                }
            }

            return result != (len << 1) ? result : -1;
        }
    }
}
