using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1137
{
    public class Solution1137_4 : Interface1137
    {
        private static List<int> memory = new() { 0, 1, 1 };

        /// <summary>
        /// 记忆化
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int Tribonacci(int n)
        {
            if (n < memory.Count) return memory[n];
            while (n >= memory.Count)
            {
                memory.Add(memory[^1] + memory[^2] + memory[^3]);
            }

            return memory[n];
        }
    }
}
