using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0322
{
    public class Solution0322_3 : Interface0322
    {
        /// <summary>
        /// 迭代
        /// 逻辑与Solution0322_2完全一样，只是将递归1:1翻译为迭代
        /// </summary>
        /// <param name="coins"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public int CoinChange(int[] coins, int amount)
        {
            if (amount == 0) return 0;

            HashSet<int> set = new HashSet<int>();
            foreach (int coin in coins)
            {
                if (coin == amount) return 1;
                if (coin < amount) set.Add(coin);
            }
            Dictionary<int, int> memory = new Dictionary<int, int>();
            Stack<int> stack = new Stack<int>();
            stack.Push(amount);
            while (stack.Count > 0)
            {
                int _amount = stack.Pop();
                if (memory.ContainsKey(_amount)) continue;

                int result = int.MaxValue;
                foreach (int coin in coins)
                {
                    if (coin == _amount)
                    {
                        result = 1; break;
                    }
                    else if (coin < _amount)
                    {
                        if (!memory.ContainsKey(_amount - coin))
                        {
                            stack.Push(_amount); stack.Push(_amount - coin); goto Recutsion;
                        }
                        else
                        {
                            if (memory[_amount - coin] != -1) result = Math.Min(result, memory[_amount - coin] + 1);
                        }
                    }
                }
                memory.Add(_amount, result != int.MaxValue ? result : -1);
                Recutsion:;
            }

            return memory[amount];
        }
    }
}
