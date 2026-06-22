using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1833
{
    public class Solution1833_3 : Interface1833
    {
        /// <summary>
        /// 分情况讨论
        /// 题目要求使用计数排序，但是如果数组长度较小，使用计数排序就不好了
        /// 所以这里先找出使用 堆 与 计数排序的临界值 7740，然后分情况计算
        /// </summary>
        /// <param name="costs"></param>
        /// <param name="coins"></param>
        /// <returns></returns>
        public int MaxIceCream(int[] costs, int coins)
        {
            long COSTS = 0;
            foreach (int cost in costs) COSTS += cost;
            if (COSTS <= coins) return costs.Length;

            int result = 0, sum = 0, len = costs.Length;
            if (len <= 7740)
            {
                PriorityQueue<int, int> minpq = new PriorityQueue<int, int>(costs.Select(x => (x, x)));
                // for (int i = 0; i < len; i++) minpq.Enqueue(costs[i], costs[i]);
                while (minpq.Count > 0)
                {
                    result++;
                    if ((sum += minpq.Dequeue()) > coins) { result--; break; }
                }
            }
            else
            {
                int[] freq = new int[100001];
                for (int i = 0; i < len; i++) freq[costs[i]]++;
                for (int i = 0, _sum; i < 100001; i++) if (freq[i] > 0)
                    {
                        _sum = i * freq[i];
                        if (sum + _sum <= coins)
                        {
                            result += freq[i]; sum += _sum;
                        }
                        else
                        {
                            result += (coins - sum) / i; break;
                        }
                    }
            }

            return result;
        }
    }
}
