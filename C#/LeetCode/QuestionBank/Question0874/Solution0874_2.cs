using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0874
{
    public class Solution0874_2 : Interface0874
    {
        /// <summary>
        /// 模拟
        /// 逻辑同Solution0874，只是在预处理obstacles上略有不同
        /// </summary>
        /// <param name="commands"></param>
        /// <param name="obstacles"></param>
        /// <returns></returns>
        public int RobotSim(int[] commands, int[][] obstacles)
        {
            int result = 0;
            Dictionary<int, List<int>> obs_x = new Dictionary<int, List<int>>(), obs_y = new Dictionary<int, List<int>>();
            for (int i = 0, _x, _y; i < obstacles.Length; i++)
            {
                _x = obstacles[i][0]; _y = obstacles[i][1];
                if (obs_x.ContainsKey(_x)) obs_x[_x].Add(_y); else obs_x.Add(_x, new List<int>() { _y });
                if (obs_y.ContainsKey(_y)) obs_y[_y].Add(_x); else obs_y.Add(_y, new List<int>() { _x });
            }
            foreach (int key in obs_x.Keys) obs_x[key].Sort();
            foreach (int key in obs_y.Keys) obs_y[key].Sort();

            (int x, int y)[] dirs = new (int x, int y)[] { (0, 1), (1, 0), (0, -1), (-1, 0) };
            (int x, int y) pos = (0, 0), next, dir; int dir_id = 0;
            (bool found, int pos) found;
            for (int i = 0; i < commands.Length; i++)
            {
                if (commands[i] < 0)
                {
                    dir_id = (dir_id + (-2 * commands[i] - 1)) % 4;
                }
                else
                {
                    dir = dirs[dir_id];
                    next = (pos.x + dir.x * commands[i], pos.y + dir.y * commands[i]);
                    switch (dir_id)
                    {
                        case 0:
                            if (obs_x.ContainsKey(pos.x))
                            {
                                found = FirstGT(obs_x[pos.x], pos.y);
                                if (found.found && found.pos <= next.y) next = (pos.x, found.pos - 1);
                            }
                            break;
                        case 1:
                            if (obs_y.ContainsKey(pos.y))
                            {
                                found = FirstGT(obs_y[pos.y], pos.x);
                                if (found.found && found.pos <= next.x) next = (found.pos - 1, pos.y);
                            }
                            break;
                        case 2:
                            if (obs_x.ContainsKey(pos.x))
                            {
                                found = FirstLT(obs_x[pos.x], pos.y);
                                if (found.found && found.pos >= next.y) next = (pos.x, found.pos + 1);
                            }
                            break;
                        case 3:
                            if (obs_y.ContainsKey(pos.y))
                            {
                                found = FirstLT(obs_y[pos.y], pos.x);
                                if (found.found && found.pos >= next.x) next = (found.pos + 1, pos.y);
                            }
                            break;
                        default:
                            throw new Exception("logic error.");
                    }
                    pos = next;
                    result = Math.Max(result, pos.x * pos.x + pos.y * pos.y);
                }
            }

            return result;
        }

        private (bool found, int pos) FirstGT(List<int> list, int target)
        {
            (bool found, int pos) result = (false, 0);
            int left = 0, right = list.Count - 1, mid;
            while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                if (list[mid] > target)
                {
                    result = (true, list[mid]); right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return result;
        }

        private (bool found, int pos) FirstLT(List<int> list, int target)
        {
            (bool found, int pos) result = (false, 0);
            int left = 0, right = list.Count - 1, mid;
            while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                if (list[mid] < target)
                {
                    result = (true, list[mid]); left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return result;
        }
    }
}
