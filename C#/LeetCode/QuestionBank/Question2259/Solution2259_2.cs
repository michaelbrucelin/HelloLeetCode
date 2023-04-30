using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2259
{
    public class Solution2259_2 : Interface2259
    {
        /// <summary>
        /// 分析
        /// 1. 如果存在一个digit，后面相邻的数字比digit大，那么将从左到右第一个满足这个条件的digit移除
        /// 2. 如果不存在满足条件的digit，那么将从左到右最后一个digit移除
        /// 证明，想想就是这么回事，这里就不证明了
        /// </summary>
        /// <param name="number"></param>
        /// <param name="digit"></param>
        /// <returns></returns>
        public string RemoveDigit(string number, char digit)
        {
            int id = -1, len = number.Length;
            for (int i = 0; i < len - 1; i++)
            {
                if (number[i] == digit)
                {
                    if (number[i] < number[i + 1])
                        return $"{number.Substring(0, i)}{number.Substring(i + 1)}";
                    else
                        id = i;
                }
            }

            if (number[len - 1] == digit)
                return number.Substring(0, len - 1);
            else
                return $"{number.Substring(0, id)}{number.Substring(id + 1)}";  // 题目保证number中一定存在一个digit
        }
    }
}
