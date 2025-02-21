using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2736
{
    public class Solution2736 : Interface2736
    {
        /// <summary>
        /// 贪心 + 排序
        /// 使用3级排序，1: num1+num2 降序, 2: num1 降序, 3: num2 降序  O(nlogn)
        /// 每一级排序，从大到小去查找符合 query 的结果                 O(n)
        /// 
        /// 逻辑没问题，TLE
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public int[] MaximumSumQueries(int[] nums1, int[] nums2, int[][] queries)
        {
            int n = nums1.Length, len = queries.Length;
            Comparer<int> comparer = Comparer<int>.Create((i, j) => j - i);
            SortedDictionary<int, SortedDictionary<int, SortedSet<int>>> dic = new SortedDictionary<int, SortedDictionary<int, SortedSet<int>>>(comparer);
            for (int i = 0, _sum; i < n; i++)
            {
                _sum = nums1[i] + nums2[i];
                if (dic.ContainsKey(_sum))
                {
                    if (dic[_sum].ContainsKey(nums1[i]))
                        dic[_sum][nums1[i]].Add(nums2[i]);
                    else
                        dic[_sum].Add(nums1[i], new SortedSet<int>(comparer) { nums2[i] });
                }
                else
                    dic.Add(_sum, new SortedDictionary<int, SortedSet<int>>(comparer) { { nums1[i], new SortedSet<int>(comparer) { nums2[i] } } });
            }

            int[] result = new int[len];
            for (int i = 0, q1 = 0, q2 = 0; i < len; i++)
            {
                (q1, q2) = (queries[i][0], queries[i][1]);
                foreach (var kv in dic) foreach (var kv1 in kv.Value)
                    {
                        if (kv1.Key < q1) break;
                        foreach (int key2 in kv1.Value)
                        {
                            if (key2 < q2) break;
                            result[i] = kv.Key; goto CONTINUE;
                        }
                    }
                result[i] = -1;
                CONTINUE:;
            }

            return result;
        }
    }
}
