using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.剑指_Offer.剑指_Offer_0039
{
    public class Solution0039 : Interface0039
    {
        /// <summary>
        /// 摩尔投票
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MajorityElement(int[] nums)
        {
            int num = nums[0], cnt = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == num) cnt++;
                else
                {
                    if (cnt == 0) { num = nums[i]; cnt = 1; }
                    else cnt--;
                }
            }

            return num;
        }
    }
}
