using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1995
{
    public class Solution1995_2 : Interface1995
    {
        /// <summary>
        /// 哈希
        /// 将nums处理为Dictionary<int:num, List<int:id>>，这样可以O(1)的找到数组中是否存在目标值，以及O(logn)展出目标值的索引的数量
        /// 本质上就是 a + b + c = d 等式两边的时间复杂度分别为 O(n^3) 与 O(n)
        ///     暴力解法为：O(n^3) * O(n)
        ///     这里为：    O(n^3) + O(n)
        /// 这样做可以将暴力解的O(n^4)降为O(n^3)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int CountQuadruplets(int[] nums)
        {
            int len = nums.Length;
            Dictionary<int, List<int>> hash = new Dictionary<int, List<int>>();
            for (int i = 0; i < len; i++)
                if (hash.ContainsKey(nums[i])) hash[nums[i]].Add(i); else hash.Add(nums[i], new List<int>() { i });

            int result = 0, target;
            for (int a = 0; a < len - 3; a++) for (int b = a + 1; b < len - 2; b++) for (int c = b + 1; c < len - 1; c++)
                    {
                        target = nums[a] + nums[b] + nums[c];
                        if (hash.ContainsKey(target)) result += BinarySearch(hash[target], c);
                    }

            return result;
        }

        private int BinarySearch(List<int> list, int target)
        {
            int id = list.Count, low = 0, high = list.Count - 1, mid;
            while (low <= high)
            {
                mid = ((high - low) >> 1) + low;
                if (list[mid] > target)
                {
                    id = mid; high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return list.Count - id;
        }
    }
}
