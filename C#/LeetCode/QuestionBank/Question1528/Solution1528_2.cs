using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1528
{
    public class Solution1528_2 : Interface1528
    {
        /// <summary>
        /// 原地
        /// </summary>
        /// <param name="s"></param>
        /// <param name="indices"></param>
        /// <returns></returns>
        public string RestoreString(string s, int[] indices)
        {
            char[] result = s.ToCharArray();
            int i1, i2; char c1, c2;
            for (int i = 0; i < result.Length; i++)
            {
                if (indices[i] == i) continue;
                i1 = indices[i]; c1 = result[i];
                while (i1 != i)
                {
                    i2 = indices[i1]; c2 = result[i1];
                    indices[i1] = i1; result[i1] = c1;
                    i1 = i2; c1 = c2;
                }
                indices[i] = i1; result[i] = c1;
            }

            return new string(result);
        }
    }
}
