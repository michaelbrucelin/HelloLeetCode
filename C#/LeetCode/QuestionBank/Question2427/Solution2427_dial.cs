using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2427
{
    public class Solution2427_dial : Interface2427
    {
        private static readonly int[] primes = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193, 197, 199, 211, 223, 227, 229, 233, 239, 241, 251, 257, 263, 269, 271, 277, 281, 283, 293, 307, 311, 313, 317, 331, 337, 347, 349, 353, 359, 367, 373, 379, 383, 389, 397, 401, 409, 419, 421, 431, 433, 439, 443, 449, 457, 461, 463, 467, 479, 487, 491, 499, 503, 509, 521, 523, 541, 547, 557, 563, 569, 571, 577, 587, 593, 599, 601, 607, 613, 617, 619, 631, 641, 643, 647, 653, 659, 661, 673, 677, 683, 691, 701, 709, 719, 727, 733, 739, 743, 751, 757, 761, 769, 773, 787, 797, 809, 811, 821, 823, 827, 829, 839, 853, 857, 859, 863, 877, 881, 883, 887, 907, 911, 919, 929, 937, 941, 947, 953, 967, 971, 977, 983, 991, 997 };

        /// <summary>
        /// 数学 + 打表
        /// 1. 计算a b的公共质因数
        ///     假设公共质因数为x1个2, x2个3, x3个5 ... xn个n
        /// 2. 那么结果是(x1+1)(x2+1)(x3+1) ... (xn+1)
        /// 求质因数本身很慢，不入直接暴力解了，但是题目限定了a与b小于等于1000，所以可以打表
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int CommonFactors(int a, int b)
        {
            if (a > b) (a, b) = (b, a);
            Dictionary<int, int> dic = new Dictionary<int, int>();
            int ptr = 0, prime;
            while (ptr < primes.Length)
            {
                if ((prime = primes[ptr]) > a) break;
                if (a % prime == 0 && b % prime == 0)
                {
                    dic.TryAdd(prime, 1); dic[prime]++;
                    a /= prime; b /= prime;
                }
                else
                {
                    ptr++;
                }
            }

            int result = 1; foreach (int v in dic.Values) result *= v;
            return result;
        }

        /// <summary>
        /// 与CommonFactors()相同，将字典改为数组
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int CommonFactors2(int a, int b)
        {
            if (a > b) (a, b) = (b, a);
            int[] dic = new int[1000]; Array.Fill(dic, 1);
            int ptr = 0, prime;
            while (ptr < primes.Length)
            {
                if ((prime = primes[ptr]) > a) break;
                if (a % prime == 0 && b % prime == 0)
                {
                    dic[prime]++;
                    a /= prime; b /= prime;
                }
                else
                {
                    ptr++;
                }
            }

            int result = 1; foreach (int i in dic) result *= i;
            return result;
        }

        /// <summary>
        /// 与CommonFactors2()相同，压缩数组的大小
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int CommonFactors3(int a, int b)
        {
            if (a > b) (a, b) = (b, a);
            int[] dic = new int[primes.Length]; Array.Fill(dic, 1);
            int ptr = 0, prime;
            while (ptr < primes.Length)
            {
                if ((prime = primes[ptr]) > a) break;
                if (a % prime == 0 && b % prime == 0)
                {
                    dic[ptr]++;
                    a /= prime; b /= prime;
                }
                else
                {
                    ptr++;
                }
            }

            int result = 1; foreach (int i in dic) result *= i;
            return result;
        }
    }
}
