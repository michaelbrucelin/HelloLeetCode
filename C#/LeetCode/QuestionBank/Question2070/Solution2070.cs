using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2070
{
    public class Solution2070 : Interface2070
    {
        /// <summary>
        /// 排序
        /// 按照price排序，二分找出价格合适的范围，遍历查找最大值
        /// 
        /// 逻辑没问题，TLE，参考测试用例04
        /// </summary>
        /// <param name="items"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public int[] MaximumBeauty(int[][] items, int[] queries)
        {
            Array.Sort(items, (x, y) => x[0] - y[0]);
            int len = queries.Length;
            int[] result = new int[len];
            for (int i = 0, idx = -1, max = 0; i < len; i++)
            {
                if ((idx = BinarySearch(queries[i])) == -1) continue;
                max = items[0][1];
                for (int j = 1; j <= idx; j++) max = Math.Max(max, items[j][1]);
                result[i] = max;
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
