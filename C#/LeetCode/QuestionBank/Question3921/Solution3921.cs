using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3921
{
    public class Solution3921 : Interface3921
    {
        /// <summary>
        /// 状态机
        /// </summary>
        /// <param name="events"></param>
        /// <returns></returns>
        public int[] ScoreValidator(string[] events)
        {
            Dictionary<string, (int, int)> map = new Dictionary<string, (int, int)>()
            {
                { "0", (0,0) }, { "1", (0,1) }, { "2", (0,2) }, { "3", (0,3) }, { "4", (0,4) }, { "6", (0,6) }, { "W", (1,1) }, { "WD", (0,1) }, { "NB", (0,1) }
            };

            int[] result = new int[2];
            foreach (string e in events)
            {
                result[map[e].Item1] += map[e].Item2;
                if (result[1] == 10) break;
            }

            return result;
        }
    }
}
