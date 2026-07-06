using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0390
{
    public class Solution0390_2 : Interface0390
    {
        /// <summary>
        /// 栈迭代
        /// 逻辑同Solution0390，将递归改为显示的栈迭代
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int LastRemaining(int n)
        {
            Stack<int> stack = new Stack<int>();
            bool flag = true;
            while (n > 1)
            {
                stack.Push((flag ? 0 : 1) * (1 - (n & 1)));
                n >>= 1;
                flag = !flag;
            }

            int result = 1;
            while (stack.Count > 0) result = (result << 1) - stack.Pop();
            return result;
        }
    }
}
