using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3551
{
    public class Solution3551 : Interface3551
    {
        /// <summary>
        /// 排序
        /// 先找出正确排序的顺序，然后从前向后逐位替换即可，这样对吗？怎样证明？
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinSwaps(int[] nums)
        {
            int result = 0, len = nums.Length;
            int[] order = new int[len];
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < len; i++) { order[i] = nums[i]; map.Add(nums[i], i); }
            Array.Sort(order, (x, y) => { int idx = digitsum(x); int idy = digitsum(y); return idx != idy ? idx - idy : x - y; });

            for (int i = 0, j; i < len; i++) if (nums[i] != order[i])
                {
                    j = map[order[i]];
                    (nums[i], nums[j]) = (nums[j], nums[i]);
                    map[nums[j]] = j;
                    result++;
                }

            return result;

            static int digitsum(int x)
            {
                int sum = 0;
                while (x > 0) { sum += x % 10; x /= 10; }
                return sum;
            }
        }
    }
}
