using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2449
{
    public class Solution2449 : Interface2449
    {
        /// <summary>
        /// 脑筋急转弯
        /// 题目保证有接，那么就排序贪心就行了，注意每次 +-2，所以奇偶分别排序
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public long MakeSimilar(int[] nums, int[] target)
        {
            long result = 0;
            List<int>[] _nums = [[], []], _target = [[], []];
            foreach (int x in nums) _nums[x & 1].Add(x);
            foreach (int x in target) _target[x & 1].Add(x);

            _nums[0].Sort();
            _nums[1].Sort();
            _target[0].Sort();
            _target[1].Sort();

            for (int i = 0, cnt = _nums[0].Count; i < cnt; i++) if (_nums[0][i] < _target[0][i]) result += _target[0][i] - _nums[0][i];  // 题目保证了_nums[0].Count == _target[0].Count
            for (int i = 0, cnt = _nums[1].Count; i < cnt; i++) if (_nums[1][i] < _target[1][i]) result += _target[1][i] - _nums[1][i];

            return result >> 1;
        }
    }
}
