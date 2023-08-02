using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0822
{
    public class Solution0822_api : Interface0822
    {
        public int Flipgame(int[] fronts, int[] backs)
        {
            var set = fronts.Zip(backs).Where(t => t.First == t.Second).Select(t => t.First).ToHashSet();

            return fronts.Concat(backs).Where(i => !set.Contains(i)).DefaultIfEmpty(0).Min();
        }
    }
}
