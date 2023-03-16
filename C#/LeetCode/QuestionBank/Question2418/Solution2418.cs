using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2418
{
    public class Solution2418 : Interface2418
    {
        public string[] SortPeople2(string[] names, int[] heights)
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
        public string[] SortPeople(string[] names, int[] heights)
        {
            int len = names.Length;
            int[] ids = new int[len];
            for (int i = 0; i < len; i++) ids[i] = i;
            Array.Sort(ids, (id1, id2) => heights[id2] - heights[id1]);

            for (int i = 0; i < len; i++)
            {
                if (ids[i] != i)
                {
                    string _s = names[i]; names[i] = names[ids[i]]; names[ids[i]] = _s;
                    int _i = ids[i]; ids[i] = i; ids[_i] = _i;
                }
            }

            return names;
        }
    }
}
