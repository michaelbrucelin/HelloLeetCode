using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3634
{
    public class Solution3634_err : Interface3634
    {
        /// <summary>
        /// 排序 + 贪心
        /// 每次操作尝试删除头部或尾部，保证删除后尾部与头部比更小
        /// 
        /// 逻辑错误，参考测试用例04，再次证明使用贪心算法的话，一定要有严格的数学证明才行
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MinRemoval(int[] nums, int k)
        {
            Array.Sort(nums);
            int result = 0, pl = 0, pr = nums.Length - 1, len = nums.Length;
            while (pl < pr)
            {
                if (1L * nums[pl] * k >= nums[pr]) return result;
                result++;
                if ((1L * nums[pl + 1] * nums[pr - 1]) <= (1L * nums[pl] * nums[pr])) pr--; else pl++;
            }

            return len - 1;
        }
    }
}
