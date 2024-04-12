using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2924
{
    public class Solution2924 : Interface2924
    {
        /// <summary>
        /// 遍历
        /// 找出入度为0的节点即可
        /// </summary>
        /// <param name="n"></param>
        /// <param name="edges"></param>
        /// <returns></returns>
        public int FindChampion(int n, int[][] edges)
        {
            int[] incnt = new int[n];
            foreach (var edge in edges) incnt[edge[1]]++;

            int result = -1;
            for (int i = 0; i < n; i++) if (incnt[i] == 0)
                {
                    if (result != -1) return -1;
                    result = i;
                }

            return result;
        }
    }
}
