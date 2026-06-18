using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0330
{
    public class Solution0330 : Interface0330
    {
        /// <summary>
        /// 遍历，类BFS
        /// 例如：nums = [1,5,10], n = 20
        /// 1， 覆盖到[0,1]，没有达到下一个元素5
        ///     补数字2，覆盖到[0,3]，没有达到下一个元素5
        ///     补数字4，覆盖到[0,7]，达到下一个元素5
        /// 5， 覆盖到[0,12]，达到下一个元素10
        /// 10，覆盖到[0,22]，达标n=20
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public int MinPatches(int[] nums, int n)
        {
            int result = 0; long reach = 0; int idx = 0, len = nums.Length;
            if (nums[0] == 1) { reach = 1; idx = 1; }                        // 题目限定nums非空
            while (reach < n)
            {
                while (reach < n && idx < len && reach + 1 >= nums[idx]) reach += nums[idx++];
                if (reach >= n) break;
                reach += reach + 1;
                result++;
            }

            return result;
        }
    }
}
