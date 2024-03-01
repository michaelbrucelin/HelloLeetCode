using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3046
{
    public class Solution3046 : Interface3046
    {
        /// <summary>
        /// 哈希计数
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool IsPossibleToSplit(int[] nums)
        {
            if (nums.Length < 3) return true;

            Dictionary<int, int> map = new Dictionary<int, int>();
            foreach (int num in nums)
            {
                map.TryAdd(num, 0);
                if (++map[num] > 2) return false;
            }

            return true;
        }
    }
}
