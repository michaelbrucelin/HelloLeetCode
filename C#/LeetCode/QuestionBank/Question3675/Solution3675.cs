using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3675
{
    public class Solution3675 : Interface3675
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MinOperations(string s)
        {
            int result = 0;
            foreach (char c in s) result = Math.Max(result, (26 - c + 'a') % 26);
            return result;
        }
    }
}
