using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2363
{
    public class Solution2363 : Interface2363
    {
        /// <summary>
        /// 有序哈希
        /// </summary>
        /// <param name="items1"></param>
        /// <param name="items2"></param>
        /// <returns></returns>
        public IList<IList<int>> MergeSimilarItems(int[][] items1, int[][] items2)
        {
            SortedDictionary<int, int> helper = new SortedDictionary<int, int>();
            for (int i = 0; i < items1.Length; i++) helper.Add(items1[i][0], items1[i][1]);
            for (int i = 0; i < items2.Length; i++)
                if (helper.ContainsKey(items2[i][0])) helper[items2[i][0]] += items2[i][1]; else helper.Add(items2[i][0], items2[i][1]);

            List<IList<int>> result = new List<IList<int>>();
            foreach (var kv in helper) result.Add(new int[] { kv.Key, kv.Value });
            return result;
        }

        /// <summary>
        /// 排序归并
        /// </summary>
        /// <param name="items1"></param>
        /// <param name="items2"></param>
        /// <returns></returns>
        public IList<IList<int>> MergeSimilarItems2(int[][] items1, int[][] items2)
        {
            Array.Sort(items1, (arr1, arr2) => arr1[0] - arr2[0]);
            Array.Sort(items2, (arr1, arr2) => arr1[0] - arr2[0]);

            List<IList<int>> result = new List<IList<int>>();
            int p1 = 0, p2 = 0, len1 = items1.Length, len2 = items2.Length;
            while (p1 < len1 && p2 < len2)
            {
                switch (items1[p1][0] - items2[p2][0])
                {
                    case < 0:
                        result.Add(new int[] { items1[p1][0], items1[p1++][1] });
                        break;
                    case > 0:
                        result.Add(new int[] { items2[p2][0], items2[p2++][1] });
                        break;
                    default:  // case 0:
                        result.Add(new int[] { items1[p1][0], items1[p1++][1] + items2[p2++][1] });
                        break;
                }
            }
            // while (p1 < len1) result.Add(new int[] { items1[p1][0], items1[p1++][1] });
            if (p1 < len1) result.AddRange(items1[p1..^0]);
            // while (p2 < len2) result.Add(new int[] { items2[p2][0], items2[p2++][1] });
            if (p2 < len2) result.AddRange(items2[p2..^0]);

            return result;
        }

        public IList<IList<int>> MergeSimilarItems3(int[][] items1, int[][] items2)
        {
            return items1.Concat(items2)
                         .GroupBy(item => item[0])
                         .OrderBy(g => g.Key)
                         .Select(g => new int[] { g.Key, g.Sum(_g => _g[1]) })
                         .ToArray();
        }
    }
}
