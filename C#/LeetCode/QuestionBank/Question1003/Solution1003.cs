using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1003
{
    public class Solution1003 : Interface1003
    {
        /// <summary>
        /// 分析
        /// 只要可以通过不断把s中的"abc"替换为""，s最后变成""的话，结果就是true，下面简单证明一下
        /// 1. 充分条件
        ///     如果可以通过不断把s中的"abc"替换为""，s最后变成""的话，显然逆着操作就相当于把一个空字符串""不断的插入"abc"变成了s
        /// 2. 必要条件
        ///     如果s是""通过不断插入"abc"而来，此时再插入一个"abc"，无论怎么插入，只有可能把原有的"abc"打散，而不会构成新的"abc"
        ///         如果可以构成新的"abc"，那么必然需要用到新插入"abc"的一部分，可以看出这是不可能的
        ///     既然不可能构成新的"abc"，那么将"abc"替换为""时，被替换掉一定是插入进来的“原始的”"abc"，
        ///     所以替换的过程就相当于插入的逆操作，即可以被替换为""
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool IsValid(string s)
        {
            if (s.Length % 3 != 0) return false;
            int[] freq = new int[4];
            for (int i = 0; i < s.Length; i++) freq[s[i] & 3]++;
            if (freq[1] != freq[2] || freq[2] != freq[3] || freq[3] != freq[1]) return false;

            StringBuilder sb = new StringBuilder(s);
            int len = sb.Length, _len;
            while (true)
            {
                _len = sb.Replace("abc", "").Length;
                if (len != _len) len = _len; else break;
            }

            return sb.Length == 0;
        }

        /// <summary>
        /// 与IsValid()一样，这里将StringBuilder改为List
        /// 从后向前删除"abc"，这样理论上删除单个字符整体移动的次数更少
        ///     不排除从前面删除，.NetCore有优化，直接改List的地址
        /// 未完成
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool IsValid2(string s)
        {
            if (s.Length % 3 != 0) return false;
            int[] freq = new int[4];
            for (int i = 0; i < s.Length; i++) freq[s[i] & 3]++;
            if (freq[1] != freq[2] || freq[2] != freq[3] || freq[3] != freq[1]) return false;

            List<char> chars = s.ToList();
            throw new NotImplementedException();
        }

        /// <summary>
        /// 与IsValid()一样，这里将StringBuilder改为链表
        /// 未完成
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool IsValid3(string s)
        {
            throw new NotImplementedException();
        }
    }
}
