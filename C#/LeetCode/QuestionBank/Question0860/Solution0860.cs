using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0860
{
    public class Solution0860 : Interface0860
    {
        /// <summary>
        /// 贪心
        /// 每次找零优先使用大额的即可，即当顾客付20元时，优先找10+5，没有10的时候再找5+5+5
        /// </summary>
        /// <param name="bills"></param>
        /// <returns></returns>
        public bool LemonadeChange(int[] bills)
        {
            int[] money = new int[2];  // 0:5, 1:10, 20不需要记录
            for (int i = 0; i < bills.Length; i++)
            {
                switch (bills[i])
                {
                    case 5:
                        money[0]++;
                        break;
                    case 10:
                        if (money[0] == 0) return false;
                        money[0]--; money[1]++;
                        break;
                    case 20:
                        if (money[0] > 0 && money[1] > 0)
                        {
                            money[0]--; money[1]--;
                        }
                        else if (money[0] >= 3)
                            money[0] -= 3;
                        else
                            return false;
                        break;
                }
            }

            return true;
        }
    }
}
