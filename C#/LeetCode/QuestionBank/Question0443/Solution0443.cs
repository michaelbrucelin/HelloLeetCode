using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0443
{
    public class Solution0443 : Interface0443
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="chars"></param>
        /// <returns></returns>
        public int Compress(char[] chars)
        {
            if (chars.Length == 1) return 1;

            int result = 0, last = chars[0], cnt = 1, ptr = 0;
            for (int i = 1, curr, len = chars.Length; i < len; i++)
            {
                if ((curr = chars[i]) == last)
                {
                    cnt++;
                }
                else
                {
                    chars[ptr++] = (char)last;
                    if (cnt != 1)
                    {
                        string cntstr = cnt.ToString();
                        foreach (char c in cntstr) chars[ptr++] = c;
                    }
                    result += cnt != 1 ? cnt.ToString().Length + 1 : 1;

                    last = curr; cnt = 1;
                }
            }
            chars[ptr++] = (char)last;
            if (cnt != 1)
            {
                string cntstr = cnt.ToString();
                foreach (char c in cntstr) chars[ptr++] = c;
            }
            result += cnt != 1 ? cnt.ToString().Length + 1 : 1;

            return result;
        }
    }
}
