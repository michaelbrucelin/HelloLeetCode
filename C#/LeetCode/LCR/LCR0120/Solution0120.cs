using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0120
{
    public class Solution0120 : Interface0120
    {
        /// <summary>
        /// 哈希表
        /// </summary>
        /// <param name="documents"></param>
        /// <returns></returns>
        public int FindRepeatDocument(int[] documents)
        {
            HashSet<int> set = new HashSet<int>();
            foreach (int document in documents)
            {
                if (set.Contains(document)) return document;
                set.Add(document);
            }

            return -1;
        }
    }
}
