using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0442
{
    public class Solution0442 : Interface0442
    {
        /// <summary>
        /// Hash
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<int> FindDuplicates(int[] nums)
        {
            List<int> result = [];
            HashSet<int> set = [];
            foreach (int num in nums) if (!set.Add(num)) result.Add(num);

            return result;
        }

        /// <summary>
        /// 数组
        /// 逻辑同FindDuplicates()，将Hash换成数组
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<int> FindDuplicates2(int[] nums)
        {
            List<int> result = [];
            bool[] set = new bool[nums.Length + 1];
            foreach (int num in nums) if (set[num]) result.Add(num); else set[num] = true;

            return result;
        }
    }
}
