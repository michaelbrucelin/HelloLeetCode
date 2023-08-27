using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0506
{
    public class Solution0506 : Interface0506
    {
        /// <summary>
        /// 按索引排序
        /// </summary>
        /// <param name="score"></param>
        /// <returns></returns>
        public string[] FindRelativeRanks(int[] score)
        {
            int len = score.Length;
            int[] index = new int[len];
            for (int i = 0; i < len; i++) index[i] = i;
            Array.Sort(index, (i, j) => score[j] - score[i]);

            string[] result = new string[len];
            for (int i = 0, j; i < len; i++)
            {
                j = index[i];
                switch (i)
                {
                    case 0: result[j] = "Gold Medal"; break;
                    case 1: result[j] = "Silver Medal"; break;
                    case 2: result[j] = "Bronze Medal"; break;
                    default: result[j] = (i + 1).ToString(); break;
                }
            }

            return result;
        }
    }
}
