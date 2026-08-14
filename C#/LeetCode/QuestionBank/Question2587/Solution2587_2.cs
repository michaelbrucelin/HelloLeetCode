using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2587
{
    public class Solution2587_2 : Interface2587
    {
        /// <summary>
        /// 贪心
        /// 逻辑同Solution2587，优化排序部分
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxScore(int[] nums)
        {
            int result = 0, cnt0 = 0; long sum = 0;
            List<(int, int)> lt0 = [];
            for (int i = 0, len = nums.Length; i < len; i++) switch (nums[i])
                {
                    case > 0: result++; sum += nums[i]; break;
                    case < 0: lt0.Add((nums[i], -nums[i])); break;
                    default: cnt0++; break;
                }
            if (result == 0) return 0;
            result += cnt0;

            PriorityQueue<int, int> maxpq = new PriorityQueue<int, int>(lt0);
            while (maxpq.Count > 0)
            {
                if ((sum += maxpq.Dequeue()) > 0) result++; else break;
            }

            return result;
        }
    }
}
