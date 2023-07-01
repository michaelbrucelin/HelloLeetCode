using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1078
{
    public class Solution1078 : Interface1078
    {
        /// <summary>
        /// C Style
        /// 使用类似于C的朴素方式解
        /// 1. 从前向后遍历得出每一个word
        /// 2. 使用(bool is1, bool is2)记录word是否是first， 是否是second
        /// 3. 记录前面两个word的(bool is1, bool is2)状态，然后判断当前word是否可以加入结果
        /// 4. 继续向前
        /// </summary>
        /// <param name="text"></param>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public string[] FindOcurrences(string text, string first, string second)
        {
            List<string> result = new List<string>();
            (bool is1, bool is2) f1 = (false, false), f2 = (false, false);
            int ptr1 = 0, ptr2, len = text.Length; string str;
            while (ptr1 < len)
            {
                while (ptr1 < len && text[ptr1] == ' ') ptr1++;
                if (ptr1 == len) break;
                ptr2 = ptr1;
                while (ptr2 + 1 < len && text[ptr2 + 1] != ' ') ptr2++;
                str = text.Substring(ptr1, ptr2 - ptr1 + 1);
                if (f1.is1 && f2.is2) result.Add(str);

                f1 = f2; f2 = (str == first, str == second);
                ptr1 = ptr2 + 2;
            }

            return result.ToArray();
        }
    }
}
