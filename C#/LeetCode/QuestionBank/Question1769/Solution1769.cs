using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1769
{
    public class Solution1769 : Interface1769
    {
        /// <summary>
        /// 先计算出answer[0]的值，然后逐步分析后面的值。
        /// 例如：boxes = "001011"
        /// 1. 遍历一次，得到answer[0] = 11，且boxes中共有3个1
        /// 2. 初始化变量left = 0，right = 3，分别表示当前位置（不含）左边有多少个1、当前位置（含）有多少个1
        /// 3. 指针移到answer[1]，left=0 right=3，answer[1] = 11-3+0 = 8
        /// 4. 指针移到answer[2]，left=0 right=3，answer[1] = 8-3+0  = 5
        /// 5. 指针移到answer[3]，left=1 right=2，answer[1] = 5-2+1  = 4
        /// 6. 指针移到answer[4]，left=1 right=2，answer[1] = 4-2+1  = 3
        /// 7. 指针移到answer[5]，left=2 right=1，answer[1] = 3-1+2  = 4
        /// </summary>
        /// <param name="boxes"></param>
        /// <returns></returns>
        public int[] MinOperations(string boxes)
        {
            int len = boxes.Length, left = 0, right = 0;
            int[] result = new int[len];
            for (int i = 0; i < len; i++)
            {
                if (boxes[i] == '1') { result[0] += i; right++; }
            }

            for (int i = 1; i < len; i++)
            {
                if (boxes[i - 1] == '1') { left++; right--; }
                result[i] = result[i - 1] - right + left;
            }

            return result;
        }
    }
}
