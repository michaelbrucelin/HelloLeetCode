using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2827
{
    public class Solution2827_err : Interface2827
    {
        /// <summary>
        /// 分段函数
        /// 例如low = 1010, high = 10101010，分别计算 [1010, 9999], [100000, 999999], [10000000, 10101010] 中的结果的数量即可
        /// 
        /// 题目理解错了，题意是数位中奇数的数量和偶数的数量相等，这里理解成奇数位索引与偶数位索引数量相等了
        /// 例如：1234                1 3   2个   2 4   2个                 数字的宽度是4
        /// </summary>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int NumberOfBeautifulIntegers(int low, int high, int k)
        {
            long result = 0, _low = 10, left, right, offset;
            while (_low < low) _low *= 100;
            while (_low <= high)
            {
                left = Math.Max(_low, low);
                right = Math.Min(_low * 10 - 1, high);
                offset = k - left % k;
                left += offset;
                if (left <= right) result += (right - left) / k + 1;

                _low *= 100;
            }

            return (int)result;
        }
    }
}
