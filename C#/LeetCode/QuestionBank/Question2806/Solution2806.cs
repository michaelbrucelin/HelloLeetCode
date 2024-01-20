using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2806
{
    public class Solution2806 : Interface2806
    {
        public int AccountBalanceAfterPurchase(int purchaseAmount)
        {
            return 100 - (purchaseAmount / 10 + (purchaseAmount % 10 < 5 ? 0 : 1)) * 10;
        }

        public int AccountBalanceAfterPurchase2(int purchaseAmount)
        {
            return 100 - (purchaseAmount + 5) / 10 * 10;
        }
    }
}
