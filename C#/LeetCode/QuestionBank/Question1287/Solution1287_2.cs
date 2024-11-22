using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1287
{
    public class Solution1287_2 : Interface1287
    {
        /// <summary>
        /// 哈希计数
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public int FindSpecialInteger(int[] arr)
        {
            Dictionary<int, int> freq = new Dictionary<int, int>();
            foreach (var num in arr)
                if (freq.ContainsKey(num)) freq[num]++; else freq.Add(num, 1);

            int p25 = arr.Length >> 2;
            foreach (var kv in freq)
                if (kv.Value > p25) return kv.Key;

            throw new Exception("TestCase Or Code Logic Error.");  // 题目保证了一定有唯一解
        }

        /// <summary>
        /// 哈希计数优化
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public int FindSpecialInteger2(int[] arr)
        {
            int p25 = arr.Length >> 2;
            Dictionary<int, int> freq = new Dictionary<int, int>();
            foreach (var num in arr)
            {
                if (freq.ContainsKey(num)) freq[num]++; else freq.Add(num, 1);
                if (freq[num] > p25) return num;
            }

            throw new Exception("TestCase Or Code Logic Error.");  // 题目保证了一定有唯一解
        }
    }
}
