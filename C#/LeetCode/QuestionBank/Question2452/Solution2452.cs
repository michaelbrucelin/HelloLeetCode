using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2452
{
    public class Solution2452 : Interface2452
    {
        /// <summary>
        /// Hash + 回溯
        /// 
        /// 逻辑没问题，TLE，参考测试用例03
        /// </summary>
        /// <param name="queries"></param>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        public IList<string> TwoEditWords(string[] queries, string[] dictionary)
        {
            List<string> result = [];
            HashSet<string> set = [.. dictionary];
            char[] letter = new char[26];
            for (int i = 0; i < 26; i++) letter[i] = (char)('a' + i);
            int n = queries[0].Length;
            char[] buffer = new char[n];
            foreach (string s in queries)
            {
                if (set.Contains(s)) { result.Add(s); continue; }
                for (int i = 0; i < n; i++) buffer[i] = s[i];
                if (backtrack1()) { result.Add(s); continue; }     // 编辑1次
                if (backtrack2()) { result.Add(s); continue; }     // 编辑2次
            }

            return result;

            bool backtrack1()
            {
                char c;
                for (int i = 0; i < n; i++)
                {
                    c = buffer[i];
                    for (int _i = 0; _i < 26; _i++)
                    {
                        buffer[i] = letter[_i];
                        if (set.Contains(new string(buffer))) return true;
                    }
                    buffer[i] = c;
                }

                return false;
            }

            bool backtrack2()
            {
                char c1, c2;
                for (int i = 0; i < n - 1; i++)
                {
                    c1 = buffer[i];
                    for (int _i = 0; _i < 26; _i++)
                    {
                        buffer[i] = letter[_i];
                        for (int j = i + 1; j < n; j++)
                        {
                            c2 = buffer[j];
                            for (int _j = 0; _j < 26; _j++)
                            {
                                buffer[j] = letter[_j];
                                if (set.Contains(new string(buffer))) return true;
                            }
                            buffer[j] = c2;
                        }
                    }
                    buffer[i] = c1;
                }

                return false;
            }
        }
    }
}
