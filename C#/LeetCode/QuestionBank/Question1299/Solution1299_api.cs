using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1299
{
    public class Solution1299_api : Interface1299
    {
        /// <summary>
        /// 提交超时，没想到简单题也超时。。。
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int[] ReplaceElements(int[] arr)
        {
            return arr.Select((num, id) => (num, id))
                      .Select(t => arr.Skip(t.id + 1).DefaultIfEmpty(-1).Max())
                      .ToArray();
        }
    }
}
