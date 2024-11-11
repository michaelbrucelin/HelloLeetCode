using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1547
{
    public class Solution1547 : Interface1547
    {
        /// <summary>
        /// DFS + 记忆化搜索
        /// 递归，分治的思想
        /// 
        /// 逻辑没问题，TLE，参考测试用例03，怀疑LC统计的是累计内存，而不是单个测试用例的内存，测试用例03是LC中的第74个测试用例
        /// </summary>
        /// <param name="n"></param>
        /// <param name="cuts"></param>
        /// <returns></returns>
        public int MinCost(int n, int[] cuts)
        {
            Array.Sort(cuts);
            List<int> _cuts = cuts.ToList(); _cuts.Insert(0, 0); _cuts.Add(n);

            int[] _pos = new int[_cuts[^1] + 1];  // 记录“切”在cuts中位置
            for (int i = 0; i < _cuts.Count; i++) _pos[_cuts[i]] = i;
            int[,] memory = new int[n + 1, n + 1];

            return _MinCost(0, n);

            int _MinCost(int left, int right)
            {
                if (_pos[right] == _pos[left] + 1) return 0;
                if (memory[left, right] == 0)
                {
                    int _result = int.MaxValue;
                    for (int i = _pos[left] + 1; i < _pos[right]; i++)
                        _result = Math.Min(_result, _MinCost(left, _cuts[i]) + _MinCost(_cuts[i], right));

                    memory[left, right] = right - left + _result;
                }

                return memory[left, right];
            }
        }

        /// <summary>
        /// 逻辑与MinCost()相同，只是将其中的数组换成了字典，这样对于稀疏数据更节约内存
        /// </summary>
        /// <param name="n"></param>
        /// <param name="cuts"></param>
        /// <returns></returns>
        public int MinCost2(int n, int[] cuts)
        {
            Array.Sort(cuts);
            List<int> _cuts = cuts.ToList(); _cuts.Insert(0, 0); _cuts.Add(n);

            Dictionary<int, int> _pos = new Dictionary<int, int>();       // 记录“切”在cuts中位置
            for (int i = 0; i < _cuts.Count; i++) _pos.Add(_cuts[i], i);
            Dictionary<(int, int), int> memory = new Dictionary<(int, int), int>();

            return _MinCost(0, n);

            int _MinCost(int left, int right)
            {
                if (_pos[right] == _pos[left] + 1) return 0;
                if (!memory.ContainsKey((left, right)))
                {
                    int _result = int.MaxValue;
                    for (int i = _pos[left] + 1; i < _pos[right]; i++)
                        _result = Math.Min(_result, _MinCost(left, _cuts[i]) + _MinCost(_cuts[i], right));

                    memory.Add((left, right), right - left + _result);
                }

                return memory[(left, right)];
            }
        }
    }
}
