using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0970
{
    public class Solution0970 : Interface0970
    {
        /// <summary>
        /// 暴力枚举
        /// x == 1或 y == 1单独判断
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="bound"></param>
        /// <returns></returns>
        public IList<int> PowerfulIntegers(int x, int y, int bound)
        {
            if (bound < 2) return new int[0];
            if (bound == 2 || (x == 1 && y == 1)) return new int[] { 2 };

            HashSet<int> result = new HashSet<int>();
            if (x > y) { int t = x; x = y; y = t; }
            if (x == 1)
            {
                for (int i = 1; i < bound; i *= y) result.Add(i + 1);
            }
            else
            {
                for (int i = 1; i < bound; i *= x) for (int j = 1; i + j <= bound; j *= y) result.Add(i + j);
            }

            return result.ToArray();
        }

        /// <summary>
        /// 暴力枚举 + 预处理
        /// 1. 预处理出所有可能的x^i 与 y^j
        /// 相对于PowerfulIntegers()，每个x^i只计算了一次
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="bound"></param>
        /// <returns></returns>
        public IList<int> PowerfulIntegers2(int x, int y, int bound)
        {
            if (bound < 2) return new int[0];
            if (bound == 2 || (x == 1 && y == 1)) return new int[] { 2 };

            HashSet<int> result = new HashSet<int>();
            if (x > y) { int t = x; x = y; y = t; }
            if (x == 1)
            {
                for (int i = 1; i < bound; i *= y) result.Add(i + 1);
            }
            else
            {
                List<int> listx = new List<int>(), listy = new List<int>();
                for (int i = 1; i < bound; i *= x) listx.Add(i);
                for (int i = 1; i < bound; i *= y) listy.Add(i);
                for (int i = 0; i < listx.Count; i++) for (int j = 0; j < listy.Count; j++)
                        if (listx[i] + listy[j] <= bound) result.Add(listx[i] + listy[j]);
            }

            return result.ToArray();
        }
    }
}
