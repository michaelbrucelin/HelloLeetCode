using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2698
{
    public class Solution2698_dial : Interface2698
    {
        private static readonly (int key, int value)[] map = new (int key, int value)[] {
            (1, 1), (9, 82), (10, 182), (36, 1478), (45, 3503), (55, 6528), (82, 13252), (91, 21533), (99, 31334), (100, 41334), (235, 96559), (297, 184768),
            (369, 320929), (370, 457829), (379, 601470), (414, 772866), (657, 1204515), (675, 1660140), (703, 2154349), (756, 2725885), (792, 3353149),
            (909, 4179430), (918, 5022154), (945, 5915179), (964, 6844475), (990, 7824575), (991, 8806656), (999, 9804657), (1000, 10804657)
        };

        /// <summary>
        /// 打表
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int PunishmentNumber(int n)
        {
            int key = 0, left = 0, right = map.Length - 1, mid;
            while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                if (map[mid].key <= n)
                {
                    key = mid; left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return map[key].value;
        }
    }
}
