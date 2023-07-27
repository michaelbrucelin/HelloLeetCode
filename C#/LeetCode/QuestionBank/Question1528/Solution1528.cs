using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1528
{
    public class Solution1528 : Interface1528
    {
        /// <summary>
        /// 类基数排序
        /// </summary>
        /// <param name="s"></param>
        /// <param name="indices"></param>
        /// <returns></returns>
        public string RestoreString(string s, int[] indices)
        {
            int len = s.Length;
            char[] result = new char[len];
            for (int i = 0; i < len; i++) result[indices[i]] = s[i];

            return new string(result);
        }
    }
}
