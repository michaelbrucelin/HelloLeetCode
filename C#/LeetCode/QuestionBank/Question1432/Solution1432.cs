using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1432
{
    public class Solution1432 : Interface1432
    {
        /// <summary>
        /// 贪心
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int MaxDiff(int num)
        {
            if (num < 10) return 8;

            List<int> digits1 = new List<int>(), digits2 = new List<int>();
            int _num = num;
            while (_num > 0)
            {
                digits1.Add(_num % 10);
                digits2.Add(_num % 10);
                _num /= 10;
            }
            int len = digits1.Count;
            if (num == Math.Pow(10, len - 1) || digits1.All(x => x == 1)) return num << 3;

            int max = -1, min = -1;
            // 最大值
            for (int i = len - 1; i >= 0; i--)
            {
                if (max != -1)
                {
                    if (digits1[i] == max) digits1[i] = 9;
                }
                else
                {
                    if (digits1[i] != 9) { max = digits1[i]; digits1[i] = 9; }
                }
            }
            // 最小值
            if (digits2[^1] != 1)
            {
                min = digits2[^1];
                for (int i = 0; i < len; i++) if (digits2[i] == min) digits2[i] = 1;
            }
            else
            {
                for (int i = len - 2; i >= 0; i--)
                {
                    if (min != -1)
                    {
                        if (digits2[i] == min) digits2[i] = 0;
                    }
                    else
                    {
                        if (digits2[i] > 1) { min = digits2[i]; digits2[i] = 0; }
                    }
                }
            }

            max = min = 0;
            for (int i = len - 1; i >= 0; i--)
            {
                max = max * 10 + digits1[i];
                min = min * 10 + digits2[i];
            }

            return max - min;
        }
    }
}
