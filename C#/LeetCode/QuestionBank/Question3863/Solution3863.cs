using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3863
{
    public class Solution3863 : Interface3863
    {
        /// <summary>
        /// 脑筋急转弯
        /// 最多两次，假定字符串最小字母在idx位置，长度为len，那么操作[0..idx]，再操作[1,,len-1]即可
        /// 特殊情况有点多，多测试一些测试用例就好，思路没错
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MinOperations(string s)
        {
            if (s.Length == 1) return 0;
            if (s.Length == 2) return s[0] <= s[1] ? 0 : -1;

            int min = s[0], mincnt = 1, max = s[0], maxcnt = 1, len = s.Length;
            bool is_order = true;
            for (int i = 1; i < len; i++)
            {
                if (s[i] < min) { min = s[i]; mincnt = 1; } else if (s[i] == min) mincnt++;
                if (s[i] > max) { max = s[i]; maxcnt = 1; } else if (s[i] == max) maxcnt++;
                if (s[i] < s[i - 1]) is_order = false;
            }
            if (is_order) return 0;
            if (s[0] == min || s[len - 1] == max) return 1;
            if (s[0] == max && maxcnt == 1 && s[len - 1] == min && mincnt == 1) return 3;

            return 2;
        }
    }
}
