using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2241
{
    public class Solution2241_3
    {
    }

    public class ATM_3 : Interface2241
    {
        /// <summary>
        /// 模拟
        /// 逻辑同Solution2241，脑残了，除一下就知道结果了，还在Solution2241_2中用二分法。。。
        /// </summary>
        public ATM_3()
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
            for (int i = 4, _cnt; i >= 0; i--)
            {
                _cnt = (int)Math.Min(amount / values[i], counts[i]);
                if (_cnt > 0)
                {
                    amount -= values[i] * _cnt;
                    result[i] = _cnt;

                    if (amount == 0)
                    {
                        for (int j = 0; j < 5; j++) counts[j] -= result[j];
                        return result;
                    }
                }
            }

            return [-1];
        }
    }
}
