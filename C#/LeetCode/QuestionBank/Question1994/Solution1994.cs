using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1994
{
    public class Solution1994 : Interface1994
    {
        /// <summary>
        /// 二进制枚举 + 组合数学
        /// 题目限制 1 <= nums[i] <= 30，那么可以选择的值有18个
        ///     2, 3, 5, 6, 7, 10, 11, 13, 14, 15, 17, 19, 21, 22, 23, 26, 29, 30
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int NumberOfGoodSubsets(int[] nums)
        {
            //           [ 0,  1, 2, 3,  4, 5, 6, 7,  8,  9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30];
            int[] map1 = [18, 18, 0, 1, 18, 2, 3, 4, 18, 18,  5,  6, 18,  7,  8,  9, 18, 10, 18, 11, 18, 12, 13, 14, 18, 18, 15, 18, 18, 16, 17];
            int[] map2 = [2, 3, 5, 6, 7, 10, 11, 13, 14, 15, 17, 19, 21, 22, 23, 26, 29, 30];
            int[] cnts = new int[19];

            throw new NotImplementedException();
        }
    }
}
