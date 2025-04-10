using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2999
{
    public class Solution2999 : Interface2999
    {
        /// <summary>
        /// 构造 + 排列组合
        /// 令F(N)表示[1..N]的结果，则[start, finish]的结果为F(finish) - F(start - 1)
        /// 
        /// 不难，但很恶心易错，目前还是错误的，参考测试用例06，不改了
        /// </summary>
        /// <param name="start"></param>
        /// <param name="finish"></param>
        /// <param name="limit"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public long NumberOfPowerfulInt(long start, long finish, int limit, string s)
        {
            long suffix = long.Parse(s);
            if (suffix > finish) return 0;

            return NumberOfPowerfulInt(finish) - NumberOfPowerfulInt(start - 1);

            long NumberOfPowerfulInt(long N)
            {
                if (N < suffix) return 0;

                int lens = s.Length, lenN = (int)Math.Log10(N) + 1;
                if (lenN == lens) return 1;  // N >= suffix

                long count = 1, cnt;
                // 构造长度小于N的
                for (int len = lens + 1; len < lenN; len++)
                {
                    cnt = limit;
                    for (int i = 0; i < len - lens - 1; i++) cnt *= limit + 1;
                    count += cnt;
                }
                // 构造长度等于N且首位小于N首位的
                long step = (long)Math.Pow(10, lenN - 1);
                cnt = Math.Min(N / step - 1, limit);
                if (cnt > 0) for (int i = 0; i < lenN - lens - 1; i++) cnt *= limit + 1;
                count += cnt;
                // 构造长度等于N且首位等于N首位的
                long _N = N;
                _N -= step * (N / step);                              // 移除首位
                _N /= (long)Math.Pow(10, lens);                       // 移除末尾的suffix长度
                if (_N > 0)
                {
                    cnt = CountLimitN(_N);
                }
                else
                {
                    cnt = 0;
                }
                if (cnt == 0 && N % (long)Math.Pow(10, lens) >= suffix) cnt = 1;
                count += cnt;

                return count;
            }

            long CountLimitN(long N)   // 由[0..limit]构成的小于等于N的整数数量
            {
                if (N == 0) return 0;  // 题目限定limit >= 1

                int len = (int)Math.Log10(N) + 1;
                if (len == 1)
                {
                    return Math.Min(N, limit) + 1;
                }
                else
                {
                    long count = 1;
                    for (int i = 0; i < len - 1; i++) count *= limit + 1;
                    long step = (long)Math.Pow(10, len - 1);
                    count *= Math.Min(N / step, limit);

                    return count + CountLimitN(N - (N / step * step));
                }
            }
        }
    }
}
