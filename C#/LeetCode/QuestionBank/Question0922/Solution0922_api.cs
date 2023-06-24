using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0922
{
    public class Solution0922_api : Interface0922
    {
        /// <summary>
        /// 这个解时错误的，[2,3]与[3,4]这两个最简单的测试用例都过不去，没想明白时为什么
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] SortArrayByParityII(int[] nums)
        {
            Comparer<(int, int)> comparer = Comparer<(int, int)>.Create((t1, t2) =>
            {
                if (((t1.Item1 & 1) != (t1.Item2 & 1)) && ((t2.Item1 & 1) != (t2.Item2 & 1))) return -1;
                return 1;
            });

            return nums.Select((num, id) => (num, id))
                       .OrderBy(t => t, comparer)
                       .Select(t => t.num)
                       .ToArray();
        }
    }
}
