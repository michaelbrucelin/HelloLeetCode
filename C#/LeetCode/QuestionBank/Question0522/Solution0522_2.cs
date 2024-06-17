using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0522
{
    public class Solution0522_2 : Interface0522
    {
        /// <summary>
        /// 逻辑同Solution0522，使用Dictionary<string,bool>[] 做为过滤器，省去排序
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public int FindLUSlength(string[] strs)
        {
            Dictionary<string, bool>[] buffer = new Dictionary<string, bool>[11];
            for (int i = 1; i < 11; i++) buffer[i] = new Dictionary<string, bool>();
            for (int i = 0, _i; i < strs.Length; i++)
            {
                _i = strs[i].Length;
                if (buffer[_i].ContainsKey(strs[i])) buffer[_i][strs[i]] = false; else buffer[_i].Add(strs[i], true);
            }

            for (int i = 10; i > 0; i--) foreach (string str in buffer[i].Keys) if (buffer[i][str])
                    {
                        for (int j = 10; j > i; j--) foreach (string _str in buffer[j].Keys) if (IsLUS(_str, str)) goto CONTINUE;
                        return str.Length;
                        CONTINUE:;
                    }

            return -1;
        }

        private bool IsLUS(string str1, string str2)
        {
            if (str2.Length > str1.Length) return false;

            int p1 = 0, p2 = 0, l1 = str1.Length, l2 = str2.Length;
            while (p1 < l1 && p2 < l2)
            {
                if (str1[p1] == str2[p2]) p2++;
                p1++;
            }

            return p2 == l2;
        }
    }
}
