using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3542
{
    public class Solution3542 : Interface3542
    {
        /// <summary>
        /// 分治
        /// 找出数组中的最小值，将其变为0，这是一次操作，将原数组分为了若干子数组，然后同理操作子数组即可
        /// 
        /// 逻辑没问题，意料之中的TLE，参考测试用例06
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinOperations(int[] nums)
        {
            return rec(0, nums.Length - 1);

            int rec(int left, int right)
            {
                if (left > right) return 0;
                if (left == right) return -((nums[left] | -nums[left]) >> 31);  // nums[left] > 0 ? 1 : 0;

                List<int> list = [left];
                int min = nums[left], p = 0;
                for (int i = left + 1; i <= right; i++) if (nums[i] <= min)
                    {
                        if (nums[i] < min)
                        {
                            min = nums[i]; list[p = 0] = i;
                        }
                        else
                        {
                            if (++p == list.Count) list.Add(i); else list[p] = i;
                        }
                    }

                int result = -((min | -min) >> 31);
                result += rec(left, list[0] - 1);
                for (int i = 1; i <= p; i++) result += rec(list[i - 1] + 1, list[i] - 1);
                result += rec(list[p] + 1, right);

                return result;
            }
        }
    }
}
