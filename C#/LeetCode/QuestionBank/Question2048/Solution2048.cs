using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2048
{
    public class Solution2048 : Interface2048
    {
        /// <summary>
        /// 暴力枚举
        /// 题目限定 n 的范围是 [0, 1000000]，所以对于这道题，
        ///     最大的“平衡数”是1224444
        ///     数字中不能出现0 7 8 9
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int NextBeautifulNumber(int n)
        {
            int result = n + 1;
            while (!IsBeautifulNumber(result)) result++;

            return result;
        }

        private bool IsBeautifulNumber(int n)
        {
            if (n <= 0) return false;

            int r; int[] freq = new int[10];
            while (n > 0)
            {
                if ((r = n % 10) == 0 || r > 6) return false;
                freq[r]++; n /= 10;
            }

            for (int i = 1; i < 7; i++) if (freq[i] != 0 && freq[i] != i) return false;

            return true;
        }
    }
}
