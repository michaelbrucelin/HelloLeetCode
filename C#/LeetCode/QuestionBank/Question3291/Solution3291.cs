using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3291
{
    public class Solution3291 : Interface3291
    {
        /// <summary>
        /// 暴力解，DFS + 记忆化搜索
        /// 先将所有可能的“前缀”放Hash表中，然后DFS去解，直接上这道题有更好的数据结构可以去使用，先暴力解然后再去优化
        /// 
        /// 逻辑没问题，TLE，参考测试用例05
        /// </summary>
        /// <param name="words"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int MinValidStrings(string[] words, string target)
        {
            HashSet<string> set = new HashSet<string>();
            foreach (string word in words) for (int i = 0; i < word.Length; i++) set.Add(word[0..(i + 1)]);
            Dictionary<string, int> memory = new Dictionary<string, int>();

            return dfs(target);

            int dfs(string _target)
            {
                if (!memory.ContainsKey(_target))
                {
                    if (set.Contains(_target))
                    {
                        memory.Add(_target, 1);
                    }
                    else
                    {
                        int cnt = int.MaxValue, _cnt;
                        // for (int i = 0; i < _target.Length; i++) if (set.Contains(_target[0..(i + 1)]))  // 没有小前缀，就一定没有大前缀
                        for (int i = 0; i < _target.Length && set.Contains(_target[0..(i + 1)]); i++)
                        {
                            _cnt = dfs(_target[(i + 1)..]);
                            if (_cnt != -1) cnt = Math.Min(cnt, _cnt);
                            if (cnt == 1) break;
                        }
                        memory.Add(_target, cnt != int.MaxValue ? cnt + 1 : -1);
                    }
                }

                return memory[_target];
            }
        }

        /// <summary>
        /// 逻辑同MinValidStrings()，将set与memory合并
        /// 
        /// 没有提交测试，大概率依然TLE
        /// </summary>
        /// <param name="words"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int MinValidStrings2(string[] words, string target)
        {
            Dictionary<string, int> memory = new Dictionary<string, int>();
            foreach (string word in words) for (int i = 0; i < word.Length; i++) memory.TryAdd(word[0..(i + 1)], 1);

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
