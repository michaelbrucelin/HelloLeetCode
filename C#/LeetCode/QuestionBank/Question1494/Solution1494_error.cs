using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1494
{
    public class Solution1494_error : Interface1494
    {
        /// <summary>
        /// 暴力贪心
        /// 题目是拓扑排序？
        /// 这里采用暴力贪心去解决，每一轮都找出k个没有前置的课程，不足k个就有几个选几个
        /// 由于题目限定最多15门课程，所以最多有15*14/2个关系，最多15轮，所以时间复杂度在O(1575)
        /// 
        /// 错误的，错在如果一轮选择有大于k个没有前置的结点时，代码随便选了两个，而不同的选择会产生不同的结果
        /// 参考：
        ///     n = 10
        ///     relations = [[1,4],[2,4],[3,4],[4,5],[6,9],[7,9],[8,9],[9,10]]
        ///     k = 2
        /// </summary>
        /// <param name="n"></param>
        /// <param name="relations"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MinNumberOfSemesters(int n, int[][] relations, int k)
        {
            if (k == 1) return n;
            if (relations.Length == 0) return (int)Math.Ceiling((double)n / k);

            HashSet<int> set = new HashSet<int>();
            for (int i = 1; i <= n; i++) set.Add(i);
            List<int[]> rel = relations.ToList();
            List<int> temp = new List<int>();

            int result = 0, cnt; bool flag;
            while (set.Count > 0)
            {
                result++; cnt = 0; temp.Clear();
                foreach (int i in set)
                {
                    flag = true;
                    for (int j = 0; j < rel.Count; j++)
                    {
                        if (rel[j][1] == i)
                        {
                            flag = false; break;
                        }
                    }
                    if (flag)
                    {
                        temp.Add(i);
                        if (++cnt == k) break;
                    }
                }
                foreach (int i in temp)
                {
                    set.Remove(i);
                    for (int j = rel.Count - 1; j >= 0; j--)
                        if (rel[j][0] == i) rel.RemoveAt(j);
                }
            }

            return result;
        }
    }
}
