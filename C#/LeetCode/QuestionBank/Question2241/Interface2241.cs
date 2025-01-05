using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2241
{
    /// <summary>
    /// Your ATM object will be instantiated and called as such:
    /// ATM obj = new ATM();
    /// obj.Deposit(banknotesCount);
    /// int[] param_2 = obj.Withdraw(amount);
    /// </summary>
    public interface Interface2241
    {
        // public ATM()
        // {
        // }

        public void Deposit(int[] banknotesCount);

        public int[] Withdraw(int amount);
    }
}
