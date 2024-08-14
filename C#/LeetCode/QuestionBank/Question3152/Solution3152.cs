using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3152
{
    public class Solution3152 : Interface3152
    {
        /// <summary>
        /// 分析
        /// 1. 预处理出“特殊数组”的区间
        /// 2. 二分法验证待查的区间在不在预处理出来的区间内
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public bool[] IsArraySpecial(int[] nums, int[][] queries)
        {
            List<(int from, int to)> list = new List<(int from, int to)>();
            int l, r, len = nums.Length;
            for (l = 0, r = 1; r < len; r++) if (((nums[r] ^ nums[r - 1]) & 1) != 1)
                {
                    if (l != r - 1) list.Add((l, r - 1));
                    l = r;
                }
            list.Add((l, r));

            len = queries.Length;
            bool[] result = new bool[len];
            for (int i = 0, from, to, id; i < len; i++)
            {
                from = queries[i][0]; to = queries[i][1];
                if (from == to)
                {
                    result[i] = true;
                }
                else if (from + 1 == to)
                {
                    result[i] = ((nums[from] ^ nums[to]) & 1) != 0;
                }
                else
                {
                    id = BinarySearch(from);
                    if (id != -1 && to <= list[id].to) result[i] = true;
                }
            }

            return result;

            int BinarySearch(int target)
            {
                int result = -1, left = 0, right = list.Count - 1, mid;
                while (left <= right)
                {
                    mid = left + ((right - left) >> 1);
                    if (list[mid].from <= target)
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
