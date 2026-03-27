using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2262
{
    public class Solution2262 : Interface2262
    {
        /// <summary>
        /// DP
        /// F(N,0)表示s[0..N]的结果，F(N,1)表示以s[N]结尾的结果，这样就可以推到F(N+1,0)与F(N+1,1)了
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public long AppealSum(string s)
        {
            throw new NotImplementedException();
        }
    }
}
