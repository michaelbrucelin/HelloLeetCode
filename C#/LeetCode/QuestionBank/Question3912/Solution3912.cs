using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3912
{
    public class Solution3912 : Interface3912
    {
        /// <summary>
        /// 暴力枚举
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<int> FindValidElements(int[] nums)
        {
            if (nums.Length < 3) return [.. nums];

            IList<int> result = new List<int>();
            result.Add(nums[0]);
            for (int i = 1, r = nums.Length - 1, num; i < r; i++)
            {
                num = nums[i];
                for (int j = 0; j < i; j++) if (nums[j] >= num) goto CHECK_RIGHT;
                result.Add(num);
                continue;
            CHECK_RIGHT:;
                for (int j = nums.Length - 1; j > i; j--) if (nums[j] >= num) goto CONTINUE;
                result.Add(num);
            CONTINUE:;
            }
            result.Add(nums[^1]);

            return result;
        }
    }
}
