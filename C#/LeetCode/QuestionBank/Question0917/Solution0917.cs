using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0917
{
    public class Solution0917 : Interface0917
    {
        /// <summary>
        /// 原地交换
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string ReverseOnlyLetters(string s)
        {
            char[] chars = s.ToCharArray();
            int i = -1, j = s.Length; char t;
            while (++i < --j)
            {
                while (i < j && !char.IsLetter(chars[i])) i++;
                if (i == j) break;
                while (j > i && !char.IsLetter(chars[j])) j--;
                if (j == i) break;

                t = chars[i]; chars[i] = chars[j]; chars[j] = t;
            }

            return new string(chars);
        }
    }
}
