using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.剑指_Offer.剑指_Offer_0039
{
    public class Solution0039_2 : Interface0039
    {
        /// <summary>
        /// 无限猴子
        /// 既然是简单题，就给它弄复杂点
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MajorityElement(int[] nums)
        {
            Random random = new Random();
            int num, len = nums.Length;
            while (true)
            {
                num = nums[random.Next(0, len)];
                if ((nums.Count(i => i == num) << 1) > len) return num;
            }
        }
    }
}
