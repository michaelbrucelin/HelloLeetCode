using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0676
{
    public class Solution0676_2
    {
    }

    /// <summary>
    /// 逻辑同Solution0676，与Solution0676相比，但是Hash表记录的信息更少，但是查询时更耗时
    /// </summary>
    public class MagicDictionary_2 : Interface0676
    {
        public MagicDictionary_2()
        {
            map = new Dictionary<string, Dictionary<string, char>>();
        }

        Dictionary<string, Dictionary<string, char>> map;

        public void BuildDict(string[] dictionary)
        {
            foreach (string str in dictionary) for (int i = 0; i < str.Length; i++)
                {
                    if (map.ContainsKey(str[0..i]))
                    {
                        if (map[str[0..i]].ContainsKey(str[(i + 1)..]))
                        {
                            // 题目限定dictionary中没有重复
                            // if (map[str[0..i]][str[(i + 1)..]] != str[i]) map[str[0..i]][str[(i + 1)..]] = '\0';
                            map[str[0..i]][str[(i + 1)..]] = '\0';
                        }
                        else
                        {
                            map[str[0..i]].Add(str[(i + 1)..], str[i]);
                        }
                    }
                    else
                    {
                        map.Add(str[0..i], new Dictionary<string, char>() { { str[(i + 1)..], str[i] } });
                    }
                }
        }

        public bool Search(string searchWord)
        {
            for (int i = 0; i < searchWord.Length; i++)
            {
                if (map.ContainsKey(searchWord[0..i])
                    && map[searchWord[0..i]].ContainsKey(searchWord[(i + 1)..])
                    && map[searchWord[0..i]][searchWord[(i + 1)..]] != searchWord[i])
                    return true;
            }
            return false;
        }
    }
}
