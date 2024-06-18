using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2288
{
    public class Solution2288 : Interface2288
    {
        /// <summary>
        /// 类C的朴素解法
        /// </summary>
        /// <param name="sentence"></param>
        /// <param name="discount"></param>
        /// <returns></returns>
        public string DiscountPrices(string sentence, int discount)
        {
            List<char> buffer = new List<char>();
            int pl = 0, pr, p, len = sentence.Length; decimal num; bool flag;  // float num会丢精度，参考测试用例03; flag 是否是数字
            while (pl < len)
            {
                flag = true;
                pr = pl;
                while (pr + 1 < len && sentence[pr + 1] != ' ') pr++;
                if (pr > pl && sentence[pl] == '$')
                {
                    p = pl; while (++p <= pr)
                    {
                        if (!char.IsAsciiDigit(sentence[p])) { flag = false; break; }
                    }
                }
                else
                {
                    flag = false;
                }

                buffer.Add(sentence[pl]);
                if (flag)
                {
                    num = decimal.Parse(sentence[(pl + 1)..(pr + 1)]) * (100 - discount) / 100;
                    foreach (char c in $"{num:F2}") buffer.Add(c);
                }
                else
                {
                    p = pl; while (++p <= pr) buffer.Add(sentence[p]);
                }
                buffer.Add(' ');
                pl = pr + 2;
            }

            return new string(buffer[..^1].ToArray());
        }
    }
}
