using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2043
{
    public class Solution2043
    {
    }

    public class Bank : Interface2043
    {
        public Bank(long[] balance)
        {
            this.balance = balance;
            count = balance.Length;
        }

        private int count;
        private long[] balance;

        public bool Deposit(int account, long money)
        {
            if (account > 0 && account <= count)
            {
                balance[account - 1] += money;
                return true;
            }
            return false;
        }

        public bool Transfer(int account1, int account2, long money)
        {
            if (account1 > 0 && account1 <= count && balance[account1 - 1] >= money && account2 > 0 && account2 <= count)
            {
                balance[account1 - 1] -= money;
                balance[account2 - 1] += money;
                return true;
            }
            return false;
        }

        public bool Withdraw(int account, long money)
        {
            if (account > 0 && account <= count && balance[account - 1] >= money)
            {
                balance[account - 1] -= money;
                return true;
            }
            return false;
        }
    }
}
