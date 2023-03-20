using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1012
{
    public class Solution1012_api : Interface1012
    {
        /// <summary>
        /// 提交会超时
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int NumDupDigitsAtMostN(int n)
        {
            // if (n < 11) return 0;
            return Enumerable.Range(1, n).Select(i => i.ToString().ToCharArray())
                                         .Select(arr => arr.Length - arr.Distinct().Count())
                                         .Where(i => i > 0)
                                         .Count();
        }

        /// <summary>
        /// 提交会超时
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int NumDupDigitsAtMostN2(int n)
        {
            // if (n < 11) return 0;
            return Enumerable.Range(1, n).Select(i => i.ToString())
                                         .Select(s => s.Length - s.Distinct().Count())
                                         .Where(i => i > 0)
                                         .Count();
        }
    }
}
