using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0001
{
    public class Solution0001_api : Interface0001
    {
        public int[] TwoSum(int[] nums, int target)
        {
            var dic = nums.Select((num, id) => (num, id)).GroupBy(t => t.num).ToDictionary(g => g.Key, g => g.Select(t => t.id));
            var num = dic.Where(kv => ((kv.Key << 1) != target && dic.ContainsKey(target - kv.Key))
                                   || ((kv.Key << 1) == target && kv.Value.Count() > 1)
                               ).First().Key;

            return (num << 1) != target ? [dic[num].First(), dic[target - num].First()] : dic[num].ToArray();
        }
    }
}
