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
            int min = nums[0], max = nums[0];
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

        /// <summary>
        /// 逻辑同FindMissingElements()，更快的找出数组的最大值及最小值
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<int> FindMissingElements2(int[] nums)
        {
            int min = nums[0], max = nums[0], len = nums.Length;
            bool[] mask = new bool[101];
            mask[nums[0]] = true;
            for (int i = len & 1, j = (len & 1) + 1; j < len; i += 2, j += 2)
            {
                switch (nums[i] - nums[j])
                {
                    case > 0: max = Math.Max(max, nums[i]); min = Math.Min(min, nums[j]); break;
                    case < 0: max = Math.Max(max, nums[j]); min = Math.Min(min, nums[i]); break;
                    default: max = Math.Max(max, nums[i]); min = Math.Min(min, nums[i]); break;
                }
                mask[nums[i]] = true;
                mask[nums[j]] = true;
            }

            List<int> list = [];
            for (int i = min + 1; i < max; i++) if (!mask[i]) list.Add(i);

            return list;
        }
    }
}
