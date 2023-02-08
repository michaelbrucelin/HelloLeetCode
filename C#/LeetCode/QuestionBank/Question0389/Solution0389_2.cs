using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0389
{
    public class Solution0389_2 : Interface0389
    {
        /// <summary>
        /// 排序
        /// 解法没有任何优势，写着玩的
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public char FindTheDifference(string s, string t)
        {
            char[] arr_s = s.OrderBy(c => c).ToArray();
            char[] arr_t = t.OrderBy(c => c).ToArray();

            for (int i = 0; i < arr_s.Length; i++)
                if (arr_t[i] != arr_s[i]) return arr_t[i];

            return arr_t[^1];
        }
    }
}
