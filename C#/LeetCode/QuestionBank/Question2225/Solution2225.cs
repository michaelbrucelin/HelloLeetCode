using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2225
{
    public class Solution2225 : Interface2225
    {
        /// <summary>
        /// 遍历，状态机
        /// 1. 维护一个状态机（states，字典），key是玩家，value是输的场次
        /// 2. 遍历matches，A战胜B
        ///     A
        ///         如果states中没有A，A的值是0
        ///     B
        ///         如果states中没有B，B的值是1
        ///         如果states中有B，B的值+1
        /// 3. 最后遍历字典加可以取得结果
        /// </summary>
        /// <param name="matches"></param>
        /// <returns></returns>
        public IList<IList<int>> FindWinners(int[][] matches)
        {
            Dictionary<int, int> states = new Dictionary<int, int>();
            foreach (var match in matches)
            {
                if (!states.ContainsKey(match[0])) states[match[0]] = 0;
                if (!states.ContainsKey(match[1])) states[match[1]] = 1; else states[match[1]]++;
            }

            List<int>[] result = [new List<int>(), new List<int>()];
            foreach (int key in states.Keys) if (states[key] < 2) result[states[key]].Add(key);
            result[0].Sort();
            result[1].Sort();

            return result;
        }
    }
}
