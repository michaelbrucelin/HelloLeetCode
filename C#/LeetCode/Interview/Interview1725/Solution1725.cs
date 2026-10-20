using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1725
{
    public class Solution1725 : Interface1725
    {
        /// <summary>
        /// 回溯
        /// 暴力尝试，然后使用合适的数据结构加速某些查找的环节
        /// 1. 选择两个字符串SR与SC做为矩阵的第一行与第一列，显然SR[0] = SC[0]
        /// 2. 回溯尝试每一行的填充，对于第r行，假定选择的是sr
        ///     首字母是SC[r]
        ///     sr的长度与SR的长度相同
        ///     逐列检查是否存在当前前缀的字符串且长度与SC的长度相同
        /// 预处理一个map Dictionary<string, Dictionary<int, List<int>>>
        ///     key为所有可能的前缀字符串，
        ///     val的key为前缀字符串对应字符串的长度
        ///     val的val为前缀字符串对应字符串在words中的索引
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public string[] MaxRectangle(string[] words)
        {
            Dictionary<string, Dictionary<int, List<int>>> map = new Dictionary<string, Dictionary<int, List<int>>>();
            HashSet<string> set = new HashSet<string>();
            int len = words.Length, _len; string prefix;
            for (int i = 0; i < len; i++) if (set.Add(words[i]))
                {
                    _len = words[i].Length;
                    for (int j = 0; j < _len; j++)
                    {
                        prefix = words[i][0..(j + 1)];
                        if (map.TryGetValue(prefix, out var _map))
                        {
                            if (_map.TryGetValue(_len, out var _set)) _set.Add(i); else _map.Add(_len, [i]);
                        }
                        else
                        {
                            map.Add(prefix, new Dictionary<int, List<int>>() { { _len, [i] } });
                        }
                    }
                }

            int area = 0, rcnt, ccnt;
            string[] result = [], _result;
            StringBuilder sb = new StringBuilder();
            HashSet<(int, int)> visited = new HashSet<(int, int)>();
            for (int i = 0; i < len; i++) foreach (var _map in map[$"{words[i][0]}"]) foreach (int j in _map.Value) if (visited.Add((i, j)))
                        {
                            visited.Add((j, i));
                            if ((ccnt = words[i].Length) * (rcnt = words[j].Length) <= area) continue;
                            _result = new string[rcnt];
                            if (backtrack(words[i], words[j], 1))
                            {
                                result = _result; area = rcnt * ccnt;
                            }
                        }

            return result;

            bool backtrack(string rhead, string chead, int id)
            {
                throw new NotImplementedException();
            }
        }
    }
}
