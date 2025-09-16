using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2197
{
    public class Solution2197_5 : Interface2197
    {
        /// <summary>
        /// 栈
        /// 逻辑同Solution2197，使用系统内置的求最大公约数的函数
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
                // Math.GreatestCommonDivisor(a, b)  .net core 9+
                while (stack.Count > 0 && (gcd = (int)BigInteger.GreatestCommonDivisor(num, stack.Peek())) > 1)
                {
                    num = num / gcd * stack.Pop();
                }
                stack.Push(num);
            }

            return stack.ToArray();
        }

        /// <summary>
        /// 将栈改为List
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<int> ReplaceNonCoprimes2(int[] nums)
        {
            if (nums.Length == 1) return nums;

            List<int> list = new List<int>();
            int gcd, id = -1, len = nums.Length;
            for (int i = 0, num; i < len; i++)
            {
                num = nums[i];
                // Math.GreatestCommonDivisor(a, b)  .net core 9+
                while (id > -1 && (gcd = (int)BigInteger.GreatestCommonDivisor(num, list[id])) > 1)
                {
                    num = num / gcd * list[id];
                    id--;
                }
                if (id == list.Count - 1) list.Add(num); else list[id + 1] = num;
                id++;
            }

            return list[0..(id + 1)];
        }
    }
}
