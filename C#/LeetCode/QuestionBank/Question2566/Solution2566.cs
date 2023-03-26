using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2566
{
    public class Solution2566 : Interface2566
    {
        /// <summary>
        /// 分析
        /// 1. 最大，从前向后第一位非9的数字映射为9
        /// 2. 最小，第一位数字映射为0
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int MinMaxDifference(int num)
        {
            int max = 0, min = 0, cmax, cmin;
            List<int> list = new List<int>();
            while (num > 0) { list.Add(num % 10); num /= 10; }
            cmax = -1; cmin = list[^1];
            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (cmax >= 0)
                {
                    max = max * 10 + (list[i] == cmax ? 9 : list[i]);
                }
                else
                {
                    if (list[i] < 9) cmax = list[i];
                    max = max * 10 + 9;
                }
                min = min * 10 + (list[i] == cmin ? 0 : list[i]);
            }

            return max - min;
        }

        /// <summary>
        /// 与MinMaxDifference()一样，不过使用字符串来处理
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int MinMaxDifference2(int num)
        {
            string str = num.ToString();
            char cmax = '\0', cmin = str[0];
            for (int i = 0; i < str.Length; i++)
                if (str[i] < '9') { cmax = str[i]; break; }

            return int.Parse(str.Replace(cmax, '9')) - int.Parse(str.Replace(cmin, '0'));
        }
    }
}
