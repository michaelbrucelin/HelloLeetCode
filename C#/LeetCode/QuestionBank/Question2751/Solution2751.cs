using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2751
{
    public class Solution2751 : Interface2751
    {
        /// <summary>
        /// 自定义排序 + 栈
        /// </summary>
        /// <param name="positions"></param>
        /// <param name="healths"></param>
        /// <param name="directions"></param>
        /// <returns></returns>
        public IList<int> SurvivedRobotsHealths(int[] positions, int[] healths, string directions)
        {
            int len = positions.Length;
            int[] order = new int[len];
            for (int i = 0; i < len; i++) order[i] = i;
            Array.Sort(order, (x, y) => positions[x] - positions[y]);
            Stack<(int, int, char)> stack = new Stack<(int, int, char)>();
            int position, health, position_i, health_i;
            foreach (int i in order)
            {
                position_i = positions[i]; health_i = healths[i];
                if (directions[i] == 'L')
                {
                    while (stack.Count > 0 && stack.Peek().Item3 == 'R' && health_i >= stack.Peek().Item2)
                    {
                        (position, health, _) = stack.Pop();
                        if (health_i > health) health_i--; else health_i = 0;
                    }
                    if (health_i > 0)
                    {
                        if (stack.Count > 0 && stack.Peek().Item3 == 'R')
                        {
                            (position, health, _) = stack.Pop();
                            if (health > health_i)
                            {
                                stack.Push((position, health - 1, 'R'));
                            }
                            else if (health < health_i)
                            {
                                stack.Push((position_i, health_i - 1, 'L'));
                            }
                        }
                        else
                        {
                            stack.Push((position_i, health_i, 'L'));
                        }
                    }
                }
                else
                {
                    stack.Push((position_i, health_i, 'R'));
                }
            }

            List<int> result = [];
            Dictionary<int, int> map = new Dictionary<int, int>();
            while (stack.Count > 0) { (position, health, _) = stack.Pop(); map.Add(position, health); }
            foreach (int pos in positions) if (map.TryGetValue(pos, out int val)) result.Add(val);

            return result;
        }
    }
}
