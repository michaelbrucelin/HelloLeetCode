using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2375
{
    public class Solution2375 : Interface2375
    {
        /// <summary>
        /// 贪心
        /// 初始状态为123456789，将每组降序区间反转即可
        /// </summary>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public string SmallestNumber(string pattern)
        {
            int len = pattern.Length;
            char[] result = new char[len + 1];
            for (int i = 0, j = 49; i <= len; i++, j++) result[i] = (char)j;
            int pl = 0, pr;
            while (pl < len)
            {
                while (pl < len && pattern[pl] == 'I') pl++;
                pr = pl;
                while (pr < len && pattern[pr] == 'D') pr++;
                for (int i = pl, j = pr; i < j; i++, j--) (result[i], result[j]) = (result[j], result[i]);
                pl = pr + 1;
            }

            return new string(result);
        }
    }
}
