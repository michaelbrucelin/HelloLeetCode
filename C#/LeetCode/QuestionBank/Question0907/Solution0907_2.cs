using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0907
{
    public class Solution0907_2 : Interface0907
    {
        /// <summary>
        /// 单调栈
        /// 逻辑同Solution0907的贡献法，这里使用单调栈加速查找“左右边界”，“大于”入栈，“小于等于”出栈
        /// 具体流程参考官解
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int SumSubarrayMins(int[] arr)
        {
            long result = 0;
            int len = arr.Length; const int MOD = 1000000007;

            Stack<(int val, int id)> stack = new Stack<(int val, int id)>();
            stack.Push((0, -1));  // 哨兵
            (int val, int id) t;
            for (int i = 0, val; i < len; i++)
            {
                val = arr[i];
                while (val <= stack.Peek().val)
                {
                    t = stack.Pop();
                    result += ((long)t.val) * (t.id - stack.Peek().id) * (i - t.id) % MOD;
                    result %= MOD;
                }
                stack.Push((val, i));
            }

            while (stack.Count > 1)
            {
                t = stack.Pop();
                result += ((long)t.val) * (t.id - stack.Peek().id) * (len - t.id) % MOD;
                result %= MOD;
            }

            return (int)result;
        }
    }
}
