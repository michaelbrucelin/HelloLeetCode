using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2670
{
    public class Solution2670_2 : Interface2670
    {
        /// <summary>
        /// 类前缀和
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] DistinctDifferenceArray(int[] nums)
        {
            int len = nums.Length;
            int[] result = new int[len];

            Dictionary<int, int> freq = new Dictionary<int, int>();
            for (int i = 0; i < len; i++)
                if (freq.ContainsKey(nums[i])) freq[nums[i]]++; else freq.Add(nums[i], 1);

            HashSet<int> set = new HashSet<int>();
            for (int i = 0; i < len; i++)
            {
                set.Add(nums[i]);
                freq[nums[i]]--; if (freq[nums[i]] == 0) freq.Remove(nums[i]);
                result[i] = set.Count - freq.Count;
            }

            return result;
        }

        /// <summary>
        /// 与DistinctDifferenceArray()逻辑一样，DistinctDifferenceArray()弄复杂了
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] DistinctDifferenceArray2(int[] nums)
        {
            int len = nums.Length;
            int[] sufcnt = new int[len];
            HashSet<int> set = new HashSet<int>();
            for (int i = len - 1; i >= 0; i--)
            {
                sufcnt[i] = set.Count(); set.Add(nums[i]);
            }

            int[] result = new int[len];
            set.Clear();
            for (int i = 0; i < len; i++)
            {
                set.Add(nums[i]); result[i] = set.Count - sufcnt[i];
            }

            return result;
        }
    }
}
