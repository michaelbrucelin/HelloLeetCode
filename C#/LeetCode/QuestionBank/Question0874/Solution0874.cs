using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0874
{
    public class Solution0874 : Interface0874
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="commands"></param>
        /// <param name="obstacles"></param>
        /// <returns></returns>
        public int RobotSim(int[] commands, int[][] obstacles)
        {
            int result = 0;
            HashSet<(int x, int y)> set = new HashSet<(int x, int y)>();
            for (int i = 0; i < obstacles.Length; i++) set.Add((obstacles[i][0], obstacles[i][1]));

            (int x, int y)[] dirs = new (int x, int y)[] { (0, 1), (1, 0), (0, -1), (-1, 0) };
            (int x, int y) pos = (0, 0), dir; int dir_id = 0;
            for (int i = 0; i < commands.Length; i++)
            {
                if (commands[i] < 0)
                {
                    dir_id = (dir_id + (-2 * commands[i] - 1)) % 4;
                }
                else
                {
                    dir = dirs[dir_id];
                    for (int j = 0; j < commands[i]; j++)
                    {
                        if (set.Contains((pos.x + dir.x, pos.y + dir.y)))
                            break;
                        else
                            pos = (pos.x + dir.x, pos.y + dir.y);
                    }
                    result = Math.Max(result, pos.x * pos.x + pos.y * pos.y);
                }
            }

            return result;
        }
    }
}
