using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1006
{
    public class Solution1006_err : Interface1006
    {
        /// <summary>
        /// 模拟
        /// 
        /// 题意要求考虑四则运算优先级，这里没有考虑
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int Clumsy(int n)
        {
            int result = n;
            Queue<Func<int, int, int>> queue = new Queue<Func<int, int, int>>();
            queue.Enqueue((x, y) => x * y);
            queue.Enqueue((x, y) => x / y);
            queue.Enqueue((x, y) => x + y);
            queue.Enqueue((x, y) => x - y);
            Func<int, int, int> opt;
            while (--n > 0)
            {
                opt = queue.Dequeue();
                result = opt(result, n);
                queue.Enqueue(opt);
            }

            return result;
        }
    }
}
