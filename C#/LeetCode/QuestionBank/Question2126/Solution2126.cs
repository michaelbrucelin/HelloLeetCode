using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2126
{
    public class Solution2126 : Interface2126
    {
        /// <summary>
        /// 贪心 + 排序
        /// </summary>
        /// <param name="mass"></param>
        /// <param name="asteroids"></param>
        /// <returns></returns>
        public bool AsteroidsDestroyed(int mass, int[] asteroids)
        {
            Array.Sort(asteroids);
            long _mass = mass;
            for (int i = 0, len = asteroids.Length; i < len; i++)
            {
                if (_mass >= asteroids[i]) _mass += asteroids[i]; else return false;
            }

            return true;
        }
    }
}
