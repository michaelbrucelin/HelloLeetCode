using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3152
{
    public class Solution3152_3 : Interface3152
    {
        /// <summary>
        /// 逻辑同Solution3152，预处理反模式的话，就不需要记录(from, to)了，因为 to = from + 1，所以只记录from即可
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public bool[] IsArraySpecial(int[] nums, int[][] queries)
        {
            List<int> list = new List<int>();
            int len = nums.Length;
            for (int i = 1; i < len; i++) if (((nums[i] ^ nums[i - 1]) & 1) != 1) list.Add(i - 1);

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
                    if (id == -1 || to <= list[id]) result[i] = true;
                }
            }

            return result;

            int BinarySearch(int target)
            {
                int result = -1, left = 0, right = list.Count - 1, mid;
                while (left <= right)
                {
                    mid = left + ((right - left) >> 1);
                    if (list[mid] < target)
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
