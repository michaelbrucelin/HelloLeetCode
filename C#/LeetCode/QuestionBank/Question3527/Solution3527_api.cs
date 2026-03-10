using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3527
{
    public class Solution3527_api : Interface3527
    {
        public string FindCommonResponse(IList<IList<string>> responses)
        {
            return responses.SelectMany(x => x.Distinct())
                            .GroupBy(x => x)
                            .OrderByDescending(x => x.Count())
                            .ThenBy(x => x.Key)
                            .First().Key;
        }

        public string FindCommonResponse2(IList<IList<string>> responses)
        {
            return responses.SelectMany(x => x.Distinct())
                            .GroupBy(x => x)
                            .MaxBy(x => (x.Count(), string.CompareOrdinal("", x.Key)))  // 这样也不对，没找到MaxBy中求最小值的方法
                            .Key;
        }
    }
}
