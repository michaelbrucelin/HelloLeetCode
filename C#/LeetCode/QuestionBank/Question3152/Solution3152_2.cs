using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3152
{
    public class Solution3152_2 : Interface3152
    {
        /// <summary>
        /// 反模式
        /// 逻辑本质上与Solution3152一样，只是这里预处理出来“阻断”“特殊数组”的值
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public bool[] IsArraySpecial(int[] nums, int[][] queries)
        {
            List<(int from, int to)> list = new List<(int from, int to)>();
            int len = nums.Length;
            for (int i = 1; i < len; i++) if (((nums[i] ^ nums[i - 1]) & 1) != 1) list.Add((i - 1, i));

            len = queries.Length;
            bool[] result = new bool[len];
            if (list.Count == 0)
            {
                Array.Fill(result, true); return result;
            }

            for (int i = 0, from = 0, to = 0, id = 0; i < len; i++)
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
                    if (id == -1 || to < list[id].to) result[i] = true;
                }
            }

            return result;

            int BinarySearch(int target)
            {
                int result = -1, left = 0, right = list.Count - 1, mid;
                while (left <= right)
                {
                    mid = left + ((right - left) >> 1);
                    if (list[mid].from < target)
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        result = mid; right = mid - 1;
                    }
                }

                return result;
            }
        }
    }
}
