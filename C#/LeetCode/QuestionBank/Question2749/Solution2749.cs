using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2749
{
    public class Solution2749 : Interface2749
    {
        /// <summary>
        /// 分析
        /// 好题，思路见Solution2749.md
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public int MakeTheIntegerZero(int num1, int num2)
        {
            if (num1 <= num2) return -1;

            long num = num1;
            int result = 1, cnt1;
            while (true)
            {
                num -= num2;
                if (num <= 0) break;
                cnt1 = BitOperations.PopCount((ulong)num);
                if (result >= cnt1 && result <= num) return result;
                result++;
            }

            return -1;
        }
    }
}
