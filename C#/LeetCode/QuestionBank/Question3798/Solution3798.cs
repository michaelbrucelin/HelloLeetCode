using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3798
{
    public class Solution3798 : Interface3798
    {
        /// <summary>
        /// 贪心
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string LargestEven(string s)
        {
            char[] chars = s.ToCharArray();
            int ptr = chars.Length - 1;
            while (ptr >= 0 && chars[ptr] != '2') ptr--;

            return new string(chars, 0, ptr + 1);
        }
    }
}
