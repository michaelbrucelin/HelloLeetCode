using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2899
{
    public class Solution2899 : Interface2899
    {
        /// <summary>
        /// 模拟
        /// ... ...，又是一道阅读理解题
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public IList<int> LastVisitedIntegers(IList<string> words)
        {
            List<int> result = new List<int>();
            List<int> list = new List<int>();
            int id = -1;
            foreach (string word in words)
            {
                if (word[0] != 'p')
                {
                    id = -1;
                    list.Insert(0, int.Parse(word));
                }
                else
                {
                    id++;
                    if (id < list.Count) result.Add(list[id]); else result.Add(-1);
                }
            }

            return result;
        }

        /// <summary>
        /// 逻辑同LastVisitedIntegers()，但是改为list向后追加元素
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public IList<int> LastVisitedIntegers2(IList<string> words)
        {
            List<int> result = new List<int>();
            List<int> list = new List<int>();
            int id = 0;
            foreach (string word in words)
            {
                if (word[0] != 'p')
                {
                    id = 0;
                    list.Add(int.Parse(word));
                }
                else
                {
                    id++;
                    if (id <= list.Count) result.Add(list[^id]); else result.Add(-1);
                }
            }

            return result;
        }
    }
}
