using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3133
{
    public class Solution3133 : Interface3133
    {
        /// <summary>
        /// 构造
        /// 1. x的二进制为1的位，数组中所有项都必须为1，
        /// 2. x的二进制为0的位，数组中所有项至少1个0
        /// 3. 本质上就是构造x的二进制为0的位
        ///     从小到大构造n个，那么第n个就是结果，由于最小的所有位都是0，所以上面第二个限制条件不用考虑了
        /// 代码实现
        /// 1. 计算n-1的二进制
        /// 2. 将n-1的二进制位从低位到高位，一次插入x二进制位为0的位置
        /// </summary>
        /// <param name="n"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public long MinEnd(int n, int x)
        {
            long result = x;
            n--;
            long bit; int pos = 0;
            while (n > 0)
            {
                bit = n & 1;
                while (((result >> pos) & 1) != 0) pos++;
                result |= bit << pos;
                n >>= 1;
                pos++;
            }

            return result;
        }
    }
}
