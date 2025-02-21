using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2976
{
    public class Solution2976 : Interface2976
    {
        /// <summary>
        /// Floyd
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <param name="original"></param>
        /// <param name="changed"></param>
        /// <param name="cost"></param>
        /// <returns></returns>
        public long MinimumCost(string source, string target, char[] original, char[] changed, int[] cost)
        {
            int[,] grpah = new int[26, 26];
            int infty = int.MaxValue;
            for (int i = 0; i < 26; i++) for (int j = 0; j < 26; j++) grpah[i, j] = infty;
            for (int i = 0; i < 26; i++) grpah[i, i] = 0;
            for (int i = 0, _s = 0, _t = 0; i < cost.Length; i++)
            {
                _s = original[i] - 'a'; _t = changed[i] - 'a';
                grpah[_s, _t] = Math.Min(grpah[_s, _t], cost[i]);
            }
            for (int k = 0; k < 26; k++) for (int i = 0; i < 26; i++) for (int j = 0; j < 26; j++)
                    {
                        if (grpah[i, k] != infty && grpah[k, j] != infty)
                            grpah[i, j] = Math.Min(grpah[i, j], grpah[i, k] + grpah[k, j]);
                    }

            long result = 0;
            for (int i = 0, _s = 0, _t = 0; i < source.Length; i++) if (source[i] != target[i])
                {
                    _s = source[i] - 'a'; _t = target[i] - 'a';
                    if (grpah[_s, _t] != infty) result += grpah[_s, _t]; else return -1;
                }

            return result;
        }
    }
}
