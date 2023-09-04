using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0077
{
    public class Solution0077 : Interface0077
    {
        /// <summary>
        /// 暴力解
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public IList<IList<int>> Combine(int n, int k)
        {
            List<HashSet<int>> r = new List<HashSet<int>>() { new HashSet<int>() }, _r;
            while (k-- > 0)
            {
                _r = new List<HashSet<int>>();
                foreach (var set in r) for (int i = 1; i <= n; i++)
                    {
                        if (!set.Contains(i)) _r.Add(new HashSet<int>(set) { i });
                    }
                r = _r;
            }

            List<IList<int>> result = new List<IList<int>>();
            for (int i = 0; i < r.Count; i++) result.Add(new List<int>(r[i]));

            return result;
        }
    }
}
