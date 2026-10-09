using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1362
{
    public class Solution1362 : Interface1362
    {
        /// <summary>
        /// 暴力查找
        /// 令x=floor(sqrt(num)), y=ceiling(sqrt(num))，如果x==y，结果为[x,y]
        /// if(xy > num) x=min(x-1,floor(num/y)); else y=max(y+1,ceiling(num/x));  // 就是加速 if(xy > num) x--; else y++;
        /// 
        /// TLE
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int[] ClosestDivisors(int num)
        {
            int[] r1 = _ClosestDivisors(num + 1);
            int[] r2 = _ClosestDivisors(num + 2);

            return r1[1] - r1[0] <= r2[1] - r2[0] ? r1 : r2;

            static int[] _ClosestDivisors(int num)
            {
                int x = (int)Math.Sqrt(num) + 1;
                while (--x > 1) if (num % x == 0) return [x, num / x];
                return [1, num];
            }
        }
    }
}
