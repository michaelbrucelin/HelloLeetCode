using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1250
{
    public class Solution1250 : Interface1250
    {
        /// <summary>
        /// 分析
        /// 1. 数组先去重，重复的项没有意义
        /// 2. 数组去掉倍数（6是3的倍数），倍数（6）没有意义
        /// 3. 数组中必有奇数，全是偶数的结果必然是偶数，不可能为1
        /// 
        /// 已经猜测到“只要一组数没有公约数，即最大公约数为1，就有解”，但是没证明出来，看了官解才知道有“裴蜀定理”。
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool IsGoodArray(int[] nums)
        {
            throw new NotImplementedException();
        }
    }
}
