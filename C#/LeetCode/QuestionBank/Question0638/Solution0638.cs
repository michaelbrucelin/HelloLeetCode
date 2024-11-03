using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0638
{
    public class Solution0638 : Interface0638
    {
        /// <summary>
        /// DFS + 回溯
        /// 1. 如果大礼包的价值大于等于买单独的礼品，那么移除这个大礼包
        /// 2. DFS大礼包，差的部分单买相应的礼品补齐
        /// </summary>
        /// <param name="price"></param>
        /// <param name="special"></param>
        /// <param name="needs"></param>
        /// <returns></returns>
        public int ShoppingOffers(IList<int> price, IList<IList<int>> special, IList<int> needs)
        {
            int n = price.Count;
            // 移除“假的”、“超标”大礼包
            for (int i = special.Count - 1, _price; i >= 0; i--)
            {
                _price = 0;
                for (int j = 0; j < n; j++)
                {
                    if (special[i][j] > needs[j]) { special.RemoveAt(i); goto REMOVEATI; }
                    _price += price[j] * special[i][j];
                }
                if (_price <= special[i][^1]) special.RemoveAt(i);
                REMOVEATI:;
            }

            int result = int.MaxValue;
            dfs(0, 0);

            return result;

            void dfs(int pos, int cost)
            {
                if (pos == special.Count)
                {
                    for (int i = 0; i < n; i++) cost += price[i] * needs[i];
                    result = Math.Min(result, cost);
                }
                else
                {
                    int times = int.MaxValue;
                    for (int i = 0; i < n; i++) if (special[pos][i] > 0) times = Math.Min(times, needs[i] / special[pos][i]);  // 题目限定special至少一个个礼品非0
                    for (int i = 0; i <= times; i++)
                    {
                        for (int j = 0; j < n; j++) needs[j] -= special[pos][j] * i;
                        dfs(pos + 1, cost + special[pos][^1] * i);
                        for (int j = 0; j < n; j++) needs[j] += special[pos][j] * i;
                    }
                }
            }
        }
    }
}
