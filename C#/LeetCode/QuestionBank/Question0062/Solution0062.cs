using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0062
{
    public class Solution0062 : Interface0062
    {
        /// <summary>
        /// 组合数学
        /// 从矩阵的左上角移动到右下角，需要向下移动 m-1 次，向右移动 n-1 次
        /// 相等于 m-1 个 a，n-1 个 b 组成的字符串的数量，即 (m-1+n-1)! / (m-1)! / (n-1)!
        /// 
        /// 注意，计算过程需要防止溢出
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public int UniquePaths(int m, int n)
        {
            if (m == 1 || n == 1) return 1;
            if (--m < --n) { m ^= n; n ^= m; m ^= n; }  // 让 m >= n
            const long limit = (long)1e17;              // 题目限定 m,n 不会超过100，那么如果乘积没达到 1e17，继续乘就不会溢出

            long result = 1; int cnt, _n;
            Queue<int> queue = new Queue<int>();
            for (int i = 2; i <= n; i++) queue.Enqueue(i);
            for (int i = m + 1; i <= m + n; i++)
            {
                result *= i;
                if (result >= limit)
                {
                    cnt = queue.Count;
                    for (int j = 0; j < cnt; j++)
                    {
                        _n = queue.Dequeue();
                        if (result % _n == 0) result /= _n; else queue.Enqueue(_n);
                    }
                }
            }
            while (queue.Count > 0) result /= queue.Dequeue();

            return (int)result;
        }
    }
}
