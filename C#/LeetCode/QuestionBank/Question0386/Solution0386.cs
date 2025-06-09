using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0386
{
    public class Solution0386 : Interface0386
    {
        /// <summary>
        /// 构造，递归
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<int> LexicalOrder(int n)
        {
            List<int> result = new List<int>();
            for (int i = 1; i < 10; i++) rec(i);
            return result;

            void rec(int x)
            {
                if (x > n) return;
                result.Add(x);
                x *= 10;
                for (int i = 0; i < 10; i++) rec(x + i);
            }
        }

        /// <summary>
        /// 逻辑同LexicalOrder()，只是将递归改为迭代
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<int> LexicalOrder2(int n)
        {
            List<int> result = new List<int>();
            Stack<int> stack = new Stack<int>();
            for (int i = 9; i > 0; i--) stack.Push(i);
            int item;
            while (stack.Count > 0)
            {
                item = stack.Pop();
                if (item > n) continue;
                result.Add(item);
                item *= 10;
                for (int i = 9; i >= 0; i--) stack.Push(item + i);
            }

            return result;
        }
    }
}
