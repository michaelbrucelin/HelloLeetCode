using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2241
{
    public class Solution2241
    {
    }

    public class ATM : Interface2241
    {
        /// <summary>
        /// 模拟
        /// TLE，参考测试用例02
        /// </summary>
        public ATM()
        {
            counts = new int[5];
            values = [20, 50, 100, 200, 500];
        }

        private int[] counts;
        private int[] values;

        public void Deposit(int[] banknotesCount)
        {
            for (int i = 0; i < 5; i++) counts[i] += banknotesCount[i];
        }

        public int[] Withdraw(int amount)
        {
            int[] result = new int[5];
            for (int i = 4; i >= 0; i--)
            {
                while (amount >= values[i] && counts[i] > 0)
                {
                    amount -= values[i]; counts[i]--; result[i]++;
                }
                if (amount == 0) return result;
            }

            for (int i = 0; i < 5; i++) counts[i] += result[i];
            return [-1];
        }
    }
}
