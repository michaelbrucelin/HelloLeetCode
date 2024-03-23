using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2549
{
    public class Solution2549 : Interface2549
    {
        /// <summary>
        /// 模拟
        /// 通解，适用于初始时n特别大，而总天数比较小的情况，例如n=10^9，总共100天
        /// 一天一天处理（BFS分层处理）
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int DistinctIntegers(int n)
        {
            HashSet<int> result = new HashSet<int>() { n };
            Queue<int> queue = new Queue<int>(); queue.Enqueue(n);
            for (int i = 0, cnt; i < n; i++)  // 不会超过n天的
            {
                while ((cnt = queue.Count()) > 0) for (int j = 0; j < cnt; j++)
                    {
                        int _n = queue.Dequeue() - 1;
                        if (_n > 1 && !result.Contains(_n))
                        {
                            int ceiling = _n >> 1;
                            for (int k = 2; k <= ceiling; k++)
                            {
                                var info = Math.DivRem(_n, k);
                                if (info.Remainder == 0)
                                {
                                    result.Add(k); result.Add(info.Quotient);
                                    queue.Enqueue(k); queue.Enqueue(info.Quotient);
                                }
                            }
                            result.Add(_n); queue.Enqueue(_n);
                        }
                    }
            }

            return result.Count;
        }
    }
}
