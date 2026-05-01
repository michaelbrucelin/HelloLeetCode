using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3912
{
    public class Solution3912_2 : Interface3912
    {
        /// <summary>
        /// 预处理
        /// 预处理出每一个位置的左侧的最大值以及右侧的最大值
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<int> FindValidElements(int[] nums)
        {
            if (nums.Length < 3) return [.. nums];

            int len = nums.Length;
            int[] rmax = new int[len];
            rmax[len - 1] = int.MinValue;
            for (int i = len - 2; i >= 0; i--) rmax[i] = Math.Max(rmax[i + 1], nums[i + 1]);

            IList<int> result = new List<int>();
            int lmax = int.MinValue;
            for (int i = 0, num; i < len; i++)
            {
                num = nums[i];
                if (num > lmax || num > rmax[i]) result.Add(num);
                lmax = Math.Max(lmax, num);
            }

            return result;
        }
    }
}
