using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0735
{
    public class Solution0735 : Interface0735
    {
        /// <summary>
        /// 栈模拟
        /// </summary>
        /// <param name="asteroids"></param>
        /// <returns></returns>
        public int[] AsteroidCollision(int[] asteroids)
        {
            int len = asteroids.Length;
            Stack<int> stack = new Stack<int>();
            for (int i = 0, asteroid, _asteroid; i < len; i++)
            {
                asteroid = asteroids[i];
                if (asteroid > 0) { stack.Push(asteroid); continue; }
                while (asteroid < 0 && stack.Count > 0 && (_asteroid = stack.Peek()) > 0)
                {
                    stack.Pop();
                    switch (asteroid + _asteroid)
                    {
                        case > 0: asteroid = _asteroid; break;
                        case < 0: break;
                        default: asteroid = 0; break;
                    }
                }
                if (asteroid != 0) stack.Push(asteroid);
            }

            len = stack.Count;
            int[] result = new int[len];
            for (int i = len - 1; i >= 0; i--) result[i] = stack.Pop();

            return result;
        }
    }
}
