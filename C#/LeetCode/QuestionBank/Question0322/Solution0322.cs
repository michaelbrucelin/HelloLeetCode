using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0322
{
    public class Solution0322 : Interface0322
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="coins"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public int CoinChange(int[] coins, int amount)
        {
            if (amount == 0) return 0;

            int result = 0, len = coins.Length, cnt, curr, _amount;
            Array.Sort(coins);
            Queue<int> queue = new Queue<int>(); queue.Enqueue(0);
            HashSet<int> visited = new HashSet<int>(0);
            while ((cnt = queue.Count) > 0)
            {
                result++;
                for (int i = 0; i < cnt; i++)
                {
                    curr = queue.Dequeue();
                    for (int j = 0; j < len; j++)
                    {
                        _amount = curr + coins[j];
                        switch (amount - _amount)
                        {
                            case 0: return result;
                            case < 0: goto EndLoop;
                            default:
                                if (!visited.Contains(_amount))
                                {
                                    queue.Enqueue(_amount); visited.Add(_amount);
                                }
                                break;
                        }
                    }
                    EndLoop:;
                }
            }

            return -1;
        }
    }
}
