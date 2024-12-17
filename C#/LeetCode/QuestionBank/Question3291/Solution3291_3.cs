using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3291
{
    public class Solution3291_3 : Interface3291
    {
        /// <summary>
        /// 暴力解，DFS + 记忆化搜索
        /// 逻辑同Solution3291，优化初始化memory的过程，先加abc，如果abc已经存在，就不需要去测试ab与a了
        /// 
        /// 逻辑没问题，依然TLE，参考测试用例06
        /// </summary>
        /// <param name="words"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int MinValidStrings(string[] words, string target)
        {
            Dictionary<string, int> memory = new Dictionary<string, int>();
            foreach (string word in words) for (int i = word.Length; i > 0; i--)
                {
                    if (memory.ContainsKey(word[0..i])) break;
                    memory.Add(word[0..i], 1);
                }

            return dfs(target);

            int dfs(string _target)
            {
                if (!memory.ContainsKey(_target))
                {
                    int cnt = int.MaxValue, _cnt;
                    // for (int i = 0; i < _target.Length; i++) if (set.Contains(_target[0..(i + 1)]))  // 没有小前缀，就一定没有大前缀
                    for (int i = 0; i < _target.Length && memory.ContainsKey(_target[0..(i + 1)]); i++)
                    {
                        _cnt = dfs(_target[(i + 1)..]);
                        if (_cnt != -1) cnt = Math.Min(cnt, _cnt + memory[_target[0..(i + 1)]]);
                        if (cnt == 2) break;
                    }
                    memory.Add(_target, cnt != int.MaxValue ? cnt : -1);
                }

                return memory[_target];
            }
        }
    }
}