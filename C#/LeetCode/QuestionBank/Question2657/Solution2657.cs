using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2657
{
    public class Solution2657 : Interface2657
    {
        /// <summary>
        /// Hash
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public int[] FindThePrefixCommonArray(int[] A, int[] B)
        {
            int n = A.Length;
            int[] result = new int[n];
            HashSet<int> set1 = [], set2 = [];
            for (int i = 0; i < n; i++)
            {
                set1.Add(A[i]); set2.Add(B[i]);
                result[i] = set1.Intersect(set2).Count();
            }

            return result;
        }

        /// <summary>
        /// Hash + DP
        /// 逻辑同FindThePrefixCommonArray()，优化
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public int[] FindThePrefixCommonArray2(int[] A, int[] B)
        {
            int n = A.Length;
            int[] result = new int[n];
            HashSet<int> set1 = [], set2 = [];
            for (int i = 0, last = 0; i < n; i++)
            {
                set1.Add(A[i]); set2.Add(B[i]);
                if (A[i] == B[i])
                {
                    last++;
                }
                else
                {
                    if (set1.Contains(B[i])) last++;
                    if (set2.Contains(A[i])) last++;
                }
                result[i] = last;
            }

            return result;
        }
    }
}
