using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0039
{
    public class Solution0039_4 : Interface0039
    {
        /// <summary>
        /// 递归
        /// </summary>
        /// <param name="candidates"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            return CombinationSum(candidates, 0, target);
        }

        private IList<IList<int>> CombinationSum(int[] candidates, int startid, int target)
        {
            if (startid >= candidates.Length) return new List<IList<int>>();

            List<IList<int>> result = new List<IList<int>>();
            int sum = 0, candidate = candidates[startid];
            List<int> list = new List<int>();
            while (sum <= target)
            {
                if (sum == target)
                {
                    result.Add(new List<int>(list));
                }
                else
                {
                    var _result = CombinationSum(candidates, startid + 1, target - sum);
                    foreach (var __result in _result)
                    {
                        List<int> _list = new List<int>(list);
                        _list.AddRange(__result);
                        result.Add(_list);
                    }
                }

                sum += candidate;
                list.Add(candidate);
            }

            return result;
        }
    }
}
