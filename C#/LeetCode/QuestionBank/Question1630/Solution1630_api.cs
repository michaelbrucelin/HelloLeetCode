using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1630
{
    public class Solution1630_api : Interface1630
    {
        public IList<bool> CheckArithmeticSubarrays(int[] nums, int[] l, int[] r)
        {
            return l.Select((i, id) => (l[id], r[id] - l[id] + 1))
                    .Select(t => nums.Skip(t.Item1).Take(t.Item2).OrderBy(i => i).ToArray())
                    .Select(arr => Enumerable.Range(2, arr.Count() - 2).All(i => arr[i] - arr[i - 1] == arr[1] - arr[0]))
                    .ToArray();
        }

        public IList<bool> CheckArithmeticSubarrays2(int[] nums, int[] l, int[] r)
        {
            return l.Select((i, id) => (l[id], r[id] + 1))
                    .Select(t => nums[t.Item1..t.Item2].OrderBy(i => i).ToArray())
                    .Select(arr => Enumerable.Range(2, arr.Count() - 2).All(i => arr[i] - arr[i - 1] == arr[1] - arr[0]))
                    .ToArray();
        }
    }
}
