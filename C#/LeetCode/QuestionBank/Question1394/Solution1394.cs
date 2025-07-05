using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1394
{
    public class Solution1394 : Interface1394
    {
        /// <summary>
        /// 哈希表
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int FindLucky(int[] arr)
        {
            Dictionary<int, int> freq = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                freq.TryAdd(arr[i], 0); freq[arr[i]]++;
            }

            int result = -1;
            foreach (var kv in freq) if (kv.Key == kv.Value && kv.Key > result) result = kv.Key;

            return result;
        }

        /// <summary>
        /// 有序哈希表
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int FindLucky2(int[] arr)
        {
            SortedDictionary<int, int> freq = new SortedDictionary<int, int>(Comparer<int>.Create((i1, i2) => i2 - i1));
            for (int i = 0; i < arr.Length; i++)
            {
                freq.TryAdd(arr[i], 0); freq[arr[i]]++;
            }

            int result = -1;
            foreach (var kv in freq) if (kv.Key == kv.Value) return kv.Key;

            return result;
        }
    }
}
