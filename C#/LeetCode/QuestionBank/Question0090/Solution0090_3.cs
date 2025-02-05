using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0090
{
    public class Solution0090_3 : Interface0090
    {
        private static readonly Int128[] dim = [1, 11, 121, 1331, 14641, 161051, 1771561, 19487171, 214358881, 2357947691, 25937424601, 285311670611, 3138428376721, 34522712143931, 379749833583241,
                                                4177248169415651, 45949729863572161, 505447028499293771, 5559917313492231481,Int128.Parse("61159090448414546291"), Int128.Parse("672749994932560009201")];

        /// <summary>
        /// BFS + 标志位
        /// 标志位 = 题目限定的数据范围只有21个不同的整数，所以用21个质数就可以构建出标志位
        /// 下面是大于210（21*10）的21个质数，如果用小的质数会发生2+3=5的碰撞
        /// 211,223,227,229,233,239,241,251,257,263,269,271,277,281,283,293,307,311,313,317,331
        /// 还是不对，参考[1,9,8,3,-1,0]
        /// 采用下面数组做为维度
        /// [1,11,121,1331,14641,161051,1771561,19487171,214358881,2357947691,25937424601,285311670611,3138428376721,34522712143931,379749833583241,
        ///  4177248169415651,45949729863572161,505447028499293771,5559917313492231481,61159090448414546291,672749994932560009201]
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            IList<IList<int>> result = [[]];
            HashSet<Int128> set = new() { 0 };
            List<int> item; Int128 flag;
            foreach (int num in nums) for (int i = 0, cnt = result.Count; i < cnt; i++)
                {
                    item = new List<int>(result[i]) { num };
                    flag = ArrayFlag(item);
                    if (!set.Contains(flag))
                    {
                        result.Add(item); set.Add(flag);
                    }
                }

            return result;

            Int128 ArrayFlag(List<int> nums)
            {
                if (nums.Count == 0) return 0;

                Int128 result = 0;
                foreach (int num in nums) result += dim[num + 10];

                return result;
            }
        }
    }
}
