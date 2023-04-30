using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2515
{
    public class Solution2515 : Interface2515
    {
        /// <summary>
        /// 向两边扩散，本质上也是BFS
        /// </summary>
        /// <param name="words"></param>
        /// <param name="target"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public int ClosetTarget(string[] words, string target, int startIndex)
        {
            if (words[startIndex] == target) return 0;
            int len = words.Length, times = words.Length >> 1;
            for (int i = 1; i <= times; i++)
            {
                if (words[(startIndex + i) % len] == target || words[(startIndex + len - i) % len] == target) return i;
            }

            return -1;
        }
    }
}
