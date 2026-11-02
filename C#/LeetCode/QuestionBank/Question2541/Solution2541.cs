using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2541
{
    public class Solution2541 : Interface2541
    {
        /// <summary>
        /// 计数
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public long MinOperations(int[] nums1, int[] nums2, int k)
        {
            int len = nums1.Length;
            if (k == 0)
            {
                for (int i = 0; i < len; i++) if (nums1[i] != nums2[i]) return -1;
                return 0;
            }

            long cnt1 = 0, cnt2 = 0;
            for (int i = 0, diff; i < len; i++)
            {
                if ((diff = nums1[i] - nums2[i]) % k != 0) return -1;
                if (diff >= 0) cnt1 += diff / k; else cnt2 -= diff / k;
            }

            return cnt1 != cnt2 ? -1 : cnt1;
        }
    }
}
