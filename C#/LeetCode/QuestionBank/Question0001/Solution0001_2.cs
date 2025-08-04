using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0001
{
    public class Solution0001_2 : Interface0001
    {
        /// <summary>
        /// 哈希
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (dic.ContainsKey(target - nums[i]))
                    return [dic[target - nums[i]], i];
                dic.TryAdd(nums[i], i);
            }

            throw new Exception("logic error.");
        }

        public int[] TwoSum2(int[] nums, int target)
        {
            int[] result = new int[2];

            Dictionary<int, int> dic = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (dic.ContainsKey(target - nums[i]))
                {
                    result[0] = dic[target - nums[i]];
                    result[1] = i;
                    break;
                }

                if (!dic.ContainsKey(target - nums[i]))
                    dic.Add(nums[i], i);
            }

            return result;
        }
    }
}
