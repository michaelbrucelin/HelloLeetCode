using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2380
{
    public class Solution2380_err : Interface2380
    {
        /// <summary>
        /// 脑筋急转弯
        /// 本质上就是把全部的1移动到最前面，全部的0移动到最后面，注意相邻的1或0无法同时操作
        /// 需要统计总共有多少个1，有多少个1被前面的1挡住了导致不能一起移动，最后一个1的位置
        /// 
        /// 还是不对，感觉大方向是对的，先不想了
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int SecondsToRemoveOccurrences(string s)
        {
            int total = 0, cnt = 0, last = 0, len = s.Length;
            for (int i = 0; i < len; i++) if (s[i] == '1')
                {
                    total++; last = i;
                    if (i > 0 && s[i - 1] == '1') cnt++;
                }
            if (s[0] == '1') for (int i = 1; i < len && s[i] == '1'; i++) cnt--;

            return total == 0 ? 0 : last - (total - 1) + cnt;
        }
    }
}
