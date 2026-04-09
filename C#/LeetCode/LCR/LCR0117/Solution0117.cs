using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0117
{
    public class Solution0117 : Interface0117
    {
        /// <summary>
        /// Hash桶
        /// 声明Hash桶：List<HashSet<string>> sets
        /// 遍历整个数组，对于每个字符串str，先检查是否在某个set中
        ///     如果在，跳过
        ///     如果不在，添加一个新桶（set），将str交换两个字符（递归，回溯）的所有可能添加到这个set中
        /// 时间上压力不大，但是内存...
        /// 
        /// 逻辑没问题，意料之中的OLE了，参考测试用例03
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public int NumSimilarGroups(string[] strs)
        {
            int len = strs[0].Length;
            HashSet<string> _strs = [.. strs];
            char[] buffer = new char[len];
            List<HashSet<string>> sets = [];
            foreach (string str in _strs)
            {
                foreach (var set in sets) if (set.Contains(str)) goto CONTINUE;
                HashSet<string> _set = [];
                for (int i = 0; i < len; i++) buffer[i] = str[i];
                backtrack(_set);
                sets.Add(_set);
            CONTINUE:;
            }

            return sets.Count;

            void backtrack(HashSet<string> set)
            {
                if (!set.Add(new string(buffer)) || !_strs.Contains(new string(buffer))) return;

                char t;
                for (int i = 0; i < len; i++)
                {
                    t = buffer[i];
                    for (int j = i + 1; j < len; j++) if (buffer[j] != t)
                        {
                            buffer[i] = buffer[j]; buffer[j] = t;
                            backtrack(set);                        // set.Add(new string(buffer));
                            buffer[j] = buffer[i]; buffer[i] = t;
                        }
                }
            }
        }
    }
}
