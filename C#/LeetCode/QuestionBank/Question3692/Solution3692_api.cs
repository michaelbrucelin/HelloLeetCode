using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3692
{
    public class Solution3692_api : Interface3692
    {
        public string MajorityFrequencyGroup(string s)
        {
            return new string([.. s.GroupBy(x => x)
                                   .Select(x => (x.Key, x.Count()))
                                   .GroupBy(x => x.Item2)
                                   .OrderByDescending(x => x.Count())
                                   .ThenByDescending(x => x.Key)
                                   .First()
                                   .Select(x => x.Item1)]);
        }
    }
}
