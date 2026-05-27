using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3522
{
    public class Solution3522 : Interface3522
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="instructions"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public long CalculateScore(string[] instructions, int[] values)
        {
            long result = 0; int ptr = 0, len = instructions.Length;
            bool[] visited = new bool[len];
            while (ptr >= 0 && ptr < len && !visited[ptr])
            {
                visited[ptr] = true;
                switch (instructions[ptr])
                {
                    case "add":
                        result += values[ptr++];
                        break;
                    case "jump":
                        ptr += values[ptr];
                        break;
                    default: break;
                }
            }

            return result;
        }
    }
}
