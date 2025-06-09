using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0440
{
    public class Solution0440 : Interface0440
    {
        /// <summary>
        /// 构造，递归
        /// 递归溢出
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int FindKthNumber(int n, int k)
        {
            int _n = -1, _k = 0;
            for (int i = 1; i < 10; i++) rec(i);
            return _n;

            void rec(int x)
            {
                if (x > n || _k == k) return;
                _n = x;
                if (++_k == k) return;
                x *= 10;
                for (int i = 0; i < 10; i++) rec(x + i);
            }
        }

        /// <summary>
        /// 逻辑同FindKthNumber()，只是将递归改为迭代
        /// 依然栈溢出
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int FindKthNumber2(int n, int k)
        {
            int _n = -1, _k = 0;
            Stack<int> stack = new Stack<int>();
            for (int i = 9; i > 0; i--) stack.Push(i);
            int item;
            while (stack.Count > 0)
            {
                item = stack.Pop();
                if (item > n) continue;
                _n = item;
                if (++_k == k)
                {
                    stack.Clear();
                }
                else
                {
                    item *= 10;
                    for (int i = 9; i >= 0; i--) stack.Push(item + i);
                }
            }

            return _n;
        }
    }
}
