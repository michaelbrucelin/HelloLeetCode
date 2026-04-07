using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2087
{
    public class Solution2087 : Interface2087
    {
        /// <summary>
        /// 脑筋急转弯
        /// </summary>
        /// <param name="startPos"></param>
        /// <param name="homePos"></param>
        /// <param name="rowCosts"></param>
        /// <param name="colCosts"></param>
        /// <returns></returns>
        public int MinCost(int[] startPos, int[] homePos, int[] rowCosts, int[] colCosts)
        {
            int result = 0, sign, start, home;
            sign = -Math.Sign(startPos[0] - homePos[0]);
            if (sign != 0)
            {
                start = startPos[0]; home = homePos[0];
                do { result += rowCosts[start += sign]; } while (start != home);
            }
            sign = -Math.Sign(startPos[1] - homePos[1]);
            if (sign != 0)
            {
                start = startPos[1]; home = homePos[1];
                do { result += colCosts[start += sign]; } while (start != home);
            }

            return result;
        }
    }
}
