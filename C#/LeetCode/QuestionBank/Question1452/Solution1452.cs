using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1452
{
    public class Solution1452 : Interface1452
    {
        /// <summary>
        /// Hash + 暴力枚举
        /// </summary>
        /// <param name="favoriteCompanies"></param>
        /// <returns></returns>
        public IList<int> PeopleIndexes(IList<IList<string>> favoriteCompanies)
        {
            int cnt = favoriteCompanies.Count;
            HashSet<string>[] sets = new HashSet<string>[cnt];
            for (int i = 0; i < cnt; i++) sets[i] = [.. favoriteCompanies[i]];

            List<int> result = [];
            for (int i = 0; i < cnt; i++)
            {
                for (int j = 0; j < cnt; j++)
                {
                    if (j == i || sets[i].Count >= sets[j].Count) continue;  // 题目限定两个用户的集合不同，所以数量相等一定不存在子集关系
                    foreach (string s in sets[i]) if (!sets[j].Contains(s)) goto NOTFOUND;
                    goto ISSUBSET;
                NOTFOUND:;
                }
                result.Add(i);
            ISSUBSET:;
            }

            return result;
        }
    }
}
