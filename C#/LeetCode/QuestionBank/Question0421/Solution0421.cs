using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0421
{
    public class Solution0421 : Interface0421
    {
        /// <summary>
        /// 贪心，递归
        /// 从高位向低位逐位判断，高位异或为1的优先
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindMaximumXOR(int[] nums)
        {
            if (nums.Length <= 1) return 0;

            return rec(nums, 31);
        }

        private int rec(IList<int> nums, int pos)
        {
            if (pos == 0 || nums.Count <= 1) return 0;

            List<int> nums0, nums1; (nums0, nums1) = split(nums, pos);

            pos--;
            if (nums0.Count > 0 && nums1.Count > 0)
                return (1 << pos) | rec(nums0, nums1, pos);
            else if (nums0.Count > 0)
                return rec(nums0, pos);
            else  // if(nums1.Count > 0)
                return rec(nums1, pos);
        }

        private int rec(IList<int> nums0, IList<int> nums1, int pos)
        {
            if (pos == 0) return 0;

            List<int> nums00, nums01; (nums00, nums01) = split(nums0, pos);
            List<int> nums10, nums11; (nums10, nums11) = split(nums1, pos);

            pos--;
            if (nums00.Count > 0 && nums11.Count > 0 && nums01.Count > 0 && nums10.Count > 0)
                return (1 << pos) | Math.Max(rec(nums00, nums11, pos), rec(nums01, nums10, pos));
            else if (nums00.Count > 0 && nums11.Count > 0)
                return (1 << pos) | rec(nums00, nums11, pos);
            else if (nums01.Count > 0 && nums10.Count > 0)
                return (1 << pos) | rec(nums01, nums10, pos);
            else
                return rec(nums0.Concat(nums1).ToArray(), pos);
        }

        /// <summary>
        /// 按pos位0与1分为两个list
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        private (List<int> nums0, List<int> nums1) split(IList<int> nums, int pos)
        {
            List<int> nums0 = new List<int>(), nums1 = new List<int>();
            int mask = 1 << (pos - 1);
            for (int i = 0, num; i < nums.Count; i++)
            {
                num = nums[i];
                if ((num & mask) != 0) nums1.Add(num); else nums0.Add(num);
            }

            return (nums0, nums1);
        }
    }
}
