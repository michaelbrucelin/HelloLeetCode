using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1945
{
    public class Solution1945_3 : Interface1945
    {
        /// <summary>
        /// 与Solution1945_2一样，不过由于题目中k大于等于1，所以直接在将字符翻译为ASCII码时把第一步完成，这样就不会有Solution1945中的溢出问题了
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int GetLucky(string s, int k)
        {
            int sint = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int cint = s[i] - 'a' + 1;
                if (cint >= 10) sint += cint / 10 + cint % 10; else sint += cint;
            }
            if (sint < 10 || k == 1) return sint;

            int result = 0;
            while (--k > 0)
            {
                result = 0;
                while (sint > 0) { result += sint % 10; sint /= 10; }
                if (result < 10) return result; else sint = result;
            }

            return result;
        }
    }
}
