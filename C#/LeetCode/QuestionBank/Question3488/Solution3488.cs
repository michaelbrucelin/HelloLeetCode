using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3488
{
    public class Solution3488 : Interface3488
    {
        /// <summary>
        /// hash + 二分
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public IList<int> SolveQueries(int[] nums, int[] queries)
        {
            int lenn = nums.Length, lenq = queries.Length;
            Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
            for (int i = 0, num; i < lenn; i++)
            {
                num = nums[i];
                if (map.TryGetValue(num, out List<int> list)) list.Add(i); else map.Add(num, [i]);
            }

            int[] result = new int[lenq];
            List<int> ids;
            for (int i = 0, j, query; i < lenq; i++)
            {
                query = queries[i];
                ids = map[nums[query]];
                if (ids.Count == 1) { result[i] = -1; continue; }
                result[i] = lenn;
                j = binary_search(ids, query);
                result[i] = Math.Min(result[i], j > 0 ? query - ids[j - 1] : query + lenn - ids[^1]);
                result[i] = Math.Min(result[i], j < ids.Count - 1 ? ids[j + 1] - query : lenn - query + ids[0]);
            }

            return result;

            static int binary_search(List<int> list, int target)
            {
                int left = 0, right = list.Count - 1, mid;
                while (left <= right)
                {
                    mid = left + ((right - left) >> 1);
                    switch (list[mid] - target)
                    {
                        case > 0: right = mid - 1; break;
                        case < 0: left = mid + 1; break;
                        default: return mid;
                    }
                }

                return -1;
            }
        }
    }
}
