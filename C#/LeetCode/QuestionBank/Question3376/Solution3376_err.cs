using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3376
{
    public class Solution3376_err : Interface3376
    {
        /// <summary>
        /// 贪心
        /// 
        /// 思路是错的，有蝴蝶效应，参考测试用例03
        /// </summary>
        /// <param name="strength"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int FindMinimumTime(IList<int> strength, int k)
        {
            List<int> list = [.. strength];
            list.Sort();
            int result = 0, power = 0, x = 1, idx, cnt = list.Count;
            while (cnt > 0)
            {
                result++; power = x; idx = 0;
                while (power < list[0]) { result++; power += x; }
                while (idx + 1 < cnt && power >= list[idx + 1]) idx++;  // O(n^2)，题目的数据量较小，可以暴力查找
                list.RemoveAt(idx); cnt--;
                power = 0;
                x += k;
            }

            return result;
        }
    }
}
