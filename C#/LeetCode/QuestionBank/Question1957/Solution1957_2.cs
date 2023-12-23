using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1957
{
    public class Solution1957_2 : Interface1957
    {
        /// <summary>
        /// 类C的朴素解法，双指针
        /// 本质上就是将连续超过4个的相同字符改成2个
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string MakeFancyString(string s)
        {
            StringBuilder result = new StringBuilder();
            int i = 0, j, len = s.Length;
            while (i < len)
            {
                result.Append(s[i]);
                j = i + 1;
                while (j < len && s[j] == s[i]) j++;
                if (j != i + 1) result.Append(s[i]);  // j > i+1
                i = j;
            }

            return result.ToString();
        }
    }
}
