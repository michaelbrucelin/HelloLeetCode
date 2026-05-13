
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1674
{
    public class Solution1674_err : Interface1674
    {
        /// <summary>
        /// 贪心，枚举
        /// 1. 计算每一对的和，并记录每一个和的数量
        /// 2. 目标值按照按照和的数量的降序，依次尝试
        /// 
        /// 致命错误，这里假设最优解的目标是某一个数对的和，而真实的最优解可能不是数组中存在的数对的和，参考测试用例04
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public int MinMoves(int[] nums, int limit)
        {
            int len = nums.Length;
            Dictionary<int, List<(int, int)>> map = new Dictionary<int, List<(int, int)>>();
            for (int i = 0, j = len - 1, sum; i < j; i++, j--)
            {
                sum = nums[i] + nums[j];
                map.TryAdd(sum, []); map[sum].Add((nums[i], nums[j]));
            }
            if (map.Count == 0) return 0;
            List<List<(int, int)>> group = [.. map.Values];
            group.Sort((x, y) => y.Count - x.Count);

            int result = len, _result, total = len >> 1, cnt = group.Count;
            for (int i = 0, target, diff; i < cnt; i++)
            {
                if (total - group[i].Count >= result) break;
                target = group[i][0].Item1 + group[i][0].Item2;
                _result = 0;
                for (int j = 0; j < cnt; j++) if (j != i)
                    {
                        diff = group[i][0].Item1 + group[i][0].Item2 - group[j][0].Item1 - group[j][0].Item2;
                        if (diff > 0)
                        {
                            foreach ((int x, int y) in group[j])
                            {
                                _result += (limit - x >= diff || limit - y >= diff) ? 1 : 2;
                                if (_result >= result) break;
                            }
                        }
                        else  // if (diff < 0)
                        {
                            diff = -diff;
                            foreach ((int x, int y) in group[j])
                            {
                                _result += (x - 1 >= diff || y - 1 >= diff) ? 1 : 2;
                                if (_result >= result) break;
                            }
                        }
                    }
                result = Math.Min(result, _result);
            }

            return result;
        }
    }
}
