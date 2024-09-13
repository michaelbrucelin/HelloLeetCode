using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2398
{
    public class Solution2398_2 : Interface2398
    {
        /// <summary>
        /// 稀疏表 + 前缀和 + 双指针
        /// 逻辑同Solution2398，只是用稀疏表代替前缀树来查找子数组的极值
        ///     这里的数组事静态数组，所以可以使用稀疏表
        /// </summary>
        /// <param name="chargeTimes"></param>
        /// <param name="runningCosts"></param>
        /// <param name="budget"></param>
        /// <returns></returns>
        public int MaximumRobots(int[] chargeTimes, int[] runningCosts, long budget)
        {
            int len = chargeTimes.Length;
            SparseTable<int> times = new SparseTable<int>(chargeTimes, Math.Max);
            long[] costs = new long[len + 1];
            for (int i = 0; i < len; i++) costs[i + 1] = costs[i] + runningCosts[i];

            int result = 0, pl = -1, pr = 0;
            while (++pl < len)
            {
                pr = Math.Max(pr, pl);
                while (pr < len && times.Query(pl, pr) + (pr - pl + 1) * (costs[pr + 1] - costs[pl]) <= budget) pr++;
                result = Math.Max(result, pr - pl);
            }

            return result;
        }

        public class SparseTable<T>
        {
            public SparseTable(T[] array, Func<T, T, T> queryFunction)
            {
                int n = array.Length;
                int k = (int)Math.Log2(n) + 1;
                table = new T[n, k];
                log = new int[n + 1];
                queryFunc = queryFunction;

                BuildLog(n);
                BuildTable(array, n, k);
            }

            private T[,] table;
            private Func<T, T, T> queryFunc;
            private int[] log;

            private void BuildLog(int n)
            {
                log[1] = 0;
                for (int i = 2; i <= n; i++)
                {
                    log[i] = log[i / 2] + 1;
                }
            }

            private void BuildTable(T[] array, int n, int k)
            {
                for (int i = 0; i < n; i++)
                {
                    table[i, 0] = array[i];
                }

                for (int j = 1; j < k; j++)
                {
                    for (int i = 0; i + (1 << j) <= n; i++)
                    {
                        table[i, j] = queryFunc(table[i, j - 1], table[i + (1 << (j - 1)), j - 1]);
                    }
                }
            }

            public T Query(int left, int right)
            {
                int j = log[right - left + 1];
                return queryFunc(table[left, j], table[right - (1 << j) + 1, j]);
            }
        }
    }
}
