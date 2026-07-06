using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0390
{
    public class Solution0390 : Interface0390
    {
        /// <summary>
        /// 递归
        /// 第1轮
        ///     奇数消除了，余偶数，可以当成余 1*2 2*2 3*2 ...
        /// 第2轮
        ///     如果有奇数个元素，奇数消除了，余下：1*2 2*2 3*3 ...
        ///     如果有偶数个元素，偶数消除了，余下：0*2+1 1*2+1 2*2+1 ...
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int LastRemaining(int n)
        {
            return LastRemaining(n, true);

            static int LastRemaining(int n, bool flag)
            {
                if (n == 1) return 1;
                if (flag)
                {
                    return LastRemaining(n >> 1, false) << 1;
                }
                else
                {
                    return (LastRemaining(n >> 1, true) << 1) - (1 - (n & 1));
                }
            }
        }

        /// <summary>
        /// 逻辑同LastRemaining()
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int LastRemaining2(int n)
        {
            return LastRemaining(n, true);

            static int LastRemaining(int n, bool flag)
            {
                if (n == 1) return 1;
                return (LastRemaining(n >> 1, !flag) << 1) - (flag ? 0 : 1) * (1 - (n & 1));
            }
        }
    }
}
