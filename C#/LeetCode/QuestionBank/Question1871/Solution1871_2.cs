using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1871
{
    public class Solution1871_2 : Interface1871
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="s"></param>
        /// <param name="minJump"></param>
        /// <param name="maxJump"></param>
        /// <returns></returns>
        public bool CanReach(string s, int minJump, int maxJump)
        {
            if (s[^1] == '1') return false;

            int last = 0, min, max, idx, cnt, len = s.Length;
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(0);
            while ((cnt = queue.Count) > 0)
            {
                for (int i = 0; i < cnt; i++)
                {
                    idx = queue.Dequeue();
                    min = Math.Max(last + 1, idx + minJump);
                    max = Math.Min(idx + maxJump, len - 1);
                    if (min <= len - 1 && max == len - 1) return true;
                    for (int j = min; j <= max; j++)
                    {
                        if (s[j] == '0') queue.Enqueue(j);
                    }
                    last = max;
                }
            }

            return false;
        }
    }
}
