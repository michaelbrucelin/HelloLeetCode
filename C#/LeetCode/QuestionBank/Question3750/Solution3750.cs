using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3750
{
    public class Solution3750 : Interface3750
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int MinimumFlips(int n)
        {
            List<int> list = [];
            while (n > 0) { list.Add(n & 1); n >>= 1; }

            int result = 0, cnt = list.Count;
            for (int i = 0, j = cnt - 1; i < cnt; i++, j--) result += Math.Abs(list[i] - list[j]);

            return result;
        }
    }
}
