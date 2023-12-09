using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2048
{
    public class Solution2048_2 : Interface2048
    {
        /// <summary>
        /// 分析 + 构造 + 硬编码
        /// 1. 题目限定 n 的范围是 [0, 1000000]，所以结果也就那么几种可能
        ///     1位，只有1
        ///     2位，只有22
        ///     3位，有333，    或1,2组合，即1个1和2个2的所有组合
        ///     4位，有4444，   或1,3组合
        ///     5位，有55555，  或1,4组合，2,3组合
        ///     6位，有666666， 或1,5组合，2,4组合，1,2,3组合
        ///     7位，有7777777，或1,6组合，2,5组合，3,4组合，1,2,5组合
        /// 2. 每一种组合都可以通过全排列生成所有的可能性，然后找出符合条件的最小值
        /// 
        /// 生产中这种解法意义不大，这里这么写只是为了玩
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int NextBeautifulNumber(int n)
        {
            if (n < 1) return 1;
            if (n < 22) return 22;
            if (n < 122) return 122;

            const int MAX_RESULT = 7777777;
            int result = MAX_RESULT;
            int len = 0, _n = n; while (_n > 0) { len++; _n /= 10; }
            switch (len)
            {
                case 3: goto LEN3;
                case 4: goto LEN4;
                case 5: goto LEN5;
                case 6: goto LEN6;
                default: goto LEN7;
            }

            // 3位
            LEN3:;
            dfs(n, new Dictionary<int, int>() { { 1, 1 }, { 2, 2 } }, 0, ref result);
            if (result != MAX_RESULT) return result;
            if (333 > n) return 333;

            // 4位
            LEN4:;
            dfs(n, new Dictionary<int, int>() { { 1, 1 }, { 3, 3 } }, 0, ref result);
            if (result != MAX_RESULT) return result;
            if (4444 > n) return 4444;

            // 5位
            LEN5:;
            dfs(n, new Dictionary<int, int>() { { 1, 1 }, { 4, 4 } }, 0, ref result);
            dfs(n, new Dictionary<int, int>() { { 2, 2 }, { 3, 3 } }, 0, ref result);
            if (result != MAX_RESULT) return result;
            if (55555 > n) return 55555;

            // 6位
            LEN6:;
            dfs(n, new Dictionary<int, int>() { { 1, 1 }, { 5, 5 } }, 0, ref result);
            dfs(n, new Dictionary<int, int>() { { 2, 2 }, { 4, 4 } }, 0, ref result);
            dfs(n, new Dictionary<int, int>() { { 1, 1 }, { 2, 2 }, { 3, 3 } }, 0, ref result);
            if (result != MAX_RESULT) return result;
            if (666666 > n) return 666666;

            // 7位
            LEN7:;
            return 1224444;
        }

        private void dfs(int n, Dictionary<int, int> digits, int curr, ref int result)
        {
            if (digits.Count == 0)
            {
                if (curr > n) result = Math.Min(result, curr);
                return;
            }

            foreach (var kv in digits)
            {
                Dictionary<int, int> _digits = new Dictionary<int, int>(digits);
                if (--_digits[kv.Key] == 0) _digits.Remove(kv.Key);
                dfs(n, _digits, curr * 10 + kv.Key, ref result);
            }
        }
    }
}
