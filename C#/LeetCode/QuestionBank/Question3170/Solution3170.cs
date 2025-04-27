using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3170
{
    public class Solution3170 : Interface3170
    {
        /// <summary>
        /// 贪心
        /// 尽可能的从右边删除即可，提前预处理出每个字母的位置
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string ClearStars(string s)
        {
            int len = s.Length;
            List<int>[] pos = new List<int>[26];
            for (int i = 0; i < len; i++) pos[s[i] - 'a'].Add(i);

            throw new NotImplementedException();
        }
    }
}
