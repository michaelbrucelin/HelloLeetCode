using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1748
{
    public class Solution1748_2 : Interface1748
    {
        /// <summary>
        /// 状态机
        /// num没有出现在字典中
        ///     即第一次出现，加到结果中，字典中记为记为true
        /// num在字典中
        ///     字典中值为true，即第二次出现，从结果中剪掉，字典中记为false
        ///     字典中值为false，忽略
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int SumOfUnique(int[] nums)
        {
            Dictionary<int, bool> states = new Dictionary<int, bool>();
            int result = 0;
            foreach (int num in nums)
            {
                if (states.ContainsKey(num))
                {
                    if (states[num])
                    {
                        result -= num; states[num] = false;
                    }
                }
                else
                {
                    result += num; states.Add(num, true);
                }
            }

            return result;
        }
    }
}
