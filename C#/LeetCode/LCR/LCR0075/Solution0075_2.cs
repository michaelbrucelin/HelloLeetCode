using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0075
{
    public class Solution0075_2 : Interface0075
    {
        /// <summary>
        /// 计数排序
        /// </summary>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        /// <returns></returns>
        public int[] RelativeSortArray(int[] arr1, int[] arr2)
        {
            int[] freq = new int[1001];
            for (int i = 0; i < arr1.Length; i++) freq[arr1[i]]++;

            int[] result = new int[arr1.Length];
            int ptr = 0;
            for (int i = 0; i < arr2.Length; i++)
            {
                Array.Fill(result, arr2[i], ptr, freq[arr2[i]]);
                ptr += freq[arr2[i]];
                freq[arr2[i]] = 0;
            }
            if (ptr < arr1.Length) for (int i = 0; i < freq.Length; i++)
                {
                    Array.Fill(result, i, ptr, freq[i]);
                    ptr += freq[i];
                    if (ptr == arr1.Length) break;
                }

            return result;
        }
    }
}
