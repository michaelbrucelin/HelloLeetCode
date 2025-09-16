using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2197
{
    public class Solution2197_4 : Interface2197
    {
        /// <summary>
        /// 栈
        /// 逻辑同Solution2197，但是取消预处理的分解质因数，直接求解最大公约数
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<int> ReplaceNonCoprimes(int[] nums)
        {
            if (nums.Length == 1) return nums;

            Stack<int> stack = new Stack<int>();
            int gcd;
            for (int i = nums.Length - 1, num; i >= 0; i--)
            {
                num = nums[i];
                while (stack.Count > 0 && (gcd = GetGCD(num, stack.Peek())) > 1)
                {
                    num = num / gcd * stack.Pop();
                }
                stack.Push(num);
            }

            return stack.ToArray();
        }

        private int GetGCD(int x, int y)
        {
            if (x == y) return x;

            int move = 0;
            while (x != y)
                switch ((x & 1, y & 1))
                {
                    case (0, 0): x >>= 1; y >>= 1; move++; break;
                    case (0, 1): x >>= 1; break;
                    case (1, 0): y >>= 1; break;
                    default:  // (1, 1)
                        if (x > y) x = (x - y) >> 1; else y = (y - x) >> 1;
                        break;
                }

            return x << move;
        }
    }
}
