using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1545
{
    public class Solution1545_3 : Interface1545
    {
        /// <summary>
        /// 迭代
        /// 逻辑与Solution1545_2完全相同，将递归改为迭代
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public char FindKthBit(int n, int k)
        {
            if (n == 1) return '0';

            const int SUM = '0' + '1';
            Dictionary<(int, int), char> memory = new Dictionary<(int, int), char>() { { (1, 1), '0' } };
            Stack<(int, int)> stack = new Stack<(int, int)>();
            stack.Push((n, k));
            int _n, _k; (int, int) next;
            while (stack.Count > 0)
            {
                (_n, _k) = stack.Pop();
                if (memory.ContainsKey((_n, _k))) continue;
                switch (_k - (1 << (_n - 1)))
                {
                    case > 0:
                        next = (_n - 1, (1 << _n) - _k);
                        if (memory.ContainsKey(next)) memory.Add((_n, _k), (char)(SUM - memory[next]));
                        else { stack.Push((_n, _k)); stack.Push(next); }
                        break;
                    case < 0:
                        next = (_n - 1, _k);
                        if (memory.ContainsKey(next)) memory.Add((_n, _k), memory[next]);
                        else { stack.Push((_n, _k)); stack.Push(next); }
                        break;
                    default:
                        memory.Add((_n, _k), '1');
                        break;
                }
            }

            return memory[(n, k)];
        }
    }
}
