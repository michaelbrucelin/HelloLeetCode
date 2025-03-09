using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2070
{
    public class Solution2070_2 : Interface2070
    {
        /// <summary>
        /// 排序 + 预处理
        /// 逻辑与Solution2070一样，预处理出items前n项的最大值
        /// </summary>
        /// <param name="items"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public int[] MaximumBeauty(int[][] items, int[] queries)
        {
            int len = items.Length;
            Array.Sort(items, (x, y) => x[0] - y[0]);
            int[] maxs = new int[len];
            maxs[0] = items[0][1];
            for (int i = 1; i < len; i++) maxs[i] = Math.Max(maxs[i - 1], items[i][1]);

            len = queries.Length;
            int[] result = new int[len];
            for (int i = 0, idx = -1; i < len; i++)
            {
                if ((idx = BinarySearch(queries[i])) == -1) continue;
                result[i] = maxs[idx];
            }

            return result;

            int BinarySearch(int target)
            {
                int result = -1, left = 0, right = items.Length - 1, mid;
                while (left <= right)
                {
                    mid = left + ((right - left) >> 1);
                    if (items[mid][0] <= target)
                    {
                        result = mid; left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }

                return result;
            }
        }
    }
}
