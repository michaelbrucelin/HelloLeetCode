using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1626
{
    public class Solution1626 : Interface1626
    {
        /// <summary>
        /// dfs
        /// 类似于BestTeamScore_error()，每当出现有“矛盾”的两项，每一项都移除试一下
        /// 在BestTeamScore_error()是优先移除得分少的那一项，局部最优但是保证不了全局最优
        /// 没完成，日后再说，还可以考虑斜面两种方式
        /// 1. 用图的邻接表的方式处理
        /// 2. 用dp的思路处理
        /// </summary>
        /// <param name="scores"></param>
        /// <param name="ages"></param>
        /// <returns></returns>
        public int BestTeamScore(int[] scores, int[] ages)
        {
            int result = 0;
            
            return result;
        }

        private void dfs()
        {

        }

        /// <summary>
        /// 排序 + 贪心
        /// 具体分析见Solution1626.md
        /// 这种方法得到的不一定是全局最优解，只是每一步都是局部最优解
        /// </summary>
        /// <param name="scores"></param>
        /// <param name="ages"></param>
        /// <returns></returns>
        public int BestTeamScore_error(int[] scores, int[] ages)
        {
            int len = scores.Length; int[] order = new int[len];
            for (int i = 0; i < len; i++) order[i] = i;
            Array.Sort(order, (i1, i2) => ages[i1] != ages[i2] ? ages[i1] - ages[i2] : scores[i1] - scores[i2]);
            int[] _temp = scores.ToArray();
            for (int i = 0; i < len; i++) scores[i] = _temp[order[i]];
            Array.Sort(ages);

            int result = 0;
            for (int i = 0; i < len; i++) result += scores[i];
            for (int i = 0, j = 1; j < len;)
            {
                if (scores[j] >= scores[i]) { i++; j++; }
                else
                {
                    if (j + 1 >= len || scores[j + 1] >= scores[i])
                    {
                        result -= scores[j]; j += 2;
                    }
                    else if (i - 1 < 0 || scores[j] >= scores[i - 1])
                    {
                        result -= scores[i];
                        if (i - 1 < 0) { j++; i++; } else { i--; }
                    }
                    else
                    {
                        result -= scores[j]; j++;
                    }
                }
            }

            return result;
        }
    }
}
