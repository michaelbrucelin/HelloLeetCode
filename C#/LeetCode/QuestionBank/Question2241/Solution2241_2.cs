using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2241
{
    public class Solution2241_2
    {
    }

    public class ATM_2 : Interface2241
    {
        /// <summary>
        /// 模拟
        /// 逻辑同Solution2241，取钱的时候借助二分法加速
        /// </summary>
        public ATM_2()
        {
            counts = new long[5];
            values = [20, 50, 100, 200, 500];
        }

        private long[] counts;
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
                if (amount < values[i])
                {
                    continue;
                }
                else if (amount >= values[i] * counts[i])
                {
                    result[i] = (int)counts[i];
                    amount -= (int)(values[i] * counts[i]);
                }
                else
                {
                    long cnt = 1, low = 1, high = counts[i], mid;
                    while (low <= high)
                    {
                        mid = low + (high - low) / 2;
                        if (amount >= values[i] * mid)
                        {
                            cnt = mid; low = mid + 1;
                        }
                        else
                        {
                            high = mid - 1;
                        }
                    }
                    result[i] = (int)cnt;
                    amount -= (int)(values[i] * cnt);
                }

                if (amount == 0)
                {
                    for (int j = 0; j < 5; j++) counts[j] -= result[j];
                    return result;
                }
            }

            return [-1];
        }
    }
}
