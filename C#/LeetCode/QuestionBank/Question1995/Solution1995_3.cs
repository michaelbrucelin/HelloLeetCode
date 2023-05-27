using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1995
{
    public class Solution1995_3 : Interface1995
    {
        /// <summary>
        /// 与Solution1995_2类似，进一步优化
        /// a + b + c = d 等价于 a + b = d - c，而 a + b = d - c 等式两边的时间复杂度都是O(n^2)
        /// 这时可以将等号一边预处理为hash表，这样可以将 O(n^2) * O(n^2) 降为 O(n^2) + O(n^2)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int CountQuadruplets(int[] nums)
        {
            int len = nums.Length;
            Dictionary<int, List<int>> hash = new Dictionary<int, List<int>>();
            int diff; for (int c = 2; c < len - 1; c++) for (int d = c + 1; d < len; d++)
                {
                    diff = nums[d] - nums[c];
                    if (hash.ContainsKey(diff)) hash[diff].Add(c); else hash.Add(diff, new List<int>() { c });
                }

            int result = 0;
            int add; for (int a = 0; a < len - 3; a++) for (int b = a + 1; b < len - 2; b++)
                {
                    add = nums[a] + nums[b];
                    if (hash.ContainsKey(add)) result += BinarySearch(hash[add], b);
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
