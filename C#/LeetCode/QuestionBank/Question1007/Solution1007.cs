
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1007
{
    public class Solution1007 : Interface1007
    {
        /// <summary>
        /// 遍历计数
        /// 遍历数组，统计每个数字在 tops 和 bottoms 中出现的次数
        /// </summary>
        /// <param name="tops"></param>
        /// <param name="bottoms"></param>
        /// <returns></returns>
        public int MinDominoRotations(int[] tops, int[] bottoms)
        {
            int cnt = 0, len = tops.Length;
            int[,] cnts = new int[7, 2];
            int target = -1;
            for (int i = 0; i < len; i++)
            {
                if (tops[i] == bottoms[i])
                {
                    if (target == -1) target = tops[i]; else if (target != tops[i]) return -1;
                }
                else
                {
                    cnts[tops[i], 0]++; cnts[bottoms[i], 1]++;
                    cnt++;
                }
            }

            int result;
            if (target != -1)
            {
                if (cnts[target, 0] + cnts[target, 1] != cnt) return -1;
                result = Math.Min(cnts[target, 0], cnts[target, 1]);
            }
            else
            {
                result = len;
                for (int i = 1; i < 7; i++) if (cnts[i, 0] + cnts[i, 1] == cnt) result = Math.Min(result, Math.Min(cnts[i, 0], cnts[i, 1]));
            }


            return result != len ? result : -1;
        }
    }
}
