using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1547
{
    public class Solution1547_2 : Interface1547
    {
        /// <summary>
        /// DP
        /// 本质上与Solution1547一样，Solution1547是自顶向下，这里是自底向上
        /// 先初始化每一份的cost，显然为0，然后计算所有两份的cost，在计算3份的cost...
        /// </summary>
        /// <param name="n"></param>
        /// <param name="cuts"></param>
        /// <returns></returns>
        public int MinCost(int n, int[] cuts)
        {
            Array.Sort(cuts);
            List<int> _cuts = cuts.ToList(); _cuts.Insert(0, 0); _cuts.Add(n);

            Dictionary<(int, int), int> memory = new Dictionary<(int, int), int>();
            int len = _cuts.Count;
            for (int i = 1; i < len; i++) memory.Add((_cuts[i - 1], _cuts[i]), 0);
            for (int span = 2, l = 0, r = 0; span < len; span++) for (l = 0, r = span; r < len; l++, r++)  // span: 份数
                {
                    int _result = int.MaxValue;
                    for (int i = l + 1; i < r; i++) _result = Math.Min(_result, memory[(_cuts[l], _cuts[i])] + memory[(_cuts[i], _cuts[r])]);
                    memory.Add((_cuts[l], _cuts[r]), _cuts[r] - _cuts[l] + _result);
                }

            return memory[(0, n)];
        }
    }
}
