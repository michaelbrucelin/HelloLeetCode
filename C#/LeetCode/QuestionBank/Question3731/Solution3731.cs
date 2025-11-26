using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3731
{
    public class Solution3731 : Interface3731
    {
        /// <summary>
        /// 哈希
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<int> FindMissingElements(int[] nums)
        {
            int min = nums[0], max = nums[0], len = nums.Length;
            bool[] mask = new bool[101];
            foreach (int num in nums)
            {
                min = Math.Min(min, num);
                max = Math.Max(max, num);
                mask[num] = true;
            }

            List<int> list = [];
            for (int i = min + 1; i < max; i++) if (!mask[i]) list.Add(i);

            return list;
        }
    }
}
