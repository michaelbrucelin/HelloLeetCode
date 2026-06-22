using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1830
{
    public class Solution1830 : Interface1830
    {
        /// <summary>
        /// 数学，排列组合
        /// 题目描述的操作，就是找出下一个更小的排列，那么结果就是s在所有排列中的位置
        /// 即计算有多少个更小的排列
        /// 例如：s = "cdbea"
        /// 第1位选a，有 4*3*2*1 = 24 个
        /// 第1位选b，有 4*3*2*1 = 24 个
        /// 第1位选c，第2位选a，有 3*2*1 = 6 个
        ///           第2位选b，有 3*2*1 = 6 个
        /// 第1位选c，第2位选d，第3位选a，有 2*1 = 2 个
        /// 第1位选c，第2位选d，第3位选b，第4位选a，有 1 = 1 个
        /// 总共有 24+24+6+6+2+1 = 63 个比 "cdbea" 更小的排列
        /// 
        /// 使用BigInteger类来计算排列数，大概率会TLE，先保证基本逻辑对再说
        /// 逻辑没问题，意料之中的TLE，参考测试用例06
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MakeStringSorted2(string s)
        {
            int result = 0, len = s.Length;
            const int MOD = (int)1e9 + 7;
            int[] freq = new int[26];
            for (int i = 0; i < len; i++) freq[s[i] - 'a']++;
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < s[i] - 'a'; j++) if (freq[j] > 0)
                    {
                        freq[j]--;
                        result = (result + Count(len - i - 1)) % MOD;
                        freq[j]++;
                    }
                freq[s[i] - 'a']--;
            }

            return result;

            int Count(int len)
            {
                if (len == 0) return 0;

                BigInteger count = 1;
                for (int i = 2; i <= len; i++) count *= i;
                for (int i = 0; i < 26; i++) for (int j = 2; j <= freq[i]; j++) count /= j;
                return (int)(count % MOD);
            }
        }

        /// <summary>
        /// 逻辑同MakeStringSorted()，稍加优化，先预处理出全部的阶乘数再说
        /// 
        /// 快了很多，但是依然TLE，参考测试用例07 08
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MakeStringSorted(string s)
        {
            int result = 0, len = s.Length;
            const int MOD = (int)1e9 + 7;
            int[] freq = new int[26];
            BigInteger[] counts = Factorial(len - 1);
            for (int i = 0; i < len; i++) freq[s[i] - 'a']++;
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < s[i] - 'a'; j++) if (freq[j] > 0)
                    {
                        freq[j]--;
                        result = (result + Count(len - i - 1)) % MOD;
                        freq[j]++;
                    }
                freq[s[i] - 'a']--;
            }

            return result;

            int Count(int len)
            {
                if (len == 0) return 0;

                BigInteger count = counts[len];
                for (int i = 0; i < 26; i++) count /= counts[freq[i]];
                return (int)(count % MOD);
            }

            BigInteger[] Factorial(int n)
            {
                BigInteger[] result = new BigInteger[n + 1];
                result[0] = 1;
                for (int i = 1; i <= n; i++) result[i] = result[i - 1] * i;
                return result;
            }
        }
    }
}
