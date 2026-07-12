using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1395
{
    public class Solution1395 : Interface1395
    {
        /// <summary>
        /// 枚举
        /// 枚举中间的元素，找出左侧及右侧大于及小于当前元素的元素数量，根据乘法原理，可以得到结果
        /// </summary>
        /// <param name="rating"></param>
        /// <returns></returns>
        public int NumTeams(int[] rating)
        {
            int result = 0, len = rating.Length;
            for (int i = 1, llt, rlt; i < len - 1; i++)
            {
                llt = 0;
                for (int j = 0; j < i; j++) if (rating[j] < rating[i]) llt++;
                rlt = 0;
                for (int j = i + 1; j < len; j++) if (rating[j] < rating[i]) rlt++;
                result += llt * (len - i - 1 - rlt);
                result += (i - llt) * rlt;
            }

            return result;
        }
    }
}
