using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0201
{
    public class Solution0201 : Interface0201
    {
        /// <summary>
        /// 找规律
        /// 某1位，只要有1个0，这一位就是0，而[0..]的二进制分布如下：
        /// 倒数第1位，第0位，0          1          0           1           分布
        /// 倒数第2位，第1位，00[0,1]    11[2,3]    00[4,5]     11[6,7]     分布
        /// 倒数第3位，第2位，0000[0,3]  1111[4,7]  0000[8,11]  1111[12,15] 分布
        /// ...
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public int RangeBitwiseAnd(int left, int right)
        {
            if (left == 0) return 0;
            if (left == right) return left;

            int result = 0, cnt = right - left + 1;
            long span, span2, _left, _right;
            for (int i = 0; i < 31; i++)
            {
                span = 1L << i;
                if (span > right) break;
                if (cnt > span) continue;  // 抽屉原理
                span2 = span << 1;
                _left = left >= span ? (left - span) / span2 * span2 + span : 0;
                _right = _left + span - 1;
                if (_right >= right) result |= 1 << i;
            }

            return result;
        }
    }
}
