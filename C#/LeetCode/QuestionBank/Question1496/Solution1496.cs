using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1496
{
    public class Solution1496 : Interface1496
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool IsPathCrossing(string path)
        {
            HashSet<(int x, int y)> set = new HashSet<(int x, int y)>() { (0, 0) };
            (int x, int y) pos = (0, 0);
            for (int i = 0; i < path.Length; i++)
            {
                switch (path[i])
                {
                    case 'N': pos = (pos.x, pos.y + 1); break;
                    case 'S': pos = (pos.x, pos.y - 1); break;
                    case 'E': pos = (pos.x + 1, pos.y); break;
                    case 'W': pos = (pos.x - 1, pos.y); break;
                    default: break;
                }

                if (set.Contains(pos)) return true;
                set.Add(pos);
            }

            return false;
        }
    }
}
