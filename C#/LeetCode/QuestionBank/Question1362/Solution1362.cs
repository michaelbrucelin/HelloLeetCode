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
            int[] result = [1, num + 1];

            int x, y, z, diff;
            z = num + 1; x = (int)Math.Floor(Math.Sqrt(z)); y = (int)Math.Ceiling(Math.Sqrt(z));
            if (x == y) return [x, y];
            while (x > 1) switch (x * y - z)
                {
                    case > 0: x = Math.Min(x - 1, z / y); break;
                    case < 0: y = Math.Max(y + 1, z / x); break;
                    default: result = [x, y]; x = -1; break;
                }
            z = num + 2; x = (int)Math.Floor(Math.Sqrt(z)); y = (int)Math.Ceiling(Math.Sqrt(z));
            if (x == y) return [x, y];
            diff = result[1] - result[0];
            while (y - x < diff) switch (x * y - z)
                {
                    case > 0: x = Math.Min(x - 1, z / y); break;
                    case < 0: y = Math.Max(y + 1, z / x); break;
                    default: result = [x, y]; x = -1; break;
                }

            return result;
        }
    }
}
