using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1415
{
    public class Solution1415_2
    {
        /// <summary>
        /// 数学，递推（逆二分查找）
        /// 长度为n，总数有 cnt = 3*2*2... 个开心字符串，共 n-1 个2
        /// 如果 k>cnt，无解，否则递推找解
        ///     将 cnt 分为 3 份，k 属于第 1 份，结果的第一个字符是 a，k 属于第 2 份，结果的第一个字符是 b，k 属于第 3 份，结果的第一个字符是 c
        ///     将前面的那一份分为 2 份，k 属于第 1 份，结果的第一个字符是 ?，k 属于第 2 份，结果的第一个字符是 ?
        ///     ... ...
        /// 代码可以使用位运算（二进制掩码）进行优化，因为在缩小区间时依次为2^{n-1},2^{n-1},...2^0，意义不大，这里不做了
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public string GetHappyString(int n, int k)
        {
            int total = 3 * (int)Math.Pow(2, n - 1);
            if (k > total) return "";

            char[] buffer = new char[n];
            total /= 3;
            int idx = 0, lo, hi, mid;
            if (k <= total)
            {
                buffer[0] = 'a'; lo = 1; hi = total;
            }
            else if (k <= (total << 1))
            {
                buffer[0] = 'b'; lo = total + 1; hi = total << 1;
            }
            else
            {
                buffer[0] = 'c'; lo = (total << 1) + 1; hi = total * 3;
            }

            while (++idx < n)
            {
                mid = (lo + hi) >> 1;
                if (k <= mid)
                {
                    buffer[idx] = buffer[idx - 1] == 'a' ? 'b' : 'a';
                    hi = mid;
                }
                else
                {
                    buffer[idx] = buffer[idx - 1] == 'c' ? 'b' : 'c';
                    lo = mid + 1;
                }
            }

            return new string(buffer);
        }
    }
}
