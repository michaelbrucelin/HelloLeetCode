using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1860
{
    public class Solution1860 : Interface1860
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="memory1"></param>
        /// <param name="memory2"></param>
        /// <returns></returns>
        public int[] MemLeak(int memory1, int memory2)
        {
            int[] result = [0, memory1, memory2];
            while (true)
            {
                result[0]++;
                if (result[1] >= result[2])
                {
                    if (result[1] >= result[0]) result[1] -= result[0]; else break;
                }
                else
                {
                    if (result[2] >= result[0]) result[2] -= result[0]; else break;
                }
            }

            return result;
        }
    }
}
