using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0470
{
    public class Solution0470 : SolBase, Interface0470
    {
        /// <summary>
        /// 概率重新分布
        /// 1. 连续4次调用RAND7()，输出的可能为 [1111, 7777]，共7*7*7*7=2401种中可能，注意每一位只能是1-7
        /// 2. 如果是2401，扔掉，余下的有2400种可能，分成10份，每份对应一个值，即完成了[1,10]的随机
        /// 3. 现在的问题就是怎样把[1111, 7777] 映射为 [0000, 2400]
        ///    注意到每位只有7种可能，很容易想到7进制，可以将[1111, 7777]当成7进制，然后再还原为10进制即可
        /// 4. [1111, 7777] --> [0000, 6666] --> abcd --> a*7*7*7 + b*7*7 + c*7 + d
        /// 
        /// 连续3次调用RAND7()也可以，有7*7*7=343种可能，扔掉最后的3种即可
        /// </summary>
        /// <returns></returns>
        public int Rand10()
        {
            int base7 = 6666;
            while (base7 == 6666)
            {
                base7 = 0;
                for (int i = 0; i < 4; i++) base7 = base7 * 10 + Rand7() - 1;
            }

            int base10 = 0, k = 1;
            while (base7 > 0)
            {
                base10 += base7 % 10 * k;
                base7 /= 10;
                k *= 7;
            }
            return base10 / 240 + 1;
        }
    }
}
