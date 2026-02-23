using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3842
{
    public class Solution3842 : Interface3842
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="bulbs"></param>
        /// <returns></returns>
        public IList<int> ToggleLightBulbs(IList<int> bulbs)
        {
            bool[] mask = new bool[101];
            foreach (int x in bulbs) mask[x] = !mask[x];

            List<int> result = [];
            for (int i = 1; i < 101; i++) if (mask[i]) result.Add(i);
            return result;
        }

        /// <summary>
        /// 逻辑同ToggleLightBulbs()，如果灯泡的数量很大，数据需要改为集合
        /// </summary>
        /// <param name="bulbs"></param>
        /// <returns></returns>
        public IList<int> ToggleLightBulbs2(IList<int> bulbs)
        {
            HashSet<int> mask = [];
            foreach (int x in bulbs) if (mask.Contains(x)) mask.Remove(x); else mask.Add(x);

            return mask.OrderBy(x => x).ToArray();
        }
    }
}
