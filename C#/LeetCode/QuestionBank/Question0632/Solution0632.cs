using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0632
{
    public class Solution0632 : Interface0632
    {
        /// <summary>
        /// 小顶堆，滑动窗口
        /// 题意翻译一下就是每个组数中取1一个值，求这组值中最大值与最小值的差最小是多少？
        /// 可以将全部数组展平为一个数组（需要记录每个元素来自哪个数组），然后滑动窗口，始终保证窗口对每个原数组都至少包含一个元素
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] SmallestRange(IList<IList<int>> nums)
        {
            int k = nums.Count;
            int[] mask = new int[k];
            int pl = 0, pr = -1, cnt = 0;
            while (cnt < k)
            {
                // mask[]
            }

            throw new NotImplementedException();
        }
    }
}
