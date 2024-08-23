using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3145
{
    public class Solution3145 : Interface3145
    {
        /// <summary>
        /// 找规律 + 二分查找
        /// 参考Dial_1024.txt，找到规律后就变成易错题了，已经没什么难度了，思路与Solution3007完全一样
        /// 二进制宽度  1的数量               乘积（2的幂）
        /// 1           1    = 2^0 + 0*2      0     = 2^0*0 + 0*2
        /// 2           4    = 2^1 + 1*2      2     = 2^1*1 + 0*2
        /// 3           12   = 2^2 + 4*2      12    = 2^2*2 + 2*2
        /// 4           32   = 2^3 + 12*2     48    = 2^3*3 + 12*2
        /// 5           80   = 2^4 + 32*2     160   = 2^4*4 + 48*2
        /// 6           192  = 2^5 + 80*2     480   = 2^5*5 + 160*2
        /// 7           448  = 2^6 + 192*2    1344  = 2^6*6 + 480*2
        /// 8           1024 = 2^7 + 484*2    3584  = 2^7*7 + 1344*2
        /// 9           2304 = 2^8 + 1024*2   9216  = 2^8*8 + 3584*2
        /// 10          5120 = 2^9 + 2304*2   23040 = 2^9*9 + 9216*2
        /// 计算[from, to]相当于计算[0, to]/[0, from-1]，计算的结果是2的幂，然后再是快速幂技巧计算题目的结果
        /// </summary>
        /// <param name="queries"></param>
        /// <returns></returns>
        public int[] FindProductsOfElements(long[][] queries)
        {
            List<(long cnt, long pow)> dstb = new List<(long cnt, long pow)>() { (0, 0) };
            for (int i = 0; dstb[i].cnt < (long)1e15; i++)
                dstb.Add(((1L << i) + (dstb[i].cnt << 1), (1L << i) * i + (dstb[i].pow << 1)));

            int len = queries.Length;
            int[] result = new int[len];
            long from, to;
            for (int i = 0; i < len; i++)
            {
                // if (queries[i][2] <= 2) { result[i] = 0; continue; }  // 如果只有1，那么结果也是1，而不是0
                if (queries[i][2] == 1) { result[i] = 0; continue; }
                from = FindPows(queries[i][0]);
                to = FindPows(queries[i][1] + 1);
                result[i] = from == to ? 1 : FastPow(to - from, (int)queries[i][2]);
            }

            return result;

            long FindPows(long target)
            {
                long result = 0, plus_cnt = 0, plus_pow = 0;
                Stack<int> stack = new Stack<int>();
                while (target >= plus_cnt)
                {
                    int idx = FindPow(target, plus_cnt);
                    if (idx < 0) break;
                    result += dstb[idx].pow + plus_pow * (1L << idx);
                    target -= dstb[idx].cnt + plus_cnt * (1L << idx);
                    plus_cnt++;
                    plus_pow += idx;
                    stack.Push(idx);
                }
                for (int i = 0; i < target; i++) result += stack.Pop();

                return result;
            }

            int FindPow(long target, long plus_cnt)
            {
                int idx = -1, left = 0, right = dstb.Count - 1, mid;
                while (left <= right)
                {
                    mid = left + ((right - left) >> 1);
                    if (dstb[mid].cnt + plus_cnt * (1L << mid) <= target)
                    {
                        idx = mid; left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }

                return idx;
            }

            int FastPow(long pow, int mod)
            {
                long result = 0, b = 2;
                while (pow > 0)
                {
                    if ((pow & 1) == 1)
                    {
                        result = b % mod; b = b * b % mod; pow >>= 1;
                        break;
                    }
                    b = b * b % mod; pow >>= 1;
                }
                while (pow > 0)
                {
                    if ((pow & 1) == 1) result = result * b % mod;
                    b = b * b % mod; pow >>= 1;
                }

                return (int)result;
            }
        }
    }
}
