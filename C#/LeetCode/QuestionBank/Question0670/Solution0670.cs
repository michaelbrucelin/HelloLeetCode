using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0670
{
    public class Solution0670 : Interface0670
    {
        /// <summary>
        /// 贪心
        /// 与“绝对”的最大值相比找可能的一次交换的最大值
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int MaximumSwap(int num)
        {
            List<int> digits = new List<int>();
            while (num > 0)
            {
                digits.Add(num % 10); num /= 10;
            }

            List<int> orderd = digits.OrderBy(i => i).ToList();  // 最大值
            for (int i = digits.Count - 1; i >= 0; i--)          // 找到不同的最高位
            {
                if (digits[i] == orderd[i]) continue;
                for (int j = 0; j < i; j++)                      // 找到第一个外层循环找到的位
                {
                    if (digits[j] == orderd[i])
                    {
                        int temp = digits[i]; digits[i] = digits[j]; digits[j] = temp;
                        break;
                    }
                }
                break;
            }

            int result = 0;
            for (int i = digits.Count - 1; i >= 0; i--)
                result = result * 10 + digits[i];
            return result;
        }
    }
}
