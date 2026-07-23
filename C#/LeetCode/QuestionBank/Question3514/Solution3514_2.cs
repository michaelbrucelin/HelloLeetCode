using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3514
{
    public class Solution3514_2 : Interface3514
    {
        /// <summary>
        /// 两轮计算
        /// 本质上同Solution3514
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int UniqueXorTriplets(int[] nums)
        {
            HashSet<int> set = [], r1 = [], r2 = [];
            foreach (int num in nums) set.Add(num);
            foreach (int x in set) foreach (int y in set) r1.Add(x ^ y);
            foreach (int x in set) foreach (int y in r1) r2.Add(x ^ y);

            return r2.Count;
        }

        /// <summary>
        /// 逻辑同UniqueXorTriplets()，数据量较小，不使用Hash去重复了
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int UniqueXorTriplets2(int[] nums)
        {
            HashSet<int> r1 = [], r2 = [];
            foreach (int x in nums) foreach (int y in nums) r1.Add(x ^ y);
            foreach (int x in r1) foreach (int y in nums) r2.Add(x ^ y);

            return r2.Count;
        }
    }
}
