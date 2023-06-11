using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1419
{
    public class Solution1419 : Interface1419
    {
        /// <summary>
        /// 贪心
        /// 1. 使用五个变量分别计数'c', 'r', 'o', 'a', 'k'的数量
        /// 2. 有解的充分必要条件是
        ///     1. 整个字符串，cnt_c == cnt_r == cnt_o == cnta == cnt_k
        ///     2. 在任意位置i，切片s[0..i]中，cnt_c >= cnt_r >= cnt_o >= cnta >= cnt_k
        /// 3. 在有解的情况下，一层一层的往下拨就行，需要剥几层，就需要几只青蛙
        ///     例如："crocakcroraoakk"
        ///     第一层："cro akcro a  k "
        ///     第二层："   c     r oa k"
        /// 
        /// 逻辑没问题，提交会超时，参考测试用例05
        /// </summary>
        /// <param name="croakOfFrogs"></param>
        /// <returns></returns>
        public int MinNumberOfFrogs(string croakOfFrogs)
        {
            if (croakOfFrogs[0] != 'c' || croakOfFrogs[^1] != 'k' || croakOfFrogs.Length % 5 != 0) return -1;

            int result = 0;
            StringBuilder croak = new StringBuilder(croakOfFrogs);
            bool flag; char state;
            while (croak.Length > 0)
            {
                flag = false; state = 'k';
                for (int i = croak.Length - 1; i >= 0; i--)
                {
                    if (croak[i] == state)
                    {
                        croak.Remove(i, 1);
                        if (state == 'a') flag = true;
                        state = state switch { 'k' => 'a', 'a' => 'o', 'o' => 'r', 'r' => 'c', 'c' => 'k', _ => '\0' };
                    }
                }
                if (!flag || state != 'k') return -1;
                result++;
            }

            return result;
        }

        /// <summary>
        /// 与MinNumberOfFrogs()一样，一个一个字符的从StringBuilder中移除，而是使用bool[]标记，一轮移除一次
        /// 
        /// 测试没有变快，这也说明API中的StringBuilder内部优化的很好
        /// </summary>
        /// <param name="croakOfFrogs"></param>
        /// <returns></returns>
        public int MinNumberOfFrogs2(string croakOfFrogs)
        {
            if (croakOfFrogs[0] != 'c' || croakOfFrogs[^1] != 'k' || croakOfFrogs.Length % 5 != 0) return -1;

            int result = 0;
            StringBuilder croak = new StringBuilder(croakOfFrogs);
            bool[] mask = new bool[croak.Length]; Array.Fill(mask, true);
            bool flag; char state;
            while (croak.Length > 0)
            {
                flag = false; state = 'c';
                for (int i = 0; i < croak.Length; i++)
                {
                    if (croak[i] == state)
                    {
                        mask[i] = false;
                        if (state == 'a') flag = true;
                        state = state switch { 'c' => 'r', 'r' => 'o', 'o' => 'a', 'a' => 'k', 'k' => 'c', _ => '\0' };
                    }
                }
                if (!flag || state != 'c') return -1;
                result++;

                StringBuilder _croak = new StringBuilder();
                for (int i = 0; i < croak.Length; i++) if (mask[i]) _croak.Append(croak[i]);
                croak = _croak;
                mask = new bool[croak.Length]; Array.Fill(mask, true);
            }

            return result;
        }

        /// <summary>
        /// 与MinNumberOfFrogs2()一样，不再从StringBuilder中移除，只是做标记，所以也就不需要StringBuilder了
        /// 
        /// 测试依然没有变快
        /// </summary>
        /// <param name="croakOfFrogs"></param>
        /// <returns></returns>
        public int MinNumberOfFrogs3(string croakOfFrogs)
        {
            if (croakOfFrogs[0] != 'c' || croakOfFrogs[^1] != 'k' || croakOfFrogs.Length % 5 != 0) return -1;

            int result = 0, cnt = croakOfFrogs.Length, len = croakOfFrogs.Length;
            bool[] mask = new bool[len]; Array.Fill(mask, true);
            bool flag; char state;
            while (cnt > 0)
            {
                flag = false; state = 'c';
                for (int i = 0; i < len; i++)
                {
                    if (mask[i] && croakOfFrogs[i] == state)
                    {
                        mask[i] = false; cnt--;
                        if (state == 'a') flag = true;
                        state = state switch { 'c' => 'r', 'r' => 'o', 'o' => 'a', 'a' => 'k', 'k' => 'c', _ => '\0' };
                    }
                }
                if (!flag || state != 'c') return -1;
                result++;
            }

            return result;
        }
    }
}
