using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1000
{
    public class Solution1000_2 : Interface1000
    {
        /// <summary>
        /// 与Solution1000一样，但是改为记忆化搜索
        /// 逻辑没发现问题，速度相比较Solution1000变快了不少，但是提交依然会超时，参考测试用例06
        /// </summary>
        /// <param name="stones"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MergeStones(int[] stones, int k)
        {
            int len = stones.Length;
            if (len == 1) return 0;
            if ((len - 1) % (k - 1) != 0) return -1;

            Dictionary<int[], int> memory = new Dictionary<int[], int>(new MyKeyComparer());
            return dfs(stones, k, memory);
        }

        private int dfs(int[] stones, int k, Dictionary<int[], int> memory)
        {
            if (memory.ContainsKey(stones)) return memory[stones];

            int result, len = stones.Length;
            if (len == k)
            {
                result = stones.Sum();
            }
            else
            {
                result = int.MaxValue;
                for (int i = 0, _len = len - k + 1, _sum; i <= len - k; i++)
                {
                    int[] _stones = new int[_len];
                    for (int j = 0; j < i; j++) _stones[j] = stones[j];
                    _sum = stones[i..(i + k)].Sum(); _stones[i] = _sum;
                    for (int j = i + 1; j < _len; j++) _stones[j] = stones[j + k - 1];

                    if (memory.ContainsKey(_stones))
                    {
                        result = Math.Min(result, _sum + memory[_stones]);
                    }
                    else
                    {
                        int _result = dfs(_stones, k, memory);
                        result = Math.Min(result, _sum + _result);
                    }
                }
            }

            memory.Add(stones, result);
            return result;
        }

        private class MyKeyComparer : IEqualityComparer<int[]>
        {
            public bool Equals(int[] x, int[] y)
            {
                return Enumerable.SequenceEqual(x, y);
            }

            public int GetHashCode([DisallowNull] int[] obj)
            {
                // return obj.GetHashCode();
                return (string.Join('-', obj.Select(i => i.ToString()))).GetHashCode();
            }
        }
    }
}
