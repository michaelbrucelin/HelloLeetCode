using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2736
{
    public class Solution2736_2 : Interface2736
    {
        /// <summary>
        /// 与Solution2736逻辑一样
        /// 由于超时的测试用例queries中全部是重复值，所以添加记忆化试试，总感觉不应该使用记忆化，因为可能的情况太多，可能MLE
        /// 
        /// 提交通过，海外版 双百，很意外，国内版 双0，这算一个成就吗？... ...
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
            Dictionary<(int, int), int> memory = new Dictionary<(int, int), int>();
            for (int i = 0, q1 = 0, q2 = 0; i < len; i++)
            {
                (q1, q2) = (queries[i][0], queries[i][1]);
                if (!memory.ContainsKey((q1, q2)))
                {
                    foreach (var kv in dic) foreach (var kv1 in kv.Value)
                        {
                            if (kv1.Key < q1) break;
                            foreach (int key2 in kv1.Value)
                            {
                                if (key2 < q2) break;
                                memory.Add((q1, q2), kv.Key); goto CONTINUE;
                            }
                        }
                    memory.Add((q1, q2), -1);
                }
                CONTINUE:;
                result[i] = memory[(q1, q2)];
            }

            return result;
        }
    }
}
