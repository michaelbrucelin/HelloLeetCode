using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1399
{
    public class Solution1399 : Interface1399
    {
        /// <summary>
        /// 枚举
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int CountLargestGroup(int n)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            for (int i = 1, sum; i <= n; i++)
            {
                sum = SumDigit(i);
                dic[sum] = dic.GetValueOrDefault(sum, 0) + 1;
            }

            int cnt = 0, max = 0;
            foreach (int sum in dic.Values)
            {
                if (sum > max)
                {
                    cnt = 1; max = sum;
                }
                else if (sum == max)
                {
                    cnt++;
                }
            }

            return cnt;
        }

        private int SumDigit(int num)
        {
            int result = 0;
            while (num > 0)
            {
                result += num % 10; num /= 10;
            }

            return result;
        }
    }
}
