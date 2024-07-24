using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2766
{
    public class Solution2766 : Interface2766
    {
        /// <summary>
        /// 模拟
        /// 由于不需要关心一个位置有多少块石块，所以可以将nums去重复，只关心位置即可。
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="moveFrom"></param>
        /// <param name="moveTo"></param>
        /// <returns></returns>
        public IList<int> RelocateMarbles(int[] nums, int[] moveFrom, int[] moveTo)
        {
            HashSet<int> pos = new HashSet<int>(nums);
            for (int i = 0; i < moveFrom.Length; i++)
            {
                pos.Remove(moveFrom[i]); pos.Add(moveTo[i]);
            }

            int[] result = new int[pos.Count];
            int id = 0;
            foreach (int p in pos) result[id++] = p;
            Array.Sort(result);

            return result;
        }
    }
}
