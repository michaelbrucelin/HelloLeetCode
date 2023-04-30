using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2418
{
    public class Solution2418 : Interface2418
    {
        public string[] SortPeople(string[] names, int[] heights)
        {
            int len = names.Length;
            int[] ids = new int[len];
            for (int i = 0; i < len; i++) ids[i] = i;
            Array.Sort(ids, (id1, id2) => heights[id2] - heights[id1]);

            string[] result = new string[len];
            for (int i = 0; i < len; i++) result[i] = names[ids[i]];

            return result;
        }

        /// <summary>
        /// 与SortPeople()一样，原地更改
        /// </summary>
        /// <param name="names"></param>
        /// <param name="heights"></param>
        /// <returns></returns>
        public string[] SortPeople2(string[] names, int[] heights)
        {
            int len = names.Length;
            int[] ids = new int[len];
            for (int i = 0; i < len; i++) ids[i] = i;
            Array.Sort(ids, (id1, id2) => heights[id2] - heights[id1]);

            int _i = -1; string _s = null;
            for (int i = 0; i < len; i++)
            {
                if (ids[i] == i) continue;
                if (ids[i] == _i)
                {
                    names[i] = _s; _i = -1;
                }
                else
                {
                    if (_i == -1) { _i = i; _s = names[i]; }
                    int j = i, _j; do
                    {
                        names[j] = names[ids[j]]; _j = ids[j]; ids[j] = j; j = _j;
                    } while (ids[j] != _i);
                    names[j] = _s; ids[j] = j; _i = -1;
                }
            }

            return names;
        }
    }
}
